using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitGraphics.Lines;
using DigitGraphics.ShapeLine;
using DigitGraphics.Shapes;

namespace DigitGraphics
{
    public partial class MenuForm : Form
    {
        private Dictionary<String,Form> formsList;

        public MenuForm()
        {
            InitializeComponent();
        }

        private void updateCBItems()
        {
            formsList = new Dictionary<string, Form>();
            formsList.Add("Отрисовка линий", new LinesForm());
            formsList.Add("Отрисовка фигур", new ShapesForm());
            formsList.Add("Отрисовка фигуры с линиями", new frShapeLine());
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            updateCBItems();

            cbFormsList.Items.AddRange(formsList.Keys.ToArray());
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            updateCBItems();
            if (cbFormsList.SelectedItem == null)
            {
                MessageBox.Show("Сначала выберите форму в выпадающем списке слева");
                return;
            }

            Form getForm;
            formsList.TryGetValue(cbFormsList.SelectedItem.ToString(), out getForm);
            getForm.Show();

            this.Hide();
            getForm.Closed += GetForm_Closed;
        }

        private void GetForm_Closed(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
