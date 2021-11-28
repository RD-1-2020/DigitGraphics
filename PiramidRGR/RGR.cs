using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitGraphics.Utils;
using SharpGL;
using Settings = DigitGraphics.Utils.Settings;

namespace DigitGraphics.PiramidRGR
{
    public partial class RGR : Form
    {
        [DllImport("user32")]
        private static extern bool ReleaseCapture();

        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wp, int lp);

        private float rotationX = 0.0f;
        private float rotationZ = 0.0f;

        public RGR()
        {
            InitializeComponent();
        }
        private void exit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void glControl_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            //  Возьмём OpenGL объект
            OpenGL gl = glControl.OpenGL;

            //  Очищаем буфер цвета и глубины
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //  Загружаем единичную матрицу
            gl.LoadIdentity();

            gl.Rotate(rotationX, 1.0f, 0.0f, 0.0f);
            gl.Rotate(rotationZ, 0.0f, 0.0f, 1.0f);

            // рисуем крышу
            gl.Begin(OpenGL.GL_TRIANGLES);

            //1 плоскость
            gl.Color(1f, 0.0f, 0.0f); // здесь задаём цвет для каждой плоскости

            gl.Vertex(0.0f, 2.0f, 0.0f);
            gl.Vertex(-2.0f, 0.0f, 0.0f);
            gl.Vertex(2.0f, 0.0f, 0.0f);

            //вторая плоскость
            gl.Color(0f, 1f, 0.0f);

            gl.Vertex(2.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 2.0f, 0.0f);
            gl.Vertex(0.0f, 0.0f, 2.0f);

            //третья плоскость
            gl.Color(0f, 0f, 1f);

            gl.Vertex(-2.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 2.0f, 0.0f);
            gl.Vertex(0.0f, 0.0f, 2.0f);

            //четвертая плоскость
            gl.Color(1f, 0.0f, 1f);

            gl.Vertex(2.0f, 0.0f, 0.0f);
            gl.Vertex(-2.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 0.0f, 2.0f);

            gl.End();
        }

        private void glControl_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 161, 2, 0);
            }
        }

        private void glControl_Resized(object sender, EventArgs e)
        {
            //  Возьмём OpenGL объект
            OpenGL gl = glControl.OpenGL;

            //  Зададим матрицу проекции
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Единичная матрица для последующих преобразований
            gl.LoadIdentity();

            //  Преобразование
            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);

            //  Данная функция позволяет установить камеру и её положение
            gl.LookAt(5, 6, -7,    // Позиция самой камеры
                0, 1, 0,     // Направление, куда мы смотрим
                0, 1, 0);    // Верх камеры

            //  Зададим модель отображения
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        private void glControl_OpenGLInitialized(object sender, EventArgs e)
        {
            //  Возьмём OpenGL объект
            OpenGL gl = glControl.OpenGL;

            //  Фоновый цвет по умолчанию (в данном случае цвет голубой)
            gl.ClearColor(0.1f, 0.5f, 1.0f, 0);
        }

        private void glControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                rotationZ += 1.5f;
            }

            if (e.KeyCode == Keys.S)
            {
                rotationZ -= 1.5f;
            }

            if (e.KeyCode == Keys.A)
            {
                rotationX += 1.5f;
            }
            if (e.KeyCode == Keys.D)
            {
                rotationX -= 1.5f;
            }
        }
    }
}
