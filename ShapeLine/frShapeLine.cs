using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DigitGraphics.Properties;
using DigitGraphics.Utils;
using Settings = DigitGraphics.Utils.Settings;

namespace DigitGraphics.ShapeLine
{
    public partial class frShapeLine : Form
    {
        public frShapeLine()
        {
            InitializeComponent();
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            int fieldWidth = pbMain.ClientSize.Width;
            int fieldHeight = pbMain.ClientSize.Height;

            DrawTools.drawField(e.Graphics, fieldWidth, fieldHeight);
        }

        private void frShapeLine_Load(object sender, EventArgs e)
        {

        }

        private void rbLine_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
