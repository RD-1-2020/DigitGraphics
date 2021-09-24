
namespace DigitGraphics
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cbBrez = new System.Windows.Forms.CheckBox();
            this.cbCDA = new System.Windows.Forms.CheckBox();
            this.pbMainFrame = new System.Windows.Forms.PictureBox();
            this.tbx1 = new System.Windows.Forms.TextBox();
            this.lbx1 = new System.Windows.Forms.Label();
            this.tby1 = new System.Windows.Forms.TextBox();
            this.lby1 = new System.Windows.Forms.Label();
            this.lbx2 = new System.Windows.Forms.Label();
            this.lby2 = new System.Windows.Forms.Label();
            this.tby2 = new System.Windows.Forms.TextBox();
            this.tbx2 = new System.Windows.Forms.TextBox();
            this.cbline = new System.Windows.Forms.CheckBox();
            this.btDraw = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // cbBrez
            // 
            this.cbBrez.AutoSize = true;
            this.cbBrez.Location = new System.Drawing.Point(851, 146);
            this.cbBrez.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbBrez.Name = "cbBrez";
            this.cbBrez.Size = new System.Drawing.Size(167, 21);
            this.cbBrez.TabIndex = 0;
            this.cbBrez.Text = "Алгоритм Брезенхем";
            this.cbBrez.UseVisualStyleBackColor = true;
            // 
            // cbCDA
            // 
            this.cbCDA.AutoSize = true;
            this.cbCDA.Location = new System.Drawing.Point(851, 122);
            this.cbCDA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCDA.Name = "cbCDA";
            this.cbCDA.Size = new System.Drawing.Size(127, 21);
            this.cbCDA.TabIndex = 1;
            this.cbCDA.Text = "Алгоритм ЦДА";
            this.cbCDA.UseVisualStyleBackColor = true;
            // 
            // pbMainFrame
            // 
            this.pbMainFrame.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbMainFrame.Location = new System.Drawing.Point(32, 22);
            this.pbMainFrame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbMainFrame.Name = "pbMainFrame";
            this.pbMainFrame.Size = new System.Drawing.Size(752, 448);
            this.pbMainFrame.TabIndex = 4;
            this.pbMainFrame.TabStop = false;
            this.pbMainFrame.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMainFrame_Paint);
            // 
            // tbx1
            // 
            this.tbx1.Location = new System.Drawing.Point(852, 330);
            this.tbx1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbx1.Name = "tbx1";
            this.tbx1.Size = new System.Drawing.Size(89, 22);
            this.tbx1.TabIndex = 5;
            // 
            // lbx1
            // 
            this.lbx1.AutoSize = true;
            this.lbx1.Location = new System.Drawing.Point(802, 330);
            this.lbx1.Name = "lbx1";
            this.lbx1.Size = new System.Drawing.Size(22, 17);
            this.lbx1.TabIndex = 6;
            this.lbx1.Text = "x1";
            // 
            // tby1
            // 
            this.tby1.Location = new System.Drawing.Point(852, 356);
            this.tby1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tby1.Name = "tby1";
            this.tby1.Size = new System.Drawing.Size(89, 22);
            this.tby1.TabIndex = 7;
            // 
            // lby1
            // 
            this.lby1.AutoSize = true;
            this.lby1.Location = new System.Drawing.Point(802, 356);
            this.lby1.Name = "lby1";
            this.lby1.Size = new System.Drawing.Size(23, 17);
            this.lby1.TabIndex = 8;
            this.lby1.Text = "y1";
            // 
            // lbx2
            // 
            this.lbx2.AutoSize = true;
            this.lbx2.Location = new System.Drawing.Point(802, 382);
            this.lbx2.Name = "lbx2";
            this.lbx2.Size = new System.Drawing.Size(22, 17);
            this.lbx2.TabIndex = 9;
            this.lbx2.Text = "x2";
            // 
            // lby2
            // 
            this.lby2.AutoSize = true;
            this.lby2.Location = new System.Drawing.Point(802, 407);
            this.lby2.Name = "lby2";
            this.lby2.Size = new System.Drawing.Size(23, 17);
            this.lby2.TabIndex = 10;
            this.lby2.Text = "y2";
            // 
            // tby2
            // 
            this.tby2.Location = new System.Drawing.Point(852, 407);
            this.tby2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tby2.Name = "tby2";
            this.tby2.Size = new System.Drawing.Size(89, 22);
            this.tby2.TabIndex = 11;
            // 
            // tbx2
            // 
            this.tbx2.Location = new System.Drawing.Point(852, 382);
            this.tbx2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbx2.Name = "tbx2";
            this.tbx2.Size = new System.Drawing.Size(89, 22);
            this.tbx2.TabIndex = 12;
            // 
            // cbline
            // 
            this.cbline.AutoSize = true;
            this.cbline.Location = new System.Drawing.Point(851, 171);
            this.cbline.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbline.Name = "cbline";
            this.cbline.Size = new System.Drawing.Size(165, 21);
            this.cbline.TabIndex = 2;
            this.cbline.Text = "Нормальный график";
            this.cbline.UseVisualStyleBackColor = true;
            // 
            // btDraw
            // 
            this.btDraw.Location = new System.Drawing.Point(820, 262);
            this.btDraw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btDraw.Name = "btDraw";
            this.btDraw.Size = new System.Drawing.Size(164, 39);
            this.btDraw.TabIndex = 3;
            this.btDraw.Text = "Отрисовка";
            this.btDraw.UseVisualStyleBackColor = true;
            this.btDraw.Click += new System.EventHandler(this.btDraw_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tbx2);
            this.Controls.Add(this.tby2);
            this.Controls.Add(this.lby2);
            this.Controls.Add(this.lbx2);
            this.Controls.Add(this.lby1);
            this.Controls.Add(this.tby1);
            this.Controls.Add(this.lbx1);
            this.Controls.Add(this.tbx1);
            this.Controls.Add(this.pbMainFrame);
            this.Controls.Add(this.btDraw);
            this.Controls.Add(this.cbline);
            this.Controls.Add(this.cbCDA);
            this.Controls.Add(this.cbBrez);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Digit Graphic";
            ((System.ComponentModel.ISupportInitialize)(this.pbMainFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbBrez;
        private System.Windows.Forms.CheckBox cbCDA;
        private System.Windows.Forms.PictureBox pbMainFrame;
        private System.Windows.Forms.TextBox tbx1;
        private System.Windows.Forms.Label lbx1;
        private System.Windows.Forms.TextBox tby1;
        private System.Windows.Forms.Label lby1;
        private System.Windows.Forms.Label lbx2;
        private System.Windows.Forms.Label lby2;
        private System.Windows.Forms.TextBox tby2;
        private System.Windows.Forms.TextBox tbx2;
        private System.Windows.Forms.CheckBox cbline;
        private System.Windows.Forms.Button btDraw;
    }
}

