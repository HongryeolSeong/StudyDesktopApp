using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlagWinApp
{
    public partial class FrmMain : Form
    {
        private bool isHello = false; // flag 상태를 저장

        public FrmMain()
        {
            InitializeComponent();

            isHello = true; // 아침, 초기화
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LblGreeting.Text = string.Empty;
        }

        private void BtnGreeting_Click(object sender, EventArgs e)
        {
            if (isHello == true)
            {
                LblGreeting.Text = "Good Moring~";
                isHello = false;
                BtnGreeting.Text = "저녁 인사";
            }
            else if (isHello == false)
            {
                LblGreeting.Text = "Good Bye~";
                isHello = true;
                BtnGreeting.Text = "아침 인사";
            }
        }
    }
}
