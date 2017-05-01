namespace TopicManagement.Dialog
{
    partial class frmChangeMark
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangeMark));
            this.btnDeleteMark = new System.Windows.Forms.Button();
            this.btnSaveMark = new System.Windows.Forms.Button();
            this.dgvMarkThesis = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMarkChar = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarkThesis)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteMark
            // 
            this.btnDeleteMark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(130)))), ((int)(((byte)(189)))));
            this.btnDeleteMark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteMark.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteMark.ForeColor = System.Drawing.Color.White;
            this.btnDeleteMark.Location = new System.Drawing.Point(322, 256);
            this.btnDeleteMark.Name = "btnDeleteMark";
            this.btnDeleteMark.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteMark.TabIndex = 5;
            this.btnDeleteMark.Text = "Xóa điểm";
            this.btnDeleteMark.UseVisualStyleBackColor = false;
            this.btnDeleteMark.Click += new System.EventHandler(this.btnDeleteMark_Click);
            // 
            // btnSaveMark
            // 
            this.btnSaveMark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(130)))), ((int)(((byte)(189)))));
            this.btnSaveMark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveMark.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveMark.ForeColor = System.Drawing.Color.White;
            this.btnSaveMark.Location = new System.Drawing.Point(213, 256);
            this.btnSaveMark.Name = "btnSaveMark";
            this.btnSaveMark.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMark.TabIndex = 4;
            this.btnSaveMark.Text = "Lưu điểm";
            this.btnSaveMark.UseVisualStyleBackColor = false;
            this.btnSaveMark.Click += new System.EventHandler(this.btnSaveMark_Click);
            // 
            // dgvMarkThesis
            // 
            this.dgvMarkThesis.AllowUserToAddRows = false;
            this.dgvMarkThesis.AllowUserToDeleteRows = false;
            this.dgvMarkThesis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarkThesis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2});
            this.dgvMarkThesis.Location = new System.Drawing.Point(1, 1);
            this.dgvMarkThesis.Name = "dgvMarkThesis";
            this.dgvMarkThesis.ReadOnly = true;
            this.dgvMarkThesis.Size = new System.Drawing.Size(444, 209);
            this.dgvMarkThesis.TabIndex = 3;
            this.dgvMarkThesis.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarkThesis_CellClick);
            this.dgvMarkThesis.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvMarkThesis_RowsRemoved);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Điểm chữ:";
            // 
            // txtMarkChar
            // 
            this.txtMarkChar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarkChar.Location = new System.Drawing.Point(84, 234);
            this.txtMarkChar.MaxLength = 2;
            this.txtMarkChar.Name = "txtMarkChar";
            this.txtMarkChar.Size = new System.Drawing.Size(38, 21);
            this.txtMarkChar.TabIndex = 7;
            this.txtMarkChar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMin
            // 
            this.txtMin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMin.Location = new System.Drawing.Point(84, 258);
            this.txtMin.MaxLength = 3;
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(38, 21);
            this.txtMin.TabIndex = 9;
            this.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Min:";
            // 
            // txtMax
            // 
            this.txtMax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMax.Location = new System.Drawing.Point(84, 282);
            this.txtMax.MaxLength = 3;
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(38, 22);
            this.txtMax.TabIndex = 11;
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Max:";
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Điểm chữ";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 180;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Điểm số MIN";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "Điểm số MAX";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // frmChangeMark
            // 
            this.AcceptButton = this.btnSaveMark;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(445, 327);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMarkChar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteMark);
            this.Controls.Add(this.btnSaveMark);
            this.Controls.Add(this.dgvMarkThesis);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChangeMark";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật thang điểm đánh giá Luận văn";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarkThesis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteMark;
        private System.Windows.Forms.Button btnSaveMark;
        private System.Windows.Forms.DataGridView dgvMarkThesis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMarkChar;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}