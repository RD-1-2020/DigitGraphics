
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
            this.manual = new System.Windows.Forms.Label();
            this.manual2 = new System.Windows.Forms.Label();
            this.manual_picture = new System.Windows.Forms.PictureBox();
            this.panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.manual_picture)).BeginInit();
            this.SuspendLayout();
            // 
            // manual
            // 
            this.manual.AutoSize = true;
            this.manual.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.manual.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manual.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.manual.Location = new System.Drawing.Point(938, 92);
            this.manual.Name = "manual";
            this.manual.Size = new System.Drawing.Size(204, 40);
            this.manual.TabIndex = 1;
            this.manual.Text = "Introduction";
            // 
            // manual2
            // 
            this.manual2.AutoSize = true;
            this.manual2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manual2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.manual2.Location = new System.Drawing.Point(942, 149);
            this.manual2.Name = "manual2";
            this.manual2.Size = new System.Drawing.Size(92, 125);
            this.manual2.TabIndex = 2;
            this.manual2.Text = "W - up\r\nS - down\r\nA - left\r\nD - right\r\nR - return\r\n";
            // 
            // manual_picture
            // 
            this.manual_picture.Image = ((System.Drawing.Image)(resources.GetObject("manual_picture.Image")));
            this.manual_picture.Location = new System.Drawing.Point(856, 88);
            this.manual_picture.Name = "manual_picture";
            this.manual_picture.Size = new System.Drawing.Size(86, 49);
            this.manual_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.manual_picture.TabIndex = 3;
            this.manual_picture.TabStop = false;
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel.Location = new System.Drawing.Point(68, 67);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(722, 507);
            this.panel.TabIndex = 4;
            // 
            // RGR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1158, 638);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.manual_picture);
            this.Controls.Add(this.manual2);
            this.Controls.Add(this.manual);
            this.Name = "RGR";
            this.Text = "RGR";
            ((System.ComponentModel.ISupportInitialize)(this.manual_picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label manual;
        private System.Windows.Forms.Label manual2;
        private System.Windows.Forms.PictureBox manual_picture;
        private System.Windows.Forms.Panel panel;
    }
}