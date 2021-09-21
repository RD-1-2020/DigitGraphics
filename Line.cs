using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitGraphics
{
    class Line
    {
        private Point fPoint;

        private Point scPoint;

        private Graphics field;

        private int dY;
        private int dX;

        private double absDeltaY;
        private double absDeltaX;

        public Line(Point fPoint, Point scPoint, Graphics field)
        {
            this.fPoint = fPoint;
            this.scPoint = scPoint;
            this.field = field;

            dY = scPoint.Y - fPoint.Y;
            dX = scPoint.X - fPoint.X;

            absDeltaY = Math.Abs(dY);
            absDeltaX = Math.Abs(dX);
        }

        public void drawNormalLine()
        {
            field.DrawLine(Settings.Instance.NormalLineColor, 
            fPoint.X * Settings.CELLS_SIZE,
            fPoint.Y * Settings.CELLS_SIZE,

            scPoint.Y * Settings.CELLS_SIZE,
            scPoint.X * Settings.CELLS_SIZE);
        }

        public void drawCdaLine()
        {
            double len;
            double Px;
            double Py;

            if (absDeltaX >= absDeltaY)
            {
                len = absDeltaX;
            }
            else
            {
                len = absDeltaY;
            }

            Px = dX / len;
            Py = dY / len;

            double X = fPoint.X;
            double Y = fPoint.Y;

            for (int i = 1; i <= len; i++)
            {
                if (dX > 0)
                {
                    field.FillRectangle(Settings.Instance.CDABrush, 
                        (int)Math.Truncate(X) * Settings.CELLS_SIZE,
                        (int)Math.Truncate(Y) * Settings.CELLS_SIZE, 

                        Settings.CELLS_SIZE, 
                        Settings.CELLS_SIZE);
                }
                else
                {
                    field.FillRectangle(Settings.Instance.CDABrush, 
                        (int)Math.Truncate(X) * Settings.CELLS_SIZE - Settings.CELLS_SIZE,
                        (int)Math.Truncate(Y) * Settings.CELLS_SIZE, 

                        Settings.CELLS_SIZE, 
                        Settings.CELLS_SIZE);
                }

                X += Py;
                Y += Px;
            }
        }

        public void drawBrezLine()
        {
            double accretion = 0;

            float X1 = fPoint.X * Settings.CELLS_SIZE;
            float Y1 = fPoint.Y * Settings.CELLS_SIZE;

            float X2 = scPoint.X * Settings.CELLS_SIZE;
            float Y2 = scPoint.Y * Settings.CELLS_SIZE;

            if (absDeltaX >= absDeltaY)
            {
                int direction = dY != 0 ? (dY > 0 ? 1 : -1) : 0;
                while ( dX > 0 ? X1 <= X2 : X1 >= X2)
                {
                    field.FillRectangle(Settings.Instance.BrezBrush,
                        X1,
                        Y1,

                        Settings.CELLS_SIZE, 
                        Settings.CELLS_SIZE);

                    accretion += absDeltaY * Settings.CELLS_SIZE;

                    if (accretion >= absDeltaX * Settings.CELLS_SIZE)
                    {
                        accretion -= absDeltaX * Settings.CELLS_SIZE;

                        Y1 += direction * Settings.CELLS_SIZE;
                    }
                    if (dX > 0)
                    {
                        X1 += Settings.CELLS_SIZE;
                    }
                    else
                    {
                        X1 -= Settings.CELLS_SIZE;
                    }
                }
            }
            else
            {
                int direction = dX != 0 ? (dX > 0 ? 1 : -1) : 0;
                while(dY > 0 ? Y1 <= Y2 : Y1 >= Y2)
                {
                    field.FillRectangle(Settings.Instance.BrezBrush,
                        X1,
                        Y1,

                        Settings.CELLS_SIZE,
                        Settings.CELLS_SIZE);

                    accretion += absDeltaX * Settings.CELLS_SIZE;

                    if (accretion >= absDeltaY * Settings.CELLS_SIZE)
                    {
                        accretion -= absDeltaY * Settings.CELLS_SIZE;

                        X1 += direction * Settings.CELLS_SIZE;
                    }

                    if (dY > 0)
                    {
                        Y1 += Settings.CELLS_SIZE;
                    }
                    else
                    {
                        Y1 -= Settings.CELLS_SIZE;
                    }
                }
            }
            
        }

        public Point FPoint
        {
            get => fPoint;
            set => fPoint = value;
        }

        public Point ScPoint
        {
            get => scPoint;
            set => scPoint = value;
        }
    }
}
