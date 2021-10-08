using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitGraphics.Shapes
{
    public partial class FormRadius : Form
    {
        private Int32 _radius;

        private Int32 _holeSize;

        public FormRadius(bool isRad)
        {
            InitializeComponent();
            if (isRad == false)
            {
                tbRadius.Text = "Введите размер отверстия";
                lb1.Text = "S:";
                this.Text = "Ввод размера отверстия";
            }
            else
            {
                tbRadius.Text = "Введите радиус описанной окружности";
                lb1.Text = "R:";
                this.Text = "Ввод радиуса описанной окружности";
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (lb1.Text=="R:")
            {
                if (!Int32.TryParse(tbRadius.Text, out _radius))
                {
                    MessageBox.Show("Вы ввели некорректные данные, повторите ввод");
                    return;
                }
            }
            else
            {
                if (!Int32.TryParse(tbRadius.Text, out _holeSize))
                {
                    MessageBox.Show("Вы ввели некорректные данные, повторите ввод");
                    return;
                }
            }

            if (tbRadius.Text != null)
            {
                DialogResult = DialogResult.OK;
            }
        }

        public int Radius
        {
            get => _radius;
            set => _radius = value;
        }

        public int HoleSize
        {
            get => _holeSize;
            set => _holeSize = value;
        }
    }
}
