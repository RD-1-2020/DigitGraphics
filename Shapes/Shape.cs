﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DigitGraphics.Utils;

namespace DigitGraphics.Shapes
{
    class Shape
    {
        private int radiusOutCircle;

        private int x0;

        private int y0;

        private int x0scale;
        private int y0scale;
        private int radiusScale;

        private Graphics field;
        
        
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
            List<Point> points = new List<Point>();

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

            for (int i = 1; i < 7; i++)
            {
                points.Add(
                    new Point(
                        (int)(Math.Cos(i * Math.PI / 3) * radiusScale) + x0scale,
                        (int)(Math.Sin(i * Math.PI / 3) * radiusScale) + y0scale
                        ));
            }

            float k = ((float)points[3].Y - (float)points[2].Y) / ((float)points[3].X - (float)points[2].X);
            float b = points[3].Y - k * points[3].X;
            float b1 = points[4].Y + k * points[4].X;
            int xNew1 = (int)(((int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE - b) / k);
            int xNew2 = (int)(((int)((Math.Sin(5 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE - b1) / (-k));

            Point pointL1 = new Point(points[3].X, points[3].Y);
            Point pointL2 = new Point((int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 1) * Settings.CELLS_SIZE,
                points[3].Y);
            Point pointL3 = new Point((int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 1) * Settings.CELLS_SIZE,
                (int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE);
            Point pointL4 = new Point(xNew1,
                (int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE);

            Point[] pointsLeft = { pointL1, pointL2, pointL3, pointL4 };

            field.FillPolygon(Settings.Instance.LinesBrush, pointsLeft);


            for (int a = 0; 
                ((int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 2 + a) * Settings.CELLS_SIZE) <= 
                ((int)((Math.Cos(5 * (Math.PI / 3)) * RadiusOutCircle) + x0) * Settings.CELLS_SIZE); a++)
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

            Point pointR1 = new Point(points[4].X, 
                points[3].Y);
            Point pointR2 = new Point((int)((Math.Cos(5 * (Math.PI / 3)) * RadiusOutCircle) + x0) * Settings.CELLS_SIZE, 
                points[3].Y);
            Point pointR3 = new Point((int)((Math.Cos(5 * (Math.PI / 3)) * RadiusOutCircle) + x0) * Settings.CELLS_SIZE, 
                (int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE);
            Point pointR4 = new Point(xNew2, (int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE);

            Point[] pointsRight = { pointR1, pointR2, pointR3, pointR4 };

            field.FillPolygon(Settings.Instance.LinesBrush, pointsRight);

            int yBegin = (int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1) * Settings.CELLS_SIZE;
            int y1 = (int)((Math.Sin(2 * Math.PI / 3) * RadiusOutCircle) + y0) * Settings.CELLS_SIZE;

            int xBegin = (int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 1) * Settings.CELLS_SIZE;
            int x1 = (int)((Math.Cos(5 * (Math.PI / 3)) * RadiusOutCircle) + x0 - 1) * Settings.CELLS_SIZE;

            for (int j = 1; yBegin < y1; yBegin += Settings.CELLS_SIZE, j++)
            {
                if (pointL3.Y < y0scale)
                {
                    pointL1.X = pointL4.X;
                    pointL4.X = (int)(((int)((Math.Sin(4 * Math.PI / 3) * RadiusOutCircle) + y0 + 1 + j) * Settings.CELLS_SIZE - b) / k);
                    pointL1.Y = pointL4.Y;
                    pointL2.Y = pointL4.Y;
                    pointL3.Y = pointL4.Y + Settings.CELLS_SIZE;
                    pointL4.Y = pointL4.Y + Settings.CELLS_SIZE;
                }
                else
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

                for (int i = 0; xBegin + i <= x1; i += Settings.CELLS_SIZE)
                {
                    field.FillRectangle(Settings.Instance.LinesBrush, xBegin + i, yBegin, Settings.CELLS_SIZE, Settings.CELLS_SIZE);
                    System.Threading.Thread.Sleep(20);
                }

                if (pointR3.Y < y0scale)
                {
                    pointR1.X = pointR4.X;
                    pointR4.X = (int)(((int)((Math.Sin(5 * Math.PI / 3) * RadiusOutCircle) + y0 + 1 + j) * Settings.CELLS_SIZE - b1) / (-k));
                    pointR1.Y = pointR4.Y;
                    pointR2.Y = pointR4.Y;
                    pointR3.Y = pointR4.Y + Settings.CELLS_SIZE;
                    pointR4.Y = pointR4.Y + Settings.CELLS_SIZE;
                }
                else
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
            }

            pointL1.X = pointL4.X;
            pointL4.X = points[1].X;
            pointL1.Y = pointL4.Y;
            pointL2.Y = pointL3.Y;
            pointL3.Y = points[1].Y;
            pointL4.Y = points[1].Y;

            Point[] pointsLeft2 = { pointL1, pointL2, pointL3, pointL4 };

            field.FillPolygon(Settings.Instance.LinesBrush, pointsLeft2);

            for (int a = 0;
                ((int)((Math.Cos(4 * (Math.PI / 3)) * RadiusOutCircle) + x0 + 2 + a) * Settings.CELLS_SIZE) <=
                ((int)((Math.Cos(5 * (Math.PI / 3)) * RadiusOutCircle) + x0) * Settings.CELLS_SIZE); a++)
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

            field.FillPolygon(Settings.Instance.LinesBrush, pointsRight2);

        }

        //TODO: Релизовать
        public void drawSpiral()
        {
        }

        public int RadiusOutCircle
        {
            get => radiusOutCircle;
            set
            {
                radiusOutCircle = value;
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
