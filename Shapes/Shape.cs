using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DigitGraphics.Utils;

namespace DigitGraphics.Shapes
{
    class Shape
    {
        private int radiusOut;

        private int x0;

        private int y0;

        private int x0scale;
        private int y0scale;
        private int radiusScale;

        private Graphics field;

        private List<Point> points = new List<Point>();
        public Shape(Graphics field)
        {
            this.field = field;
        }

        public Shape(int x0, int y0, Graphics field)
        {
            X0 = x0;
            Y0 = y0;
            this.field = field;
        }

        /// <summary>
        /// В данной функции создаётся массив из 6 точек
        /// Для построения правильного шестиугольника
        /// Так как отклонение угла каждой точки от
        /// предыдущий равен пи на 3 мы берём и в цикле
        /// Используя полярные координаты получаем x;y
        /// Нашего многоугольника
        /// </summary>
        public void drawNormal()
        {
            for (int i = 1; i < 7; i++)
            {
                points.Add(
                    new Point(
                        (int)(Math.Cos(i*Math.PI/3)* radiusScale) + x0scale, 
                        (int)(Math.Sin(i * Math.PI / 3) * radiusScale) + y0scale
                        ));
            }
            field.DrawPolygon(Settings.Instance.NormalColor,points.ToArray());
        }

        //TODO: Релизовать
        public void drawLines()
        {
        }


        //TODO: Релизовать
        public void drawSpiral()
        {
            int x1 = x0scale;
            int y1 = y0scale;
            int range = 1;
            bool even=false; //Если шаг четный, то меняется направление и увеличивается range
            bool isx = true; //true - движение по Х, false - движение по Y
            int direction = 1; //Множитель, который будет определять, какие квадраты закрашивать
            float[] linek = new float[6]; // коэфф-ы K и B в уравнении прямой
            float[] lineb = new float[6];
            for (int i = 0; i < 6; i++)// заполнение массива по количеству прямых из которых составлен 6-иугольник
            {
                linek[i] = (float)(points[(i + 1)%6].Y - points[i].Y) / (float)(points[(i + 1)%6].X - points[i].X); 
                lineb[i] = -(float)(points[i].X * points[(i + 1)%6].Y - points[(i + 1)%6].X * points[i].Y)/ (float)(points[(i + 1)%6].X - points[i].X);
            }

            while (x1>points[2].X && x1<points[5].X)
            {
                for (int i = 0; i < range; i++)
                {
                    if (y1 <= points[0].Y && y1 >= points[3].Y) // проверка, находится ли точка, которую закрашиваем внутри шестиугольника путем сравнения через уравнение прямой
                     if (x1 < ((float) (y1 - lineb[5]) / linek[5]) &&
                         x1 > ((float) (y1 - lineb[1]) / linek[1]) &&
                         x1 < ((float) (y1 - lineb[4]) / linek[4]) &&
                         x1 > ((float) (y1 - lineb[2]) / linek[2]))
                     {
                    Thread.Sleep(2);
                    field.FillRectangle(Settings.Instance.ShapeBrush,
                        x1, y1,
                        Settings.SPIRAL_SIZE, Settings.SPIRAL_SIZE);
                    }


                    if (isx) // увеличение координаты в соответствии с направлением движения
                    {
                        x1 += Settings.SPIRAL_SIZE * direction;
                    }
                    else
                    {
                        y1 += Settings.SPIRAL_SIZE * direction;
                    }
                }

                isx = isx ? false : true; // смена направления с Х на У и наоборот
                    if (even) // смена направления на противоположное (вперед\назад)
                    {
                        range++; // дальность отрисовки в клетках
                        direction *= -1;
                    }

                    even = even ? false : true;
            }
        }

        public int RadiusOutCircle
        {
            get => radiusOut;
            set
            {
                radiusOut = value;
                radiusScale = value * Settings.CELLS_SIZE;

            }
        }

        public int X0
        {
            get => x0;
            set
            {
                x0 = value;
                x0scale = value * Settings.CELLS_SIZE;
            }
        }

        public int Y0
        {
            get => y0;
            set { 
            y0 = value;
            y0scale = value * Settings.CELLS_SIZE;
            }
        }
    }
}
