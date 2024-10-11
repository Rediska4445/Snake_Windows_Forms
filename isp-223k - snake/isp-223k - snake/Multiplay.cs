using System;
using System.Drawing;
using System.Windows.Forms;

namespace isp_223k___snake
{
    public partial class Multiplay : Form
    {
        private static Snake player_1;
        private static Snake player_2;

        public static string name_1, name_2;

        private static Field field;

        public Multiplay()
        {
            field = new Field(436, 30, 30, new Point[15]);

            player_1 = new Snake(10, 200, 3, 250, field, "Lupa");
            player_2 = new Snake(10, 200, 2, 150, field, "Pupa");

            player_1.setSkin(Color.DarkMagenta);
            player_2.setSkin(Color.DarkRed);

            player_1.checkEat = true;
            player_2.checkEat = true;

            InitializeComponent();
            label5.Text = player_1.getName();
            label4.Text = player_2.getName();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            player_1.Life(player_1, this, timer1, label1, e, panel1);
            field.checkPlayerFusion(player_1, player_2, this);

            player_2.Life(player_2, this, timer1, label3, e, panel1);
            field.checkPlayerFusion(player_2, player_1, this);

            field.PaintStone(e);
            field.PaintApple(e);
        }
        

        private void Multiplay_KeyDown(object sender, KeyEventArgs e)
        {
            player_1.Key(e, new Keys[] {
                    Keys.A, Keys.D, Keys.W, Keys.S
            });
            player_2.Key(e, new Keys[] {
                    Keys.H, Keys.K, Keys.U, Keys.J
            });
        }

        private void Multiplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainMenu fr = new mainMenu();
            fr.Show();
            Hide();
        }
    }
}
