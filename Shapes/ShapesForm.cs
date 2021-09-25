using System.Drawing;
using System.Windows.Forms;
using DigitGraphics.Utils;

namespace DigitGraphics.Shapes
{
    public partial class ShapesForm : Form
    {
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
    }
}
