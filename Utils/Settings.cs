using System;
using System.Drawing;

namespace DigitGraphics.Utils
{
     class Settings
    {
        private static readonly Lazy<Settings> instanceHolder =
            new Lazy<Settings>(() => new Settings());

        public static Settings Instance
        {
            get { return instanceHolder.Value; }
        }

        public static int CELLS_SIZE = 20;

        public static int SPIRAL_SIZE = 3;

        private static Pen _cellsColor = new Pen(Color.Black);

        private static Color _cdaColor = Color.FromArgb(70, Color.Chocolate);

        private static Color _brezColor = Color.FromArgb(70, Color.Aqua);

        private static Color _linesColor = Color.FromArgb(200, Color.LightSalmon);

        private static Pen _normalColor = new Pen(Color.DeepPink);

        private static Pen _normLineColor = new Pen(Color.RoyalBlue, 2);

        private static SolidBrush _cdaBrush = new SolidBrush(_cdaColor);

        private static SolidBrush _brezBrush = new SolidBrush(_brezColor);

        private static SolidBrush _linesBrush = new SolidBrush(_linesColor);

        private static SolidBrush _brushTriangle1 = new SolidBrush(Color.BlueViolet);
        private static SolidBrush _brushTriangle2 = new SolidBrush(Color.YellowGreen);
        private static SolidBrush _brushTriangle3 = new SolidBrush(Color.HotPink);
        private static SolidBrush _brushTriangle4 = new SolidBrush(Color.SkyBlue);

        public SolidBrush brushTriangle1
        {
            get
            {
                return _brushTriangle1;
            }
            set
            {
                _brushTriangle1 = value;
            }
        }

        public SolidBrush brushTriangle2
        {
            get
            {
                return _brushTriangle2;
            }
            set
            {
                _brushTriangle2 = value;
            }
        }
        public SolidBrush brushTriangle3
        {
            get
            {
                return _brushTriangle3;
            }
            set
            {
                _brushTriangle3 = value;
            }
        }
        public SolidBrush brushTriangle4
        {
            get
            {
                return _brushTriangle4;
            }
            set
            {
                _brushTriangle4 = value;
            }
        }

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

        public Color CDAColor
        {
            get
            {
                return _cdaColor;
            }
            set
            {
                _cdaColor = value;
            }
        }

        public SolidBrush CDABrush
        {
            get
            {
                return _cdaBrush;
            }
            set
            {
                _cdaBrush = value;
            }
        }

        

        public Color BrezColor
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

        public SolidBrush BrezBrush
        {
            get
            {
                return _brezBrush;
            }
            set
            {
                _brezBrush = value;
            }
        }

        public Pen NormalColor {
            get
            {
                return _normalColor;
            }
            set
            {
                _normalColor = value;
            }
        }

        public Pen NormLineColor
        {
            get
            {
                return _normLineColor;
            }
            set
            {
                _normLineColor = value;
            }
        }

        public Color LinesColor
        {
            get
            {
                return _linesColor;
            }
            set
            {
                _linesColor = value;
            }
        }

        public SolidBrush LinesBrush
        {
            get
            {
                return _linesBrush;
            }
            set
            {
                _linesBrush = value;
            }
        }
    }
}
