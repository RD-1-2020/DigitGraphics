
namespace DigitGraphics
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
            this.exit.Location = new System.Drawing.Point(1097, 12);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(49, 37);
            this.exit.TabIndex = 0;
            this.exit.Text = "X";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // manual
            // 
            this.manual.AutoSize = true;
            this.manual.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.manual.Font = new System.Drawing.Font("Mathcad UniMath", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manual.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.manual.Location = new System.Drawing.Point(938, 93);
            this.manual.Name = "manual";
            this.manual.Size = new System.Drawing.Size(158, 43);
            this.manual.TabIndex = 1;
            this.manual.Text = "Manual ";
            // 
            // manual2
            // 
            this.manual2.AutoSize = true;
            this.manual2.Font = new System.Drawing.Font("Mathcad UniMath", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manual2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.manual2.Location = new System.Drawing.Point(942, 149);
            this.manual2.Name = "manual2";
            this.manual2.Size = new System.Drawing.Size(113, 120);
            this.manual2.TabIndex = 2;
            this.manual2.Text = "U - up\r\nD - down\r\nR - right\r\nL - left\r\nR - return\r\n";
            // 
            // manual_picture
            // 
            this.manual_picture.Image = ((System.Drawing.Image)(resources.GetObject("manual_picture.Image")));
            this.manual_picture.Location = new System.Drawing.Point(856, 87);
            this.manual_picture.Name = "manual_picture";
            this.manual_picture.Size = new System.Drawing.Size(86, 49);
            this.manual_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.manual_picture.TabIndex = 3;
            this.manual_picture.TabStop = false;
            // 
            // RGR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1158, 638);
            this.Controls.Add(this.manual_picture);
            this.Controls.Add(this.manual2);
            this.Controls.Add(this.manual);
            this.Controls.Add(this.exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RGR";
            this.Text = "RGR";
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