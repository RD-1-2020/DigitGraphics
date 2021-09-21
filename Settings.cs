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

        public static int CELLS_SIZE = 20;

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

        private static Color _cdaColor = Color.FromArgb(70, Color.Chocolate);

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

        private static SolidBrush _cdaBrush = new SolidBrush(Settings.Instance.CDAColor);

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

        private static Color _brezColor = Color.FromArgb(70, Color.Aqua);

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

        private static SolidBrush _brezBrush = new SolidBrush(Settings.Instance.BrezColor);

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
