using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextViewApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 필터링
            DlgSelectText.FileName = "Select a text file";
            DlgSelectText.Filter = "Text files (*.txt)|*.txt"; // (a)|a에서 a는 두 번 적어줘야 함
            DlgSelectText.Title = "Open text file";
        }

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            if (DlgSelectText.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = DlgSelectText.FileName;

                    using (FileStream fs = File.Open(filePath, FileMode.Open))
                    {
                        Process.Start(@"C:\Program Files\Notepad++\notepad++.exe", filePath);
                    }
                }
                catch (SecurityException ex) // 접근 제한
                {
                    MessageBox.Show($"{ex.Message}");
                }
            }
        }
    }
}
