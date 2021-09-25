
namespace DigitGraphics.Shapes
{
    partial class ShapesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShapesForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.spMain = new System.Windows.Forms.SplitContainer();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.spMenu = new System.Windows.Forms.SplitContainer();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.cbNormal = new System.Windows.Forms.CheckBox();
            this.cbLine = new System.Windows.Forms.CheckBox();
            this.cbSpiral = new System.Windows.Forms.CheckBox();
            this.btDraw = new System.Windows.Forms.Button();
            this.spShapeSettings = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).BeginInit();
            this.spMain.Panel1.SuspendLayout();
            this.spMain.Panel2.SuspendLayout();
            this.spMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMenu)).BeginInit();
            this.spMenu.Panel1.SuspendLayout();
            this.spMenu.Panel2.SuspendLayout();
            this.spMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spShapeSettings)).BeginInit();
            this.spShapeSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 708);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1177, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // spMain
            // 
            this.spMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spMain.Location = new System.Drawing.Point(0, 0);
            this.spMain.Name = "spMain";
            // 
            // spMain.Panel1
            // 
            this.spMain.Panel1.Controls.Add(this.pbMain);
            // 
            // spMain.Panel2
            // 
            this.spMain.Panel2.Controls.Add(this.spMenu);
            this.spMain.Size = new System.Drawing.Size(1177, 708);
            this.spMain.SplitterDistance = 713;
            this.spMain.SplitterWidth = 1;
            this.spMain.TabIndex = 1;
            // 
            // pbMain
            // 
            this.pbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMain.Location = new System.Drawing.Point(0, 0);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(711, 706);
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            this.pbMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMain_Paint);
            // 
            // spMenu
            // 
            this.spMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spMenu.Location = new System.Drawing.Point(0, 0);
            this.spMenu.Name = "spMenu";
            this.spMenu.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spMenu.Panel1
            // 
            this.spMenu.Panel1.Controls.Add(this.spShapeSettings);
            this.spMenu.Panel1.Controls.Add(this.btDraw);
            this.spMenu.Panel1.Controls.Add(this.cbSpiral);
            this.spMenu.Panel1.Controls.Add(this.cbLine);
            this.spMenu.Panel1.Controls.Add(this.cbNormal);
            // 
            // spMenu.Panel2
            // 
            this.spMenu.Panel2.Controls.Add(this.propertyGrid1);
            this.spMenu.Size = new System.Drawing.Size(461, 706);
            this.spMenu.SplitterDistance = 303;
            this.spMenu.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(461, 399);
            this.propertyGrid1.TabIndex = 0;
            // 
            // cbNormal
            // 
            this.cbNormal.AutoSize = true;
            this.cbNormal.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbNormal.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbNormal.Location = new System.Drawing.Point(0, 0);
            this.cbNormal.Name = "cbNormal";
            this.cbNormal.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.cbNormal.Size = new System.Drawing.Size(461, 23);
            this.cbNormal.TabIndex = 0;
            this.cbNormal.Text = "Стандартная отрисовка";
            this.cbNormal.UseVisualStyleBackColor = true;
            // 
            // cbLine
            // 
            this.cbLine.AutoSize = true;
            this.cbLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbLine.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbLine.Location = new System.Drawing.Point(0, 23);
            this.cbLine.Name = "cbLine";
            this.cbLine.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.cbLine.Size = new System.Drawing.Size(461, 23);
            this.cbLine.TabIndex = 1;
            this.cbLine.Text = "Отрисовка строками";
            this.cbLine.UseVisualStyleBackColor = true;
            // 
            // cbSpiral
            // 
            this.cbSpiral.AutoSize = true;
            this.cbSpiral.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbSpiral.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbSpiral.Location = new System.Drawing.Point(0, 46);
            this.cbSpiral.Name = "cbSpiral";
            this.cbSpiral.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.cbSpiral.Size = new System.Drawing.Size(461, 23);
            this.cbSpiral.TabIndex = 2;
            this.cbSpiral.Text = "Отрисовка спиралью";
            this.cbSpiral.UseVisualStyleBackColor = true;
            // 
            // btDraw
            // 
            this.btDraw.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btDraw.Location = new System.Drawing.Point(0, 252);
            this.btDraw.Name = "btDraw";
            this.btDraw.Size = new System.Drawing.Size(461, 51);
            this.btDraw.TabIndex = 3;
            this.btDraw.Text = "Начни свой путь в Digit!";
            this.btDraw.UseVisualStyleBackColor = true;
            this.btDraw.Click += new System.EventHandler(this.button1_Click);
            // 
            // spShapeSettings
            // 
            this.spShapeSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spShapeSettings.IsSplitterFixed = true;
            this.spShapeSettings.Location = new System.Drawing.Point(0, 69);
            this.spShapeSettings.Name = "spShapeSettings";
            this.spShapeSettings.Size = new System.Drawing.Size(461, 183);
            this.spShapeSettings.SplitterDistance = 110;
            this.spShapeSettings.SplitterWidth = 1;
            this.spShapeSettings.TabIndex = 4;
            // 
            // ShapesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 730);
            this.Controls.Add(this.spMain);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShapesForm";
            this.Text = "Отрисовка шестиугольника";
            this.Load += new System.EventHandler(this.ShapesForm_Load);
            this.spMain.Panel1.ResumeLayout(false);
            this.spMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).EndInit();
            this.spMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.spMenu.Panel1.ResumeLayout(false);
            this.spMenu.Panel1.PerformLayout();
            this.spMenu.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spMenu)).EndInit();
            this.spMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spShapeSettings)).EndInit();
            this.spShapeSettings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer spMain;
        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.SplitContainer spMenu;
        private System.Windows.Forms.Button btDraw;
        private System.Windows.Forms.CheckBox cbSpiral;
        private System.Windows.Forms.CheckBox cbLine;
        private System.Windows.Forms.CheckBox cbNormal;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.SplitContainer spShapeSettings;
    }
}