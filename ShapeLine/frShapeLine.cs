using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DigitGraphics.Properties;
using DigitGraphics.Utils;
using System.Collections.Generic;
using Settings = DigitGraphics.Utils.Settings;
using Shape = DigitGraphics.Shapes.Shape;
using FormRadius = DigitGraphics.Shapes.FormRadius;

namespace DigitGraphics.ShapeLine
{
    public partial class frShapeLine : Form
    {
        private Shape shape;

        private bool isRad = true;

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




            if (rbShape.Checked)
            {
                FormRadius radiusForm = new FormRadius(isRad);
                DialogResult formDialogResult = radiusForm.ShowDialog();
                shape = new Shape(
                    (int)e.X / Settings.CELLS_SIZE + 1,
                    (int)e.Y / Settings.CELLS_SIZE + 1,
                    pbMain.CreateGraphics()
                    );

                if (formDialogResult == DialogResult.OK)
                {
                    shape.RadiusOutCircle = radiusForm.Radius;
                }    
            
                if (shape == null)
                {
                    MessageBox.Show("Сначала выполните действия указанные в инструкции!");
                    return;
                }

                Refresh(); 
                shape.drawNormal();
            }

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
