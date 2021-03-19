using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRentalShopApp
{
    public partial class FrmBooks : MetroForm
    {
        #region 전역변수 영역
        private bool isNew = false;
        #endregion

        #region 이벤트 영역
        public FrmBooks()
        {
            InitializeComponent();
        }
        private void FrmMember_Load(object sender, EventArgs e)
        {
            isNew = true; // 초기화
            InitCboData(); // 콤보박스 데이터 초기화
            RefreshData(); // 테이블 조회

            DtpReleaseDate.CustomFormat = "yyyy-MM-dd";
            DtpReleaseDate.Format = DateTimePickerFormat.Custom;
        }


        private void FrmMember_Resize(object sender, EventArgs e)
        {
            DgvData.Height = this.ClientRectangle.Height - 90;
            GrbDetail.Height = this.ClientRectangle.Height - 90;
        }
        private void DgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 선택된 값이 존재하면
            {
                var selData = DgvData.Rows[e.RowIndex];
                AsignToControls(selData);
                isNew = false;
            }
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            // Validation
            if (CheckValidation() == false) return;

            if (MetroMessageBox.Show(this, "삭제하시겠습니까?", "삭제",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            DeleteData();
            RefreshData();
            ClearInputs();
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validation 체크
            if (CheckValidation() == false) return;

            SaveData();
            RefreshData();
        }
        #endregion

        #region 커스텀 메서드 영역
        private void AsignToControls(DataGridViewRow selData)
        {
            TxtIdx.Text = selData.Cells[0].Value.ToString();
            TxtAuthor.Text = selData.Cells[1].Value.ToString();
            CboDivision.SelectedValue = selData.Cells[2].Value; // B001 = B001
            // selData.Cell[3] X
            TxtNames.Text = selData.Cells[4].Value.ToString();
            // ReleaseDate
            DtpReleaseDate.Value = (DateTime)selData.Cells[5].Value;
            TxtISBN.Text = selData.Cells[6].Value.ToString();
            TxtPrice.Text = selData.Cells[7].Value.ToString();
            TxtDescriptions.Text = selData.Cells[8].Value.ToString();

            TxtIdx.ReadOnly = true;
        }


        private void InitCboData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    var query = "SELECT Division, Names FROM dbo.divtbl ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var temp = new Dictionary<string, string>(); // <키, 밸류>
                    while (reader.Read())
                    {
                        temp.Add(reader[0].ToString(), reader[1].ToString()); // (key)B001, (value)공포/스릴러
                    }
                    CboDivision.DataSource = new BindingSource(temp, null);
                    CboDivision.DisplayMember = "Value";
                    CboDivision.ValueMember = "Key";
                    CboDivision.SelectedIndex = -1;
                }
            }
            catch { }
        }

        private void DeleteData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    var query = "DELETE FROM [dbo].[bookstbl] " +
                                " WHERE [Idx] = @Idx ";
                    cmd.CommandText = query;

                    SqlParameter pIdx = new SqlParameter("@Idx", SqlDbType.Int);
                    pIdx.Value = TxtIdx.Text;
                    cmd.Parameters.Add(pIdx);

                    var result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MetroMessageBox.Show(this, "삭제 성공", "삭제",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "삭제 실패", "삭제",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }
        private void RefreshData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = @"SELECT b.Idx
                                      ,b.Author
                                      ,b.Division
                                      ,d.Names as DivName
	                                  ,b.Names
                                      ,b.ReleaseDate
                                      ,b.ISBN
                                      ,b.Price
                                      ,b.Descriptions
                                  FROM dbo.bookstbl as b
                                 INNER JOIN dbo.divtbl as d
	                                ON b.Division = d.Division"; // 210318 Descriptions Column 추가
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "bookstbl");

                    DgvData.DataSource = ds;
                    DgvData.DataMember = "bookstbl";
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // 데이터그리드뷰 컬럼 화면에서 안보이게
            var colunm = DgvData.Columns[2]; // Division 컬럼
            colunm.Visible = false;
            colunm = DgvData.Columns[8];
            colunm.Visible = false;

            colunm = DgvData.Columns[4];
            colunm.Width = 250;
            colunm.HeaderText = "도서명";

            colunm = DgvData.Columns[0];
            colunm.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void SaveData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    var query = "";

                    if (isNew == true) // INSERT
                    {
                        query = @"INSERT INTO [dbo].[bookstbl]
                                           ([Author]
                                           ,[Division]
                                           ,[Names]
                                           ,[ReleaseDate]
                                           ,[ISBN]
                                           ,[Price]
                                           ,[Descriptions])
                                     VALUES
                                           (@Author
                                           ,@Division
                                           ,@Names
                                           ,@ReleaseDate
                                           ,@ISBN
                                           ,@Price
                                           ,@Descriptions)";
                    }
                    else // UPDATE
                    {
                        query = @"UPDATE [dbo].[bookstbl]
                                   SET [Author] = @Author
                                      ,[Division] = @Division
                                      ,[Names] = @Names
                                      ,[ReleaseDate] = @ReleaseDate
                                      ,[ISBN] = @ISBN
                                      ,[Price] = @Price
                                      ,[Descriptions] = @Descriptions
                                 WHERE Idx = @Idx";
                    }
                    cmd.CommandText = query;

                    SqlParameter pAuthor = new SqlParameter("@Author", SqlDbType.NVarChar, 50);
                    pAuthor.Value = TxtAuthor.Text;
                    cmd.Parameters.Add(pAuthor);

                    SqlParameter pDivision = new SqlParameter("@Division", SqlDbType.VarChar, 8);
                    pDivision.Value = CboDivision.SelectedValue;
                    cmd.Parameters.Add(pDivision);

                    SqlParameter pNames = new SqlParameter("@Names", SqlDbType.NVarChar, 100);
                    pNames.Value = TxtNames.Text;
                    cmd.Parameters.Add(pNames);

                    SqlParameter pReleaseDate = new SqlParameter("@ReleaseDate", SqlDbType.Date);
                    pReleaseDate.Value = DtpReleaseDate.Value;
                    cmd.Parameters.Add(pReleaseDate);

                    SqlParameter pISBN = new SqlParameter("@ISBN", SqlDbType.VarChar, 200);
                    pISBN.Value = TxtISBN.Text;
                    cmd.Parameters.Add(pISBN);

                    SqlParameter pPrice = new SqlParameter("@Price", SqlDbType.Decimal);
                    pPrice.Value = TxtPrice.Text;
                    cmd.Parameters.Add(pPrice);

                    SqlParameter pDescriptions = new SqlParameter("@Descriptions", SqlDbType.NVarChar); // 크기가 모호할땐 빈 값으로
                    pDescriptions.Value = Helper.Common.ReplaceCmdText(TxtDescriptions.Text);
                    cmd.Parameters.Add(pDescriptions);

                    if (isNew == false)
                    {
                        SqlParameter pIdx = new SqlParameter("@Idx", SqlDbType.Int);
                        pIdx.Value = TxtIdx.Text;
                        cmd.Parameters.Add(pIdx);
                    }

                    var result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MetroMessageBox.Show(this, "저장 성공", "저장",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "저장 실패", "저장",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ClearInputs()
        {
            TxtIdx.Text = TxtAuthor.Text = "";
            TxtNames.Text = TxtISBN.Text = "";
            TxtPrice.Text = TxtDescriptions.Text = "";
            CboDivision.SelectedIndex = -1;
            DtpReleaseDate.Value = DateTime.Now;
            TxtIdx.ReadOnly = true;
            isNew = true;
        }
        private bool CheckValidation()
        {
            if (string.IsNullOrEmpty(TxtAuthor.Text) ||
                string.IsNullOrEmpty(TxtNames.Text) ||
                CboDivision.SelectedIndex == -1 ||
                DtpReleaseDate.Value == null)
            {
                MetroMessageBox.Show(this, "빈 값은 처리할 수 없습니다.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;

        }
        #endregion
    }
}