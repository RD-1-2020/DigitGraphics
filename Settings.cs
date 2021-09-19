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
        private static readonly Lazy<Settings> instanceHolder =
            new Lazy<Settings>(() => new Settings());

        public static Settings Instance
        {
            get { return instanceHolder.Value; }
        }

        private static Pen _cellsColor = new Pen(Color.Black);

        public Pen CellsColor {
            get
            {
                return _cellsColor;
            }
            set
            {
                _cellsColor = value;
            }
        }

        private static Pen _brezColor = new Pen(Color.Aqua);

        public Pen BrezColor
        {
            get
            {
                return _brezColor;
            }
            set
            {
                _brezColor = value;
            }
        }

        private static Pen _normalLineColor = new Pen(Color.DeepPink);

        public Pen NormalLineColor {
            get
            {
                return _normalLineColor;
            }
            set
            {
                _normalLineColor = value;
            }
        }
    }
}
