using System;
using System.Drawing;
using System.Windows.Forms;
using DigitGraphics.Utils;

namespace DigitGraphics.Lines
{
    public partial class LinesForm : Form
    {
        private Point fPoint;

        private Point scPoint;

        public LinesForm()
        {
            InitializeComponent();
        }

        private void pbMainFrame_Paint(object sender, PaintEventArgs e)
        {
            DrawTools.drawField(e.Graphics, pbMainFrame.ClientSize.Width, pbMainFrame.ClientSize.Height);
        }

        private void btDraw_Click(object sender, EventArgs e)
        {
            Refresh();
            try
            {
                fPoint = new Point(Convert.ToInt32(tbx1.Text), Convert.ToInt32(tby1.Text));

                scPoint = new Point(Convert.ToInt32(tbx2.Text), Convert.ToInt32(tby2.Text));
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Проверьте данные в полях с точками");

                Logger.error("В полях точек невалидные данные", ex);

                return;
            }

            

            using (Graphics field = pbMainFrame.CreateGraphics())
            {
                Line line = new Line(fPoint, scPoint, field);

                if (cbline.Checked)
                {
                    line.drawNormalLine();
                }

                if (cbBrez.Checked)
                {
                    line.drawBrezLine();
                }

                if (cbCDA.Checked)
                {
                    line.drawCdaLine();
                }
            }
        }
    }
}
