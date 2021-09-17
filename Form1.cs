﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void btDraw_Click(object sender, EventArgs e)
        {
            if (!cbline.Checked)
            {
                return;
            }

            using (Graphics graphic = pbMainFrame.CreateGraphics())
            {
                graphic.Clear(Color.White);
                try
                {
                    graphic.DrawLine(Settings.normalLinePen, Convert.ToInt32(tbx1.Text), Convert.ToInt32(tby1.Text),
                        Convert.ToInt32(tbx2.Text),
                        Convert.ToInt32(tby2.Text));
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Неверно заданы координаты.\nВведите целое число", "Ошибка!", 0, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
