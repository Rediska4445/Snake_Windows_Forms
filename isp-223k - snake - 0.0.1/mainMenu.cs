using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace isp_223k___snake
{
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Multiplay().Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://github.com/Rediska4445/Snake_On_Forms");
            Process.Start(sInfo);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.Show();
            Hide();
        }

        private void mainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
