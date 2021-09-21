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
            try
            {
                field.DrawLine(Settings.Instance.NormalLineColor, 
                    fPoint.X * Settings.CELLS_SIZE,
                    fPoint.Y * Settings.CELLS_SIZE,

                    scPoint.Y * Settings.CELLS_SIZE,
                    scPoint.X * Settings.CELLS_SIZE);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Неверно заданы координаты.\nВведите целое число", "Ошибка!", 0, MessageBoxIcon.Exclamation);

                Logger.error("Пользователь ввёл неверные данные в поля с точками", ex);
            }
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
                        (int)Math.Truncate(X * Settings.CELLS_SIZE),
                        (int)Math.Truncate(Y * Settings.CELLS_SIZE), 

                        Settings.CELLS_SIZE, 
                        Settings.CELLS_SIZE);
                }
                else
                {
                    field.FillRectangle(Settings.Instance.CDABrush, 
                        (int)Math.Truncate(X * Settings.CELLS_SIZE - Settings.CELLS_SIZE),
                        (int)Math.Truncate(Y * Settings.CELLS_SIZE), 

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

            Point scaleTmpFtPoint = new Point(fPoint.X * Settings.CELLS_SIZE, fPoint.Y * Settings.CELLS_SIZE);

            Point scaleTmpScPoint = new Point(fPoint.X * Settings.CELLS_SIZE, fPoint.Y * Settings.CELLS_SIZE);

            if (absDeltaX >= absDeltaY)
            {
                int direction = dY != 0 ? (dY > 0 ? 1 : -1) : 0;
                for (; dX > 0 ? scaleTmpFtPoint.X <= scaleTmpScPoint.X : scaleTmpFtPoint.X >= scaleTmpScPoint.X;)
                {
                    field.FillRectangle(Settings.Instance.BrezBrush, 
                        scaleTmpFtPoint.X, 
                        scaleTmpFtPoint.Y,

                        Settings.CELLS_SIZE, 
                        Settings.CELLS_SIZE);
                    accretion += absDeltaY;

                    if (accretion >= absDeltaX)
                    {
                        accretion -= absDeltaX;

                        scaleTmpFtPoint = new Point(scaleTmpFtPoint.X, scaleTmpFtPoint.Y + direction * Settings.CELLS_SIZE);
                    }
                    if (dX > 0)
                    {
                        scaleTmpFtPoint = new Point(scaleTmpFtPoint.X + Settings.CELLS_SIZE, scaleTmpFtPoint.Y);
                    }
                    else
                    {
                        scaleTmpFtPoint = new Point(scaleTmpFtPoint.X - direction * Settings.CELLS_SIZE, scaleTmpFtPoint.Y);
                    }
                }
            }
            else
            {
                int direction = dX != 0 ? (dX > 0 ? 1 : -1) : 0;
                while(dY > 0 ? scaleTmpFtPoint.Y <= scaleTmpScPoint.Y : scaleTmpFtPoint.Y >= scaleTmpScPoint.Y)
                {
                    field.FillRectangle(Settings.Instance.BrezBrush,
                        scaleTmpFtPoint.X,
                        scaleTmpFtPoint.Y,

                        Settings.CELLS_SIZE,
                        Settings.CELLS_SIZE);

                    accretion += absDeltaX;
                    if (accretion >= absDeltaY)
                    {
                        accretion -= absDeltaY;
                        scaleTmpFtPoint = new Point(scaleTmpFtPoint.X + direction * Settings.CELLS_SIZE, scaleTmpFtPoint.Y);
                    }

                    if (dY > 0)
                    {
                        scaleTmpFtPoint = new Point(scaleTmpFtPoint.X, scaleTmpFtPoint.Y + Settings.CELLS_SIZE);
                    }
                    else
                    {
                        scaleTmpFtPoint = new Point(scaleTmpFtPoint.X, scaleTmpFtPoint.Y - Settings.CELLS_SIZE);
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
