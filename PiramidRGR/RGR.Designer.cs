
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
            this.exit = new System.Windows.Forms.Button();
            this.manual = new System.Windows.Forms.Label();
            this.manual2 = new System.Windows.Forms.Label();
            this.manual_picture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.manual_picture)).BeginInit();
            this.SuspendLayout();
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Red;
            this.exit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exit.Location = new System.Drawing.Point(731, 8);
            this.exit.Margin = new System.Windows.Forms.Padding(2);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(33, 24);
            this.exit.TabIndex = 0;
            this.exit.Text = "X";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // manual
            // 
            this.manual.AutoSize = true;
            this.manual.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.manual.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manual.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.manual.Location = new System.Drawing.Point(625, 60);
            this.manual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.manual.Name = "manual";
            this.manual.Size = new System.Drawing.Size(97, 29);
            this.manual.TabIndex = 1;
            this.manual.Text = "Manual ";
            // 
            // manual2
            // 
            this.manual2.AutoSize = true;
            this.manual2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manual2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.manual2.Location = new System.Drawing.Point(628, 97);
            this.manual2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.manual2.Name = "manual2";
            this.manual2.Size = new System.Drawing.Size(69, 85);
            this.manual2.TabIndex = 2;
            this.manual2.Text = "W - up\r\nS - down\r\nA - left\r\nD - right\r\nR - return\r\n";
            // 
            // manual_picture
            // 
            this.manual_picture.Image = ((System.Drawing.Image)(resources.GetObject("manual_picture.Image")));
            this.manual_picture.Location = new System.Drawing.Point(571, 57);
            this.manual_picture.Margin = new System.Windows.Forms.Padding(2);
            this.manual_picture.Name = "manual_picture";
            this.manual_picture.Size = new System.Drawing.Size(57, 32);
            this.manual_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.manual_picture.TabIndex = 3;
            this.manual_picture.TabStop = false;
            // 
            // RGR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(772, 415);
            this.Controls.Add(this.manual_picture);
            this.Controls.Add(this.manual2);
            this.Controls.Add(this.manual);
            this.Controls.Add(this.exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RGR";
            this.Text = "RGR";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RGR_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.manual_picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label manual;
        private System.Windows.Forms.Label manual2;
        private System.Windows.Forms.PictureBox manual_picture;
    }
}