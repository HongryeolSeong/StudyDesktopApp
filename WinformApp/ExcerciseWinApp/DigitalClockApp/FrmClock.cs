using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalClockApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyTimer.Start();
            LblClock.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            LblClock.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
