namespace App_sale_manager
{
    partial class Form_doipass_nv
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
            this.lb_doimatkhau_nv = new System.Windows.Forms.Label();
            this.tb_matkhaucu_nv = new System.Windows.Forms.TextBox();
            this.lb_matkhaucu = new System.Windows.Forms.Label();
            this.lb_matkhaumoi = new System.Windows.Forms.Label();
            this.lb_xacnhan = new System.Windows.Forms.Label();
            this.tb_matkhaumoi_nv = new System.Windows.Forms.TextBox();
            this.tb_xacnhan_nv = new System.Windows.Forms.TextBox();
            this.bt_hoantat = new System.Windows.Forms.Button();
            this.bt_thoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_doimatkhau_nv
            // 
            this.lb_doimatkhau_nv.AutoSize = true;
            this.lb_doimatkhau_nv.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_doimatkhau_nv.Location = new System.Drawing.Point(116, 73);
            this.lb_doimatkhau_nv.Name = "lb_doimatkhau_nv";
            this.lb_doimatkhau_nv.Size = new System.Drawing.Size(164, 29);
            this.lb_doimatkhau_nv.TabIndex = 0;
            this.lb_doimatkhau_nv.Text = "Đổi mật khẩu";
            // 
            // tb_matkhaucu_nv
            // 
            this.tb_matkhaucu_nv.Location = new System.Drawing.Point(188, 147);
            this.tb_matkhaucu_nv.Name = "tb_matkhaucu_nv";
            this.tb_matkhaucu_nv.Size = new System.Drawing.Size(197, 22);
            this.tb_matkhaucu_nv.TabIndex = 1;
            this.tb_matkhaucu_nv.UseSystemPasswordChar = true;
            // 
            // lb_matkhaucu
            // 
            this.lb_matkhaucu.AutoSize = true;
            this.lb_matkhaucu.Location = new System.Drawing.Point(48, 152);
            this.lb_matkhaucu.Name = "lb_matkhaucu";
            this.lb_matkhaucu.Size = new System.Drawing.Size(89, 17);
            this.lb_matkhaucu.TabIndex = 0;
            this.lb_matkhaucu.Text = "Mật khẩu cũ:";
            // 
            // lb_matkhaumoi
            // 
            this.lb_matkhaumoi.AutoSize = true;
            this.lb_matkhaumoi.Location = new System.Drawing.Point(48, 205);
            this.lb_matkhaumoi.Name = "lb_matkhaumoi";
            this.lb_matkhaumoi.Size = new System.Drawing.Size(96, 17);
            this.lb_matkhaumoi.TabIndex = 0;
            this.lb_matkhaumoi.Text = "Mật khẩu mới:";
            // 
            // lb_xacnhan
            // 
            this.lb_xacnhan.AutoSize = true;
            this.lb_xacnhan.Location = new System.Drawing.Point(48, 260);
            this.lb_xacnhan.Name = "lb_xacnhan";
            this.lb_xacnhan.Size = new System.Drawing.Size(134, 17);
            this.lb_xacnhan.TabIndex = 0;
            this.lb_xacnhan.Text = "Xác nhận mật khẩu:";
            // 
            // tb_matkhaumoi_nv
            // 
            this.tb_matkhaumoi_nv.Location = new System.Drawing.Point(188, 200);
            this.tb_matkhaumoi_nv.Name = "tb_matkhaumoi_nv";
            this.tb_matkhaumoi_nv.Size = new System.Drawing.Size(197, 22);
            this.tb_matkhaumoi_nv.TabIndex = 1;
            this.tb_matkhaumoi_nv.UseSystemPasswordChar = true;
            this.tb_matkhaumoi_nv.TextChanged += new System.EventHandler(this.tb_matkhaumoi_nv_TextChanged);
            // 
            // tb_xacnhan_nv
            // 
            this.tb_xacnhan_nv.Location = new System.Drawing.Point(188, 255);
            this.tb_xacnhan_nv.Name = "tb_xacnhan_nv";
            this.tb_xacnhan_nv.Size = new System.Drawing.Size(197, 22);
            this.tb_xacnhan_nv.TabIndex = 1;
            this.tb_xacnhan_nv.UseSystemPasswordChar = true;
            // 
            // bt_hoantat
            // 
            this.bt_hoantat.Location = new System.Drawing.Point(89, 341);
            this.bt_hoantat.Name = "bt_hoantat";
            this.bt_hoantat.Size = new System.Drawing.Size(93, 43);
            this.bt_hoantat.TabIndex = 2;
            this.bt_hoantat.Text = "Hoàn tất";
            this.bt_hoantat.UseVisualStyleBackColor = true;
            this.bt_hoantat.Click += new System.EventHandler(this.bt_hoantat_Click);
            // 
            // bt_thoat
            // 
            this.bt_thoat.Location = new System.Drawing.Point(253, 341);
            this.bt_thoat.Name = "bt_thoat";
            this.bt_thoat.Size = new System.Drawing.Size(93, 43);
            this.bt_thoat.TabIndex = 2;
            this.bt_thoat.Text = "Thoat";
            this.bt_thoat.UseVisualStyleBackColor = true;
            this.bt_thoat.Click += new System.EventHandler(this.bt_thoat_Click);
            // 
            // Form_doipass_nv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 500);
            this.Controls.Add(this.bt_thoat);
            this.Controls.Add(this.bt_hoantat);
            this.Controls.Add(this.tb_xacnhan_nv);
            this.Controls.Add(this.tb_matkhaumoi_nv);
            this.Controls.Add(this.tb_matkhaucu_nv);
            this.Controls.Add(this.lb_xacnhan);
            this.Controls.Add(this.lb_matkhaumoi);
            this.Controls.Add(this.lb_matkhaucu);
            this.Controls.Add(this.lb_doimatkhau_nv);
            this.Name = "Form_doipass_nv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_doipass_nv_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_doimatkhau_nv;
        private System.Windows.Forms.TextBox tb_matkhaucu_nv;
        private System.Windows.Forms.Label lb_matkhaucu;
        private System.Windows.Forms.Label lb_matkhaumoi;
        private System.Windows.Forms.Label lb_xacnhan;
        private System.Windows.Forms.TextBox tb_matkhaumoi_nv;
        private System.Windows.Forms.TextBox tb_xacnhan_nv;
        private System.Windows.Forms.Button bt_hoantat;
        private System.Windows.Forms.Button bt_thoat;
    }
}