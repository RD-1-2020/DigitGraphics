using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DigitGraphics.Properties;
using DigitGraphics.Utils;
using System.Collections.Generic;
using Settings = DigitGraphics.Utils.Settings;
using Shape = DigitGraphics.Shapes.Shape;

namespace DigitGraphics.ShapeLine
{
    public partial class frShapeLine : Form
    {
        private Shape shape;

        private Graphics field;

        private List<Point> linePoints=new List<Point>();
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

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (rbLine.Checked)
            {
                linePoints.Add(e.Location);

                if (linePoints.Count == 2)
                {
                    if (shape==null)
                    {
                        shape = new Shape(pbMain.CreateGraphics());
                    }
                    shape.drawCLine(linePoints);
                    linePoints.Clear();
                }
            }
        }
    }
}
