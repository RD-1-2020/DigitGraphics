
namespace DigitGraphics.Shapes
{
    partial class FormRadius
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRadius));
            this.tbRadius = new System.Windows.Forms.TextBox();
            this.btOk = new System.Windows.Forms.Button();
            this.lb1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbRadius
            // 
            this.tbRadius.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbRadius.Location = new System.Drawing.Point(72, 35);
            this.tbRadius.Name = "tbRadius";
            this.tbRadius.Size = new System.Drawing.Size(354, 26);
            this.tbRadius.TabIndex = 0;
            this.tbRadius.Text = "Введите радиус описанной окружности";
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(432, 35);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(91, 26);
            this.btOk.TabIndex = 1;
            this.btOk.Text = "Ок";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // lb1
            // 
            this.lb1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb1.Location = new System.Drawing.Point(35, 35);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(31, 26);
            this.lb1.TabIndex = 2;
            this.lb1.Text = "R:";
            // 
            // FormRadius
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 91);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.tbRadius);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRadius";
            this.Text = "Ввод радиуса описанной окружности";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.TextBox tbRadius;
    }
}