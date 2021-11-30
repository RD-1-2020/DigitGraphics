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
        private float rotationY = 0.0f;
        private float rotationZ = 0.0f;
        private float zoom = 1.0f;
        

        public RGR()
        {
            InitializeComponent();
        }
      
        private void glControl_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL gl = glControl.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT); // очистка буфера цвета и глубины
            gl.LoadIdentity(); // единичная матрица
            gl.PushMatrix();

            gl.Rotate(rotationX, 1.0f, 0.0f, 0.0f);
            gl.Rotate(rotationY, 0.0f, 1.0f, 0.0f);
            gl.Rotate(rotationZ, 0.0f, 0.0f, 1.0f);

            gl.Scale(zoom, zoom, zoom);

            gl.Begin(OpenGL.GL_TRIANGLES);

            // первая грань
            gl.Color(0.98f, 0.74f, 0.1f); 

            gl.Vertex(0.0f, 3.5f, 1.0f);
            gl.Vertex(-2.0f, 0.0f, 0.0f);
            gl.Vertex(2.0f, 0.0f, 0.0f);

            // вторая плоскость
            gl.Color(1f, 0.63f, 0.48f);

            gl.Vertex(2.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 3.5f, 1.0f);
            gl.Vertex(0.0f, 0.0f, 3.5f);

            // третья плоскость
            gl.Color(0.98f, 0.85f, 0.75f);

            gl.Vertex(-2.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 3.5f, 1.0f);
            gl.Vertex(0.0f, 0.0f, 3.5f);

            //четвертая плоскость
            gl.Color(0.88f, 0.65f, 0.5f);

            gl.Vertex(2.0f, 0.0f, 0.0f);
            gl.Vertex(-2.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 0.0f, 3.5f);

            gl.End();
            gl.PopMatrix();
            gl.Flush();
        }

        private void glControl_MouseDown(object sender, MouseEventArgs e)
        { // после клика мыши крутится фигура
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 161, 2, 0);
            }
        }

        private void glControl_Resized(object sender, EventArgs e)
        {
            OpenGL gl = glControl.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION); // матрица проекции
            gl.LoadIdentity();

            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);

            // устанавливаем камеру 
            gl.LookAt(2, 6, -7,    // позиция камеры
                0, 1, 0,     // куда мы смотрим
                0, 1, 0);    // верх камеры

            gl.MatrixMode(OpenGL.GL_MODELVIEW); // модель отображения
        }

        private void glControl_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = glControl.OpenGL;
            gl.ClearColor(0.0f, 0.0f, 0.0f, 0); // цвет фона 
        }

        private void glControl_KeyDown(object sender, KeyEventArgs e)
        { // вращение
            if (e.KeyCode == Keys.W) rotationX += 1.5f;
            if (e.KeyCode == Keys.S) rotationX -= 1.5f;
            if (e.KeyCode == Keys.A) rotationY -= 1.5f;
            if (e.KeyCode == Keys.D) rotationY += 1.5f;

            if (e.KeyCode == Keys.Q && zoom > 0.4f) zoom -= 0.2f;
            if (e.KeyCode == Keys.E && zoom < 1.8f) zoom += 0.2f;
        }

        private void button_close_Click(object sender, EventArgs e)
        { // закрыть форму
            this.Close();
        }
    }
}
