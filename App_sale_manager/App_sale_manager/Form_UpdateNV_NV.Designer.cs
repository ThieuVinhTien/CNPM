namespace App_sale_manager
{
    partial class Form_UpdateNV_NV
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
            this.label1 = new System.Windows.Forms.Label();
            this.bt_Sua = new System.Windows.Forms.Button();
            this.dt_Ngaysinh = new System.Windows.Forms.DateTimePicker();
            this.tb_Hoten = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_sdt = new System.Windows.Forms.TextBox();
            this.bt_Huy = new System.Windows.Forms.Button();
            this.lb_username = new System.Windows.Forms.Label();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin cá nhân";
            // 
            // bt_Sua
            // 
            this.bt_Sua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(156)))), ((int)(((byte)(85)))));
            this.bt_Sua.FlatAppearance.BorderSize = 0;
            this.bt_Sua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Sua.ForeColor = System.Drawing.Color.White;
            this.bt_Sua.Location = new System.Drawing.Point(99, 438);
            this.bt_Sua.Name = "bt_Sua";
            this.bt_Sua.Size = new System.Drawing.Size(300, 37);
            this.bt_Sua.TabIndex = 1;
            this.bt_Sua.Text = "Xác nhận";
            this.bt_Sua.UseVisualStyleBackColor = false;
            this.bt_Sua.Click += new System.EventHandler(this.bt_Sua_Click);
            // 
            // dt_Ngaysinh
            // 
            this.dt_Ngaysinh.CustomFormat = "dd/MM/yyyy";
            this.dt_Ngaysinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_Ngaysinh.Location = new System.Drawing.Point(99, 227);
            this.dt_Ngaysinh.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dt_Ngaysinh.Name = "dt_Ngaysinh";
            this.dt_Ngaysinh.Size = new System.Drawing.Size(300, 25);
            this.dt_Ngaysinh.TabIndex = 2;
            this.dt_Ngaysinh.Value = new System.DateTime(1900, 1, 1, 22, 9, 0, 0);
            // 
            // tb_Hoten
            // 
            this.tb_Hoten.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Hoten.Location = new System.Drawing.Point(99, 153);
            this.tb_Hoten.Name = "tb_Hoten";
            this.tb_Hoten.Size = new System.Drawing.Size(300, 18);
            this.tb_Hoten.TabIndex = 3;
            this.tb_Hoten.TextChanged += new System.EventHandler(this.tb_Hoten_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(95, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ và tên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(96, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày sinh:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(96, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Số điện thoại:";
            // 
            // tb_sdt
            // 
            this.tb_sdt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_sdt.Location = new System.Drawing.Point(98, 301);
            this.tb_sdt.Name = "tb_sdt";
            this.tb_sdt.Size = new System.Drawing.Size(300, 18);
            this.tb_sdt.TabIndex = 3;
            this.tb_sdt.TextChanged += new System.EventHandler(this.tb_sdt_TextChanged);
            this.tb_sdt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_sdt_KeyPress);
            this.tb_sdt.Leave += new System.EventHandler(this.tb_sdt_Leave);
            // 
            // bt_Huy
            // 
            this.bt_Huy.BackColor = System.Drawing.Color.White;
            this.bt_Huy.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bt_Huy.FlatAppearance.BorderSize = 0;
            this.bt_Huy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Huy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Huy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(156)))), ((int)(((byte)(85)))));
            this.bt_Huy.Location = new System.Drawing.Point(99, 481);
            this.bt_Huy.Name = "bt_Huy";
            this.bt_Huy.Size = new System.Drawing.Size(300, 37);
            this.bt_Huy.TabIndex = 4;
            this.bt_Huy.Text = "Thoát";
            this.bt_Huy.UseVisualStyleBackColor = false;
            this.bt_Huy.Click += new System.EventHandler(this.bt_Huy_Click);
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_username.Location = new System.Drawing.Point(96, 352);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(96, 20);
            this.lb_username.TabIndex = 5;
            this.lb_username.Text = "Username:";
            // 
            // tb_username
            // 
            this.tb_username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_username.Location = new System.Drawing.Point(99, 378);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(300, 18);
            this.tb_username.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(156)))), ((int)(((byte)(85)))));
            this.panel4.Location = new System.Drawing.Point(99, 176);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 2);
            this.panel4.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(156)))), ((int)(((byte)(85)))));
            this.panel1.Location = new System.Drawing.Point(99, 250);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 2);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(156)))), ((int)(((byte)(85)))));
            this.panel2.Location = new System.Drawing.Point(99, 324);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 2);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(156)))), ((int)(((byte)(85)))));
            this.panel3.Location = new System.Drawing.Point(99, 401);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 2);
            this.panel3.TabIndex = 18;
            // 
            // Form_UpdateNV_NV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(510, 530);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.lb_username);
            this.Controls.Add(this.bt_Huy);
            this.Controls.Add(this.tb_sdt);
            this.Controls.Add(this.tb_Hoten);
            this.Controls.Add(this.dt_Ngaysinh);
            this.Controls.Add(this.bt_Sua);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form_UpdateNV_NV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉnh sửa thông tin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_UpdateNV_NV_FormClosed);
            this.Load += new System.EventHandler(this.Form_UpdateNV_NV_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_Sua;
        private System.Windows.Forms.DateTimePicker dt_Ngaysinh;
        private System.Windows.Forms.TextBox tb_Hoten;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_sdt;
        private System.Windows.Forms.Button bt_Huy;
        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}