using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitGraphics
{
    class Point2
    {
        public Point2()
        {

        }

        public Point2(float x, float y)
        {
            _x = x;
            _y = y;
        }

        private float _x;
        private float _y;

        public float X
        {
            get => _x;
            set => _x = value;
        }

        public float getY()
        {
            return _y;
        }

        public void setY(int _y)
        {
            this._y = _y;
        }

        public static int getDistance(Point2 point1, Point2 point2)
        {
            int tmpX = Convert.ToInt32(point1.X - point2.X);

            int tmpY = Convert.ToInt32(point1.getY() - point2.getY());

            return (int) Math.Sqrt(Convert.ToDouble(tmpX * tmpX + tmpY * tmpY));
        }
    }
}
