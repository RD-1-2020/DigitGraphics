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

        private List<Point> points;
        public Shape(Graphics field)
        {
            this.field = field;
        }

        public Shape(int x0, int y0, Graphics field)
        {
            X0 = x0;
            Y0 = y0;
            this.field = field;

            int[] arrays = new int[16];
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
            points = new List<Point>();
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

        //TODO: Реализовать
        public void drawLines()
        {
            List<Point> points = new List<Point>();

            for (int i = 1; i < 7; i++)                                                                          //вычисляет точки шестиугольника (как у Ксюши) 
            {
                points.Add(
                    new Point(
                        (int)(Math.Cos(i * Math.PI / 3) * radiusScale) + x0scale,
                        (int)(Math.Sin(i * Math.PI / 3) * radiusScale) + y0scale
                        ));
            }

            float k = ((float)points[3].Y - (float)points[2].Y) / ((float)points[3].X - (float)points[2].X);     //считает коэффицент k для уравнения прямой (стороны шестиугольника)
            float b = points[3].Y - k * points[3].X;                                                             //считает b для уравнения прямой, которая идёт вверх
            float b1 = points[4].Y + k * points[4].X;                                                            //считает b для уравнения прямой, которая идёт вниз
            int xNew1 = (int)(((int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE - b) / k);        //X для нижней левой точки многоугольника в левом верхнем углу
                                                                                                                                     //(подобные X я вычисляла при задании точек, это была первая, когда я пробовала,
                                                                                                                                     //можно её убрать, поставить вместо неё в задании координат точки само вычисление) 
            int xNew2 = (int)(((int)((Math.Sin(5 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE - b1) / (-k));    //X для нижней левой точки многоугольника в правом верхнем углу
                                                                                                                                     //(подобные X я вычисляла при задании точек,
                                                                                                                                     //можно её убрать, поставить вместо неё в задании координат точки само вычисление) 

            Point pointL1 = new Point(points[3].X, points[3].Y);
            Point pointL2 = new Point((int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 1) * Settings.CELLS_SIZE,
                points[3].Y);
            Point pointL3 = new Point((int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 1) * Settings.CELLS_SIZE,
                (int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE);
            Point pointL4 = new Point(xNew1,
                (int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE);

            Point[] pointsLeft = { pointL1, pointL2, pointL3, pointL4 };

            field.FillPolygon(Settings.Instance.LinesBrush, pointsLeft);                                           //закрашивается многоугольник в левом верхнем углу


            for (int a = 0; 
                ((int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 2 + a) * Settings.CELLS_SIZE) <= 
                ((int)((Math.Cos(5 * (Math.PI / 3)) * RadiusOutCircle) + x0) * Settings.CELLS_SIZE); a++)          //закрашивается первая строка шестиугольника (неполная),
                                                                                                                   //кроме многоугольников при верхних вершинах
            {
                Point p1 = new Point((int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 1 + a) * Settings.CELLS_SIZE,
                points[3].Y);
                Point p2 = new Point((int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 2 + a) * Settings.CELLS_SIZE,
                    points[3].Y);
                Point p3 = new Point((int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 2 + a) * Settings.CELLS_SIZE,
                    (int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE);
                Point p4 = new Point((int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 1 + a) * Settings.CELLS_SIZE,
                    (int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE);

                Point[] pointsUp = { p1, p2, p3, p4 };

                field.FillPolygon(Settings.Instance.LinesBrush, pointsUp);                                          
                System.Threading.Thread.Sleep(20);

            }

            Point pointR1 = new Point(points[4].X, points[3].Y);
            Point pointR2 = new Point((int)((Math.Cos(5 * (Math.PI / 3)) * RadiusOutCircle) + x0) * Settings.CELLS_SIZE, 
                points[3].Y);
            Point pointR3 = new Point((int)((Math.Cos(5 * (Math.PI / 3)) * RadiusOutCircle) + x0) * Settings.CELLS_SIZE, 
                (int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE);
            Point pointR4 = new Point(xNew2, (int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE);

            Point[] pointsRight = { pointR1, pointR2, pointR3, pointR4 };

            field.FillPolygon(Settings.Instance.LinesBrush, pointsRight);                                         //закрашивается многоугольник в правом верхнем углу

            int yBegin = (int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE;     //Y для второй строчки
            int y1 = (int)((Math.Sin(2 * Math.PI / 3) * RadiusOutCircle) + y0) * Settings.CELLS_SIZE;             //Y для предпоследней строчки

            int xBegin = (int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 1) * Settings.CELLS_SIZE;   //левый X для прямоугольника в шестиугольнике, который состоит из полноценных квадратов
            int x1 = (int)((Math.Cos(5 * (Math.PI / 3)) * RadiusOutCircle) + x0 - 1) * Settings.CELLS_SIZE;       //правый X для прямоугольника в шестиугольнике, который состоит из полноценных квадратов

            for (int j = 1; yBegin < y1; yBegin += Settings.CELLS_SIZE, j++)               //цикл основной закраски
            {
                if (pointL3.Y < y0scale)                                                   //вычисляются точки для закраски левой части шестиугольника (верхняя половина)
                {
                    pointL1.X = pointL4.X;
                    pointL4.X = (int)(((int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1 + j) * Settings.CELLS_SIZE - b) / k);
                    pointL1.Y = pointL4.Y;
                    pointL2.Y = pointL4.Y;
                    pointL3.Y = pointL4.Y + Settings.CELLS_SIZE;
                    pointL4.Y = pointL4.Y + Settings.CELLS_SIZE;
                }
                else                                                                       //вычисляются точки для закраски левой части шестиугольника (нижняя половина)
                {
                    pointL1.X = pointL4.X;
                    pointL4.X = (int)(((int)((Math.Sin(2 * Math.PI / 3) * RadiusOutCircle) + y0 - j) * Settings.CELLS_SIZE - b) / k);
                    pointL1.Y = pointL4.Y;
                    pointL2.Y = pointL4.Y;
                    pointL3.Y = pointL4.Y + Settings.CELLS_SIZE;
                    pointL4.Y = pointL4.Y + Settings.CELLS_SIZE;
                }

                Point[] pointsLeft1 = { pointL1, pointL2, pointL3, pointL4 };

                field.FillPolygon(Settings.Instance.LinesBrush, pointsLeft1);

                for (int i = 0; xBegin + i <= x1; i += Settings.CELLS_SIZE)                //цикл закраски прямоугольника в шестиугольнике, который состоит из полноценных квадратов
                {
                    field.FillRectangle(Settings.Instance.LinesBrush, xBegin + i, yBegin, Settings.CELLS_SIZE, Settings.CELLS_SIZE);
                    System.Threading.Thread.Sleep(20);
                }

                if (pointR3.Y < y0scale)                                                   //вычисляются точки для закраски правой части шестиугольника (верхняя половина)
                {
                    pointR1.X = pointR4.X;
                    pointR4.X = (int)(((int)((Math.Sin(5 * Math.PI / 3) * RadiusOutCircle) + y0 + 1 + j) * Settings.CELLS_SIZE - b1) / (-k));
                    pointR1.Y = pointR4.Y;
                    pointR2.Y = pointR4.Y;
                    pointR3.Y = pointR4.Y + Settings.CELLS_SIZE;
                    pointR4.Y = pointR4.Y + Settings.CELLS_SIZE;
                }
                else                                                                       //вычисляются точки для закраски правой части шестиугольника (нижняя половина)
                {
                    pointR1.X = pointR4.X;
                    pointR4.X = (int)(((int)((Math.Sin(1 * Math.PI / 3) * RadiusOutCircle) + y0 - j) * Settings.CELLS_SIZE - b1) / (-k));
                    pointR1.Y = pointR4.Y;
                    pointR2.Y = pointR4.Y;
                    pointR3.Y = pointR4.Y + Settings.CELLS_SIZE;
                    pointR4.Y = pointR4.Y + Settings.CELLS_SIZE;
                }

                Point[] pointsRight1 = { pointR1, pointR2, pointR3, pointR4 };

                field.FillPolygon(Settings.Instance.LinesBrush, pointsRight1);
            }                                                                              //конец основного цикла закраски

            pointL1.X = pointL4.X;
            pointL4.X = points[1].X;
            pointL1.Y = pointL4.Y;
            pointL2.Y = pointL3.Y;
            pointL3.Y = points[1].Y;
            pointL4.Y = points[1].Y;

            Point[] pointsLeft2 = { pointL1, pointL2, pointL3, pointL4 };

            field.FillPolygon(Settings.Instance.LinesBrush, pointsLeft2);                  //закрашивается многоугольник в левом нижнем углу

            for (int a = 0;
                ((int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 2 + a) * Settings.CELLS_SIZE) <=
                ((int)((Math.Cos(5 * (Math.PI / 3)) * RadiusOutCircle) + x0) * Settings.CELLS_SIZE); a++)    //закрашивается последняя строка шестиугольника (неполная),
                                                                                                             //кроме многоугольников при нижних вершинах
            {
                Point p1 = new Point((int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 1 + a) * Settings.CELLS_SIZE,
                (int)((Math.Sin(2 * Math.PI / 3) * RadiusOutCircle) + y0) * Settings.CELLS_SIZE);
                Point p2 = new Point((int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 2 + a) * Settings.CELLS_SIZE,
                    (int)((Math.Sin(2 * Math.PI / 3) * RadiusOutCircle) + y0) * Settings.CELLS_SIZE);
                Point p3 = new Point((int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 2 + a) * Settings.CELLS_SIZE,
                    points[1].Y);
                Point p4 = new Point((int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 1 + a) * Settings.CELLS_SIZE,
                    points[1].Y);

                Point[] pointsDown = { p1, p2, p3, p4 };

                field.FillPolygon(Settings.Instance.LinesBrush, pointsDown);
                System.Threading.Thread.Sleep(20);

            }

            pointR1.X = pointR4.X;
            pointR4.X = points[0].X;
            pointR1.Y = pointR4.Y;
            pointR2.Y = pointR3.Y;
            pointR3.Y = points[0].Y;
            pointR4.Y = points[0].Y;

            Point[] pointsRight2 = { pointR1, pointR2, pointR3, pointR4 };

            field.FillPolygon(Settings.Instance.LinesBrush, pointsRight2);                  //закрашивается многоугольник в правом нижнем углу

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
                    field.FillRectangle(Settings.Instance.LinesBrush,
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
