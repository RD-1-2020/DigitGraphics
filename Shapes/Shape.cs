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
        private int radiusInCircle;

        private int x0;

        private int y0;

        private Graphics field;
        
        
        public Shape(Graphics field)
        {
            this.field = field;
        }

        public Shape(int x0, int y0, Graphics field)
        {
            this.x0 = x0;
            this.y0 = y0;
            this.field = field;
        }

        public void drawNormal()
        {
            List<Point> points = new List<Point>();

            for (int i = 1; i < 7; i++)
            {
                points.Add(new Point((int)(Math.Cos(i*Math.PI/3)* radiusInCircle) + x0, (int)(Math.Sin(i * Math.PI / 3) * radiusInCircle) + y0));
            }
            field.DrawPolygon(LinesSettings.Instance.NormalColor,points.ToArray());
        }

        //TODO: Релизовать
        public void drawLines()
        {
        }

        //TODO: Релизовать
        public void drawSpiral()
        {
        }

        public int RadiusInCircle
        {
            get => radiusInCircle;
            set => radiusInCircle = value;
        }

        public int X0
        {
            get => x0;
            set => x0 = value;
        }

        public int Y0
        {
            get => y0;
            set => y0 = value;
        }
    }
}
