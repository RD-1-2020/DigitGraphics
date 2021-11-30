using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitGraphics.Utils;
using Settings = DigitGraphics.Utils.Settings;

namespace DigitGraphics.PiramidRGR
{
    public partial class RgrForm : Form
    {
        private Piramid shape;
        public RgrForm()
        {
            InitializeComponent();
        }
        private void exit_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void RGR_Paint(object sender, PaintEventArgs e)
        {
            shape = new Piramid(e.Graphics);
            shape.drawPiramid();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RgrForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "RgrForm";
            this.Load += new System.EventHandler(this.RGR_Load);
            this.ResumeLayout(false);

        }

        private void RGR_Load(object sender, EventArgs e)
        {

        }
    }
}
