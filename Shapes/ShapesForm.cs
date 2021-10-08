using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DigitGraphics.Properties;
using DigitGraphics.Utils;
using Settings = DigitGraphics.Utils.Settings;

namespace DigitGraphics.Shapes
{
    public partial class ShapesForm : Form
    {
        private Shape shape;

        private bool isRad = true;

        public ShapesForm()
        {
            InitializeComponent();
        }

        private void btDraw_Click(object sender, System.EventArgs e)
        {
            if (shape == null)
            {
                MessageBox.Show("Сначала выполните действия указанные в инструкции!");
                return;
            }

            Refresh();

            if (cbNormal.Checked)
            {
                shape.drawNormal();
            }

            if (cbHole.Checked)
            {
                shape.drawHole(shape.Hole);
            }

            if (cbSpiral.Checked)
            {
                shape.drawSpiral();
            }

            if (cbLine.Checked)
            {
                shape.drawLines();
            }
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            int fieldWidth = pbMain.ClientSize.Width;
            int fieldHeight = pbMain.ClientSize.Height;

            DrawTools.drawField(e.Graphics, fieldWidth, fieldHeight);
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRad)
            {
                FormRadius radiusForm = new FormRadius(isRad);
                DialogResult formDialogResult = radiusForm.ShowDialog();
                shape = new Shape(
                    (int) e.X / Settings.CELLS_SIZE + 1,
                    (int) e.Y / Settings.CELLS_SIZE + 1,
                    pbMain.CreateGraphics()
                );

                if (formDialogResult == DialogResult.OK)
                {
                    shape.RadiusOutCircle = radiusForm.Radius;
                }

                pgShapeSettings.SelectedObject = shape;
                btDraw_Click(sender, EventArgs.Empty);
                isRad = !isRad;
            }
            else
            {
                FormRadius holeForm = new FormRadius(isRad);
                DialogResult formDialogResult = holeForm.ShowDialog();
                if (formDialogResult == DialogResult.OK)
                {
                    shape.Hole = holeForm.HoleSize;
                }
                btDraw_Click(sender,EventArgs.Empty);
                isRad = !isRad;
            }
        }

        private void pgShapeSettings_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            btDraw_Click(s, EventArgs.Empty);
        }
    }
}
