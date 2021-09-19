using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitGraphics
{
    public partial class MainForm : Form
    {
        private static int CELLS_SIZE = 20;

        public MainForm()
        {
            InitializeComponent();
        }

        private void pbMainFrame_Paint(object sender, PaintEventArgs e)
        {
            //Graphics graphicCells = pbMainFrame.CreateGraphics();
            Graphics graphicCells = e.Graphics;
            graphicCells.Clear(Color.White);
            for (int CellsNumber = 0; CellsNumber < 29; CellsNumber++)
            {
                graphicCells.DrawLine(Settings.Instance.CellsColor, CellsNumber * CELLS_SIZE, 360, CellsNumber * CELLS_SIZE, 0);
                graphicCells.DrawLine(Settings.Instance.CellsColor, 560, CellsNumber * CELLS_SIZE, 0, CellsNumber * CELLS_SIZE);
            }
        }

        public void drawNormalLine(Graphics graphic)
        {
            if (!cbline.Checked)
            {
                return;
            }

            try
            {
                graphic.DrawLine(Settings.Instance.NormalLineColor, Convert.ToInt32(tbx1.Text) * CELLS_SIZE , Convert.ToInt32(tby1.Text) * CELLS_SIZE,
                    Convert.ToInt32(tbx2.Text) * CELLS_SIZE,
                    Convert.ToInt32(tby2.Text) * CELLS_SIZE);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Неверно заданы координаты.\nВведите целое число", "Ошибка!", 0, MessageBoxIcon.Exclamation);

                Logger.error("Пользователь ввёл неверные данные в поля с точками", ex);
            }
        }

        private void btDraw_Click(object sender, EventArgs e)
        {
            Refresh();

            

            //TODO: Добавить более точное указание, где именно пользователь ошибся(с логированием (class Logger))
            using (Graphics graphic = pbMainFrame.CreateGraphics())
            {
                drawNormalLine(graphic);
            }

            if (!cbBrez.Checked)
            {
                return;
            }

            using (Graphics graphicBrez = pbMainFrame.CreateGraphics())
            {
                SolidBrush FillBrezColor = new SolidBrush (Color.Aqua);
                try
                {
                    int X = Convert.ToInt32(tbx1.Text);
                    int Y = Convert.ToInt32(tby1.Text);
                    int Px = Convert.ToInt32(tbx2.Text) - Convert.ToInt32(tbx1.Text);
                    int Py = Convert.ToInt32(tby2.Text) - Convert.ToInt32(tby1.Text);
                    int E = 2 * Py - Px;
                    int i = Px;
                    //graphicBrez.DrawRectangle(Settings.Instance.BrezColor, Convert.ToInt32(tbx1.Text), Convert.ToInt32(tby1.Text), 20, 20);
                    graphicBrez.FillRectangle(FillBrezColor, Convert.ToInt32(tbx1.Text), Convert.ToInt32(tby1.Text), 20, 20);
                    //while (i = i - 1)
                    //{
                    //    if (E >= 0)
                    //    {
                    //        X = X + 1;
                    //        Y = Y + 1;
                    //        E = E + 2 * (Py - Px);
                    //    }
                    //    else
                    //        X = X + 1;
                    //    E = E + 2 * Py;
                    //    graphicBrez.DrawRectangle(Settings.Instance.BrezColor, Convert.ToInt32(tbx1.Text), Convert.ToInt32(tby1.Text), 20, 20);
                    //    graphicBrez.FillRectangle(FillBrezColor, Convert.ToInt32(tbx1.Text), Convert.ToInt32(tby1.Text), 20, 20);
                    //}
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Неверно заданы координаты.\nВведите целое число", "Ошибка!", 0, MessageBoxIcon.Exclamation);

                    Logger.error("Пользователь ввёл неверные данные в поля с точками", ex);
                }
            }
        }
    }
}
