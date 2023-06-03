using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_NhapHang : Form
    {
        public string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        public SqlConnection sqlCon = null;
        public static SqlDataAdapter adapter = null;
        private DataTable tbSP = new DataTable();
        private DateTime d = new DateTime();

        public Form_NhapHang(string manv, string tennv)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            LoadCBB();
            txtSoHDNH.Text = LoadMaDN();
            txtNVNhap.Text = tennv;
            txtMaNV.Text = manv;
            txtMaDT.Text = LayIDDoiTac();
            txtSLNhap.ReadOnly = false;
            d = DateTime.Now;
            dtpNgayNhap.Value = d;
            tbSP.Columns.Add("SPID", typeof(string));
            tbSP.Columns.Add("SL", typeof(int));
            tbSP.Columns.Add("GiaNhap", typeof(double));
        }

        private void LoadCBB()
        {
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            adapter = new SqlDataAdapter("select TENLOAI from [LOAISP] group by TENLOAI", sqlCon);
            DataTable tableLoai = new DataTable();
            adapter.Fill(tableLoai);
            cbbLoaiSP.DataSource = tableLoai;
            cbbLoaiSP.DisplayMember = "TenLoai";
            cbbLoaiSP.ValueMember = "TenLoai";
            adapter = new SqlDataAdapter("select TENDT from [DTCC] group by TENDT", sqlCon);
            DataTable tableDoiTac = new DataTable();
            adapter.Fill(tableDoiTac);
            cbbDoiTac.DataSource = tableDoiTac;
            cbbDoiTac.DisplayMember = "TENDT";
            cbbDoiTac.ValueMember = "TENDT";
            adapter = new SqlDataAdapter("select TENSP from SANPHAM,LOAISP where SANPHAM.LOAIID=LOAISP.LOAIID and LOAISP.TENLOAI='" + cbbLoaiSP.Text + "'", sqlCon);
            DataTable tableTenSP = new DataTable();
            adapter.Fill(tableTenSP);
            cbbTenSP.DataSource = tableTenSP;
            cbbTenSP.DisplayMember = "TENSP";
            cbbTenSP.ValueMember = "TENSP";
            sqlCon.Close();
        }

        private void LoadDonNhap(string MaDonNhap)
        {
            if (MaDonNhap != string.Empty)
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                adapter = new SqlDataAdapter("select SPID,SL from CTHDNH where SOHD_NH=" + MaDonNhap, sqlCon);
                DataTable tableSPNH = new DataTable();
                adapter.Fill(tableSPNH);
                dgvChiTietNH.DataSource = tableSPNH;
                sqlCon.Close();
            }
        }

        private string LoadMaDN()
        {
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("select count(SOHD_NH) from HDNH", sqlCon);
            int madn = 0;
            var reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                madn = reader.GetInt32(0);
                reader.Close();
            }
            while (true)
            {
                sqlCmd = new SqlCommand("SELECT SOHD_NH from HDNH where 'NH" + madn + "' in (select SOHD_NH from HDNH) ", sqlCon);

                var reader1 = sqlCmd.ExecuteReader();
                if (reader1.Read())
                {
                    if (!reader1.IsDBNull(0))
                        madn++;
                }
                else break;
                reader1.Close();
            }
            sqlCon.Close();
            return "NH" + madn.ToString();
        }

        private void cbbLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            adapter = new SqlDataAdapter("select TENSP from SANPHAM,LOAISP where SANPHAM.LOAIID=LOAISP.LOAIID and LOAISP.TENLOAI=N'" + cbbLoaiSP.Text + "'", sqlCon);
            DataTable tableTenSP = new DataTable();
            adapter.Fill(tableTenSP);
            cbbTenSP.DataSource = tableTenSP;
            cbbTenSP.DisplayMember = "TENSP";
            cbbTenSP.ValueMember = "TENSP";
            sqlCon.Close();
        }

        private void cbbTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            adapter = new SqlDataAdapter("select SoLuong,SPID,GIANHAP from SANPHAM Where TENSP = N'" + cbbTenSP.Text + "'", sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            txtSoLuong.Text = table.Rows[0][0].ToString();
            txtMaSP.Text = table.Rows[0][1].ToString();
            txtGiaNhap.Text = string.Format("{0:0,0}", Convert.ToDouble(table.Rows[0][2].ToString()));
            sqlCon.Close();
        }

        private void dgvChiTietNH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("select LOAISP.TENLOAI,SANPHAM.TENSP,SANPHAM.SPID,SANPHAM.SOLUONG,SANPHAM.GIANHAP from SANPHAM,LOAISP where SANPHAM.SPID=N'" + dgvChiTietNH.CurrentRow.Cells["SPID"].Value.ToString() + "' and LOAISP.LOAIID=SANPHAM.LOAIID", sqlCon);
            var reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                cbbLoaiSP.Text = reader.GetString(0);
                cbbTenSP.Text = reader.GetString(1);
                txtMaSP.Text = reader.GetString(2);
                txtSoLuong.Text = reader.GetInt32(3).ToString();
                string x = reader.GetSqlMoney(4).ToString();
                txtGiaNhap.Text = string.Format("{0:0,0}", Convert.ToDouble(x));
                txtSLNhap.Text = dgvChiTietNH.CurrentRow.Cells[1].Value.ToString();
            }

            sqlCon.Close();
        }

        private void LoadDonNhap()
        {
            if (txtSoHDNH.Text != string.Empty)
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                adapter = new SqlDataAdapter("select SANPHAM.SPID,CTHDNH.SL,REPLACE(CONVERT(varchar(20),SANPHAM.GIANHAP, 1), '.00','') from CTHDNH,SANPHAM,HDNH where SANPHAM.SPID=CTHDNH.SPID and CTHDNH.SOHD_NH=HDNH.SOHD_NH and CTHDNH.SOHD_NH=" + txtSoHDNH.Text, sqlCon);

                DataTable tableSPNH = new DataTable();
                adapter.Fill(tableSPNH);
                dgvChiTietNH.DataSource = tableSPNH;
                dgvChiTietNH.Columns[0].HeaderText = "Mã Sản Phẩm";
                dgvChiTietNH.Columns[1].HeaderText = "Số Lượng Nhập";
                dgvChiTietNH.Columns[2].HeaderText = "Đơn giá nhập";
                sqlCon.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvChiTietNH.AllowUserToAddRows = false;
            if (txtSLNhap.Text != string.Empty)
            {
                if (!KiemTraHangTrung(txtMaSP.Text))
                    tbSP.Rows.Add(txtMaSP.Text, txtSLNhap.Text, txtGiaNhap.Text);
                else MessageBox.Show("Đã có sản phẩm này");
            }
            else MessageBox.Show("Chưa nhập số lượng");
            dgvChiTietNH.DataSource = tbSP;
            dgvChiTietNH.Columns[0].HeaderText = "Mã Sản Phẩm";
            dgvChiTietNH.Columns[1].HeaderText = "Số Lượng Nhập";
            dgvChiTietNH.Columns[2].HeaderText = "Đơn giá nhập";
            dgvChiTietNH.Columns[2].DefaultCellStyle.Format = "N0";
            string x = LayGia();
            txtGiaTriDN.Text = string.Format("{0:0,0}", Convert.ToDouble(x.Replace(",", string.Empty)));
        }

        private bool KiemTraHangTrung(string spid)
        {
            for (int i = 0; i < dgvChiTietNH.RowCount; i++)
            {
                if (spid == dgvChiTietNH.Rows[i].Cells["SPID"].Value.ToString())
                    return true;
            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvChiTietNH.RowCount; i++)
            {
                if (dgvChiTietNH.Rows[i].Cells[0].Value.ToString() == dgvChiTietNH.CurrentRow.Cells[0].Value.ToString())
                    dgvChiTietNH.Rows.RemoveAt(i);
            }

            string x = LayGia();
            txtGiaTriDN.Text = string.Format("{0:0,0}", Convert.ToDouble(x.Replace(",", string.Empty)));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string LayIDDoiTac()
        {
            string id = string.Empty;
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("select DTID from DTCC where TENDT=N'" + cbbDoiTac.Text + "'", sqlCon);
            var reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            { id = reader.GetString(0); }
            sqlCon.Close();
            return id;
        }

        private string LayGia()
        {
            double gia = 0;
            for (int i = 0; i < dgvChiTietNH.RowCount; i++)
            {
                if (dgvChiTietNH.Rows[i] != null)
                    gia = gia + int.Parse(dgvChiTietNH.Rows[i].Cells["SL"].Value.ToString()) * double.Parse(dgvChiTietNH.Rows[i].Cells["GiaNhap"].Value.ToString());
            }

            return gia.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string x = LayGia();
            if (txtMaDT.Text == string.Empty || txtMaNV.Text == string.Empty || txtGiaTriDN.Text == string.Empty || txtSoHDNH.Text == string.Empty)
            {
                MessageBox.Show("Chưa đủ thông tin");
                return;
            }
            else if (txtGiaTriDN.Text == "0")
            {
                MessageBox.Show("Chưa chọn hàng hoá để nhập");
                return;
            }
            else
            {
                sqlCon.Open();
                string strquery = "insert into HDNH values('" + txtSoHDNH.Text + "','" + dtpNgayNhap.Value.ToString("MM/dd/yyyy HH:mm:ss") + "','" + txtMaDT.Text + "','" + txtMaNV.Text + "'," + x + ")";
                SqlCommand sqlCmd;
                sqlCmd = new SqlCommand(strquery, sqlCon);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
                for (int i = 0; i < dgvChiTietNH.Rows.Count; i++)
                {
                    if (dgvChiTietNH.Rows[i] != null)
                    {
                        sqlCon.Open();
                        strquery = "insert into CTHDNH values('" + txtSoHDNH.Text + "','" + dgvChiTietNH.Rows[i].Cells["SPID"].Value.ToString() + "'," + dgvChiTietNH.Rows[i].Cells["SL"].Value.ToString() + ")";
                        sqlCmd = new SqlCommand(strquery, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }
                TangSL();
                MessageBox.Show("Đơn hàng nhập thành công");
                this.Close();
            }
        }

        private void TangSL()
        {
            for (int i = 0; i < dgvChiTietNH.Rows.Count; i++)
            {
                if (dgvChiTietNH.Rows[i] != null)
                {
                    sqlCon.Open();
                    string strquery = "update SANPHAM set SoLuong = SoLuong + " + dgvChiTietNH.Rows[i].Cells["SL"].Value.ToString() + " where SPID=N'" + dgvChiTietNH.Rows[i].Cells["SPID"].Value.ToString() + "'";
                    SqlCommand sqlCmd;
                    sqlCmd = new SqlCommand(strquery, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
        }

        private void cbbDoiTac_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaDT.Text = LayIDDoiTac();
        }

        private void txtSLNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (Char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số");
            }
        }

        private void cbbDoiTac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbbLoaiSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbbTenSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}