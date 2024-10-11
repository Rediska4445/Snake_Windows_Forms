using System;
using System.Drawing;
using System.Windows.Forms;

namespace isp_223k___snake
{
    public partial class Form1 : Form
    {
        private static Snake snake;
        private static Field field;

        private static Point[] stones;

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public Form1()
        {
            field = new Field(436, 250, 250, new Point[50]);
            snake = new Snake(15, 200, 3, 250, field, "Snake");
            field.GenerateApple(530);
            snake.setSkin(new Color[] {
                Color.NavajoWhite, Color.DarkBlue, Color.DarkRed
            });
            snake.checkEat = true;
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            field.PaintStone(e);
            field.PaintApple(e);

            snake.Life(snake, this, timer1, label1, e, panel1);

            label4.Text = "Timer count: " + timer1.Interval + " \nSnake length: " + snake.getLength()
                + "\nApple's spawned: " + field.getAppleSpawned() + "\nStone spawned: " + field.nStone;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            snake.Key(e, new Keys[] {
                    Keys.A, Keys.D, Keys.W, Keys.S
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainMenu fr = new mainMenu();
            fr.Show();
            Hide();
        }
    }
}
