namespace App_sale_manager
{
    partial class Form_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_login));
            this.label_tiltle_login = new System.Windows.Forms.Label();
            this.textBox_usr = new System.Windows.Forms.TextBox();
            this.textBox_passwd = new System.Windows.Forms.TextBox();
            this.btn_dangnhap = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkNhopass = new System.Windows.Forms.CheckBox();
            this.ptbPass = new System.Windows.Forms.PictureBox();
            this.ptbUser = new System.Windows.Forms.PictureBox();
            this.ptbHienthi = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTieude = new System.Windows.Forms.Label();
            this.ptbTieude = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbHienthi)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTieude)).BeginInit();
            this.SuspendLayout();
            // 
            // label_tiltle_login
            // 
            this.label_tiltle_login.AutoSize = true;
            this.label_tiltle_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tiltle_login.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_tiltle_login.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label_tiltle_login.Location = new System.Drawing.Point(57, 180);
            this.label_tiltle_login.Name = "label_tiltle_login";
            this.label_tiltle_login.Size = new System.Drawing.Size(250, 29);
            this.label_tiltle_login.TabIndex = 6;
            this.label_tiltle_login.Text = "Đăng nhập tài khoản";
            this.label_tiltle_login.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox_usr
            // 
            this.textBox_usr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_usr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox_usr.ForeColor = System.Drawing.Color.DodgerBlue;
            this.textBox_usr.Location = new System.Drawing.Point(116, 252);
            this.textBox_usr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_usr.Name = "textBox_usr";
            this.textBox_usr.Size = new System.Drawing.Size(330, 25);
            this.textBox_usr.TabIndex = 2;
            this.textBox_usr.TabStop = false;
            this.textBox_usr.Tag = "0";
            this.textBox_usr.Text = "username";
            this.textBox_usr.Enter += new System.EventHandler(this.textBox_usr_Enter);
            this.textBox_usr.Leave += new System.EventHandler(this.textBox_usr_Leave);
            // 
            // textBox_passwd
            // 
            this.textBox_passwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_passwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox_passwd.ForeColor = System.Drawing.Color.DodgerBlue;
            this.textBox_passwd.Location = new System.Drawing.Point(116, 335);
            this.textBox_passwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_passwd.Name = "textBox_passwd";
            this.textBox_passwd.Size = new System.Drawing.Size(330, 25);
            this.textBox_passwd.TabIndex = 3;
            this.textBox_passwd.TabStop = false;
            this.textBox_passwd.Tag = "0";
            this.textBox_passwd.Text = "password";
            this.textBox_passwd.Enter += new System.EventHandler(this.textBox_passwd_Enter);
            this.textBox_passwd.Leave += new System.EventHandler(this.textBox_passwd_Leave);
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_dangnhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dangnhap.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_dangnhap.Location = new System.Drawing.Point(63, 458);
            this.btn_dangnhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(428, 55);
            this.btn_dangnhap.TabIndex = 5;
            this.btn_dangnhap.Text = "Đăng nhập";
            this.btn_dangnhap.UseVisualStyleBackColor = false;
            this.btn_dangnhap.Click += new System.EventHandler(this.btn_dangnhap_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.BackColor = System.Drawing.Color.White;
            this.btn_thoat.FlatAppearance.BorderSize = 0;
            this.btn_thoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thoat.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btn_thoat.Location = new System.Drawing.Point(63, 532);
            this.btn_thoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(428, 55);
            this.btn_thoat.TabIndex = 5;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = false;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Location = new System.Drawing.Point(63, 298);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 2);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Location = new System.Drawing.Point(63, 382);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(428, 2);
            this.panel2.TabIndex = 10;
            // 
            // chkNhopass
            // 
            this.chkNhopass.AutoSize = true;
            this.chkNhopass.BackColor = System.Drawing.Color.White;
            this.chkNhopass.Checked = true;
            this.chkNhopass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNhopass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkNhopass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkNhopass.ForeColor = System.Drawing.Color.DodgerBlue;
            this.chkNhopass.Location = new System.Drawing.Point(63, 412);
            this.chkNhopass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkNhopass.Name = "chkNhopass";
            this.chkNhopass.Size = new System.Drawing.Size(166, 29);
            this.chkNhopass.TabIndex = 11;
            this.chkNhopass.Text = "Nhớ tài khoản";
            this.chkNhopass.UseVisualStyleBackColor = false;
            // 
            // ptbPass
            // 
            this.ptbPass.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptbPass.BackgroundImage")));
            this.ptbPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbPass.Location = new System.Drawing.Point(63, 325);
            this.ptbPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ptbPass.Name = "ptbPass";
            this.ptbPass.Size = new System.Drawing.Size(46, 50);
            this.ptbPass.TabIndex = 9;
            this.ptbPass.TabStop = false;
            // 
            // ptbUser
            // 
            this.ptbUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptbUser.BackgroundImage")));
            this.ptbUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbUser.Location = new System.Drawing.Point(63, 240);
            this.ptbUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ptbUser.Name = "ptbUser";
            this.ptbUser.Size = new System.Drawing.Size(46, 50);
            this.ptbUser.TabIndex = 9;
            this.ptbUser.TabStop = false;
            // 
            // ptbHienthi
            // 
            this.ptbHienthi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ptbHienthi.Image = global::App_sale_manager.Properties.Resources.matdong;
            this.ptbHienthi.Location = new System.Drawing.Point(452, 335);
            this.ptbHienthi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ptbHienthi.Name = "ptbHienthi";
            this.ptbHienthi.Size = new System.Drawing.Size(46, 40);
            this.ptbHienthi.TabIndex = 8;
            this.ptbHienthi.TabStop = false;
            this.ptbHienthi.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.Controls.Add(this.lblTieude);
            this.panel3.Controls.Add(this.ptbTieude);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(600, 150);
            this.panel3.TabIndex = 12;
            // 
            // lblTieude
            // 
            this.lblTieude.AutoSize = true;
            this.lblTieude.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieude.ForeColor = System.Drawing.Color.White;
            this.lblTieude.Location = new System.Drawing.Point(133, 39);
            this.lblTieude.Name = "lblTieude";
            this.lblTieude.Size = new System.Drawing.Size(307, 76);
            this.lblTieude.TabIndex = 1;
            this.lblTieude.Text = "Phần mềm \r\nQuản lí Siêu thị N7";
            this.lblTieude.Click += new System.EventHandler(this.lblTieude_Click);
            // 
            // ptbTieude
            // 
            this.ptbTieude.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptbTieude.BackgroundImage")));
            this.ptbTieude.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbTieude.Location = new System.Drawing.Point(15, 16);
            this.ptbTieude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ptbTieude.Name = "ptbTieude";
            this.ptbTieude.Size = new System.Drawing.Size(112, 118);
            this.ptbTieude.TabIndex = 0;
            this.ptbTieude.TabStop = false;
            // 
            // Form_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 625);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.chkNhopass);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ptbPass);
            this.Controls.Add(this.ptbUser);
            this.Controls.Add(this.ptbHienthi);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_dangnhap);
            this.Controls.Add(this.textBox_passwd);
            this.Controls.Add(this.textBox_usr);
            this.Controls.Add(this.label_tiltle_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.Form_login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbHienthi)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTieude)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_tiltle_login;
        private System.Windows.Forms.TextBox textBox_usr;
        private System.Windows.Forms.TextBox textBox_passwd;
        private System.Windows.Forms.Button btn_dangnhap;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.PictureBox ptbHienthi;
        private System.Windows.Forms.PictureBox ptbUser;
        private System.Windows.Forms.PictureBox ptbPass;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkNhopass;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTieude;
        private System.Windows.Forms.PictureBox ptbTieude;
    }
}

