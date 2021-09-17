using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitGraphics
{
     class Settings
    {
        private static Pen _normalLinePen = new Pen(Color.DeepPink);

        public static Pen normalLinePen {
            get
            {
                return _normalLinePen;
            }
            set
            {
                _normalLinePen = value;
            }
        }
    }
}
