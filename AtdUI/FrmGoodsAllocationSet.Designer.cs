namespace AtdUI
{
    partial class FrmGoodsAllocationSet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAddGoodsAllocation = new System.Windows.Forms.Button();
            this.btnUpdateGoodsAllocation = new System.Windows.Forms.Button();
            this.btnDeletGoodsAllocation = new System.Windows.Forms.Button();
            this.dgvGoodsAllocation = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reachtinf = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAllGAIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsAllocation)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddGoodsAllocation
            // 
            this.btnAddGoodsAllocation.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddGoodsAllocation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddGoodsAllocation.Location = new System.Drawing.Point(17, 39);
            this.btnAddGoodsAllocation.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddGoodsAllocation.Name = "btnAddGoodsAllocation";
            this.btnAddGoodsAllocation.Size = new System.Drawing.Size(109, 41);
            this.btnAddGoodsAllocation.TabIndex = 3;
            this.btnAddGoodsAllocation.Text = "新增";
            this.btnAddGoodsAllocation.UseVisualStyleBackColor = false;
            this.btnAddGoodsAllocation.Click += new System.EventHandler(this.btnAddGoodsAllocation_Click);
            // 
            // btnUpdateGoodsAllocation
            // 
            this.btnUpdateGoodsAllocation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUpdateGoodsAllocation.Location = new System.Drawing.Point(166, 39);
            this.btnUpdateGoodsAllocation.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateGoodsAllocation.Name = "btnUpdateGoodsAllocation";
            this.btnUpdateGoodsAllocation.Size = new System.Drawing.Size(111, 41);
            this.btnUpdateGoodsAllocation.TabIndex = 4;
            this.btnUpdateGoodsAllocation.Text = "修改";
            this.btnUpdateGoodsAllocation.UseVisualStyleBackColor = true;
            this.btnUpdateGoodsAllocation.Click += new System.EventHandler(this.btnUpdateGoodsAllocation_Click);
            // 
            // btnDeletGoodsAllocation
            // 
            this.btnDeletGoodsAllocation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDeletGoodsAllocation.Location = new System.Drawing.Point(327, 39);
            this.btnDeletGoodsAllocation.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeletGoodsAllocation.Name = "btnDeletGoodsAllocation";
            this.btnDeletGoodsAllocation.Size = new System.Drawing.Size(111, 41);
            this.btnDeletGoodsAllocation.TabIndex = 5;
            this.btnDeletGoodsAllocation.Text = "删除";
            this.btnDeletGoodsAllocation.UseVisualStyleBackColor = true;
            this.btnDeletGoodsAllocation.Click += new System.EventHandler(this.btnDeletGoodsAllocation_Click);
            // 
            // dgvGoodsAllocation
            // 
            this.dgvGoodsAllocation.AllowUserToAddRows = false;
            this.dgvGoodsAllocation.AllowUserToDeleteRows = false;
            this.dgvGoodsAllocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGoodsAllocation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGoodsAllocation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGoodsAllocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoodsAllocation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column8,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvGoodsAllocation.Location = new System.Drawing.Point(8, 123);
            this.dgvGoodsAllocation.Margin = new System.Windows.Forms.Padding(4);
            this.dgvGoodsAllocation.Name = "dgvGoodsAllocation";
            this.dgvGoodsAllocation.ReadOnly = true;
            this.dgvGoodsAllocation.RowHeadersVisible = false;
            this.dgvGoodsAllocation.RowTemplate.Height = 23;
            this.dgvGoodsAllocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGoodsAllocation.Size = new System.Drawing.Size(1108, 496);
            this.dgvGoodsAllocation.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "GoodsAllocationID";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "GoodsAlllocationCount";
            this.Column2.HeaderText = "序号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "GoodsAllocationNum";
            this.Column3.HeaderText = "货位号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "GoodsCode";
            this.Column8.HeaderText = "货位代码";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "GoodsAllocationName";
            this.Column4.HeaderText = "货物名称";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "CreatDateTime";
            this.Column5.HeaderText = "创建时间";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "UpDateTime";
            this.Column6.HeaderText = "修改时间";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "GoodsAllocationbeizhu";
            this.Column7.HeaderText = "备注";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(16, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1135, 656);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabPage1.Controls.Add(this.BtnAllGAIn);
            this.tabPage1.Controls.Add(this.reachtinf);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dgvGoodsAllocation);
            this.tabPage1.Controls.Add(this.btnDeletGoodsAllocation);
            this.tabPage1.Controls.Add(this.btnAddGoodsAllocation);
            this.tabPage1.Controls.Add(this.btnUpdateGoodsAllocation);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1127, 627);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "总货位设置";
            // 
            // reachtinf
            // 
            this.reachtinf.Font = new System.Drawing.Font("宋体", 12.20339F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reachtinf.Location = new System.Drawing.Point(841, 44);
            this.reachtinf.Name = "reachtinf";
            this.reachtinf.Size = new System.Drawing.Size(196, 30);
            this.reachtinf.TabIndex = 7;
            this.reachtinf.TextChanged += new System.EventHandler(this.reachtinf_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12.20339F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(697, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "货位号/名称";
            // 
            // BtnAllGAIn
            // 
            this.BtnAllGAIn.Location = new System.Drawing.Point(474, 39);
            this.BtnAllGAIn.Name = "BtnAllGAIn";
            this.BtnAllGAIn.Size = new System.Drawing.Size(112, 41);
            this.BtnAllGAIn.TabIndex = 8;
            this.BtnAllGAIn.Text = "总货位导入";
            this.BtnAllGAIn.UseVisualStyleBackColor = true;
            this.BtnAllGAIn.Click += new System.EventHandler(this.BtnAllGAIn_Click);
            // 
            // FrmGoodsAllocationSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 686);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmGoodsAllocationSet";
            this.Text = "总货位设置";
            this.Load += new System.EventHandler(this.FrmGoodsAllocationSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsAllocation)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddGoodsAllocation;
        private System.Windows.Forms.Button btnUpdateGoodsAllocation;
        private System.Windows.Forms.Button btnDeletGoodsAllocation;
        private System.Windows.Forms.DataGridView dgvGoodsAllocation;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox reachtinf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Button BtnAllGAIn;
    }
}