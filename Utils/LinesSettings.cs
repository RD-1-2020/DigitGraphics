using System;
using System.Drawing;

namespace DigitGraphics.Utils
{
     class LinesSettings
    {
        private static readonly Lazy<LinesSettings> instanceHolder =
            new Lazy<LinesSettings>(() => new LinesSettings());

        public static LinesSettings Instance
        {
            get { return instanceHolder.Value; }
        }

        public static int CELLS_SIZE = 20;

        private static Pen _cellsColor = new Pen(Color.Black);

        private static Color _cdaColor = Color.FromArgb(70, Color.Chocolate);

        private static Color _brezColor = Color.FromArgb(70, Color.Aqua);

        private static Pen _normalColor = new Pen(Color.DeepPink);

        private static SolidBrush _cdaBrush = new SolidBrush(_cdaColor);

        private static SolidBrush _brezBrush = new SolidBrush(_brezColor);

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
    }
}
