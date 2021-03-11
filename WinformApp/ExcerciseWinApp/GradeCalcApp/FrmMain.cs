using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeCalcApp
{
    public partial class FrmMain : Form
    {
        TextBox[] titles;
        ComboBox[] crds;
        ComboBox[] grds;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            TxtSubject1.Text = "과목1";
            TxtSubject2.Text = "과목2";
            TxtSubject3.Text = "과목3";
            TxtSubject4.Text = "과목4";
            TxtSubject5.Text = "과목5";
            TxtSubject6.Text = "과목6";
            TxtSubject7.Text = "과목7";

        }

        private void BtnAverage_Click(object sender, EventArgs e)
        {

        }
    }
}
