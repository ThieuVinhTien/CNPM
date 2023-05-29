using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_HoaDonNH : Form
    {
        public string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        public SqlConnection sqlCon = null;
        public static SqlDataAdapter adapter = null;
        private string manv = string.Empty;
        private string tennv = string.Empty;

        public Form_HoaDonNH(string manv, string tennv)
        {
            this.tennv = tennv;
            this.manv = manv;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            LoadCBBDN();
            LoadHDNH();
        }

        public DataTable TimKiemHD()
        {
            DataTable tb = new DataTable();
            string query = string.Empty;
            if (txtTriGia.Text == string.Empty)
                query = "select HDNH.SOHD_NH,HDNH.NGNHAP,DTCC.TENDT,NHANVIEN.HOTEN,REPLACE(CONVERT(varchar(20), HDNH.TRIGIA, 1), '.00', '') from HDNH,DTCC,NHANVIEN where HDNH.DTID = DTCC.DTID and HDNH.NVID = NHANVIEN.NVID and NHANVIEN.NVID like N'%" +
                        txtNVID.Text + "%' and HDNH.SOHD_NH like N'%" + txtMaHDNH.Text + "%' and DTCC.DTID like N'%" + txtDTID.Text + "%'";
            else
                query = "select HDNH.SOHD_NH,HDNH.NGNHAP,DTCC.TENDT,NHANVIEN.HOTEN,REPLACE(CONVERT(varchar(20), HDNH.TRIGIA, 1), '.00', '') from HDNH,DTCC,NHANVIEN where HDNH.DTID = DTCC.DTID and HDNH.NVID = NHANVIEN.NVID and NHANVIEN.NVID like N'%" +
                       txtNVID.Text + "%' and HDNH.SOHD_NH like N'%" + txtMaHDNH.Text + "%' and DTCC.DTID like N'%" + txtDTID.Text + "%' and TRIGIA > " + txtTriGia.Text;

            adapter = new SqlDataAdapter(query, sqlCon);
            adapter.Fill(tb);
            sqlCon.Close();
            return tb;
        }

        private void DinhDangdgvHDNH()
        {
            dgvHDHN.Columns[0].HeaderText = "Số hoá đơn nhập";
            dgvHDHN.Columns[1].HeaderText = "Ngày nhập";
            dgvHDHN.Columns[2].HeaderText = "Tên đối tác";
            dgvHDHN.Columns[3].HeaderText = "Tên nhân viên nhập";
            dgvHDHN.Columns[4].HeaderText = "Giá trị ";
        }

        private void LoadHDNH()
        {
            sqlCon = new SqlConnection(strCon);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCon.Open();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select SOHD_NH,NGNHAP,TENDT,HOTEN,REPLACE(CONVERT(varchar(20), TRIGIA, 1), '.00', '') from HDNH,DTCC,NHANVIEN where HDNH.DTID=DTCC.DTID and HDNH.NVID=NHANVIEN.NVID";
            sqlCmd.Connection = sqlCon;
            adapter = new SqlDataAdapter(sqlCmd);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataTable tbHDNH = new DataTable();
            tbHDNH.Clear();
            adapter.Fill(tbHDNH);
            dgvHDHN.DataSource = tbHDNH;
            sqlCon.Close();
            DinhDangdgvHDNH();
            ClearCBBDN();
        }

        private void LoadCBBDN()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            adapter = new SqlDataAdapter("select HOTEN from NHANVIEN", sqlCon);
            DataTable tableNV = new DataTable();
            adapter.Fill(tableNV);
            cbbNhanVien.DataSource = tableNV;
            cbbNhanVien.DisplayMember = "HOTEN";
            cbbNhanVien.ValueMember = "HOTEN";
            adapter = new SqlDataAdapter("select TENDT from DTCC", sqlCon);
            DataTable tableDT = new DataTable();
            adapter.Fill(tableDT);
            cbbDoiTac.DataSource = tableDT;
            cbbDoiTac.DisplayMember = "TENDT";
            cbbDoiTac.ValueMember = "TENDT";
            sqlCon.Close();
        }

        public void ClearCBBDN()
        {
            cbbDoiTac.Text = string.Empty;
            cbbNhanVien.Text = string.Empty;
            txtDTID.Text = string.Empty;
            txtTriGia.Text = string.Empty;
            txtNVID.Text = string.Empty;
            txtMaHDNH.Text = string.Empty;
        }

        private void dgvHDHN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHDHN.SelectedRows != null)
            {
                LoadDonNhap(dgvHDHN.CurrentRow.Cells[0].Value.ToString());
                label6.Text = dgvHDHN.CurrentRow.Cells[4].Value.ToString();
            }
        }

        private void LoadDonNhap(string MaDonNhap)
        {
            if (MaDonNhap != string.Empty)
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                adapter = new SqlDataAdapter("select SPID,SL from CTHDNH where SOHD_NH='" + MaDonNhap + "'", sqlCon);
                DataTable tableSPNH = new DataTable();
                adapter.Fill(tableSPNH);
                dgvChiTietNH.DataSource = tableSPNH;
                dgvChiTietNH.Columns[0].HeaderText = "Mã Sản Phẩm";
                dgvChiTietNH.Columns[1].HeaderText = "Số Lượng Nhập";
                sqlCon.Close();
            }
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

        private string LayIDNV()
        {
            string id = string.Empty;
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("select NVID from NHANVIEN where HOTEN=N'" + cbbNhanVien.Text + "'", sqlCon);
            var reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            { id = reader.GetString(0); }
            sqlCon.Close();
            return id;
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_NhapHang f = new Form_NhapHang(manv, tennv);
            f.ShowDialog();
            this.Show();
            LoadHDNH();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_ChiTietNH f = new Form_ChiTietNH(dgvHDHN.CurrentRow.Cells["SOHD_NH"].Value.ToString());
            f.ShowDialog();
            f.Close();
            this.Show();
        }

        private void GiamSL()
        {
            for (int i = 0; i < dgvChiTietNH.Rows.Count - 1; i++)
            {
                sqlCon.Open();
                string strquery = "update SANPHAM set SoLuong = SoLuong - " + dgvChiTietNH.Rows[i].Cells["SL"].Value.ToString() + " where SPID=N'" + dgvChiTietNH.Rows[i].Cells["SPID"].Value.ToString() + "'";
                SqlCommand sqlCmd;
                sqlCmd = new SqlCommand(strquery, sqlCon);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            sqlCon.Open();
            if (dgvHDHN.CurrentRow == null)
            {
                MessageBox.Show("Chưa chọn hoá đơn để xoá");
                return;
            }
            DialogResult dar = MessageBox.Show("Xoá hoá đơn sẽ làm số lượng sản phẩm giảm.\nBạn có chắc chắn xoá ", "Chú ý", MessageBoxButtons.YesNo);
            if (dar == DialogResult.Yes)
            {
                string strquery = "delete CTHDNH where SOHD_NH= '" + dgvHDHN.CurrentRow.Cells["SOHD_NH"].Value.ToString() + "' " +
                              "delete from HDNH where SOHD_NH='" + dgvHDHN.CurrentRow.Cells["SOHD_NH"].Value.ToString() + "'";
                SqlCommand sqlCmd;
                sqlCmd = new SqlCommand(strquery, sqlCon);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Đã xoá");
            }
            sqlCon.Close();
            GiamSL();
            LoadHDNH();
            LoadDonNhap("0");
        }

        private void txtMaHDNH_TextChanged(object sender, EventArgs e)
        {
            dgvHDHN.DataSource = TimKiemHD();
            DinhDangdgvHDNH();
        }

        private void dtkNgayNhap_ValueChanged(object sender, EventArgs e)
        {
            dgvHDHN.DataSource = TimKiemHD();
            DinhDangdgvHDNH();
        }

        private void cbbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNVID.Text = LayIDNV();
        }

        private void cbbDoiTac_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDTID.Text = LayIDDoiTac();
        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            dgvHDHN.DataSource = TimKiemHD();
            DinhDangdgvHDNH();
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            LoadHDNH();
        }

        private void txtNVID_TextChanged(object sender, EventArgs e)
        {
            dgvHDHN.DataSource = TimKiemHD();
            DinhDangdgvHDNH();
        }

        private void txtDTID_TextChanged(object sender, EventArgs e)
        {
            dgvHDHN.DataSource = TimKiemHD();
            DinhDangdgvHDNH();
        }

        private void cbbNhanVien_TextChanged(object sender, EventArgs e)
        {
            if (cbbNhanVien.Text == string.Empty)
                txtNVID.Text = string.Empty;
        }

        private void cbbDoiTac_TextChanged(object sender, EventArgs e)
        {
            if (cbbDoiTac.Text == string.Empty)
                txtDTID.Text = string.Empty;
        }

        private void cbbNhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbbDoiTac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTriGia_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}