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
    public partial class FormModalRadiusDialog : Form
    {
        public FormModalRadiusDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
