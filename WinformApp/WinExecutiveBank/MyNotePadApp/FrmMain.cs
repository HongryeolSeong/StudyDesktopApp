using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNotePadApp
{
    public partial class FrmMain : Form
    {
        public bool IsModify { get; set; }

        private const string firstfileName = "noname.txt";

        private string currFileName = firstfileName;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void MnuNewFile_Click(object sender, EventArgs e)
        {
            // TODO : 만약 작업중인 파일이 있는 경우 -> 저장 처리
            ProcessSaveFileBeforeClose();
            TxtMain.Text = "";
            IsModify = false;
            currFileName = firstfileName;
            this.Text = $"{currFileName} - 내 메모장";
        }

        private void ProcessSaveFileBeforeClose()
        {
            if (IsModify)
            {
                DialogResult answer = MessageBox.Show("변경사항이 있습니다. 저장하시겠습니까?",
                    "저장", 
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)
                {
                    if (currFileName == firstfileName)
                    {
                        if (DlgSaveText.ShowDialog() == DialogResult.OK) // 다른 이름으로 새로 저장
                        {
                            StreamWriter sw = File.CreateText(DlgSaveText.FileName);
                            sw.WriteLine(TxtMain.Text);
                            sw.Close();
                        }
                        else // 기저장된 파일에 덮어쓰기
                        {
                            StreamWriter sw = File.CreateText(currFileName);
                            sw.WriteLine(TxtMain.Text);
                            sw.Close();
                        }
                    }
                }
                else
                {

                }
            }
        }

        private void MnuOpenFile_Click(object sender, EventArgs e)
        {
            ProcessSaveFileBeforeClose();

            DlgOpenText.ShowDialog();
            currFileName = DlgOpenText.FileName;
            this.Text = $"{currFileName} - 내 메모장";

            try
            {
                StreamReader sr = File.OpenText(currFileName);
                TxtMain.Text = sr.ReadLine();
                IsModify = false;
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MnuSaveFile_Click(object sender, EventArgs e)
        {
            if (currFileName == firstfileName)
            {
                if (DlgSaveText.ShowDialog() == DialogResult.OK)
                    currFileName = DlgSaveText.FileName;
            }

            StreamWriter sw = File.CreateText(currFileName);
            sw.WriteLine(TxtMain.Text);

            IsModify = false;
            sw.Close();

            this.Text = $"{currFileName} - 내 메모장";
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            ProcessSaveFileBeforeClose();
            Environment.Exit(0);
        }

        private void MnuCopy_Click(object sender, EventArgs e)
        {
            var contents = ActiveControl as RichTextBox;
            if (contents != null)
            {
                Clipboard.SetDataObject(contents.SelectedText);
                MessageBox.Show(contents.SelectedText);
            }
        }

        private void MnuPaste_Click(object sender, EventArgs e)
        {
            var contents = ActiveControl as RichTextBox;
            if (contents != null)
            {
                IDataObject data = Clipboard.GetDataObject();
                contents.SelectedText = data.GetData(DataFormats.Text).ToString();
                IsModify = true;
            }
        }

        private void MnuAbout_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("메모장 v1.0입니다");
            var form = new AboutThis(); // 어셈블리 인포 값
            form.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            DlgSaveText.Filter = DlgOpenText.Filter = "Text file (*.txt)|*.txt|(*.log)|*.log";
            this.Text = $"{currFileName} - 내 메모장";
            IsModify = false;
        }

        private void TxtMain_TextChanged(object sender, EventArgs e)
        {
            IsModify = true;
            this.Text = $"{currFileName}* - 내 메모장";
        }
    }
}
