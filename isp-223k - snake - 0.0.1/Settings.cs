using System;
using System.Windows.Forms;

namespace isp_223k___snake
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new mainMenu().Show();
            Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Multiplay.name_1 = textBox1.Text;
            Multiplay.name_2 = textBox2.Text;
        }
    }
}
