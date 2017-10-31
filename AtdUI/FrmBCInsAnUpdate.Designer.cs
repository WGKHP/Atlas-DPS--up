namespace AtdUI
{
    partial class FrmBCInsAnUpdate
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
            this.btnInsOrUpdate = new System.Windows.Forms.Button();
            this.BarCodebeizhuText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BarCodeIDText = new System.Windows.Forms.TextBox();
            this.BarCodeText = new System.Windows.Forms.TextBox();
            this.BarCodeNameText = new System.Windows.Forms.TextBox();
            this.BC = new System.Windows.Forms.Label();
            this.BCName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInsOrUpdate
            // 
            this.btnInsOrUpdate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInsOrUpdate.Location = new System.Drawing.Point(483, 321);
            this.btnInsOrUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsOrUpdate.Name = "btnInsOrUpdate";
            this.btnInsOrUpdate.Size = new System.Drawing.Size(153, 45);
            this.btnInsOrUpdate.TabIndex = 14;
            this.btnInsOrUpdate.Text = "确认";
            this.btnInsOrUpdate.UseVisualStyleBackColor = true;
            this.btnInsOrUpdate.Click += new System.EventHandler(this.btnInsOrUpdate_Click);
            // 
            // BarCodebeizhuText
            // 
            this.BarCodebeizhuText.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BarCodebeizhuText.Location = new System.Drawing.Point(144, 235);
            this.BarCodebeizhuText.Margin = new System.Windows.Forms.Padding(4);
            this.BarCodebeizhuText.Name = "BarCodebeizhuText";
            this.BarCodebeizhuText.Size = new System.Drawing.Size(336, 34);
            this.BarCodebeizhuText.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(28, 242);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "条码备注：";
            // 
            // BarCodeIDText
            // 
            this.BarCodeIDText.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BarCodeIDText.Location = new System.Drawing.Point(564, 328);
            this.BarCodeIDText.Margin = new System.Windows.Forms.Padding(4);
            this.BarCodeIDText.Name = "BarCodeIDText";
            this.BarCodeIDText.Size = new System.Drawing.Size(44, 34);
            this.BarCodeIDText.TabIndex = 11;
            this.BarCodeIDText.Visible = false;
            // 
            // BarCodeText
            // 
            this.BarCodeText.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BarCodeText.Location = new System.Drawing.Point(149, 94);
            this.BarCodeText.Margin = new System.Windows.Forms.Padding(4);
            this.BarCodeText.Name = "BarCodeText";
            this.BarCodeText.Size = new System.Drawing.Size(165, 34);
            this.BarCodeText.TabIndex = 12;
            this.BarCodeText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BarCodeText_KeyPress);
            // 
            // BarCodeNameText
            // 
            this.BarCodeNameText.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BarCodeNameText.Location = new System.Drawing.Point(147, 158);
            this.BarCodeNameText.Margin = new System.Windows.Forms.Padding(4);
            this.BarCodeNameText.Name = "BarCodeNameText";
            this.BarCodeNameText.Size = new System.Drawing.Size(168, 34);
            this.BarCodeNameText.TabIndex = 13;
            // 
            // BC
            // 
            this.BC.AutoSize = true;
            this.BC.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BC.Location = new System.Drawing.Point(28, 98);
            this.BC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BC.Name = "BC";
            this.BC.Size = new System.Drawing.Size(94, 24);
            this.BC.TabIndex = 6;
            this.BC.Text = "条 码：";
            // 
            // BCName
            // 
            this.BCName.AutoSize = true;
            this.BCName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BCName.Location = new System.Drawing.Point(28, 164);
            this.BCName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BCName.Name = "BCName";
            this.BCName.Size = new System.Drawing.Size(130, 24);
            this.BCName.TabIndex = 7;
            this.BCName.Text = "条码名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(326, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "（由PW字母和9个数字组成）";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(326, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "（示例：PW123456789）";
            // 
            // FrmBCInsAnUpdate
            // 
            this.AcceptButton = this.btnInsOrUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 410);
            this.Controls.Add(this.btnInsOrUpdate);
            this.Controls.Add(this.BarCodebeizhuText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BarCodeIDText);
            this.Controls.Add(this.BarCodeText);
            this.Controls.Add(this.BarCodeNameText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BC);
            this.Controls.Add(this.BCName);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmBCInsAnUpdate";
            this.Text = "条码操作";
            this.Load += new System.EventHandler(this.FrmBCInsAnUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInsOrUpdate;
        private System.Windows.Forms.TextBox BarCodebeizhuText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BarCodeIDText;
        private System.Windows.Forms.TextBox BarCodeText;
        private System.Windows.Forms.TextBox BarCodeNameText;
        private System.Windows.Forms.Label BC;
        private System.Windows.Forms.Label BCName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}