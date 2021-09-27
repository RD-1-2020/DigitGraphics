using System;
using System.Drawing;
using System.Windows.Forms;
using DigitGraphics.Properties;
using DigitGraphics.Utils;

namespace DigitGraphics.Shapes
{
    public partial class ShapesForm : Form
    {
        private Shape shape;

        public ShapesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {

        }

        private void ShapesForm_Load(object sender, System.EventArgs e)
        {
            
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            int fieldWidth = pbMain.ClientSize.Width;
            int fieldHeight = pbMain.ClientSize.Height;

            DrawTools.drawField(e.Graphics, fieldWidth, fieldHeight);
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            FormModalRadiusDialog radiusForm = new FormModalRadiusDialog();
            DialogResult formDialogResult = radiusForm.ShowDialog();
            shape = new Shape((int)e.X, (int)e.Y, pbMain.CreateGraphics());

            if (formDialogResult == DialogResult.OK)
            {
                int RadiusInCircle = Convert.ToInt32(radiusForm.textBox1.Text);

                shape.RadiusInCircle = LinesSettings.CELLS_SIZE * RadiusInCircle;
            }

            shape.drawNormal();
        }
    }
}
