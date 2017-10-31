namespace AtdUI
{
    partial class FrmGoodsAllocationSelect
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
            this.btnGASOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnGASOK
            // 
            this.btnGASOK.Location = new System.Drawing.Point(1189, 803);
            this.btnGASOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnGASOK.Name = "btnGASOK";
            this.btnGASOK.Size = new System.Drawing.Size(100, 29);
            this.btnGASOK.TabIndex = 0;
            this.btnGASOK.Text = "确定按钮";
            this.btnGASOK.UseVisualStyleBackColor = true;
            this.btnGASOK.Click += new System.EventHandler(this.btnGASOK_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1885, 763);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // FrmGoodsAllocationSelect
            // 
            this.AcceptButton = this.btnGASOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1914, 989);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGASOK);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmGoodsAllocationSelect";
            this.Text = "条码对应的货位关联";
            this.Load += new System.EventHandler(this.FrmGoodsAllocationSelect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnGASOK;
        private System.Windows.Forms.Panel panel1;
    }
}