using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelTestApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LblAutoSize.Text = LblManualSize.Text = string.Empty;
        }

        private void BtnPushText_Click(object sender, EventArgs e) // autosize 차이
        {
            string sample1 = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ullam repellendus harum ipsa voluptatem ut delectus ipsum quae asperiores eligendi ducimus ex nisi, sapiente ab eos. Ullam iure natus animi! Debitis!";
            string sample2 = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Sit reiciendis, vitae repellat velit animi maxime cum, nam autem ad itaque iste minus impedit assumenda tenetur perspiciatis quis! Asperiores, dignissimos fugit.";

            LblAutoSize.Text = sample1;
            LblManualSize.Text = sample2;
        }
    }
}
