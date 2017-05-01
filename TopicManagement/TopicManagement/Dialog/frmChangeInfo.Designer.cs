namespace TopicManagement.Dialog
{
    partial class frmChangeInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangeInfo));
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.btnRePress = new System.Windows.Forms.Button();
            this.btnSavePass = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRePressCodeInstructor = new System.Windows.Forms.Button();
            this.txtConfirmCodeInstructor = new System.Windows.Forms.TextBox();
            this.txtNewCodeInstructor = new System.Windows.Forms.TextBox();
            this.btnSaveCodeInstructor = new System.Windows.Forms.Button();
            this.txtOldCodeInstructor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtConfirmPass.Location = new System.Drawing.Point(150, 84);
            this.txtConfirmPass.MaxLength = 16;
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(134, 21);
            this.txtConfirmPass.TabIndex = 3;
            this.txtConfirmPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Xác nhận mật khẩu mới:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Mật khẩu mới:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Mật khẩu cũ:";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtNewPass.Location = new System.Drawing.Point(150, 59);
            this.txtNewPass.MaxLength = 16;
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(134, 21);
            this.txtNewPass.TabIndex = 2;
            this.txtNewPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // txtOldPass
            // 
            this.txtOldPass.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtOldPass.Location = new System.Drawing.Point(150, 33);
            this.txtOldPass.MaxLength = 16;
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.Size = new System.Drawing.Size(134, 21);
            this.txtOldPass.TabIndex = 1;
            this.txtOldPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOldPass.UseSystemPasswordChar = true;
            // 
            // btnRePress
            // 
            this.btnRePress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(130)))), ((int)(((byte)(189)))));
            this.btnRePress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRePress.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRePress.ForeColor = System.Drawing.Color.White;
            this.btnRePress.Location = new System.Drawing.Point(175, 117);
            this.btnRePress.Name = "btnRePress";
            this.btnRePress.Size = new System.Drawing.Size(75, 23);
            this.btnRePress.TabIndex = 5;
            this.btnRePress.Text = "Nhập lại";
            this.btnRePress.UseVisualStyleBackColor = false;
            this.btnRePress.Click += new System.EventHandler(this.btnRePress_Click);
            // 
            // btnSavePass
            // 
            this.btnSavePass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(130)))), ((int)(((byte)(189)))));
            this.btnSavePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSavePass.ForeColor = System.Drawing.Color.White;
            this.btnSavePass.Location = new System.Drawing.Point(94, 117);
            this.btnSavePass.Name = "btnSavePass";
            this.btnSavePass.Size = new System.Drawing.Size(75, 23);
            this.btnSavePass.TabIndex = 4;
            this.btnSavePass.Text = "Lưu";
            this.btnSavePass.UseVisualStyleBackColor = false;
            this.btnSavePass.Click += new System.EventHandler(this.btnSavePass_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtConfirmPass);
            this.groupBox1.Controls.Add(this.btnSavePass);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnRePress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOldPass);
            this.groupBox1.Controls.Add(this.txtNewPass);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 146);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thay đổi mật khẩu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnRePressCodeInstructor);
            this.groupBox2.Controls.Add(this.txtConfirmCodeInstructor);
            this.groupBox2.Controls.Add(this.txtNewCodeInstructor);
            this.groupBox2.Controls.Add(this.btnSaveCodeInstructor);
            this.groupBox2.Controls.Add(this.txtOldCodeInstructor);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(7, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 140);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thay đổi mã giảng viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Mã giảng viên cũ:";
            // 
            // btnRePressCodeInstructor
            // 
            this.btnRePressCodeInstructor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(130)))), ((int)(((byte)(189)))));
            this.btnRePressCodeInstructor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRePressCodeInstructor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRePressCodeInstructor.ForeColor = System.Drawing.Color.White;
            this.btnRePressCodeInstructor.Location = new System.Drawing.Point(175, 111);
            this.btnRePressCodeInstructor.Name = "btnRePressCodeInstructor";
            this.btnRePressCodeInstructor.Size = new System.Drawing.Size(75, 23);
            this.btnRePressCodeInstructor.TabIndex = 19;
            this.btnRePressCodeInstructor.Text = "Nhập lại";
            this.btnRePressCodeInstructor.UseVisualStyleBackColor = false;
            this.btnRePressCodeInstructor.Click += new System.EventHandler(this.btnRePressCodeInstructor_Click);
            // 
            // txtConfirmCodeInstructor
            // 
            this.txtConfirmCodeInstructor.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtConfirmCodeInstructor.Location = new System.Drawing.Point(150, 78);
            this.txtConfirmCodeInstructor.MaxLength = 8;
            this.txtConfirmCodeInstructor.Name = "txtConfirmCodeInstructor";
            this.txtConfirmCodeInstructor.Size = new System.Drawing.Size(133, 21);
            this.txtConfirmCodeInstructor.TabIndex = 17;
            this.txtConfirmCodeInstructor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNewCodeInstructor
            // 
            this.txtNewCodeInstructor.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtNewCodeInstructor.Location = new System.Drawing.Point(150, 53);
            this.txtNewCodeInstructor.MaxLength = 8;
            this.txtNewCodeInstructor.Name = "txtNewCodeInstructor";
            this.txtNewCodeInstructor.Size = new System.Drawing.Size(133, 21);
            this.txtNewCodeInstructor.TabIndex = 16;
            this.txtNewCodeInstructor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSaveCodeInstructor
            // 
            this.btnSaveCodeInstructor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(130)))), ((int)(((byte)(189)))));
            this.btnSaveCodeInstructor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveCodeInstructor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSaveCodeInstructor.ForeColor = System.Drawing.Color.White;
            this.btnSaveCodeInstructor.Location = new System.Drawing.Point(93, 111);
            this.btnSaveCodeInstructor.Name = "btnSaveCodeInstructor";
            this.btnSaveCodeInstructor.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCodeInstructor.TabIndex = 18;
            this.btnSaveCodeInstructor.Text = "Lưu";
            this.btnSaveCodeInstructor.UseVisualStyleBackColor = false;
            this.btnSaveCodeInstructor.Click += new System.EventHandler(this.btnSaveCodeInstructor_Click);
            // 
            // txtOldCodeInstructor
            // 
            this.txtOldCodeInstructor.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtOldCodeInstructor.Location = new System.Drawing.Point(150, 27);
            this.txtOldCodeInstructor.MaxLength = 8;
            this.txtOldCodeInstructor.Name = "txtOldCodeInstructor";
            this.txtOldCodeInstructor.Size = new System.Drawing.Size(133, 21);
            this.txtOldCodeInstructor.TabIndex = 15;
            this.txtOldCodeInstructor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Xác nhận mã GV mới:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Mã giảng viên mới:";
            // 
            // frmChangeInfo
            // 
            this.AcceptButton = this.btnSavePass;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(302, 301);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChangeInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi thông tin cá nhân";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Button btnRePress;
        private System.Windows.Forms.Button btnSavePass;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRePressCodeInstructor;
        private System.Windows.Forms.TextBox txtConfirmCodeInstructor;
        private System.Windows.Forms.TextBox txtNewCodeInstructor;
        private System.Windows.Forms.Button btnSaveCodeInstructor;
        private System.Windows.Forms.TextBox txtOldCodeInstructor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}