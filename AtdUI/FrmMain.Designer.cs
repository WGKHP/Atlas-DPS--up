namespace AtdUI
{
    partial class FrmMain
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
            this.btHelper = new System.Windows.Forms.Button();
            this.btSYS = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btIN = new System.Windows.Forms.Button();
            this.btnGoodAllocation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btHelper
            // 
            this.btHelper.Location = new System.Drawing.Point(640, 12);
            this.btHelper.Margin = new System.Windows.Forms.Padding(4);
            this.btHelper.Name = "btHelper";
            this.btHelper.Size = new System.Drawing.Size(125, 81);
            this.btHelper.TabIndex = 0;
            this.btHelper.Text = "帮助";
            this.btHelper.UseVisualStyleBackColor = true;
            // 
            // btSYS
            // 
            this.btSYS.Location = new System.Drawing.Point(278, 13);
            this.btSYS.Margin = new System.Windows.Forms.Padding(4);
            this.btSYS.Name = "btSYS";
            this.btSYS.Size = new System.Drawing.Size(125, 81);
            this.btSYS.TabIndex = 0;
            this.btSYS.Text = "站设置";
            this.btSYS.UseVisualStyleBackColor = true;
            this.btSYS.Click += new System.EventHandler(this.button5_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1504, 124);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 124);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1504, 711);
            this.splitContainer1.SplitterDistance = 212;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Click += new System.EventHandler(this.FrmBarCodeSet_Load);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.splitContainer2.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel2_Paint);
            this.splitContainer2.Size = new System.Drawing.Size(1287, 711);
            this.splitContainer2.SplitterDistance = 527;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // btIN
            // 
            this.btIN.Location = new System.Drawing.Point(100, 13);
            this.btIN.Margin = new System.Windows.Forms.Padding(4);
            this.btIN.Name = "btIN";
            this.btIN.Size = new System.Drawing.Size(125, 81);
            this.btIN.TabIndex = 0;
            this.btIN.Text = "条码导入";
            this.btIN.UseVisualStyleBackColor = true;
            this.btIN.Click += new System.EventHandler(this.btIN_Click);
            // 
            // btnGoodAllocation
            // 
            this.btnGoodAllocation.Location = new System.Drawing.Point(456, 13);
            this.btnGoodAllocation.Margin = new System.Windows.Forms.Padding(4);
            this.btnGoodAllocation.Name = "btnGoodAllocation";
            this.btnGoodAllocation.Size = new System.Drawing.Size(136, 80);
            this.btnGoodAllocation.TabIndex = 3;
            this.btnGoodAllocation.Text = "货位总设置";
            this.btnGoodAllocation.UseVisualStyleBackColor = true;
            this.btnGoodAllocation.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1504, 835);
            this.Controls.Add(this.btnGoodAllocation);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btSYS);
            this.Controls.Add(this.btIN);
            this.Controls.Add(this.btHelper);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Text = "电子标签管理系统";
            this.Load += new System.EventHandler(this.FrimMain_Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btHelper;
        private System.Windows.Forms.Button btSYS;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btIN;
        private System.Windows.Forms.Button btnGoodAllocation;
    }
}