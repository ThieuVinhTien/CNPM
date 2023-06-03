
namespace App_sale_manager
{
    partial class Form_NhapHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.cbbLoaiSP = new System.Windows.Forms.ComboBox();
            this.lblLoaiID = new System.Windows.Forms.Label();
            this.cbbTenSP = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbDoiTac = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSLNhap = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dgvChiTietNH = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNVNhap = new System.Windows.Forms.TextBox();
            this.txtGiaTriDN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSoHDNH = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMaDT = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietNH)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSP.Location = new System.Drawing.Point(52, 97);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(138, 25);
            this.lblTenSP.TabIndex = 65;
            this.lblTenSP.Text = "Tên sản phẩm";
            // 
            // cbbLoaiSP
            // 
            this.cbbLoaiSP.FormattingEnabled = true;
            this.cbbLoaiSP.Location = new System.Drawing.Point(202, 43);
            this.cbbLoaiSP.Name = "cbbLoaiSP";
            this.cbbLoaiSP.Size = new System.Drawing.Size(337, 28);
            this.cbbLoaiSP.TabIndex = 64;
            this.cbbLoaiSP.SelectedIndexChanged += new System.EventHandler(this.cbbLoaiSP_SelectedIndexChanged);
            this.cbbLoaiSP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbLoaiSP_KeyPress);
            // 
            // lblLoaiID
            // 
            this.lblLoaiID.AutoSize = true;
            this.lblLoaiID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiID.Location = new System.Drawing.Point(52, 46);
            this.lblLoaiID.Name = "lblLoaiID";
            this.lblLoaiID.Size = new System.Drawing.Size(49, 25);
            this.lblLoaiID.TabIndex = 63;
            this.lblLoaiID.Text = "Loại";
            // 
            // cbbTenSP
            // 
            this.cbbTenSP.FormattingEnabled = true;
            this.cbbTenSP.Location = new System.Drawing.Point(202, 94);
            this.cbbTenSP.Name = "cbbTenSP";
            this.cbbTenSP.Size = new System.Drawing.Size(334, 28);
            this.cbbTenSP.TabIndex = 66;
            this.cbbTenSP.SelectedIndexChanged += new System.EventHandler(this.cbbTenSP_SelectedIndexChanged);
            this.cbbTenSP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbTenSP_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 67;
            this.label1.Text = "Đối tác cung cấp";
            // 
            // cbbDoiTac
            // 
            this.cbbDoiTac.FormattingEnabled = true;
            this.cbbDoiTac.Location = new System.Drawing.Point(201, 149);
            this.cbbDoiTac.Name = "cbbDoiTac";
            this.cbbDoiTac.Size = new System.Drawing.Size(314, 28);
            this.cbbDoiTac.TabIndex = 68;
            this.cbbDoiTac.SelectedIndexChanged += new System.EventHandler(this.cbbDoiTac_SelectedIndexChanged);
            this.cbbDoiTac.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbDoiTac_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(591, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 25);
            this.label2.TabIndex = 69;
            this.label2.Text = "Số lượng ";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(741, 46);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.ReadOnly = true;
            this.txtSoLuong.Size = new System.Drawing.Size(198, 26);
            this.txtSoLuong.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 25);
            this.label4.TabIndex = 73;
            this.label4.Text = "Ngày nhập";
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Location = new System.Drawing.Point(201, 97);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(224, 26);
            this.dtpNgayNhap.TabIndex = 74;
            this.dtpNgayNhap.Value = new System.DateTime(2022, 4, 1, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(591, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 25);
            this.label5.TabIndex = 75;
            this.label5.Text = "Số lượng nhập";
            // 
            // txtSLNhap
            // 
            this.txtSLNhap.Location = new System.Drawing.Point(741, 143);
            this.txtSLNhap.Name = "txtSLNhap";
            this.txtSLNhap.Size = new System.Drawing.Size(196, 26);
            this.txtSLNhap.TabIndex = 76;
            this.txtSLNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSLNhap_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 25);
            this.label6.TabIndex = 77;
            this.label6.Text = "Nhân viên nhập";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(156)))), ((int)(((byte)(85)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(768, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 48);
            this.button1.TabIndex = 78;
            this.button1.Text = "Thêm sản phẩm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(156)))), ((int)(((byte)(85)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(768, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 48);
            this.button2.TabIndex = 79;
            this.button2.Text = "Xoá sản phẩm";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(156)))), ((int)(((byte)(85)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(42, 414);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(452, 63);
            this.button3.TabIndex = 80;
            this.button3.Text = "Hoàn tất";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(156)))), ((int)(((byte)(85)))));
            this.button4.Location = new System.Drawing.Point(42, 483);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(452, 63);
            this.button4.TabIndex = 81;
            this.button4.Text = "Huỷ";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dgvChiTietNH
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dgvChiTietNH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTietNH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietNH.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvChiTietNH.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChiTietNH.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(204)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietNH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChiTietNH.ColumnHeadersHeight = 29;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(156)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTietNH.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChiTietNH.EnableHeadersVisualStyles = false;
            this.dgvChiTietNH.Location = new System.Drawing.Point(20, 74);
            this.dgvChiTietNH.Name = "dgvChiTietNH";
            this.dgvChiTietNH.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(156)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietNH.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvChiTietNH.RowHeadersWidth = 51;
            this.dgvChiTietNH.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvChiTietNH.RowTemplate.Height = 24;
            this.dgvChiTietNH.Size = new System.Drawing.Size(921, 297);
            this.dgvChiTietNH.TabIndex = 82;
            this.dgvChiTietNH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietNH_CellClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(15, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 20);
            this.label7.TabIndex = 83;
            this.label7.Text = "THÔNG TIN ĐƠN";
            // 
            // txtNVNhap
            // 
            this.txtNVNhap.Location = new System.Drawing.Point(201, 257);
            this.txtNVNhap.Name = "txtNVNhap";
            this.txtNVNhap.ReadOnly = true;
            this.txtNVNhap.Size = new System.Drawing.Size(314, 26);
            this.txtNVNhap.TabIndex = 84;
            // 
            // txtGiaTriDN
            // 
            this.txtGiaTriDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaTriDN.Location = new System.Drawing.Point(622, 28);
            this.txtGiaTriDN.Name = "txtGiaTriDN";
            this.txtGiaTriDN.ReadOnly = true;
            this.txtGiaTriDN.Size = new System.Drawing.Size(314, 30);
            this.txtGiaTriDN.TabIndex = 86;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(404, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 25);
            this.label8.TabIndex = 85;
            this.label8.Text = "Giá trị đơn nhập";
            // 
            // txtSoHDNH
            // 
            this.txtSoHDNH.Location = new System.Drawing.Point(201, 45);
            this.txtSoHDNH.Name = "txtSoHDNH";
            this.txtSoHDNH.ReadOnly = true;
            this.txtSoHDNH.Size = new System.Drawing.Size(314, 26);
            this.txtSoHDNH.TabIndex = 88;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(30, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 25);
            this.label9.TabIndex = 87;
            this.label9.Text = "Số hoá đơn nhập";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(202, 145);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.ReadOnly = true;
            this.txtMaSP.Size = new System.Drawing.Size(337, 26);
            this.txtMaSP.TabIndex = 92;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(52, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 25);
            this.label10.TabIndex = 91;
            this.label10.Text = "Mã Sản Phẩm";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(201, 309);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.ReadOnly = true;
            this.txtMaNV.Size = new System.Drawing.Size(314, 26);
            this.txtMaNV.TabIndex = 94;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(30, 315);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 25);
            this.label11.TabIndex = 93;
            this.label11.Text = "Mã nhân viên";
            // 
            // txtMaDT
            // 
            this.txtMaDT.Location = new System.Drawing.Point(201, 205);
            this.txtMaDT.Name = "txtMaDT";
            this.txtMaDT.ReadOnly = true;
            this.txtMaDT.Size = new System.Drawing.Size(314, 26);
            this.txtMaDT.TabIndex = 96;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(30, 209);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 25);
            this.label12.TabIndex = 95;
            this.label12.Text = "Mã đối tác";
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Location = new System.Drawing.Point(741, 95);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.ReadOnly = true;
            this.txtGiaNhap.Size = new System.Drawing.Size(198, 26);
            this.txtGiaNhap.TabIndex = 98;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(591, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 25);
            this.label3.TabIndex = 97;
            this.label3.Text = "Giá Nhập";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtGiaNhap);
            this.panel1.Controls.Add(this.cbbLoaiSP);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblLoaiID);
            this.panel1.Controls.Add(this.lblTenSP);
            this.panel1.Controls.Add(this.cbbTenSP);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtMaSP);
            this.panel1.Controls.Add(this.txtSoLuong);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtSLNhap);
            this.panel1.Location = new System.Drawing.Point(15, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 248);
            this.panel1.TabIndex = 99;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label14.Location = new System.Drawing.Point(14, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(186, 20);
            this.label14.TabIndex = 83;
            this.label14.Text = "TÌM KIẾM HÀNG HÓA";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label13.Location = new System.Drawing.Point(15, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(235, 20);
            this.label13.TabIndex = 83;
            this.label13.Text = "CHI TIẾT ĐƠN NHẬP HÀNG";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtGiaTriDN);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(15, 658);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(978, 95);
            this.panel2.TabIndex = 100;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtSoHDNH);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cbbDoiTac);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.txtMaDT);
            this.panel3.Controls.Add(this.dtpNgayNhap);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtMaNV);
            this.panel3.Controls.Add(this.txtNVNhap);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(1012, 15);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(537, 571);
            this.panel3.TabIndex = 101;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.dgvChiTietNH);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Location = new System.Drawing.Point(14, 277);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(978, 374);
            this.panel4.TabIndex = 102;
            // 
            // Form_NhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1558, 760);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_NhapHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietNH)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.ComboBox cbbLoaiSP;
        private System.Windows.Forms.Label lblLoaiID;
        private System.Windows.Forms.ComboBox cbbTenSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbDoiTac;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSLNhap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dgvChiTietNH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNVNhap;
        private System.Windows.Forms.TextBox txtGiaTriDN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSoHDNH;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMaDT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}