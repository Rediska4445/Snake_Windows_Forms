using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace isp_223k___snake
{
    internal class Field
    {
        Point apple;
        Point[] stone;

        Random r;

        public static int field;

        public Field(int size)
        {
            field = size;
        }

        public Field(int size, int x, int y, Point[] stone)
        {
            r = new Random();
            apple.X = x;
            apple.Y = y;
            this.stone = stone;
            field = size;
        }

        public void GenerateRandomItems(int dia)
        {
            GenerateApple(dia);
            for (int i = 0; i < stone.Length; i++)
            {
                stone[i].X = r.Next(0, (dia - 40) / 10) * 10;
                stone[i].Y = r.Next(0, (dia - 40) / 10) * 10;
                if (stone[i].X == apple.X && stone[i].Y == apple.Y)
                {
                    apple.X += 20;
                    apple.Y += 20;
                }
            }
        }

        public void GenerateApple(int dia)
        {
            apple.X = r.Next(0, (dia - 40) / 10) * 10;
            apple.Y = r.Next(0, (dia - 40) / 10) * 10;
        }

        public Point[] getStones()
        {
            return stone;
        }

        public void PaintStone(PaintEventArgs e)
        {
            for(int i = 0; i < stone.Length; i++)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Gray), stone[i].X, stone[i].Y, 10, 10);
            }
        }

        public void PaintApple(PaintEventArgs e)
        {
            SolidBrush b1 = new SolidBrush(Color.Red);
            e.Graphics.FillEllipse(b1, apple.X, apple.Y, 10, 10);
        }

        public void checkPlayerFusion(Snake player_1, Snake player_2, Form forma)
        {
            for (int i = 1; i < player_1.getLength(); i++)
            {
                if (player_1.getSnake()[0].X == player_2.getSnake()[i].X && player_1.getSnake()[0].Y == player_2.getSnake()[i].Y)
                {
                    player_1.End(forma);
                }
            }
        }

        public int getX()
        {
            return apple.X;
        }

        public int getY()
        {
            return apple.Y;
        }
    }
}
