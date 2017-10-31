namespace AtdUI
{
    partial class FrmBarCodeSet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BtnGAReInPut = new System.Windows.Forms.Button();
            this.btnGAsee = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvBarCode = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnGAupdate = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnDelBC = new System.Windows.Forms.Button();
            this.btnUpdateBC = new System.Windows.Forms.Button();
            this.btnAddBC = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarCode)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleName = "";
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(13, 12);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1285, 650);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AccessibleName = "";
            this.tabPage1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tabPage1.Controls.Add(this.BtnGAReInPut);
            this.tabPage1.Controls.Add(this.btnGAsee);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.dgvBarCode);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.btnGAupdate);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.btnDelBC);
            this.tabPage1.Controls.Add(this.btnUpdateBC);
            this.tabPage1.Controls.Add(this.btnAddBC);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1277, 621);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "条码操作";
            // 
            // BtnGAReInPut
            // 
            this.BtnGAReInPut.Location = new System.Drawing.Point(534, 22);
            this.BtnGAReInPut.Name = "BtnGAReInPut";
            this.BtnGAReInPut.Size = new System.Drawing.Size(113, 95);
            this.BtnGAReInPut.TabIndex = 9;
            this.BtnGAReInPut.Text = "货位关联导入";
            this.BtnGAReInPut.UseVisualStyleBackColor = true;
            this.BtnGAReInPut.Click += new System.EventHandler(this.BtnGAReInPut_Click);
            // 
            // btnGAsee
            // 
            this.btnGAsee.Location = new System.Drawing.Point(859, 20);
            this.btnGAsee.Margin = new System.Windows.Forms.Padding(4);
            this.btnGAsee.Name = "btnGAsee";
            this.btnGAsee.Size = new System.Drawing.Size(132, 38);
            this.btnGAsee.TabIndex = 8;
            this.btnGAsee.Text = "关联货位查看";
            this.btnGAsee.UseVisualStyleBackColor = true;
            this.btnGAsee.Click += new System.EventHandler(this.btnGAsee_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1041, 19);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 39);
            this.button1.TabIndex = 7;
            this.button1.Text = "数据更新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvBarCode
            // 
            this.dgvBarCode.AllowUserToAddRows = false;
            this.dgvBarCode.AllowUserToDeleteRows = false;
            this.dgvBarCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBarCode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBarCode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBarCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column10,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column9,
            this.Column8});
            this.dgvBarCode.Location = new System.Drawing.Point(14, 162);
            this.dgvBarCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvBarCode.Name = "dgvBarCode";
            this.dgvBarCode.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBarCode.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBarCode.RowHeadersVisible = false;
            this.dgvBarCode.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgvBarCode.RowTemplate.Height = 27;
            this.dgvBarCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBarCode.Size = new System.Drawing.Size(1244, 446);
            this.dgvBarCode.TabIndex = 5;
            this.dgvBarCode.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBarCode_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "BarCodeID";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "条码发送选择";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column10.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "BarCodeCount";
            this.Column2.HeaderText = "序号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "BarCode";
            this.Column3.HeaderText = "条码";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "BarCodeName";
            this.Column4.HeaderText = "条码名称";
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
            this.Column7.DataPropertyName = "StationNum";
            this.Column7.HeaderText = "归属站";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "GAReStates";
            this.Column9.HeaderText = "货位指派状态";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "条码备注";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(22, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "条码名称/条码";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12.20339F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(201, 84);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(234, 30);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnGAupdate
            // 
            this.btnGAupdate.Location = new System.Drawing.Point(696, 78);
            this.btnGAupdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGAupdate.Name = "btnGAupdate";
            this.btnGAupdate.Size = new System.Drawing.Size(125, 39);
            this.btnGAupdate.TabIndex = 2;
            this.btnGAupdate.Text = "关联货位修改";
            this.btnGAupdate.UseVisualStyleBackColor = true;
            this.btnGAupdate.Click += new System.EventHandler(this.btnGAupdate_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(696, 19);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(125, 38);
            this.button5.TabIndex = 2;
            this.button5.Text = "关联货位指派";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnDelBC
            // 
            this.btnDelBC.Location = new System.Drawing.Point(344, 19);
            this.btnDelBC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelBC.Name = "btnDelBC";
            this.btnDelBC.Size = new System.Drawing.Size(91, 36);
            this.btnDelBC.TabIndex = 2;
            this.btnDelBC.Text = "删除";
            this.btnDelBC.UseVisualStyleBackColor = true;
            this.btnDelBC.Click += new System.EventHandler(this.btnDelBC_Click);
            // 
            // btnUpdateBC
            // 
            this.btnUpdateBC.Location = new System.Drawing.Point(184, 19);
            this.btnUpdateBC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateBC.Name = "btnUpdateBC";
            this.btnUpdateBC.Size = new System.Drawing.Size(91, 38);
            this.btnUpdateBC.TabIndex = 1;
            this.btnUpdateBC.Text = "修改";
            this.btnUpdateBC.UseVisualStyleBackColor = true;
            this.btnUpdateBC.Click += new System.EventHandler(this.btnUpdateBC_Click);
            // 
            // btnAddBC
            // 
            this.btnAddBC.Location = new System.Drawing.Point(27, 20);
            this.btnAddBC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddBC.Name = "btnAddBC";
            this.btnAddBC.Size = new System.Drawing.Size(91, 38);
            this.btnAddBC.TabIndex = 0;
            this.btnAddBC.Text = "新增";
            this.btnAddBC.UseVisualStyleBackColor = true;
            this.btnAddBC.Click += new System.EventHandler(this.btnInsBC_Click);
            // 
            // FrmBarCodeSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 673);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBarCodeSet";
            this.Text = "条码管理";
            this.Load += new System.EventHandler(this.FrmBarCodeSet_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.DataGridView dgvBarCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnDelBC;
        private System.Windows.Forms.Button btnUpdateBC;
        private System.Windows.Forms.Button btnAddBC;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnGAupdate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGAsee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Button BtnGAReInPut;
    }
}