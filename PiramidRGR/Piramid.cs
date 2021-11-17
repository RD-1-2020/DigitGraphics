using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DigitGraphics.Utils;

namespace DigitGraphics.PiramidRGR
{
    class Piramid
    {
        private Graphics field;
        public Piramid(Graphics field)
        {
            this.field = field;
        }
        public void drawPiramid()
        {
            float Winth = 772;
            float Height = 415;
            Point[] pTriangle1 = new Point[3];
            for (int i = 0; i < 3; i++)
            {
                pTriangle1[i] =
                    new Point((int)((Math.Cos(2 * i * Math.PI / 3 + 3 * Math.PI / 2) * 100) + Winth / 2),
                        (int)((Math.Sin(2 * i * Math.PI / 3 + 3 * Math.PI / 2) * 100) + Height / 2));
            }
            Point[] pTriangle2 = { pTriangle1[0], pTriangle1[1], new Point((int)(Winth/2), (int)(Height/2))};
            Point[] pTriangle3 = { pTriangle1[1], pTriangle1[2], new Point((int)(Winth / 2), (int)(Height / 2)) };
            Point[] pTriangle4 = { pTriangle1[2], pTriangle1[0], new Point((int)(Winth / 2), (int)(Height / 2)) };            
            
            field.FillPolygon(Settings.Instance.brushTriangle1, pTriangle1);
            field.FillPolygon(Settings.Instance.brushTriangle2, pTriangle2);
            field.FillPolygon(Settings.Instance.brushTriangle3, pTriangle3);
            field.FillPolygon(Settings.Instance.brushTriangle4, pTriangle4);
            //field.DrawPolygon(Settings.Instance.NormalColor, pTriangle1);              //чтобы посмотреть на скелет пирамиды
            //field.DrawPolygon(Settings.Instance.NormalColor, pTriangle2);
            //field.DrawPolygon(Settings.Instance.NormalColor, pTriangle3);
            //field.DrawPolygon(Settings.Instance.NormalColor, pTriangle4);
        }
    }
}
