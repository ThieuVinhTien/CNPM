using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_main_admin : Form
    {
        //TabPage Hàng hóa
        public void LoadHangHoa()
        {
            sqlCon = new SqlConnection(strCon);
            SqlCommand sqlCmd = new SqlCommand();
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select SANPHAM.SPID,SANPHAM.TENSP,LOAISP.TENLOAI,SANPHAM.NUOCSX,SANPHAM.HANGSX,REPLACE(CONVERT(varchar(20),SANPHAM.GIABAN, 1), '.00','') as GIABAN,REPLACE(CONVERT(varchar(20),SANPHAM.GIANHAP, 1), '.00','') AS GIANHAP,SANPHAM.DVT,SANPHAM.SOLUONG,SANPHAM.SLTT,SANPHAM.MOTA from SANPHAM,LOAISP where SANPHAM.LOAIID = LOAISP.LOAIID ";
            sqlCmd.Connection = sqlCon;
            adapter = new SqlDataAdapter(sqlCmd);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataTable tbHH = new DataTable();
            tbHH.Clear();
            adapter.Fill(tbHH);
            dgvSP.DataSource = tbHH;
            HH_DinhDangdgv();
            lblTieuDeHH.Text = "Hàng Hoá Còn Lại";
            sqlCon.Close();
        }

        private void LoadCBBHH()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            adapter = new SqlDataAdapter("select TENLOAI from [LOAISP] group by TENLOAI", sqlCon);
            DataTable tableLoai = new DataTable();
            adapter.Fill(tableLoai);
            cbbLoaiSP.DataSource = tableLoai;
            cbbLoaiSP.DisplayMember = "TenLoai";
            cbbLoaiSP.ValueMember = "TenLoai";
            adapter = new SqlDataAdapter("select NUOCSX from [SANPHAM] group by NUOCSX", sqlCon);
            DataTable tableNuoc = new DataTable();
            adapter.Fill(tableNuoc);
            cbbNuocSX.DataSource = tableNuoc;
            cbbNuocSX.DisplayMember = "NUOCSX";
            cbbNuocSX.ValueMember = "NUOCSX";
            adapter = new SqlDataAdapter("select HANGSX from [SANPHAM] group by HANGSX", sqlCon);
            DataTable tableHang = new DataTable();
            adapter.Fill(tableHang);
            cbbHang.DataSource = tableHang;
            cbbHang.DisplayMember = "HANGSX";
            cbbHang.ValueMember = "HANGSX";
            sqlCon.Close();
            HH_ClearCBBTB();
        }

        public void HH_ClearCBBTB()
        {
            cbbLoaiSP.Text = "";
            cbbHang.Text = "";
            cbbNuocSX.Text = "";
            cbbChonGia.Text = "";
            txtTenSP.Text = string.Empty;
            txtGiaBan.Text = string.Empty;
        }

        public void HH_DinhDangdgv()
        {
            dgvSP.Columns[0].HeaderText = "Mã Sản Phẩm";
            dgvSP.Columns[0].Width = 60;
            dgvSP.Columns[1].HeaderText = "Tên Sản Phẩm";
            dgvSP.Columns[2].HeaderText = "Loại Sản Phẩm";
            dgvSP.Columns[3].HeaderText = "Nước Sản Xuất";
            dgvSP.Columns[3].Width = 80;
            dgvSP.Columns[4].HeaderText = "Hãng";
            dgvSP.Columns[5].HeaderText = "Giá Bán";

            dgvSP.Columns[6].HeaderText = "Giá Nhập";

            dgvSP.Columns[7].HeaderText = "Đơn Vị Tính";
            dgvSP.Columns[7].Width = 50;
            dgvSP.Columns[8].HeaderText = "Số Lượng";
            dgvSP.Columns[8].Width = 50;
            dgvSP.Columns[9].HeaderText = "Số Lượng Tối Thiểu";
            dgvSP.Columns[9].Width = 50;
            dgvSP.Columns[10].HeaderText = "Mô Tả";
        }

        private void XemChiTiet()

        {
            if (dgvSP.CurrentRow == null)
            {
                MessageBox.Show("Chưa chọn hàng để xem chi tiết");
                return;
            }
            Form_ChiTietHH f = new Form_ChiTietHH(dgvSP.CurrentRow.Cells["SPID"].Value.ToString(), dgvSP.CurrentRow.Cells["TENSP"].Value.ToString(), dgvSP.CurrentRow.Cells["SOLUONG"].Value.ToString(), dgvSP.CurrentRow.Cells["NUOCSX"].Value.ToString(), dgvSP.CurrentRow.Cells["HANGSX"].Value.ToString(), dgvSP.CurrentRow.Cells[6].Value.ToString(), dgvSP.CurrentRow.Cells[5].Value.ToString(), dgvSP.CurrentRow.Cells["DVT"].Value.ToString(), dgvSP.CurrentRow.Cells["SLTT"].Value.ToString(), dgvSP.CurrentRow.Cells["TENLOAI"].Value.ToString(), dgvSP.CurrentRow.Cells["MoTa"].Value.ToString());
            this.Hide();
            f.ShowDialog();
            f.Close();
            this.Show();
        }

        private void rbtnXemtatca_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnXemtatca.Checked == true)
            {
                HH_ClearCBBTB();
                LoadHangHoa();
            }
        }

        private void rbtnHanghoasaphet_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnHanghoasaphet.Checked == true)
            {
                sqlCon = new SqlConnection(strCon);
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "select SANPHAM.SPID,SANPHAM.TENSP,LOAISP.TENLOAI,SANPHAM.NUOCSX,SANPHAM.HANGSX,REPLACE(CONVERT(varchar(20),SANPHAM.GIABAN, 1), '.00',''),REPLACE(CONVERT(varchar(20),SANPHAM.GIANHAP, 1), '.00',''),SANPHAM.DVT,SANPHAM.SOLUONG,SANPHAM.SLTT,SANPHAM.MOTA from SANPHAM,LOAISP where SANPHAM.LOAIID = LOAISP.LOAIID and SoLuong<SLTT";
                // gửi truy vấn tới kết nối.
                sqlCmd.Connection = sqlCon;
                adapter = new SqlDataAdapter(sqlCmd);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataTable tbHHSH = new DataTable();
                tbHHSH.Clear();
                adapter.Fill(tbHHSH);
                dgvSP.DataSource = tbHHSH;
            }
        }

        public DataTable HH_TimKiem()
        {
            DataTable tb = new DataTable();
            string query = string.Empty;
            if (txtGiaBan.Text != string.Empty)
            {
                switch (cbbChonGia.SelectedIndex)
                {
                    case 0:
                        {
                            query = "select SANPHAM.SPID,SANPHAM.TENSP,LOAISP.TENLOAI,SANPHAM.NUOCSX,SANPHAM.HANGSX,REPLACE(CONVERT(varchar(20),SANPHAM.GIABAN, 1), '.00',''),REPLACE(CONVERT(varchar(20),SANPHAM.GIANHAP, 1), '.00',''),SANPHAM.DVT,SANPHAM.SOLUONG,SANPHAM.SLTT,SANPHAM.MOTA from SANPHAM,LOAISP" +
                         " where (SANPHAM.LOAIID = LOAISP.LOAIID and LOAISP.TENLOAI like N'%" + cbbLoaiSP.Text + "%' and GIABAN = " + txtGiaBan.Text + " and  TENSP Like N'%" + txtTenSP.Text + "%' and NUOCSX Like N'%" + cbbNuocSX.Text + "%'" + " and HANGSX Like N'%" + cbbHang.Text + "%')";
                            break;
                        }
                    case 1:
                        {
                            query = "select SANPHAM.SPID,SANPHAM.TENSP,LOAISP.TENLOAI,SANPHAM.NUOCSX,SANPHAM.HANGSX,REPLACE(CONVERT(varchar(20),SANPHAM.GIABAN, 1), '.00',''),REPLACE(CONVERT(varchar(20),SANPHAM.GIANHAP, 1), '.00',''),SANPHAM.DVT,SANPHAM.SOLUONG,SANPHAM.SLTT,SANPHAM.MOTA from SANPHAM,LOAISP" +
                               " where (SANPHAM.LOAIID = LOAISP.LOAIID and LOAISP.TENLOAI like N'%" + cbbLoaiSP.Text + "%' and GIABAN < " + txtGiaBan.Text + " and  TENSP Like N'%" + txtTenSP.Text + "%' and NUOCSX Like N'%" + cbbNuocSX.Text + "%'" + " and HANGSX Like N'%" + cbbHang.Text + "%')";
                            break;
                        }
                    case 2:
                        {
                            query = "select SANPHAM.SPID,SANPHAM.TENSP,LOAISP.TENLOAI,SANPHAM.NUOCSX,SANPHAM.HANGSX,REPLACE(CONVERT(varchar(20),SANPHAM.GIABAN, 1), '.00',''),REPLACE(CONVERT(varchar(20),SANPHAM.GIANHAP, 1), '.00',''),SANPHAM.DVT,SANPHAM.SOLUONG,SANPHAM.SLTT,SANPHAM.MOTA from SANPHAM,LOAISP" +
                            " where (SANPHAM.LOAIID = LOAISP.LOAIID and LOAISP.TENLOAI like N'%" + cbbLoaiSP.Text + "%' and GIABAN > " + txtGiaBan.Text + " and  TENSP Like N'%" + txtTenSP.Text + "%' and NUOCSX Like N'%" + cbbNuocSX.Text + "%'" + " and HANGSX Like N'%" + cbbHang.Text + "%')";
                            break;
                        }
                    default:
                        {
                            query = "select SANPHAM.SPID,SANPHAM.TENSP,LOAISP.TENLOAI,SANPHAM.NUOCSX,SANPHAM.HANGSX,REPLACE(CONVERT(varchar(20),SANPHAM.GIABAN, 1), '.00',''),REPLACE(CONVERT(varchar(20),SANPHAM.GIANHAP, 1), '.00',''),SANPHAM.DVT,SANPHAM.SOLUONG,SANPHAM.SLTT,SANPHAM.MOTA from SANPHAM,LOAISP" +
                                " where (SANPHAM.LOAIID = LOAISP.LOAIID and LOAISP.TENLOAI like N'%" + cbbLoaiSP.Text + "%'" + " and  TENSP Like N'%" + txtTenSP.Text + "%' and NUOCSX Like N'%" + cbbNuocSX.Text + "%'" + " and HANGSX Like N'%" + cbbHang.Text + "%')";
                            break;
                        }
                }
            }
            else query = "select SANPHAM.SPID,SANPHAM.TENSP,LOAISP.TENLOAI,SANPHAM.NUOCSX,SANPHAM.HANGSX,REPLACE(CONVERT(varchar(20),SANPHAM.GIABAN, 1), '.00',''),REPLACE(CONVERT(varchar(20),SANPHAM.GIANHAP, 1), '.00',''),SANPHAM.DVT,SANPHAM.SOLUONG,SANPHAM.SLTT,SANPHAM.MOTA from SANPHAM,LOAISP" +
                 " where (SANPHAM.LOAIID = LOAISP.LOAIID and LOAISP.TENLOAI like N'%" + cbbLoaiSP.Text + "%'" + " and  TENSP Like N'%" + txtTenSP.Text + "%' and NUOCSX Like N'%" + cbbNuocSX.Text + "%'" + " and HANGSX Like N'%" + cbbHang.Text + "%')";

            adapter = new SqlDataAdapter(query, sqlCon);
            adapter.Fill(tb);
            sqlCon.Close();
            return tb;
        }

        private void dgvSP_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            XemChiTiet();
        }

        private void btnThemHH_Click(object sender, EventArgs e)
        {
            Form_ThemSuaHangHoa f = new Form_ThemSuaHangHoa(1);
            this.Hide();
            f.ShowDialog();
            LoadHangHoa();
            this.Show();
        }

        private void btnXoaHH_Click(object sender, EventArgs e)
        {
            sqlCon.Open();
            if (dgvSP.CurrentRow == null)
            {
                MessageBox.Show("Chưa chọn hàng để xoá");
                return;
            }
            DialogResult dar = MessageBox.Show("Xoá sản phẩm sẽ làm thông tin liên quan bị xoá.Ví dụ các hoá đơn.\nBạn có chắc chắn xoá ", "Chú ý", MessageBoxButtons.YesNo);
            if (dar == DialogResult.Yes)
            {
                string strquery = "delete CTHDNH where SPID in (select SPID from SANPHAM where LOAIID = '" + dgvSP.CurrentRow.Cells["SPID"].Value.ToString() + "')" +
                              "delete CTHDBH where SPID in (select SPID from SANPHAM where LOAIID = '" + dgvSP.CurrentRow.Cells["SPID"].Value.ToString() + "')" +
                              "delete from SANPHAM where SPID='" + dgvSP.CurrentRow.Cells["SPID"].Value.ToString() + "'";
                FileInfo info = new FileInfo(@"..\..\HangHoa\" + dgvSP.CurrentRow.Cells["SPID"].Value.ToString() + ".jpg");
                info.Delete();
                SqlCommand sqlCmd = new SqlCommand(strquery, sqlCon);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
                LoadHangHoa();
                MessageBox.Show("Đã xoá");
            }
        }

        private void btnSuaHH_Click(object sender, EventArgs e)
        {
            if (dgvSP.CurrentRow == null)
            {
                MessageBox.Show("Chưa chọn hàng để sửa");
                return;
            }
            Form_ThemSuaHangHoa f = new Form_ThemSuaHangHoa(2, dgvSP.CurrentRow.Cells["SPID"].Value.ToString(), dgvSP.CurrentRow.Cells["TENSP"].Value.ToString(), dgvSP.CurrentRow.Cells["NUOCSX"].Value.ToString(), dgvSP.CurrentRow.Cells["HANGSX"].Value.ToString(), dgvSP.CurrentRow.Cells["GIABAN"].Value.ToString(), dgvSP.CurrentRow.Cells["GIANHAP"].Value.ToString(), dgvSP.CurrentRow.Cells["SLTT"].Value.ToString(), dgvSP.CurrentRow.Cells["DVT"].Value.ToString(), dgvSP.CurrentRow.Cells["TENLOAI"].Value.ToString(), dgvSP.CurrentRow.Cells["MoTa"].Value.ToString());
            this.Hide();
            f.ShowDialog();
            LoadHangHoa();
            this.Show();
        }

        private void btnQLLoaiHH_Click(object sender, EventArgs e)
        {
            Form_QLLoaiHH f = new Form_QLLoaiHH();
            this.Hide();
            f.ShowDialog();
            this.Show();
            LoadHangHoa();
        }

        private void btnHangSapHet_Click(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(strCon);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select SANPHAM.SPID,SANPHAM.TENSP,LOAISP.TENLOAI,SANPHAM.NUOCSX,SANPHAM.HANGSX,SANPHAM.GIABAN,SANPHAM.GIANHAP,SANPHAM.DVT,SANPHAM.SOLUONG,SANPHAM.SLTT,SANPHAM.MOTA from SANPHAM,LOAISP where SANPHAM.LOAIID = LOAISP.LOAIID and SoLuong<SLTT";
            // gửi truy vấn tới kết nối.
            sqlCmd.Connection = sqlCon;
            adapter = new SqlDataAdapter(sqlCmd);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataTable tbHHSH = new DataTable();
            tbHHSH.Clear();
            adapter.Fill(tbHHSH);
            dgvSP.DataSource = tbHHSH;
        }

        private void btnHoaDonNhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_HoaDonNH f = new Form_HoaDonNH(manv, tennv);
            f.ShowDialog();
            this.Show();
            LoadHangHoa();
        }

        private void btnXemChiTietHH_Click(object sender, EventArgs e)
        {
            XemChiTiet();
        }

        private void cbbLoaiSP_TextChanged(object sender, EventArgs e)
        {
            dgvSP.DataSource = HH_TimKiem();
            HH_DinhDangdgv();
        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {
            dgvSP.DataSource = HH_TimKiem();
            HH_DinhDangdgv();
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            dgvSP.DataSource = HH_TimKiem();
            HH_DinhDangdgv();
        }

        private void cbbChonGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSP.DataSource = HH_TimKiem();
            HH_DinhDangdgv();
        }

        private void cbbHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSP.DataSource = HH_TimKiem();
            HH_DinhDangdgv();
        }

        private void cbbNuocSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSP.DataSource = HH_TimKiem();
            HH_DinhDangdgv();
        }

        private void cbbLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSP.DataSource = HH_TimKiem();
            HH_DinhDangdgv();
        }

        private void btn_XemHH_Click(object sender, EventArgs e)
        {
            HH_ClearCBBTB();
            LoadHangHoa();
        }

        private void cbbLoaiSP_TextChanged_1(object sender, EventArgs e)
        {
            dgvSP.DataSource = HH_TimKiem();
            HH_DinhDangdgv();
        }

        private void cbbHang_TextChanged(object sender, EventArgs e)
        {
            dgvSP.DataSource = HH_TimKiem();
            HH_DinhDangdgv();
        }

        private void cbbNuocSX_TextChanged(object sender, EventArgs e)
        {
            dgvSP.DataSource = HH_TimKiem();
            HH_DinhDangdgv();
        }

        private void cbbChonGia_TextChanged(object sender, EventArgs e)
        {
            dgvSP.DataSource = HH_TimKiem();
            HH_DinhDangdgv();
        }

        private void cbbLoaiSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbbHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbbNuocSX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbbChonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}