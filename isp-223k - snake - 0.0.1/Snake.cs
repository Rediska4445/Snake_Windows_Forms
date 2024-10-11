using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace isp_223k___snake
{
    internal class Snake
    {
        private Field field;
        Point[] p;

        private Color colorSkin;
        private Color[] colorSkinArr;

        private bool rainbowSkin;
        public bool checkEat;

        string name;

        int len;
        int dir;
        int c1;

        public Snake(int lgth, int points, int direction, int start_pos, Field field, string name)
        {
            checkEat = false;
            this.field = field;
            this.name = name;
            colorSkin = Color.Black;
            len = lgth;
            p = new Point[points];
            dir = direction;
            for (int i = 0; i < 5; i++)
            {
                p[i].X = start_pos;
                p[i].Y = start_pos + i + 10;
            }
        }

        public void Key(KeyEventArgs e, Keys[] key)
        {
            if (e.KeyCode == key[0])
                dir = 1;
            if (e.KeyCode == key[1])
                dir = 2;
            if (e.KeyCode == key[2])
                dir = 3;
            if (e.KeyCode == key[3])
                dir = 4;
        }

        public void Paint(Label label1, Timer timer1, PaintEventArgs e, Panel panel1)
        {
            typeof(Panel).InvokeMember("DoubleBuffered",
 BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
 null, panel1, new object[] { true });
            for (int i = 198; i >= 0; i--)
            {
                p[i + 1].X = p[i].X;
                p[i + 1].Y = p[i].Y;
            }

            Control();

            if(checkEat)
            {
                if (p[0].X == field.getX() && p[0].Y == field.getY())
                {
                    field.nStone++;
                    EatApple(field.getX(), field.getY(), label1, timer1);
                    field.GenerateRandomItems(430, timer1);
                }
            }

            SolidBrush b = new SolidBrush(colorSkin);
            int j = 0;
            for (int i = 0; i < len; i++)
            {
                if(rainbowSkin)
                {
                    if (i == (len / colorSkinArr.Length) * j)
                    {
                        if (j >= colorSkinArr.Length)
                        {
                            j = colorSkinArr.Length - 1;
                        }
                        b.Color = colorSkinArr[j++];
                    }
                }

                e.Graphics.FillEllipse(b, p[i].X, p[i].Y, 10, 10);
            }
        }

        public void setSkin(Color snake)
        {
            this.rainbowSkin = false;
            colorSkin = snake;
        }

        public void setSkin(Color[] snake)
        {
            this.rainbowSkin = true;
            colorSkinArr = snake;
        }

        public void Control()
        {
            if (dir == 1)
            {
                p[0].X = p[1].X - 10;
                if (p[0].X < 0) p[0].X = Field.field;
                p[0].Y = p[1].Y;
            }
            if (dir == 2)
            {
                p[0].X = p[1].X + 10;
                if (p[0].X > Field.field) p[0].X = 0;
                p[0].Y = p[1].Y;
            }
            if (dir == 3)
            {
                p[0].X = p[1].X;
                p[0].Y = p[1].Y - 10;
                if (p[0].Y < 0) p[0].Y = Field.field;
            }
            if (dir == 4)
            {
                p[0].X = p[1].X;
                p[0].Y = p[0].Y + 10;
                if (p[0].Y > Field.field) p[0].Y = 0;
            }
        }

        public Point[] getSnake()
        {
            return p;
        }

        public int getLength()
        {
            return len;
        }
        
        public void EatApple(int appleX, int appleY, Label label1, Timer timer1)
        {
            len += 1;
            c1 += 1;
            label1.Text = c1.ToString();
            timer1.Interval -= 5;
        }

        public void Life(Snake snake, Form form, Timer timer1, Label label1, PaintEventArgs e, Panel panel1)
        {
            snake.Collision(form, timer1);
            snake.Paint(label1, timer1, e, panel1);
            for (int i = 1; i < snake.getLength(); i++)
            {
                if (snake.getSnake()[0].X == snake.getSnake()[i].X && snake.getSnake()[0].Y == snake.getSnake()[i].Y)
                {
                    snake.End(form);
                }
            }
        }

        public int getScore()
        {
            return c1;
        }

        public String getName()
        {
            return name;
        }

        public void Collision(Form form, Timer timer1)
        {
            for(int i = 0; i < field.getStones().Length; i++)
            {
                if (p[0].X == field.getStones()[i].X && p[0].Y == field.getStones()[i].Y)
                {
                    End(form);
                }
            }

            if (timer1.Interval <= 10)
            {
                timer1.Interval = 250;
            }
            if (c1 >= 1000)
            {
                End(form);
            }
        }

        public void End(Form form)
        {
            mainMenu menu = new mainMenu();
            menu.Show();
            form.Hide();
            MessageBox.Show(name + " проиграл!");
        }
    }
}
