
namespace DigitGraphics.ShapeLine
{
    partial class frShapeLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frShapeLine));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.spMain = new System.Windows.Forms.SplitContainer();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.spMenu = new System.Windows.Forms.SplitContainer();
            this.spHelp = new System.Windows.Forms.SplitContainer();
            this.lbHelpTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbLine = new System.Windows.Forms.RadioButton();
            this.rbShape = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).BeginInit();
            this.spMain.Panel1.SuspendLayout();
            this.spMain.Panel2.SuspendLayout();
            this.spMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMenu)).BeginInit();
            this.spMenu.Panel1.SuspendLayout();
            this.spMenu.Panel2.SuspendLayout();
            this.spMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spHelp)).BeginInit();
            this.spHelp.Panel1.SuspendLayout();
            this.spHelp.Panel2.SuspendLayout();
            this.spHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 1028);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1765, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // spMain
            // 
            this.spMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spMain.Location = new System.Drawing.Point(0, 0);
            this.spMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.spMain.Name = "spMain";
            // 
            // spMain.Panel1
            // 
            this.spMain.Panel1.Controls.Add(this.pbMain);
            // 
            // spMain.Panel2
            // 
            this.spMain.Panel2.Controls.Add(this.spMenu);
            this.spMain.Size = new System.Drawing.Size(1765, 1028);
            this.spMain.SplitterDistance = 1068;
            this.spMain.SplitterWidth = 1;
            this.spMain.TabIndex = 1;
            // 
            // pbMain
            // 
            this.pbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMain.Location = new System.Drawing.Point(0, 0);
            this.pbMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(1066, 1026);
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            this.pbMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMain_Paint);
            this.pbMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseClick);
            // 
            // spMenu
            // 
            this.spMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spMenu.Location = new System.Drawing.Point(0, 0);
            this.spMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.spMenu.Name = "spMenu";
            this.spMenu.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spMenu.Panel1
            // 
            this.spMenu.Panel1.Controls.Add(this.spHelp);
            // 
            // spMenu.Panel2
            // 
            this.spMenu.Panel2.Controls.Add(this.rbLine);
            this.spMenu.Panel2.Controls.Add(this.rbShape);
            this.spMenu.Size = new System.Drawing.Size(694, 1026);
            this.spMenu.SplitterDistance = 440;
            this.spMenu.SplitterWidth = 6;
            this.spMenu.TabIndex = 0;
            // 
            // spHelp
            // 
            this.spHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spHelp.Location = new System.Drawing.Point(0, 0);
            this.spHelp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.spHelp.Name = "spHelp";
            this.spHelp.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spHelp.Panel1
            // 
            this.spHelp.Panel1.Controls.Add(this.lbHelpTitle);
            // 
            // spHelp.Panel2
            // 
            this.spHelp.Panel2.Controls.Add(this.label1);
            this.spHelp.Size = new System.Drawing.Size(694, 440);
            this.spHelp.SplitterDistance = 130;
            this.spHelp.SplitterWidth = 1;
            this.spHelp.TabIndex = 1;
            // 
            // lbHelpTitle
            // 
            this.lbHelpTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbHelpTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHelpTitle.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbHelpTitle.Location = new System.Drawing.Point(0, 0);
            this.lbHelpTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHelpTitle.Name = "lbHelpTitle";
            this.lbHelpTitle.Size = new System.Drawing.Size(694, 130);
            this.lbHelpTitle.TabIndex = 0;
            this.lbHelpTitle.Text = "Подсказка";
            this.lbHelpTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(694, 309);
            this.label1.TabIndex = 1;
            this.label1.Text = "Чтобы начать работу выбирите что вы будете рисовать, затем тыкните на поле (едино" +
    "жды - если фигура, дважды - если линия) ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbLine
            // 
            this.rbLine.AutoSize = true;
            this.rbLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbLine.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbLine.Location = new System.Drawing.Point(0, 32);
            this.rbLine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbLine.Name = "rbLine";
            this.rbLine.Size = new System.Drawing.Size(694, 32);
            this.rbLine.TabIndex = 1;
            this.rbLine.TabStop = true;
            this.rbLine.Text = "Отрисовка линий";
            this.rbLine.UseVisualStyleBackColor = true;
            this.rbLine.CheckedChanged += new System.EventHandler(this.rbLine_CheckedChanged);
            // 
            // rbShape
            // 
            this.rbShape.AutoSize = true;
            this.rbShape.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbShape.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbShape.Location = new System.Drawing.Point(0, 0);
            this.rbShape.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbShape.Name = "rbShape";
            this.rbShape.Size = new System.Drawing.Size(694, 32);
            this.rbShape.TabIndex = 0;
            this.rbShape.TabStop = true;
            this.rbShape.Text = "Отрисовка фигур";
            this.rbShape.UseVisualStyleBackColor = true;
            // 
            // frShapeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1765, 1050);
            this.Controls.Add(this.spMain);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frShapeLine";
            this.Text = "Отрисовка шестиугольника";
            this.Load += new System.EventHandler(this.frShapeLine_Load);
            this.spMain.Panel1.ResumeLayout(false);
            this.spMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).EndInit();
            this.spMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.spMenu.Panel1.ResumeLayout(false);
            this.spMenu.Panel2.ResumeLayout(false);
            this.spMenu.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spMenu)).EndInit();
            this.spMenu.ResumeLayout(false);
            this.spHelp.Panel1.ResumeLayout(false);
            this.spHelp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spHelp)).EndInit();
            this.spHelp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer spMain;
        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.SplitContainer spMenu;
        private System.Windows.Forms.SplitContainer spHelp;
        private System.Windows.Forms.Label lbHelpTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbLine;
        private System.Windows.Forms.RadioButton rbShape;
    }
}