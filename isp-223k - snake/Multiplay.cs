using System;
using System.Drawing;
using System.Windows.Forms;

namespace isp_223k___snake
{
    public partial class Multiplay : Form
    {
        private static Snake player_1;
        private static Snake player_2;

        private static Field field;

        public static string name, name1;

        public Multiplay()
        {
            field = new Field(436, 250, 250, new Point[] {
                new Point(500, 500),
                new Point(500, 500),
                new Point(500, 500),
                new Point(500, 500),
                new Point(500, 500)
            });

            player_1 = new Snake(10, 200, 3, 250, field, "player_1");
            player_2 = new Snake(10, 200, 2, 150, field, "player_2");
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (player_1.getSnake()[0].X == field.getX() && player_1.getSnake()[0].Y == field.getY())
            {
                player_1.EatApple(field.getX(), field.getY(), label1, timer1);
                field.GenerateRandomItems(436);
            }

            if (player_2.getSnake()[0].X == field.getX() && player_2.getSnake()[0].Y == field.getY())
            {
                player_2.EatApple(field.getX(), field.getY(), label3, timer1);
                field.GenerateRandomItems(436);
            }

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

        private void button1_Click(object sender, EventArgs e)
        {
            mainMenu fr = new mainMenu();
            fr.Show();
            Hide();
        }
    }
}
