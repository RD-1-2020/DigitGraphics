
namespace DigitGraphics
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.spMain = new System.Windows.Forms.SplitContainer();
            this.spMenu = new System.Windows.Forms.SplitContainer();
            this.cbFormsList = new System.Windows.Forms.ComboBox();
            this.btStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).BeginInit();
            this.spMain.Panel2.SuspendLayout();
            this.spMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spMenu)).BeginInit();
            this.spMenu.Panel1.SuspendLayout();
            this.spMenu.Panel2.SuspendLayout();
            this.spMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // spMain
            // 
            this.spMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spMain.Location = new System.Drawing.Point(0, 0);
            this.spMain.Name = "spMain";
            this.spMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spMain.Panel1
            // 
            this.spMain.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("spMain.Panel1.BackgroundImage")));
            this.spMain.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            // 
            // spMain.Panel2
            // 
            this.spMain.Panel2.Controls.Add(this.spMenu);
            this.spMain.Size = new System.Drawing.Size(595, 277);
            this.spMain.SplitterDistance = 242;
            this.spMain.SplitterWidth = 1;
            this.spMain.TabIndex = 0;
            // 
            // spMenu
            // 
            this.spMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spMenu.Location = new System.Drawing.Point(0, 0);
            this.spMenu.Name = "spMenu";
            // 
            // spMenu.Panel1
            // 
            this.spMenu.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.spMenu.Panel1.Controls.Add(this.cbFormsList);
            // 
            // spMenu.Panel2
            // 
            this.spMenu.Panel2.Controls.Add(this.btStart);
            this.spMenu.Size = new System.Drawing.Size(595, 34);
            this.spMenu.SplitterDistance = 323;
            this.spMenu.SplitterWidth = 1;
            this.spMenu.TabIndex = 0;
            // 
            // cbFormsList
            // 
            this.cbFormsList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbFormsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbFormsList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFormsList.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbFormsList.FormattingEnabled = true;
            this.cbFormsList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbFormsList.ItemHeight = 22;
            this.cbFormsList.Location = new System.Drawing.Point(0, 0);
            this.cbFormsList.Name = "cbFormsList";
            this.cbFormsList.Size = new System.Drawing.Size(321, 30);
            this.cbFormsList.TabIndex = 0;
            // 
            // btStart
            // 
            this.btStart.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btStart.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btStart.ForeColor = System.Drawing.Color.OrangeRed;
            this.btStart.Location = new System.Drawing.Point(0, 0);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(269, 32);
            this.btStart.TabIndex = 0;
            this.btStart.Text = "Открыть для себя Digit!";
            this.btStart.UseVisualStyleBackColor = false;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(595, 277);
            this.Controls.Add(this.spMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.spMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).EndInit();
            this.spMain.ResumeLayout(false);
            this.spMenu.Panel1.ResumeLayout(false);
            this.spMenu.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spMenu)).EndInit();
            this.spMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spMain;
        private System.Windows.Forms.SplitContainer spMenu;
        private System.Windows.Forms.ComboBox cbFormsList;
        private System.Windows.Forms.Button btStart;
    }
}