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

        public FormRadius()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (!Int32.TryParse(tbRadius.Text, out _radius))
            {
                MessageBox.Show("Вы ввели некорректные данные, повторите ввод");
                return;
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

    }
}
