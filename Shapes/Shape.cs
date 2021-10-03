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

        private byte[][] map;

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

        private void drawCircleOnMap()
        {
            if (radiusOut < 0)
            {
                return;
            }

            int d = 2 * radiusOut;

            map = new byte[d][];

            for (var i = 0; i < map.Length; i++)
            {
                map[i] = new byte[d];
            }

            for (int x = 0; x < d; x++)
            {
                for (int rad = 0; rad < radiusOut; rad++)
                {
                    try
                    {
                        int tmpy = (int) Math.Sqrt(rad * rad - (x - radiusOut) * (x - radiusOut)) + radiusOut;
                        map[x][tmpy] = 1;
                        tmpy = - (int)Math.Sqrt(rad * rad - (x - radiusOut) * (x - radiusOut)) + radiusOut;
                        map[x][tmpy] = 1;
                    } catch (Exception inored){}
                }
            }

            for (int x = 0; x < d; x++)
            {
                int lastIndex = -1;
                for (int y = 0; y < d; y++)
                {
                    if (map[x][y] == 1)
                    {
                        lastIndex = d - y;

                        for (int y1 = y; y1 < lastIndex; y1++)
                        {
                            map[x][y1] = 1;
                        }
                        break;
                    }
                }
            }

            foreach (byte[] b in map)
            {
                foreach (byte b1 in b)
                {
                    Debug.Write(b1 == 1 ? "*" : " ");
                }
                Debug.Write("\n");
            }
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
            float[] linekb = new float[12];
            for (int i = 0, j=0; i < 11; i+=2)
            {
                linekb[i] = (points[(j + 1)%6].Y - points[j].Y) / (points[(j + 1)%6].X - points[j].X);
                linekb[i+1] = -(points[j].X * points[(j + 1)%6].Y - points[(j + 1)%6].X * points[j].Y)/ (points[(j + 1)%6].X - points[j].X);
                j++;
            }

            while (x1 > (x0scale - (radiusOut * (Settings.CELLS_SIZE-1))) && 
                   y1 > (y0scale - (radiusOut * Settings.CELLS_SIZE)) &&
                   x1 < (x0scale + (radiusOut * Settings.CELLS_SIZE)) &&
                   y1 < (y0scale + (radiusOut * Settings.CELLS_SIZE)))
            {
                for (int i = 0; i < range; i++)
                {
                    if (x1 * linekb[0] - linekb[1] - y1 < 0 &&
                        x1 * linekb[2] - linekb[3] - y1 < 0 &&
                        x1 * linekb[4] - linekb[5] - y1 > 0 &&
                        x1 * linekb[6] - linekb[7] - y1 > 0 &&
                        x1 * linekb[8] - linekb[9] - y1 > 0 &&
                        x1 * linekb[10] - linekb[11] - y1 < 0)
                    {
                        Thread.Sleep(2);
                        field.FillRectangle(Settings.Instance.ShapeBrush,
                            x1, y1,
                            Settings.SPIRAL_SIZE, Settings.SPIRAL_SIZE);
                    }

                    if (isx)
                    {
                        x1 += Settings.SPIRAL_SIZE * direction;
                    }
                    else
                    {
                        y1 += Settings.SPIRAL_SIZE * direction;
                    }
                }
                isx = isx ? false : true;
                if (even)
                {
                    range++;
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
                new Thread(delegate()
                {
                    drawCircleOnMap();
                }).Start();
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
