using System;
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

        //TODO: Релизовать
        public void drawLines()
        {
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
