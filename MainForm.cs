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

        public MainForm()
        {
            InitializeComponent();
        }

        private void pbMainFrame_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphicCells = e.Graphics;
            graphicCells.Clear(Color.White);
            for (int CellsNumber = 0; CellsNumber < 29; CellsNumber++)
            {
                graphicCells.DrawLine(Settings.Instance.CellsColor, CellsNumber * Settings.CELLS_SIZE, pbMainFrame.ClientSize.Height, CellsNumber * Settings.CELLS_SIZE, 0);
                graphicCells.DrawLine(Settings.Instance.CellsColor, pbMainFrame.ClientSize.Width, CellsNumber * Settings.CELLS_SIZE, 0, CellsNumber * Settings.CELLS_SIZE);
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
                graphic.DrawLine(Settings.Instance.NormalLineColor, Convert.ToInt32(tbx1.Text) * Settings.CELLS_SIZE, Convert.ToInt32(tby1.Text) * Settings.CELLS_SIZE,
                    Convert.ToInt32(tbx2.Text) * Settings.CELLS_SIZE,
                    Convert.ToInt32(tby2.Text) * Settings.CELLS_SIZE);
            } catch (FormatException ex)
            {
                MessageBox.Show("Неверно заданы координаты.\nВведите целое число", "Ошибка!", 0, MessageBoxIcon.Exclamation);

                Logger.error("Пользователь ввёл неверные данные в поля с точками", ex);
            }
        }

        public void drawBrez(Graphics graphicBrez)
        {
            if (!cbBrez.Checked)
            {
                return;
            }

            try
            {

                int deltaX = Convert.ToInt32(tbx2.Text) * Settings.CELLS_SIZE - Convert.ToInt32(tbx1.Text) * Settings.CELLS_SIZE;
                int deltaY = Convert.ToInt32(tby2.Text) * Settings.CELLS_SIZE - Convert.ToInt32(tby1.Text) * Settings.CELLS_SIZE;
                int absDeltaX = Math.Abs(deltaX);
                int absDeltaY = Math.Abs(deltaY);

                int accretion = 0;

                if (absDeltaX >= absDeltaY)
                {
                    int y = Convert.ToInt32(tby1.Text) * Settings.CELLS_SIZE;
                    int direction = deltaY != 0 ? (deltaY > 0 ? 1 : -1) : 0;
                    for (int x = Convert.ToInt32(tbx1.Text) * Settings.CELLS_SIZE; deltaX > 0 ? x <= Convert.ToInt32(tbx2.Text) * Settings.CELLS_SIZE : x >= Convert.ToInt32(tbx2.Text) * Settings.CELLS_SIZE; )
                    {
                        graphicBrez.FillRectangle(Settings.Instance.BrezBrush, x, y, Settings.CELLS_SIZE, Settings.CELLS_SIZE);
                        accretion += absDeltaY;

                        if (accretion >= absDeltaX)
                        {
                            accretion -= absDeltaX;
                            y += direction * Settings.CELLS_SIZE;
                        }
                        if (deltaX > 0)
                        {
                            x += Settings.CELLS_SIZE;
                        }
                        else x -= Settings.CELLS_SIZE;
                    }
                }
                else
                {
                    int x = Convert.ToInt32(tbx1.Text) * Settings.CELLS_SIZE;
                    int direction = deltaX != 0 ? (deltaX > 0 ? 1 : -1) : 0;
                    for (int y = Convert.ToInt32(tby1.Text) * Settings.CELLS_SIZE; deltaY > 0 ? y <= Convert.ToInt32(tby2.Text) * Settings.CELLS_SIZE : y >= Convert.ToInt32(tby2.Text) * Settings.CELLS_SIZE; )
                    {
                        graphicBrez.FillRectangle(Settings.Instance.BrezBrush, x, y, Settings.CELLS_SIZE, Settings.CELLS_SIZE);
                        accretion += absDeltaX;
                        if (accretion >= absDeltaY)
                        {
                            accretion -= absDeltaY;
                            x += direction * Settings.CELLS_SIZE;
                        }

                        if (deltaY > 0)
                        {
                            y += Settings.CELLS_SIZE;
                        }
                        else y -= Settings.CELLS_SIZE;
                    }
                }
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

            using (Graphics graphicBrez = pbMainFrame.CreateGraphics())
            {
                drawBrez(graphicBrez);
            }
        }
    }
}
