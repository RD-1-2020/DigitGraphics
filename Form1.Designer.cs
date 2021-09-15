
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
            this.cbDDA = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbx1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lby1 = new System.Windows.Forms.Label();
            this.lbx2 = new System.Windows.Forms.Label();
            this.lby2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.cbline = new System.Windows.Forms.CheckBox();
            this.btDraw = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbBrez
            // 
            this.cbBrez.AutoSize = true;
            this.cbBrez.Location = new System.Drawing.Point(957, 183);
            this.cbBrez.Name = "cbBrez";
            this.cbBrez.Size = new System.Drawing.Size(196, 24);
            this.cbBrez.TabIndex = 0;
            this.cbBrez.Text = "Алгоритм Брезенхем";
            this.cbBrez.UseVisualStyleBackColor = true;
            this.cbBrez.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cbDDA
            // 
            this.cbDDA.AutoSize = true;
            this.cbDDA.Location = new System.Drawing.Point(957, 153);
            this.cbDDA.Name = "cbDDA";
            this.cbDDA.Size = new System.Drawing.Size(149, 24);
            this.cbDDA.TabIndex = 1;
            this.cbDDA.Text = "Алгоритм ЦДА";
            this.cbDDA.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(36, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(846, 552);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(958, 413);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 5;
            // 
            // lbx1
            // 
            this.lbx1.AutoSize = true;
            this.lbx1.Location = new System.Drawing.Point(900, 419);
            this.lbx1.Name = "lbx1";
            this.lbx1.Size = new System.Drawing.Size(25, 20);
            this.lbx1.TabIndex = 6;
            this.lbx1.Text = "x1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(958, 445);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 26);
            this.textBox2.TabIndex = 7;
            // 
            // lby1
            // 
            this.lby1.AutoSize = true;
            this.lby1.Location = new System.Drawing.Point(900, 448);
            this.lby1.Name = "lby1";
            this.lby1.Size = new System.Drawing.Size(25, 20);
            this.lby1.TabIndex = 8;
            this.lby1.Text = "y1";
            // 
            // lbx2
            // 
            this.lbx2.AutoSize = true;
            this.lbx2.Location = new System.Drawing.Point(901, 483);
            this.lbx2.Name = "lbx2";
            this.lbx2.Size = new System.Drawing.Size(25, 20);
            this.lbx2.TabIndex = 9;
            this.lbx2.Text = "x2";
            // 
            // lby2
            // 
            this.lby2.AutoSize = true;
            this.lby2.Location = new System.Drawing.Point(901, 515);
            this.lby2.Name = "lby2";
            this.lby2.Size = new System.Drawing.Size(25, 20);
            this.lby2.TabIndex = 10;
            this.lby2.Text = "y2";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(957, 509);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 26);
            this.textBox3.TabIndex = 11;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(958, 477);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 26);
            this.textBox4.TabIndex = 12;
            // 
            // cbline
            // 
            this.cbline.AutoSize = true;
            this.cbline.Location = new System.Drawing.Point(958, 213);
            this.cbline.Name = "cbline";
            this.cbline.Size = new System.Drawing.Size(194, 24);
            this.cbline.TabIndex = 2;
            this.cbline.Text = "Нормальный график";
            this.cbline.UseVisualStyleBackColor = true;
            // 
            // btDraw
            // 
            this.btDraw.Location = new System.Drawing.Point(922, 328);
            this.btDraw.Name = "btDraw";
            this.btDraw.Size = new System.Drawing.Size(184, 50);
            this.btDraw.TabIndex = 3;
            this.btDraw.Text = "Отрисовка";
            this.btDraw.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.lby2);
            this.Controls.Add(this.lbx2);
            this.Controls.Add(this.lby1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lbx1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btDraw);
            this.Controls.Add(this.cbline);
            this.Controls.Add(this.cbDDA);
            this.Controls.Add(this.cbBrez);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Digit Graphic";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbBrez;
        private System.Windows.Forms.CheckBox cbDDA;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbx1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lby1;
        private System.Windows.Forms.Label lbx2;
        private System.Windows.Forms.Label lby2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.CheckBox cbline;
        private System.Windows.Forms.Button btDraw;
    }
}

