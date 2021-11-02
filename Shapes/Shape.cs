using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
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

        private int hole;
        private int holeScale;

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
        }

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

        public async void drawLines()
        {
            if (radiusScale == 0 || radiusScale == holeScale / 2)                                     //выходит из функции, если радиус = 0 или = половине размера отверстия
                return;

            List<Point> points = new List<Point>();

            for (int i = 1; i < 7; i++) {
                points.Add(
                    new Point(
                        (int)(Math.Cos(i * Math.PI / 3) * radiusScale) + x0scale,
                        (int)(Math.Sin(i * Math.PI / 3) * radiusScale) + y0scale
                        ));
            }

            float k = ((float)points[3].Y - (float)points[2].Y) / ((float)points[3].X - (float)points[2].X);     //считает коэффицент k для уравнения прямой (стороны шестиугольника)
            float b = points[2].Y - k * points[2].X;                                                             //считает b для уравнения прямой, которая идёт вверх
            float b1 = points[5].Y + k * points[5].X;                                                            //считает b для уравнения прямой, которая идёт вниз
            int xNew1 = (int)(((int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE - b) / k);        //X для нижней левой точки многоугольника в левом верхнем углу
            int xNew2 = (int)(((int)((Math.Sin(5 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE - b1) / (-k));    //X для нижней левой точки многоугольника в правом верхнем углу

            Point pointL1 = new Point(points[3].X, points[3].Y);
            Point pointL2 = new Point((int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 1) * Settings.CELLS_SIZE,
                points[3].Y);
            Point pointL3 = new Point((int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 1) * Settings.CELLS_SIZE,
                (int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE);
            Point pointL4 = new Point(xNew1,
                (int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE);

            if (holeScale == 0 || pointL3.Y <= y0scale - holeScale / 2)                               //закрашивается многоугольник в левом верхнем углу
            {                                                                                         //если его не касается отверстие
                Point[] pointsLeft = { pointL1, pointL2, pointL3, pointL4 };
                field.FillPolygon(Settings.Instance.LinesBrush, pointsLeft);
            }
            else if (points[3].Y <= y0scale - holeScale / 2)                                          //если касается отверстие
            {
                int pL4Y = pointL4.Y;
                int pL4X = pointL4.X;
                pointL3.Y = y0scale - holeScale / 2;
                pointL4.Y = pointL3.Y;
                pointL4.X = (int)((pointL4.Y - b) / k);
                Point[] pointsLeft = { pointL1, pointL2, pointL3, pointL4 };
                field.FillPolygon(Settings.Instance.LinesBrush, pointsLeft);
                if (hole == 1 && radiusOut == 1)                                                     //для радиуса 1, отверстия 1
                {
                    Point dopPL1 = pointL4;
                    Point dopPL2 = new Point(x0scale - holeScale / 2, pointL4.Y); ;
                    Point dopPL3 = new Point(x0scale - holeScale / 2, y0scale);
                    Point dopPL4 = new Point((int)((y0scale - b) / k), y0scale);

                    Point[] pointsDopL = { dopPL1, dopPL2, dopPL3, dopPL4 };
                    field.FillPolygon(Settings.Instance.LinesBrush, pointsDopL);
                }
                pointL4.Y = pL4Y;
                pointL3.Y = pL4Y;
                pointL4.X = pL4X;
            }

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

                if (holeScale == 0 || p3.Y <= y0scale - holeScale / 2)                                       //если не касается отверстия
                {
                    Point[] pointsUp = { p1, p2, p3, p4 };
                    field.FillPolygon(Settings.Instance.LinesBrush, pointsUp);
                    await Task.Delay(10);
                }
                else if (p1.Y <= y0scale - holeScale / 2)                                                   //если касается отверстия
                {
                    p4.Y = y0scale - holeScale / 2;
                    p3.Y = p4.Y;
                    Point[] pointsUp = { p1, p2, p3, p4 };
                    field.FillPolygon(Settings.Instance.LinesBrush, pointsUp);
                    await Task.Delay(10);
                }
            }

            Point pointR1 = new Point(points[4].X, points[3].Y);
            Point pointR2 = new Point((int)((Math.Cos(5 * (Math.PI / 3)) * RadiusOutCircle) + x0) * Settings.CELLS_SIZE, 
                points[3].Y);
            Point pointR3 = new Point((int)((Math.Cos(5 * (Math.PI / 3)) * RadiusOutCircle) + x0) * Settings.CELLS_SIZE, 
                (int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE);
            Point pointR4 = new Point(xNew2, (int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE);

            if (holeScale == 0 || pointR3.Y <= y0scale - holeScale / 2)                                         //закрашивается многоугольник в правом верхнем углу
            {                                                                                                   //если не касается отверстия
                Point[] pointsRight = { pointR1, pointR2, pointR3, pointR4 };
                field.FillPolygon(Settings.Instance.LinesBrush, pointsRight);
            }
            else if (points[4].Y <= y0scale - holeScale / 2)                                                    //если касается отверстия
            {
                int pR4Y = pointR4.Y;
                int pR4X = pointR4.X;
                pointR3.Y = y0scale - holeScale / 2;
                pointR4.Y = pointR3.Y;
                pointR4.X = (int)((pointR4.Y - b1) / (-k));
                Point[] pointsRight = { pointR1, pointR2, pointR3, pointR4 };
                field.FillPolygon(Settings.Instance.LinesBrush, pointsRight);

                if (hole == 1 && radiusOut == 1)                                                                //для радиуса 1, отверстия 1
                {
                    Point dopPR1 = pointR4;
                    Point dopPR2 = new Point(x0scale + holeScale / 2, pointR4.Y); ;
                    Point dopPR3 = new Point(x0scale + holeScale / 2, y0scale);
                    Point dopPR4 = new Point((int)((y0scale - b1) / (-k)), y0scale);

                    Point[] pointsDopR = { dopPR1, dopPR2, dopPR3, dopPR4 };
                    field.FillPolygon(Settings.Instance.LinesBrush, pointsDopR);
                }
                pointR4.Y = pR4Y;
                pointR3.Y = pR4Y;
                pointR4.X = pR4X;
            }

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

                if ((yBegin < y0scale - holeScale / 2) || (yBegin > y0scale + holeScale / 2) || holeScale == 0)
                {
                    if ((pointL3.Y > y0scale - holeScale / 2) && (pointL2.Y < y0scale - holeScale / 2) 
                        && (pointL2.X > x0scale - holeScale / 2))                                                          //отверстие уголком задевает
                    {
                        Point pAL1 = pointL1;
                        Point pAL2 = pointL2;
                        Point pAL3 = new Point(pointL3.X, pointL3.Y - Settings.CELLS_SIZE / 2);
                        Point pAL4 = new Point(x0scale - holeScale / 2, pointL3.Y - Settings.CELLS_SIZE / 2);
                        Point pAL5 = new Point(x0scale - holeScale / 2, pointL3.Y);
                        Point pAL6 = pointL4;
                        if (pAL4.X < (int)((pAL4.Y - b) / k))                    //чтобы не отрисовывалось лишнее, если отверстие где-то выходит за пределы шестиугольника
                        {
                            pAL4.X = (int)((pAL4.Y - b) / k);
                            pAL5 = pAL4;
                            pAL6 = pAL4;
                        }
                        Point[] pointsAL = { pAL1, pAL2, pAL3, pAL4, pAL5, pAL6 };
                        field.FillPolygon(Settings.Instance.LinesBrush, pointsAL);
                    }
                    else                                                                                                      //отверстие не влияет
                    {
                        Point[] pointsLeft1 = { pointL1, pointL2, pointL3, pointL4 };
                        field.FillPolygon(Settings.Instance.LinesBrush, pointsLeft1);
                    }
                }
                else if ((pointL1.X > x0scale - holeScale / 2) && (pointL4.X > x0scale - holeScale / 2))              //чтобы не отрисовывалось, если по х в зоне отверстия,
                {
                    if (pointL4.Y > y0scale + holeScale / 2)                                           //кроме случая внизу шестиугольника, когда отверстие касается
                    {
                        int pL1Y = pointL1.Y;
                        int pL1X = pointL1.X;
                        pointL2.Y = y0scale + holeScale / 2;
                        pointL1.Y = y0scale + holeScale / 2;
                        pointL1.X = (int)((pointL1.Y - (points[2].Y + k * points[2].X)) / -k);
                        Point[] pointsLeft1 = { pointL1, pointL2, pointL3, pointL4 };
                        field.FillPolygon(Settings.Instance.LinesBrush, pointsLeft1);
                        pointL1.X = pL1X;
                        pointL1.Y = pL1Y;
                        pointL2.Y = pL1Y;
                    }
                }
                else if (pointL2.X <= x0scale - holeScale / 2)                                              //отверстие не касается или границы совпадают
                {
                    Point[] pointsLeft1 = { pointL1, pointL2, pointL3, pointL4 };
                    field.FillPolygon(Settings.Instance.LinesBrush, pointsLeft1);
                }
                else if (pointL2.X > x0scale - holeScale / 2)                                              //отверстие залезло на левую отрисовку с правой стороны
                {
                    int pL2X = pointL2.X;
                    pointL2.X = x0scale - holeScale / 2;
                    pointL3.X = pointL2.X;
                    if ((pointL1.X > x0scale - holeScale / 2) && (pointL4.X < x0scale - holeScale / 2))  //отверстие не касается только самого левого угла в левой отрисовке
                    {                                                                                    //верхняя половина
                        int pL1X = pointL1.X;
                        int pL1Y = pointL1.Y;
                        pointL1.X = pointL3.X;
                        pointL1.Y = (int)(k * pointL1.X + b);
                        Point[] pointsLeft1 = { pointL1, pointL2, pointL3, pointL4 };
                        field.FillPolygon(Settings.Instance.LinesBrush, pointsLeft1);
                        pointL1.X = pL1X;
                        pointL1.Y = pL1Y;
                    }
                    else if ((pointL1.X < x0scale - holeScale / 2) && (pointL4.X > x0scale - holeScale / 2)) //отверстие не касается только самого левого угла в левой отрисовке
                    {                                                                                        //нижняя половина
                        int pL4X = pointL4.X;
                        int pL4Y = pointL4.Y;
                        pointL4.X = pointL3.X;
                        pointL4.Y = (int)(-k * pointL4.X + (points[2].Y + k * points[2].X));
                        Point[] pointsLeft1 = { pointL1, pointL2, pointL3, pointL4 };
                        field.FillPolygon(Settings.Instance.LinesBrush, pointsLeft1);

                        Point pDopL1 = new Point((int)(((y0scale + holeScale / 2) - (points[2].Y + k * points[2].X)) / (-k)), y0scale + holeScale / 2);
                        Point pDopL2 = new Point(pL2X, y0scale + holeScale / 2);
                        Point pDopL3 = new Point(pL2X, pointL3.Y);
                        Point pDopL4 = new Point(pL4X, pL4Y);
                        Point[] pointsDopL = { pDopL1, pDopL2, pDopL3, pDopL4 };
                        if ((pDopL1.Y <= y0scale + holeScale / 2) && (pDopL4.Y > y0scale + holeScale / 2)) //закрашивает возникающую при нижнем левом крае дырку
                        {
                            field.FillPolygon(Settings.Instance.LinesBrush, pointsDopL);
                        }
                        pointL4.X = pL4X;
                        pointL4.Y = pL4Y;
                    }
                    else
                    {
                        if (pointL3.Y < y0scale + holeScale / 2)                     //основные левые многоугольники, у которых изменены только границы с правой стороны
                        {
                            Point[] pointsLeft1 = { pointL1, pointL2, pointL3, pointL4 };
                            field.FillPolygon(Settings.Instance.LinesBrush, pointsLeft1);
                        }
                        else                                                              //нижний угол отверстия
                        {
                            Point[] pointsLeft1 = { pointL1, pointL2, pointL3, pointL4 };
                            field.FillPolygon(Settings.Instance.LinesBrush, pointsLeft1);
                            field.FillRectangle(Settings.Instance.LinesBrush, pointL3.X, y0scale + holeScale / 2,
                            pL2X - (x0scale - holeScale / 2), pointL3.Y - (y0scale + holeScale / 2));
        }
                    }
                    pointL2.X = pL2X;
                    pointL3.X = pointL2.X;
                }
                for (int i = 0; xBegin + i <= x1; i += Settings.CELLS_SIZE)   //цикл закраски прямоугольника в шестиугольнике, который состоит из полноценных квадратов и не только
                {

                    if (holeScale == 0 || ((yBegin < y0scale - holeScale / 2) && yBegin + Settings.CELLS_SIZE <= y0scale - holeScale / 2) ||
                        (yBegin >= y0scale + holeScale / 2) ||
                        ((xBegin + i < x0scale - holeScale / 2) && xBegin + i + Settings.CELLS_SIZE <= x0scale - holeScale / 2) ||
                        (xBegin + i >= x0scale + holeScale / 2))                                                                  //полноценные квадраты
                    {
                        field.FillRectangle(Settings.Instance.LinesBrush, xBegin + i, yBegin, Settings.CELLS_SIZE, Settings.CELLS_SIZE);
                        await Task.Delay(10);
                    }
                    else if ((xBegin + i < x0scale - holeScale / 2) && (xBegin + i + Settings.CELLS_SIZE > x0scale - holeScale / 2) &&
                        ((yBegin < y0scale - holeScale / 2) || (yBegin + Settings.CELLS_SIZE > y0scale + holeScale / 2)))   //при углах отверстия слева
                    {
                        Point pL1 = new Point(xBegin + i, yBegin);
                        Point pL2 = new Point(xBegin + i + Settings.CELLS_SIZE, yBegin);
                        Point pL3 = new Point(pL2.X, yBegin + Settings.CELLS_SIZE / 2);
                        Point pL4 = new Point(xBegin + i + Settings.CELLS_SIZE / 2, pL3.Y);
                        Point pL5 = new Point(pL4.X, yBegin + Settings.CELLS_SIZE);
                        Point pL6 = new Point(xBegin + i, yBegin + Settings.CELLS_SIZE);
                        if (yBegin < y0scale - holeScale / 2)                                          //сверху
                        {
                            Point[] pointsAngleL = { pL1, pL2, pL3, pL4, pL5, pL6 };
                            field.FillPolygon(Settings.Instance.LinesBrush, pointsAngleL);
                        }
                        else if (yBegin + Settings.CELLS_SIZE > y0scale + holeScale / 2)               //снизу
                        {
                            pL2.X = pL4.X;
                            pL3.X = pL4.X;
                            pL4.X += Settings.CELLS_SIZE / 2;
                            pL5.X = pL4.X;
                            Point[] pointsAngleL = { pL1, pL2, pL3, pL4, pL5, pL6 };
                            field.FillPolygon(Settings.Instance.LinesBrush, pointsAngleL);
                        }
                    }
                    else if ((xBegin + i + Settings.CELLS_SIZE > x0scale + holeScale / 2) && (xBegin + i < x0scale + holeScale / 2) &&
                        ((yBegin < y0scale - holeScale / 2) || (yBegin + Settings.CELLS_SIZE > y0scale + holeScale / 2)))        //при углах отверстия справа
                    {
                        Point pR1 = new Point(xBegin + i, yBegin);
                        Point pR2 = new Point(xBegin + i + Settings.CELLS_SIZE, yBegin);
                        Point pR3 = new Point(pR2.X, yBegin + Settings.CELLS_SIZE);
                        Point pR4 = new Point(xBegin + i + Settings.CELLS_SIZE / 2, pR3.Y);
                        Point pR5 = new Point(pR4.X, yBegin + Settings.CELLS_SIZE / 2);
                        Point pR6 = new Point(xBegin + i, yBegin + Settings.CELLS_SIZE / 2);
                        if (yBegin < y0scale - holeScale / 2)                                                                   //сверху
                        {
                            Point[] pointsAngleR = { pR1, pR2, pR3, pR4, pR5, pR6 };
                            field.FillPolygon(Settings.Instance.LinesBrush, pointsAngleR);
                        }
                        else if (yBegin + Settings.CELLS_SIZE > y0scale + holeScale / 2)                                       //снизу
                        {
                            pR1.X = pR4.X;;
                            pR4.X = xBegin + i;
                            pR5.X = pR4.X;
                            pR6.X = xBegin + i + Settings.CELLS_SIZE / 2;
                            Point[] pointsAngleR = { pR1, pR2, pR3, pR4, pR5, pR6 };
                            field.FillPolygon(Settings.Instance.LinesBrush, pointsAngleR);
                        }
                    }
                    else if ((xBegin + i < x0scale - holeScale / 2) || (xBegin + i + Settings.CELLS_SIZE > x0scale + holeScale / 2))
                    {                                                                                                //неполные стороны отверстия 
                        Point pS1 = new Point(xBegin + i, yBegin);
                        Point pS2 = new Point(xBegin + i + Settings.CELLS_SIZE / 2, yBegin);
                        Point pS3 = new Point(pS2.X, yBegin + Settings.CELLS_SIZE);
                        Point pS4 = new Point(xBegin + i, pS3.Y);
                        if (xBegin + i < x0scale - holeScale / 2)                                                    //слева
                        {
                            Point[] pointsSide = { pS1, pS2, pS3, pS4 };
                            field.FillPolygon(Settings.Instance.LinesBrush, pointsSide);
                        }
                        else                                                                                         //справа
                        {
                            pS1.X += Settings.CELLS_SIZE;
                            pS4.X += Settings.CELLS_SIZE;
                            Point[] pointsSide = { pS1, pS2, pS3, pS4 };
                            field.FillPolygon(Settings.Instance.LinesBrush, pointsSide);
                        }
                    }
                    else if ((yBegin < y0scale - holeScale / 2) || (yBegin + Settings.CELLS_SIZE > y0scale + holeScale / 2))  //верх и низ отверстия
                    {
                        Point pUD1 = new Point(xBegin + i, yBegin);
                        Point pUD2 = new Point(xBegin + i + Settings.CELLS_SIZE, yBegin);
                        Point pUD3 = new Point(pUD2.X, yBegin + Settings.CELLS_SIZE / 2);
                        Point pUD4 = new Point(xBegin + i, pUD3.Y);
                        if (yBegin < y0scale - holeScale / 2)                                                                 //верх
                        {
                            Point[] pointsUD = { pUD1, pUD2, pUD3, pUD4 };
                            field.FillPolygon(Settings.Instance.LinesBrush, pointsUD);
                        }
                        else                                                                                                  //низ
                        {
                            pUD1.Y += Settings.CELLS_SIZE;
                            pUD2.Y += Settings.CELLS_SIZE;
                            Point[] pointsUD = { pUD1, pUD2, pUD3, pUD4 };
                            field.FillPolygon(Settings.Instance.LinesBrush, pointsUD);
                        }
                    }
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

                if ((yBegin < y0scale - holeScale / 2) || (yBegin > y0scale + holeScale / 2) || holeScale == 0)
                {
                    if ((pointR3.Y > y0scale - holeScale / 2) && (pointR2.Y < y0scale - holeScale / 2) 
                        && (pointR2.X < x0scale + holeScale / 2))                                            //отверстие уголком задевает
                    {
                        Point pAR1 = pointR1;
                        Point pAR2 = pointR2;
                        Point pAR3 = new Point(pointR3.X, y0scale - holeScale / 2);
                        Point pAR4 = new Point(x0scale + holeScale / 2, y0scale - holeScale / 2);
                        Point pAR5 = new Point(x0scale + holeScale / 2, pointR3.Y);
                        Point pAR6 = pointR4;
                        if (pAR4.X > (int)((pAR4.Y - b1) / -k))               //чтобы не отрисовывалось лишнее, если отверстие где-то выходит за пределы шестиугольника
                        {
                            pAR4.X = (int)((pAR4.Y - b1) / -k);
                            pAR5 = pAR4;
                            pAR6 = pAR4;
                        }
                        Point[] pointsAR = { pAR1, pAR2, pAR3, pAR4, pAR5, pAR6 };
                        field.FillPolygon(Settings.Instance.LinesBrush, pointsAR);
                    }
                    else                                                               //отверстие не влияет, закрашивается дырка наверху и внизу
                    {
                        Point[] pointsRight1 = { pointR1, pointR2, pointR3, pointR4 };
                        field.FillPolygon(Settings.Instance.LinesBrush, pointsRight1);
                    }

                }
                else if ((pointR1.X < x0scale + holeScale / 2) && (pointR4.X < x0scale + holeScale / 2))     //чтобы не отрисовывалось, если по х в зоне отверстия
                {
                    if (pointR4.Y > y0scale + holeScale / 2)                                              //кроме случая внизу шестиугольника, когда отверстие касается
                    {
                        int pR1Y = pointR1.Y;
                        int pR1X = pointR1.X;
                        pointR2.Y = y0scale + holeScale / 2;
                        pointR1.Y = y0scale + holeScale / 2;
                        pointR1.X = (int)((pointR1.Y - (points[5].Y - k * points[5].X)) / k);
                        Point[] pointsRight1 = { pointR1, pointR2, pointR3, pointR4 };
                        field.FillPolygon(Settings.Instance.LinesBrush, pointsRight1);
                        pointR1.X = pR1X;
                        pointR1.Y = pR1Y;
                        pointR2.Y = pR1Y;
                    }
                }
                else if (pointR2.X >= x0scale + holeScale / 2)                                    //отверстие не касается или границы совпадают
                {
                    Point[] pointsRight1 = { pointR1, pointR2, pointR3, pointR4 };
                    field.FillPolygon(Settings.Instance.LinesBrush, pointsRight1);
                }
                else if (pointR2.X < x0scale + holeScale / 2)                                    //отверстие залезло на правую отрисовку с левой стороны
                {
                    int pR2X = pointR2.X;
                    pointR2.X = x0scale + holeScale / 2;
                    pointR3.X = pointR2.X;
                    if ((pointR1.X < x0scale + holeScale / 2) && (pointR4.X > x0scale + holeScale / 2)) //отверстие не касается только самого правого угла в правой отрисовке
                    {                                                                                   //верхняя половина
                        int pR1X = pointR1.X;
                        int pR1Y = pointR1.Y;
                        pointR1.X = pointR3.X;
                        pointR1.Y = (int)(-k * pointR1.X + b1);
                        Point[] pointsRight1 = { pointR1, pointR2, pointR3, pointR4 };
                        field.FillPolygon(Settings.Instance.LinesBrush, pointsRight1);
                        pointR1.X = pR1X;
                        pointR1.Y = pR1Y; ;
                    }
                    else if ((pointR1.X >= x0scale + holeScale / 2) && (pointR4.X < x0scale + holeScale / 2))   //отверстие не касается только самого правого угла в правой отрисовке
                    {                                                                                           //нижняя половина
                        int pR4X = pointR4.X;
                        int pR4Y = pointR4.Y;
                        pointR4.X = pointR3.X;
                        pointR4.Y = (int)(k * pointR4.X + (points[5].Y - k * points[5].X));
                        Point[] pointsRight1 = { pointR1, pointR2, pointR3, pointR4 };
                        field.FillPolygon(Settings.Instance.LinesBrush, pointsRight1);

                        Point pDopR1 = new Point((int)(((y0scale + holeScale / 2) - (points[5].Y - k * points[5].X)) / k), 
                            y0scale + holeScale / 2);
                        Point pDopR2 = new Point(pR2X, y0scale + holeScale / 2);
                        Point pDopR3 = new Point(pR2X, pointR3.Y);
                        Point pDopR4 = new Point(pR4X, pR4Y);
                        Point[] pointsDopR = { pDopR1, pDopR2, pDopR3, pDopR4 };
                        if ((pDopR1.Y <= y0scale + holeScale / 2) && (pDopR4.Y > y0scale + holeScale / 2))  //закрашивает возникающую при нижнем правом крае дырку
                        {
                            field.FillPolygon(Settings.Instance.LinesBrush, pointsDopR);
                        }
                        pointR4.X = pR4X;
                        pointR4.Y = pR4Y;
                    }
                    else
                    {
                        if (pointR3.Y < y0scale + holeScale / 2)                  //основные правые многоугольники, у которых изменены границы толькот с левой стороны
                        {
                            Point[] pointsRight1 = { pointR1, pointR2, pointR3, pointR4 };
                            field.FillPolygon(Settings.Instance.LinesBrush, pointsRight1);
                        }
                        else                                                                  //нижний угол отверстия
                        {
                            Point[] pointsRight1 = { pointR1, pointR2, pointR3, pointR4 };
                            field.FillPolygon(Settings.Instance.LinesBrush, pointsRight1);
                            field.FillRectangle(Settings.Instance.LinesBrush, pR2X, y0scale + holeScale / 2,
                                x0scale + holeScale / 2 - pR2X, pointR3.Y - (y0scale + holeScale / 2));
                        }

                    }
                    pointR2.X = pR2X;
                    pointR3.X = pointR2.X;
                }
            }                                                                              //конец основного цикла закраски

            pointL1.X = pointL4.X;
            pointL4.X = points[1].X;
            pointL1.Y = pointL4.Y;
            pointL2.Y = pointL3.Y;
            pointL3.Y = points[1].Y;
            pointL4.Y = points[1].Y;

            if (holeScale == 0 || pointL2.Y >= y0scale + holeScale / 2)                  //закрашивается многоугольник в левом нижнем углу
            {                                                                            //если его не касается отверстие
                Point[] pointsLeft2 = { pointL1, pointL2, pointL3, pointL4 };
                field.FillPolygon(Settings.Instance.LinesBrush, pointsLeft2);
            }
            else if (points[1].Y >= y0scale + holeScale / 2)                             //если касается отверстие
            {
                int pL1Y = pointL1.Y;
                int pL1X = pointL1.X;
                pointL2.Y = y0scale + holeScale / 2;
                pointL1.Y = pointL2.Y;
                pointL1.X = (int)((pointL1.Y - (points[2].Y + k * points[2].X)) / (-k));
                Point[] pointsLeft2 = { pointL1, pointL2, pointL3, pointL4 };
                field.FillPolygon(Settings.Instance.LinesBrush, pointsLeft2);

                if (hole == 1 && radiusOut == 1)                                               //для радиуса 1, отверстия 1
                {
                    Point dopPLD1 = new Point((int)((y0scale - b) / k), y0scale);
                    Point dopPLD2 = new Point(x0scale - holeScale / 2, y0scale);
                    Point dopPLD3 = new Point(x0scale - holeScale / 2, pointL1.Y);
                    Point dopPLD4 = pointL1;

                    Point[] pointsDopLD = { dopPLD1, dopPLD2, dopPLD3, dopPLD4 };
                    field.FillPolygon(Settings.Instance.LinesBrush, pointsDopLD);
                }
                pointL1.Y = pL1Y;
                pointL2.Y = pL1Y;
                pointL1.X = pL1X;
            }

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

                if (holeScale == 0 || p2.Y >= y0scale + holeScale / 2)                                       //если не касается отверстия
                {
                    Point[] pointsDown = { p1, p2, p3, p4 };
                    field.FillPolygon(Settings.Instance.LinesBrush, pointsDown);
                    await Task.Delay(10);
                }
                else if (p4.Y >= y0scale + holeScale / 2)                                                    //если касается отверстия
                {
                    p1.Y = y0scale + holeScale / 2;
                    p2.Y = p1.Y;
                    Point[] pointsDown = { p1, p2, p3, p4 };
                    field.FillPolygon(Settings.Instance.LinesBrush, pointsDown);
                    await Task.Delay(10);
                }
            }

            pointR1.X = pointR4.X;
            pointR4.X = points[0].X;
            pointR1.Y = pointR4.Y;
            pointR2.Y = pointR3.Y;
            pointR3.Y = points[0].Y;
            pointR4.Y = points[0].Y;

            if (holeScale == 0 || pointR2.Y >= y0scale + holeScale / 2)                  //закрашивается многоугольник в правом нижнем углу
            {                                                                            //если не касается отверстия
                Point[] pointsRight = { pointR1, pointR2, pointR3, pointR4 };
                field.FillPolygon(Settings.Instance.LinesBrush, pointsRight);
            }
            else if (points[0].Y >= y0scale + holeScale / 2)                             //если касается отверстия
            {
                int pR1Y = pointR1.Y;
                int pR1X = pointR1.X;
                pointR2.Y = y0scale + holeScale / 2;
                pointR1.Y = pointR2.Y;
                pointR1.X = (int)((pointR1.Y - (points[5].Y - k * points[5].X)) / k);
                Point[] pointsRight2 = { pointR1, pointR2, pointR3, pointR4 };
                field.FillPolygon(Settings.Instance.LinesBrush, pointsRight2);

                if (hole == 1 && radiusOut == 1)                                          //для радиуса 1, отвенрстия 1
                {
                    Point dopPRD1 = new Point((int)((y0scale - b1) / (-k)), y0scale);
                    Point dopPRD2 = new Point(x0scale + holeScale / 2, y0scale);
                    Point dopPRD3 = new Point(x0scale + holeScale / 2, pointR1.Y);
                    Point dopPRD4 = pointR1;

                    Point[] pointsDopRD = { dopPRD1, dopPRD2, dopPRD3, dopPRD4 };
                    field.FillPolygon(Settings.Instance.LinesBrush, pointsDopRD);
                }
                pointR1.Y = pR1Y;
                pointR1.Y = pR1Y;
                pointR1.X = pR1X;
            }
        }

        public async void drawSpiral() {
            int x1 = x0scale;
            int y1 = y0scale;
            int range = 1;
            bool even=false; //Если шаг четный, то меняется направление и увеличивается range
            bool isx = true; //true - движение по Х, false - движение по Y
            int direction = 1; //Множитель, который будет определять, какие квадраты закрашивать
            float[] linek = new float[6]; // коэфф-ы K и B в уравнении прямой
            float[] lineb = new float[6];
            if (points == null) {
                points = new List<Point>();

                for (int i = 1; i < 7; i++) //вычисляет точки шестиугольника
                {
                    points.Add(
                        new Point(
                            (int)(Math.Cos(i * Math.PI / 3) * radiusScale) + x0scale,
                            (int)(Math.Sin(i * Math.PI / 3) * radiusScale) + y0scale
                        ));
                }
            }

            for (int i = 0; i < 6; i++)// заполнение массива по количеству прямых из которых составлен 6-иугольник
            {
                linek[i] = (float)(points[(i + 1)%6].Y - points[i].Y) / (float)(points[(i + 1)%6].X - points[i].X); 
                lineb[i] = -(float)(points[i].X * points[(i + 1)%6].Y - points[(i + 1)%6].X * points[i].Y)/ (float)(points[(i + 1)%6].X - points[i].X);
            }

            while (x1>points[2].X && x1<points[5].X) {
                for (int i = 0; i < range; i++) {
                    if (y1 <= points[0].Y && y1 >= points[3].Y) // проверка, находится ли точка, которую закрашиваем внутри шестиугольника путем сравнения через уравнение прямой
                        if (x1 < ((float) (y1 - lineb[5]) / linek[5]) &&
                            x1 > ((float) (y1 - lineb[1]) / linek[1]) &&
                            x1 < ((float) (y1 - lineb[4]) / linek[4]) &&
                            x1 > ((float) (y1 - lineb[2]) / linek[2]) &&
                            !(x1 < x0scale + (holeScale / 2) && x1 > x0scale - (holeScale / 2) &&
                              y1 < y0scale + (holeScale / 2) && y1 > y0scale - (holeScale / 2)))
                        {
                            field.FillRectangle(Settings.Instance.LinesBrush,
                                    x1, y1,
                                    Settings.SPIRAL_SIZE, Settings.SPIRAL_SIZE);
                            if (x1 % 5 == 0) { await Task.Delay(2); }
                        }

                    if (isx) // увеличение координаты в соответствии с направлением движения
                    {
                        x1 += Settings.SPIRAL_SIZE * direction;
                    }
                    else y1 += Settings.SPIRAL_SIZE * direction;
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

        public void drawHole(int size) {
            size *= Settings.CELLS_SIZE;
            field.DrawRectangle(Settings.Instance.NormalColor, x0scale-(size/2),y0scale-(size/2),size,size);
        }

        public void drawCLine(List<Point> points) {
            field.DrawLine(Settings.Instance.NormLineColor, points[0], points[1]);

               List <Point> points1 = new List<Point>();

                //вычисляет точки шестиугольника
                for (int i = 1; i < 7; i++) {
                    points1.Add(new Point((int)(Math.Cos(i * Math.PI / 3) * radiusScale) + x0scale,
                            (int)(Math.Sin(i * Math.PI / 3) * radiusScale) + y0scale));
                }

                // коэффициенты k для фигуры
                float kF3 = ((float)points1[2].Y - (float)points1[3].Y)/(float)(points1[2].X - (float)points1[3].X);
                float kF4 = ((float)points1[4].Y - (float)points1[5].Y)/((float)points1[4].X - (float)points1[5].X);
                float kFUD= 0;
                      

                // коэффициенты b для фигуры
                float bF0 = (float)points1[5].Y + kF4 * (float)points1[5].X;
                float bF1 = (float)points1[2].Y + kF3 * (float)points1[2].X;
                float bF3 = (float)points1[2].Y - kF3 * (float)points1[2].X;
                float bF4 = (float)points1[5].Y - kF4 * (float)points1[5].X;
                float bFUp = (float)points1[3].Y - kFUD * (float)points1[3].X;
                float bFDown = (float)points1[0].Y - kFUD * (float)points1[0].X;
                
                // коэффициенты k для линии
                float kL = ((float)points[0].Y - (float)points[1].Y)/((float)points[0].X - (float)points[1].X);
                float bL = (float)points[0].Y - kL * (float)points[0].X;
                             
                Point p1 = new Point();
                Point p2 = new Point();

                if ((points[0].Y < points1[2].Y && points[0].X < points1[3].X) || (points[0].Y > points1[5].Y && points[0].X > points1[4].X)) {
                    p1.X = (int)((bL - bF3)/(kF3 - kL));
                    p2.X = (int)((bL - bF0)/(-kF4 - kL));
                    p1.Y = (int)(kL * (float)p1.X + bL);
                    p2.Y = (int)(kL * (float)p2.X + bL);

                    if ((points[1].Y < points1[5].Y && points[1].X > points1[4].X)) {
                        p2.X = (int)((bL - bF4)/(kF4 - kL));
                        p2.Y = (int)(kL*(float)p2.X + bL);
                    } 

                    if ((points[1].Y > points1[1].Y && points[1].X < points1[0].X)) {
                        p2.X = (int)((bL - bFDown)/(kFUD - kL));
                        p2.Y = (int)(kL*(float)p2.X + bL);
                    }

                    if ((points[1].Y < points1[3].Y && points[1].X < points1[4].X)) {
                        p2.X = (int)((bL - bFUp)/(kFUD - kL));
                        p2.Y = (int)(kL*(float)p2.X + bL);
                    }

                     if ((points[1].Y > points1[2].Y && points[1].X < points1[1].X)) {
                        p1.X = (int)((bL - bF3)/(kF3 - kL));
                        p1.Y = (int)(kL * (float)p1.X + bL);
                        p2.X = (int)((bL - bF1)/(-kF3 - kL));
                        p2.Y = (int)(kL*(float)p2.X + bL);
                     } 
                }

                else if ((points[0].Y > points1[2].Y && points[0].X < points1[3].X) || (points[0].Y < points1[5].Y && points[0].X > points1[4].X)) {
                    p1.X = (int)((bL - bF1)/(-kF3 - kL));
                    p1.Y = (int)(kL * (float)p1.X + bL);
                    p2.X = (int)((bL - bF4)/(kF4 - kL));
                    p2.Y = (int)(kL * (float)p2.X + bL);

                    if ((points[1].Y < points1[2].Y && points[1].X < points1[3].X)) {
                        p1.X = (int)((bL - bF4)/(kF4 - kL));
                        p1.Y = (int)(kL * (float)p1.X + bL);
                        p2.X = (int)((bL - bF3)/(kF3 - kL));
                        p2.Y = (int)(kL*(float)p2.X + bL);
                    } 

                   if ((points[1].Y < points1[2].Y && points[1].X < points1[3].X && points[1].X > points1[2].X)) {
                        p1.X = (int)((bL - bF1)/(-kF3 - kL));
                        p1.Y = (int)(kL * (float)p1.X + bL);
                        p2.X = (int)((bL - bF3)/(kF3 - kL));
                        p2.Y = (int)(kL*(float)p2.X + bL);
                   } 
                }
                
                else if ((points[0].Y <= points1[3].Y && points[0].X >= points1[3].X) || (points[0].Y >= points1[1].Y && points[0].X >= points1[1].X)) {
                    p1.X = (int)((bL - bFUp)/(kFUD - kL));
                    p1.Y = (int)(kL * (float)p1.X + bL);
                    p2.X = (int)((bL - bFDown)/(kFUD - kL));
                    p2.Y = (int)(kL * (float)p2.X + bL);
                    if (points[0].X == points[1].X)
                    {
                        p1.X = p2.X = points[0].X;
                        p1.Y = points1[3].Y;
                        p2.Y = points1[1].Y;
                    }

                    if ((points[1].Y < points1[2].Y && points[1].X < points1[3].X)) {
                        p1.X = (int)((bL - bFUp)/(kFUD - kL));
                        p1.Y = (int)(kL * (float)p1.X + bL);
                        p2.X = (int)((bL - bF3)/(kF3 - kL));
                        p2.Y = (int)(kL*(float)p2.X + bL);
                    } 

                     if ((points[1].Y < points1[2].Y && points[1].X < points1[3].X && points[1].X > points1[2].X) ) {
                        p1.X = (int)((bL - bFDown)/(kFUD - kL));
                        p1.Y = (int)(kL * (float)p1.X + bL);
                        p2.X = (int)((bL - bF3)/(kF3 - kL));
                        p2.Y = (int)(kL*(float)p2.X + bL);
                     } 
                } 
             
                // пыталась реализовать алгоритм частичного пересечения фигиры линией
                /*else {
                        p1.X = (int)(points[0].X); 
                        p1.Y = (int)(kL*(float)p1.X + bL);
                        p2.X = (int)(points[1].X); 
                        p2.Y = (int)(kL*(float)p2.X + bL);
                }*/

                // внутри фигуры
                /*else if (points[0].X > points1[3].X && points[0].X < points1[5].X && points[0].X > points1[2].X && points[0].Y < points1[1].Y && points[0].Y > points1[4].Y) {
                        p1.X = (int)(points[0].X);
                        p1.Y = (int)(kL*(float)p1.X + bL);
                        p2.X = (int)(points[1].X);
                        p2.Y = (int)(kL*(float)p2.X + bL);
                }*/

                field.DrawLine(Settings.Instance.NormalColor, p1, p2);
        }

        public int RadiusOutCircle
        {
            get => radiusOut;
            set {
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

        public int Hole
        {
            get => hole;
            set
            {
                hole = value;
                holeScale = value * Settings.CELLS_SIZE;
            }
        }
    }
}
