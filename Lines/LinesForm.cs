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

        public void drawField(Graphics field)
        {
            field.Clear(Color.White);
            for (int CellsNumber = 0; CellsNumber < 29; CellsNumber++)
            {
                field.DrawLine(Settings.Instance.CellsColor, CellsNumber * Settings.CELLS_SIZE, pbMainFrame.ClientSize.Height, CellsNumber * Settings.CELLS_SIZE, 0);
                field.DrawLine(Settings.Instance.CellsColor, pbMainFrame.ClientSize.Width, CellsNumber * Settings.CELLS_SIZE, 0, CellsNumber * Settings.CELLS_SIZE);
            }
        }

        private void pbMainFrame_Paint(object sender, PaintEventArgs e)
        {
            drawField(e.Graphics);
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
