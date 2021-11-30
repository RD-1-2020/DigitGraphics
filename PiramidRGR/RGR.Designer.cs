
namespace DigitGraphics.PiramidRGR
{
    partial class RGR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RGR));
            this.manual = new System.Windows.Forms.Label();
            this.manual_picture = new System.Windows.Forms.PictureBox();
            this.glControl = new SharpGL.OpenGLControl();
            this.button_close = new System.Windows.Forms.Button();
            this.manual2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.manual_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glControl)).BeginInit();
            this.SuspendLayout();
            // 
            // manual
            // 
            this.manual.AutoSize = true;
            this.manual.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.manual.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manual.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.manual.Location = new System.Drawing.Point(921, 92);
            this.manual.Name = "manual";
            this.manual.Size = new System.Drawing.Size(182, 40);
            this.manual.TabIndex = 1;
            this.manual.Text = "Instruction";
            // 
            // manual_picture
            // 
            this.manual_picture.Image = ((System.Drawing.Image)(resources.GetObject("manual_picture.Image")));
            this.manual_picture.Location = new System.Drawing.Point(849, 92);
            this.manual_picture.Name = "manual_picture";
            this.manual_picture.Size = new System.Drawing.Size(75, 40);
            this.manual_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.manual_picture.TabIndex = 3;
            this.manual_picture.TabStop = false;
            // 
            // glControl
            // 
            this.glControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl.DrawFPS = false;
            this.glControl.Location = new System.Drawing.Point(0, 0);
            this.glControl.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.glControl.Name = "glControl";
            this.glControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.glControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.glControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.glControl.Size = new System.Drawing.Size(1158, 638);
            this.glControl.TabIndex = 4;
            this.glControl.OpenGLInitialized += new System.EventHandler(this.glControl_OpenGLInitialized);
            this.glControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.glControl_OpenGLDraw);
            this.glControl.Resized += new System.EventHandler(this.glControl_Resized);
            this.glControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glControl_KeyDown);
            this.glControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseDown);
            // 
            // button_close
            // 
            this.button_close.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_close.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_close.Location = new System.Drawing.Point(1071, 12);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(75, 39);
            this.button_close.TabIndex = 5;
            this.button_close.Text = "X";
            this.button_close.UseVisualStyleBackColor = false;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // manual2
            // 
            this.manual2.AutoSize = true;
            this.manual2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manual2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.manual2.Location = new System.Drawing.Point(985, 151);
            this.manual2.Name = "manual2";
            this.manual2.Size = new System.Drawing.Size(118, 150);
            this.manual2.TabIndex = 2;
            this.manual2.Text = "W - up\r\nS - down\r\nA - left\r\nD - right\r\nQ - distance\r\nE - zoom\r\n";
            // 
            // RGR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1158, 638);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.manual_picture);
            this.Controls.Add(this.manual2);
            this.Controls.Add(this.manual);
            this.Controls.Add(this.glControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RGR";
            this.Text = "RGR";
            ((System.ComponentModel.ISupportInitialize)(this.manual_picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label manual;
        private System.Windows.Forms.PictureBox manual_picture;
        private SharpGL.OpenGLControl glControl;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Label manual2;
    }
}