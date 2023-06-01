using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_main_admin : Form
    {
        // NHÓM HÀM TABPAGE NHÂN VIÊN
        private void tab_nv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab_nv.SelectedIndex == 0)
            {
            }
            else if (tab_nv.SelectedIndex == 1)
            {
                load_tabpage_phancong();
            }
            else if (tab_nv.SelectedIndex == 2)
            {
            }
        }

        // nhóm hàm tabpage danh mục nhân viên
        private void LoadData_nv_infonv()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT NVID,HOTEN,SDT,NGVL,NGSINH,CV FROM NHANVIEN";
            adapter.SelectCommand = cmd;
            table_nv_infonv.Clear();
            adapter.Fill(table_nv_infonv);
            dgv_nv_infonv.DataSource = table_nv_infonv;
            dgv_nv_infonv.Columns[0].HeaderText = "Mã nhân viên";
            dgv_nv_infonv.Columns[0].Width = 50;
            dgv_nv_infonv.Columns[1].HeaderText = "Họ và tên";
            dgv_nv_infonv.Columns[1].Width = 130;
            dgv_nv_infonv.Columns[2].HeaderText = "Số điện thoại";
            dgv_nv_infonv.Columns[3].HeaderText = "Ngày vào làm";
            dgv_nv_infonv.Columns[4].HeaderText = "Ngày sinh";
            dgv_nv_infonv.Columns[5].HeaderText = "Chức vụ";
            sqlCon.Close();
        }

        private void loadanh_nv_bangluong()
        {
            Image image1 = null;
            using (FileStream stream = new FileStream(@"Image samples for testing\NV\No Image.jpg", FileMode.Open))
            {
                image1 = Image.FromStream(stream);
            }
            pictureBox_image_import_nv2.Image = image1;
        }

        private void LoadData_nv_bangluong()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT NVID,HOTEN,REPLACE(CONVERT(varchar(20), LUONG, 1), '.00', ''),REPLACE(CONVERT(varchar(20), THUONG, 1), '.00', ''),HESO FROM NHANVIEN";
            adapter.SelectCommand = cmd;
            table_nv_bangluong.Clear();
            adapter.Fill(table_nv_bangluong);
            dgv_nv_bangluong.DataSource = table_nv_bangluong;
            dgv_nv_bangluong.Columns[0].HeaderText = "Mã nhân viên";
            dgv_nv_bangluong.Columns[0].Width = 50;
            dgv_nv_bangluong.Columns[1].HeaderText = "Họ và tên";
            dgv_nv_bangluong.Columns[1].Width = 130;
            dgv_nv_bangluong.Columns[2].HeaderText = "Lương";
            dgv_nv_bangluong.Columns[3].HeaderText = "Thưởng";
            dgv_nv_bangluong.Columns[4].HeaderText = "Hệ số";
            sqlCon.Close();
        }

        private void tb_SDT_nv_infonv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tb_SDT_nv_infonv_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(tb_SDT_nv_infonv.Text, @"^\d+$"))
            {
                tb_SDT_nv_infonv.ForeColor = Color.Red;
            }
            else
            {
                tb_SDT_nv_infonv.ForeColor = Color.Black;
            }
        }

        private void tb_SDT_nv_infonv_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(tb_SDT_nv_infonv.Text, @"^\d+$"))
            {
                tb_SDT_nv_infonv.Text = "";
            }
        }

        private void bt_Them_nv_infonv_Click(object sender, EventArgs e)
        {
            Form_addnv_admin frm = new Form_addnv_admin();
            frm.Thoat += thoat_form_addnv_admin;
            frm.Show();
            this.Hide();
        }

        private void thoat_form_addnv_admin(object sender, EventArgs e)
        {
            this.Show();
            LoadData_nv_infonv();
            lammoi_tabNhanvien_tracuuinfo();
        }

        private void bt_nv_infonv_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xóa dữ liệu", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(tb_MaNV_nv_infonv.Text))
                {
                    MessageBox.Show("Bạn chưa chọn nhân viên để xóa");
                }
                else
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    filepath = @"Image samples for testing\NV\" + tb_MaNV_nv_infonv.Text + ".jpg";
                    cmd = sqlCon.CreateCommand();
                    cmd.CommandText = "delete from NHANVIEN where NVID='" + tb_MaNV_nv_infonv.Text + "'";
                    cmd.ExecuteNonQuery();
                    pictureBox_image_import_nv.Image = null;
                    if (File.Exists(filepath))
                    {
                        File.Delete(filepath);
                    }
                    filepath = "";
                    LoadData_nv_infonv();
                    lammoi_tabNhanvien_tracuuinfo();
                    MessageBox.Show("Bạn đã xoá thành công!");
                }
            }
        }

        private void bt_nv_infonv_Sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_MaNV_nv_infonv.Text))
            {
                MessageBox.Show("Bạn chưa chọn nhân viên để sửa");
            }
            else
            {
                Form_UpdateNV_admin frm = new Form_UpdateNV_admin(tb_MaNV_nv_infonv.Text);
                frm.Thoat += thoat_form_updateNV_admin;
                frm.Show();
                this.Hide();
            }
        }

        private void thoat_form_updateNV_admin(object sender, EventArgs e)
        {
            this.Show();
            LoadData_nv_infonv();
            lammoi_tabNhanvien_tracuuinfo();
        }

        private void lammoi_tabNhanvien_tracuuinfo()
        {
            tb_MaNV_nv_infonv.Text = "";
            tb_TenNV_nv_infonv.Text = "";
            tb_SDT_nv_infonv.Text = "";
            //dt_NgaySinh_nv_infonv.Value = DateTime.Now;

            tb_NgaySinh_nv_infonv.Text = "";
            //dt_NgayVaoLam_nv_infonv.Value = DateTime.Now;
            tb_NgayVaoLam_nv_infonv.Text = "";
            //tb_NgayVaoLam_nv_infonv.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            tb_ChucVu_nv_infonv.Text = "";

            (dgv_nv_infonv.DataSource as DataTable).DefaultView.RowFilter = string.Empty;

            Image image1 = null;
            using (FileStream stream = new FileStream(@"Image samples for testing\NV\No Image.jpg", FileMode.Open))
            {
                image1 = Image.FromStream(stream);
            }
            pictureBox_image_import_nv.Image = image1;
        }

        private void bt_nv_infonv_Khoitao_Click(object sender, EventArgs e)
        {
            lammoi_tabNhanvien_tracuuinfo();
        }

        private void bt_nv_infonv_Tracuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_search_nv_infonv.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung cần tìm.");
                tb_search_nv_infonv.Focus();
                return;
            }
            if (cb_searchoption_nv_infonv.Text == "Chưa chọn")
            {
                MessageBox.Show("Vui lòng chọn trường cần tìm");
                cb_searchoption_nv_infonv.Focus();
                return;
            }
            switch (cb_searchoption_nv_infonv.Text)
            {
                case "Mã NV":
                    {
                        (dgv_nv_infonv.DataSource as DataTable).DefaultView.RowFilter = string.Format("[NVID] ='{0}'", tb_search_nv_infonv.Text);
                        break;
                    }
                case "Họ Tên":
                    {
                        (dgv_nv_infonv.DataSource as DataTable).DefaultView.RowFilter = string.Format("[HOTEN] LIKE'%{0}%'", tb_search_nv_infonv.Text);
                        break;
                    }
                case "Số điện thoại":
                    {
                        if (Regex.IsMatch(tb_search_nv_infonv.Text, @"^\d+$"))
                        {
                            (dgv_nv_infonv.DataSource as DataTable).DefaultView.RowFilter = string.Format(" [SDT] LIKE'{0}%' ", tb_search_nv_infonv.Text);
                        }
                        else
                        {
                            MessageBox.Show("vui long nhap 1 so dien thoai");
                            tb_search_nv_infonv.Focus();
                        }
                        break;
                    }
                case "Ngày sinh":
                    {
                        try
                        {
                            (dgv_nv_infonv.DataSource as DataTable).DefaultView.RowFilter = string.Format("[NGSINH]='{0}' ", tb_search_nv_infonv.Text);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Bạn không nhập đúng format ngày");
                            tb_search_nv_infonv.Focus();
                        }
                        break;
                    }
                case "Ngày vào làm":
                    {
                        try
                        {
                            (dgv_nv_infonv.DataSource as DataTable).DefaultView.RowFilter = string.Format(" [NGVL] = '{0}' ", tb_search_nv_infonv.Text);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Bạn không nhập đúng format ngày");
                            tb_search_nv_infonv.Focus();
                        }
                        break;
                    }
                case "Chức vụ":
                    {
                        (dgv_nv_infonv.DataSource as DataTable).DefaultView.RowFilter = string.Format(" [CV] LIKE'%{0}%' ", tb_search_nv_infonv.Text);
                        break;
                    }
            }
        }

        // nhóm hàm tabpage phân công
        private void event_load_tabp_phancong(object sender, EventArgs e)
        {
            (sender as Form).Close();
            this.load_tabpage_phancong();
        }

        private void load_tabpage_phancong()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT CT_LAMVIEC.NVID, HOTEN, CV, CAID, TIEUDE, CHEDO FROM CT_LAMVIEC INNER JOIN NHANVIEN ON CT_LAMVIEC.NVID = NHANVIEN.NVID WHERE NGAYLAM = '" + mon_nv_phancong_lich.SelectionRange.Start.ToString("MM/dd/yyyy") + "' "
                                + "UNION "
                                + "SELECT CT_LAMVIEC_HANGTUAN.NVID, HOTEN, CV, CT_LAMVIEC_HANGTUAN.CAID, TIEUDE, CHEDO = N'Lặp lại' "
                                + "FROM CT_LAMVIEC_HANGTUAN, NHANVIEN, CALAMVIEC "
                                + "WHERE CT_LAMVIEC_HANGTUAN.NVID = NHANVIEN.NVID AND CT_LAMVIEC_HANGTUAN.CAID = CALAMVIEC.CAID AND THU = '" + mon_nv_phancong_lich.SelectionRange.Start.DayOfWeek.ToString() + "' "
                                + "order by NVID";
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            lbl_nv_phancong_lich.Text = mon_nv_phancong_lich.SelectionRange.Start.DayOfWeek.ToString();
            dgv_nv_phancong_lich.Rows.Clear();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                dgv_nv_phancong_lich.Rows.Add(table.Rows[i]["NVID"], table.Rows[i]["HOTEN"], table.Rows[i]["CV"], false, false, false, table.Rows[i]["TIEUDE"], table.Rows[i]["CHEDO"]);
                string NVID = table.Rows[i]["NVID"].ToString();

                while (table.Rows[i]["NVID"].ToString() == NVID)
                {
                    switch (table.Rows[i]["CAID"].ToString().Substring(2))
                    {
                        case "S":
                            dgv_nv_phancong_lich.Rows[dgv_nv_phancong_lich.Rows.Count - 2].Cells[3].Value = true;
                            break;

                        case "C":
                            dgv_nv_phancong_lich.Rows[dgv_nv_phancong_lich.Rows.Count - 2].Cells[4].Value = true;
                            break;

                        case "T":
                            dgv_nv_phancong_lich.Rows[dgv_nv_phancong_lich.Rows.Count - 2].Cells[5].Value = true;
                            break;
                    }

                    i++;
                    if (i >= table.Rows.Count)
                        return;
                }
                i--;
            }

            sqlCon.Close();
        }

        private void tao_datgridview_lich_lamviec()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT GIO_BD, GIO_NGHI FROM CALAMVIEC WHERE THU = '" + mon_nv_phancong_lich.SelectionStart.DayOfWeek.ToString() + "' ORDER BY GIO_NGHI";
            adapter.SelectCommand = cmd;
            DataTable table1 = new DataTable();
            table1.Clear();
            adapter.Fill(table1);
            // tạo bảng dữ liệu.
            DataGridViewTextBoxColumn dgvID = new DataGridViewTextBoxColumn();
            dgvID.HeaderText = "Mã NV";
            dgvID.Frozen = true;
            dgvID.Width = 50;
            DataGridViewTextBoxColumn dgvTen = new DataGridViewTextBoxColumn();
            dgvTen.HeaderText = "Họ tên";
            dgvTen.Width = 140;
            dgvTen.Frozen = true;
            DataGridViewTextBoxColumn dgvChucvu = new DataGridViewTextBoxColumn();
            dgvChucvu.HeaderText = "Chức vụ";

            DataGridViewCheckBoxColumn dgvSang = new DataGridViewCheckBoxColumn();
            dgvSang.HeaderText = "Ca sáng(" + table1.Rows[0]["GIO_BD"] + " - " + table1.Rows[0]["GIO_NGHI"] + ")";
            DataGridViewCheckBoxColumn dgvChieu = new DataGridViewCheckBoxColumn();
            dgvChieu.HeaderText = "Ca chiều(" + table1.Rows[1]["GIO_BD"] + " - " + table1.Rows[1]["GIO_NGHI"] + ")";
            DataGridViewCheckBoxColumn dgvToi = new DataGridViewCheckBoxColumn();
            dgvToi.HeaderText = "Ca tối(" + table1.Rows[2]["GIO_BD"] + " - " + table1.Rows[2]["GIO_NGHI"] + ")";

            DataGridViewTextBoxColumn dgvChedo = new DataGridViewTextBoxColumn();
            dgvChedo.HeaderText = "Chế độ";

            DataGridViewTextBoxColumn dgvTieude = new DataGridViewTextBoxColumn();
            dgvTieude.HeaderText = "Tiêu đề";
            dgvTieude.Width = 150;

            dgv_nv_phancong_lich.Columns.AddRange(dgvID, dgvTen, dgvChucvu, dgvSang, dgvChieu, dgvToi, dgvTieude, dgvChedo);

            sqlCon.Close();
        }

        private void mon_nv_phancong_lich_DateChanged(object sender, DateRangeEventArgs e)
        {
            load_tabpage_phancong();
        }

        private void btn_nv_phancong_luu_Click(object sender, EventArgs e)
        {
            if (mon_nv_phancong_lich.SelectionRange.Start < DateTime.Today)
            {
                MessageBox.Show("Bạn không thể thay đổi lịch trong quá khứ");
                return;
            }
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "DELETE FROM CT_LAMVIEC WHERE NGAYLAM = '" + mon_nv_phancong_lich.SelectionRange.Start.ToString("MM/dd/yyyy") + "'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DELETE FROM CT_LAMVIEC_HANGTUAN WHERE SUBSTRING(CAID,2,1)= '" + ((int)mon_nv_phancong_lich.SelectionRange.Start.DayOfWeek) + "'";
            cmd.ExecuteNonQuery();
            for (int i = 0; i < dgv_nv_phancong_lich.Rows.Count - 1; i++)
            {
                if (dgv_nv_phancong_lich.Rows[i].Cells[7].Value.ToString() == "Lặp lại")
                {
                    if (dgv_nv_phancong_lich.Rows[i].Cells[3].Value.ToString() == "True")
                    {
                        try
                        {
                            cmd.CommandText = "INSERT INTO CT_LAMVIEC_HANGTUAN VALUES('" + dgv_nv_phancong_lich.Rows[i].Cells[0].Value.ToString() + "', 'C" + ((int)mon_nv_phancong_lich.SelectionRange.Start.DayOfWeek).ToString() + "S', N'Lịch làm việc hàng tuần' )";
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception) { }
                    }
                    if (dgv_nv_phancong_lich.Rows[i].Cells[4].Value.ToString() == "True")
                    {
                        try
                        {
                            cmd.CommandText = "INSERT INTO CT_LAMVIEC_HANGTUAN VALUES('" + dgv_nv_phancong_lich.Rows[i].Cells[0].Value.ToString() + "', 'C" + ((int)mon_nv_phancong_lich.SelectionRange.Start.DayOfWeek).ToString() + "C', N'Lịch làm việc hàng tuần' )";
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception) { }
                    }
                    if (dgv_nv_phancong_lich.Rows[i].Cells[5].Value.ToString() == "True")
                    {
                        try
                        {
                            cmd.CommandText = "INSERT INTO CT_LAMVIEC_HANGTUAN VALUES('" + dgv_nv_phancong_lich.Rows[i].Cells[0].Value.ToString() + "', 'C" + ((int)mon_nv_phancong_lich.SelectionRange.Start.DayOfWeek).ToString() + "T', N'Lịch làm việc hàng tuần' )";
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception) { }
                    }
                }
                else
                {
                    if (dgv_nv_phancong_lich.Rows[i].Cells[3].Value.ToString() == "True")
                    {
                        try
                        {
                            cmd.CommandText = "INSERT INTO CT_LAMVIEC VALUES('" + dgv_nv_phancong_lich.Rows[i].Cells[0].Value.ToString() + "', 'C" + ((int)mon_nv_phancong_lich.SelectionRange.Start.DayOfWeek).ToString() + "S', '" + mon_nv_phancong_lich.SelectionRange.Start.ToString("d") + "', N'Chưa điểm danh', N'" + dgv_nv_phancong_lich.Rows[i].Cells[7].Value.ToString() + "',N'" + dgv_nv_phancong_lich.Rows[i].Cells[6].Value.ToString() + "' )";
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception) { }
                    }
                    if (dgv_nv_phancong_lich.Rows[i].Cells[4].Value.ToString() == "True")
                    {
                        try
                        {
                            cmd.CommandText = "INSERT INTO CT_LAMVIEC VALUES('" + dgv_nv_phancong_lich.Rows[i].Cells[0].Value.ToString() + "', 'C" + ((int)mon_nv_phancong_lich.SelectionRange.Start.DayOfWeek).ToString() + "C', '" + mon_nv_phancong_lich.SelectionRange.Start.ToString("d") + "', N'Chưa điểm danh', N'" + dgv_nv_phancong_lich.Rows[i].Cells[7].Value.ToString() + "',N'" + dgv_nv_phancong_lich.Rows[i].Cells[6].Value.ToString() + "' )";
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception) { }
                    }
                    if (dgv_nv_phancong_lich.Rows[i].Cells[5].Value.ToString() == "True")
                    {
                        try
                        {
                            cmd.CommandText = "INSERT INTO CT_LAMVIEC VALUES('" + dgv_nv_phancong_lich.Rows[i].Cells[0].Value.ToString() + "', 'C" + ((int)mon_nv_phancong_lich.SelectionRange.Start.DayOfWeek).ToString() + "T', '" + mon_nv_phancong_lich.SelectionRange.Start.ToString("d") + "', N'Chưa điểm danh', N'" + dgv_nv_phancong_lich.Rows[i].Cells[7].Value.ToString() + "', N'" + dgv_nv_phancong_lich.Rows[i].Cells[6].Value.ToString() + "')";
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception) { }
                    }
                }
            }
            MessageBox.Show("Đã lưu thành công");
            sqlCon.Close();
        }

        private void btn_nv_phancong_xoa_Click(object sender, EventArgs e)
        {
            if (mon_nv_phancong_lich.SelectionRange.Start <= DateTime.Today)
            {
                MessageBox.Show("Bạn không thể xóa lịch trong quá khứ và ngày hôm nay", "Thông báo");
            }
            dgv_nv_phancong_lich.Rows.RemoveAt(dgv_nv_phancong_lich.CurrentRow.Index);
        }

        private void btn_nv_phancong_them_Click(object sender, EventArgs e)
        {
            Form_nv_phancong_themlich Frm = new Form_nv_phancong_themlich();
            Frm.Load_frm_main += event_load_tabp_phancong;
            Frm.ShowDialog();
        }

        private void btn_nv_phancong_tuan_Click(object sender, EventArgs e)
        {
            Form_lichhangtuan frm = new Form_lichhangtuan();
            frm.Load_form_main += event_load_tabp_phancong;
            frm.ShowDialog();
        }

        private void btn_nv_phancong_chamcong_Click(object sender, EventArgs e)
        {
            Form_nv_phancong_chamcong frm = new Form_nv_phancong_chamcong();
            frm.ShowDialog();
        }

        //nhóm tabpage bảng lương nhân viên
        private void bt_Sua_nv_bangluong_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Bạn có chắc chắn muốn sửa?", "Sửa dữ liệu", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                cmd = sqlCon.CreateCommand();
                cmd.CommandText = "update NHANVIEN set LUONG='" + nud_Luong_nv_bangluong.Value.ToString() + "',HESO='" + float.Parse(nud_Heso_nv_bangluong.Value.ToString()) + "',THUONG='" + nud_Thuong_nv_bangluong.Value.ToString() + "' WHERE NVID='" + tb_MaNV_nv_bangluong.Text + "'";
                cmd.ExecuteNonQuery();
                LoadData_nv_bangluong();
                sqlCon.Close();
            }
        }

        private void bt_Khoitao_nv_bangluong_Click(object sender, EventArgs e)
        {
            tb_MaNV_nv_bangluong.ReadOnly = false;
            tb_TenNV_nv_bangluong.ReadOnly = false;
            tb_MaNV_nv_bangluong.Text = "";
            tb_TenNV_nv_bangluong.Text = "";
            nud_Luong_nv_bangluong.Value = 0;
            nud_Heso_nv_bangluong.Value = 0;
            nud_Thuong_nv_bangluong.Value = 0;
            (dgv_nv_bangluong.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            Image image1 = null;
            using (FileStream stream = new FileStream(@"Image samples for testing\NV\No Image.jpg", FileMode.Open))
            {
                image1 = Image.FromStream(stream);
            }
            pictureBox_image_import_nv2.Image = image1;
        }

        private void bt_Tracuu_nv_bangluong_Click(object sender, EventArgs e)
        {
            (dgv_nv_bangluong.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            if (string.IsNullOrEmpty(tb_search_nv_bangluong.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung cần tìm.");
                tb_search_nv_bangluong.Focus();
                return;
            }
            if (cb_searchoption_nv_bangluong.Text == "Chưa chọn")
            {
                MessageBox.Show("Vui lòng chọn trường cần tìm");
                cb_searchoption_nv_bangluong.Focus();
                return;
            }
            switch (cb_searchoption_nv_bangluong.Text)
            {
                case "Mã NV":
                    {
                        (dgv_nv_bangluong.DataSource as DataTable).DefaultView.RowFilter = string.Format("[NVID] ='{0}'", tb_search_nv_bangluong.Text);

                        break;
                    }
                case "Họ Tên":
                    {
                        (dgv_nv_bangluong.DataSource as DataTable).DefaultView.RowFilter = string.Format("[HOTEN] LIKE'%{0}%'", tb_search_nv_bangluong.Text);
                        break;
                    }
                case "Lương":
                    {
                        if (cb_LocLuong_nv_bangluong.Text == "Lọc")
                        {
                            MessageBox.Show("Vui lòng chọn miền lương cần lọc");
                            cb_LocLuong_nv_bangluong.Focus();
                        }
                        else
                        {
                            if (decimal.TryParse(tb_search_nv_bangluong.Text, out decimal result))
                            {
                                if (cb_LocLuong_nv_bangluong.SelectedIndex.Equals(0))
                                    (dgv_nv_bangluong.DataSource as DataTable).DefaultView.RowFilter = string.Format(" LUONG = '{0}'", Convert.ToDecimal(tb_search_nv_bangluong.Text));
                                else if (cb_LocLuong_nv_bangluong.SelectedIndex.Equals(1))
                                    (dgv_nv_bangluong.DataSource as DataTable).DefaultView.RowFilter = string.Format("LUONG > '{0}'", Convert.ToDecimal(tb_search_nv_bangluong.Text));
                                else if (cb_LocLuong_nv_bangluong.SelectedIndex.Equals(2))
                                    (dgv_nv_bangluong.DataSource as DataTable).DefaultView.RowFilter = string.Format(" LUONG < '{0}'", Convert.ToDecimal(tb_search_nv_bangluong.Text));
                            }
                            else
                            {
                                MessageBox.Show("vui lòng nhập một số tiền");
                                tb_search_nv_bangluong.Focus();
                            }
                        }
                        break;
                    }
                case "Hệ số":
                    {
                        if (cb_LocLuong_nv_bangluong.Text == "Lọc")
                        {
                            MessageBox.Show("Vui lòng chọn miền lương cần lọc");
                            cb_LocLuong_nv_bangluong.Focus();
                        }
                        else
                        {
                            if (decimal.TryParse(tb_search_nv_bangluong.Text, out decimal result))
                            {
                                if (cb_LocLuong_nv_bangluong.SelectedIndex.Equals(0))
                                    (dgv_nv_bangluong.DataSource as DataTable).DefaultView.RowFilter = string.Format(" [HESO] = '{0}'", Convert.ToDecimal(tb_search_nv_bangluong.Text));
                                else if (cb_LocLuong_nv_bangluong.SelectedIndex.Equals(1))
                                    (dgv_nv_bangluong.DataSource as DataTable).DefaultView.RowFilter = string.Format(" [HESO] > '{0}'", Convert.ToDecimal(tb_search_nv_bangluong.Text));
                                else if (cb_LocLuong_nv_bangluong.SelectedIndex.Equals(2))
                                    (dgv_nv_bangluong.DataSource as DataTable).DefaultView.RowFilter = string.Format(" [HESO] < '{0}'", Convert.ToDecimal(tb_search_nv_bangluong.Text));
                            }
                            else
                            {
                                MessageBox.Show("vui lòng nhập một số thập phân");
                                tb_search_nv_bangluong.Focus();
                            }
                        }
                        break;
                    }
                case "Thưởng":
                    {
                        if (cb_LocLuong_nv_bangluong.Text == "Lọc")
                        {
                            MessageBox.Show("Vui lòng chọn miền thưởng cần lọc");
                            cb_LocLuong_nv_bangluong.Focus();
                        }
                        else
                        {
                            if (decimal.TryParse(tb_search_nv_bangluong.Text, out decimal result))
                            {
                                if (cb_LocLuong_nv_bangluong.SelectedIndex.Equals(0))
                                    (dgv_nv_bangluong.DataSource as DataTable).DefaultView.RowFilter = string.Format(" THUONG = '{0}'", Convert.ToDecimal(tb_search_nv_bangluong.Text));
                                else if (cb_LocLuong_nv_bangluong.SelectedIndex.Equals(1))
                                    (dgv_nv_bangluong.DataSource as DataTable).DefaultView.RowFilter = string.Format(" THUONG > '{0}'", Convert.ToDecimal(tb_search_nv_bangluong.Text));
                                else if (cb_LocLuong_nv_bangluong.SelectedIndex.Equals(2))
                                    (dgv_nv_bangluong.DataSource as DataTable).DefaultView.RowFilter = string.Format(" THUONG < '{0}'", Convert.ToDecimal(tb_search_nv_bangluong.Text));
                            }
                            else
                            {
                                MessageBox.Show("vui lòng nhập một số tiền");
                                tb_search_nv_bangluong.Focus();
                            }
                        }
                        break;
                    }
            }
        }

        private void button_Image_import_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_MaNV_nv_infonv.Text))
            {
                MessageBox.Show("Bạn chưa chọn nhân viên nào để thay ảnh!");
                tb_MaNV_nv_infonv.Focus();
            }
            else
            {
                OpenFileDialog Open1 = new OpenFileDialog();
                Open1.Multiselect = false;
                Open1.Filter = " Image file (*.BMP,*.JPG,*.JPEG)|*.bmp;*.jpg;*.jpeg ";
                if (Open1.ShowDialog() == DialogResult.OK)
                {
                    var filepath = Open1.FileName;
                    Bitmap bmp = new Bitmap(filepath);
                    Form_selectphoto_nv frm = new Form_selectphoto_nv(filepath, tb_MaNV_nv_infonv.Text, tb_MaNV_nv_infonv.Text);
                    if (bmp.Width < (frm.panel1.Width + SystemInformation.VerticalScrollBarWidth) * 2 || bmp.Height < (frm.panel1.Height + SystemInformation.HorizontalScrollBarHeight) * 2)
                    {
                        MessageBox.Show("Ảnh bạn phải có kích thước tối thiểu " + ((frm.panel1.Width + SystemInformation.VerticalScrollBarWidth) * 2).ToString() + "x" + ((frm.panel1.Height + SystemInformation.HorizontalScrollBarHeight) * 2).ToString());
                        frm.Close();
                    }
                    else
                    {
                        frm.Thoat += Thoat_Form_selectphoto_nv;
                        frm.Isnv = 1;
                        frm.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void Thoat_Form_selectphoto_nv(object sender, EventArgs e)
        {
            this.Show();
            Image image1 = null;
            using (FileStream stream = new FileStream(@"Image samples for testing\NV\" + tb_MaNV_nv_infonv.Text + ".jpg", FileMode.Open))
            {
                image1 = Image.FromStream(stream);
            }
            pictureBox_image_import_nv.Image = image1;
        }

        private void dgv_nv_infonv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_nv_infonv.CurrentRow.Index;
            tb_MaNV_nv_infonv.Text = dgv_nv_infonv.Rows[i].Cells[0].Value.ToString();
            tb_TenNV_nv_infonv.Text = dgv_nv_infonv.Rows[i].Cells[1].Value.ToString();
            tb_SDT_nv_infonv.Text = dgv_nv_infonv.Rows[i].Cells[2].Value.ToString();
            dt_NgayVaoLam_nv_infonv.Visible = true;
            dt_NgayVaoLam_nv_infonv.Text = dgv_nv_infonv.Rows[i].Cells[3].Value.ToString();
            tb_NgayVaoLam_nv_infonv.Text = dt_NgayVaoLam_nv_infonv.Text;
            dt_NgayVaoLam_nv_infonv.Visible = false;
            dt_NgaySinh_nv_infonv.Visible = true;
            dt_NgaySinh_nv_infonv.Text = dgv_nv_infonv.Rows[i].Cells[4].Value.ToString();
            tb_NgaySinh_nv_infonv.Text = dt_NgaySinh_nv_infonv.Text;
            dt_NgaySinh_nv_infonv.Visible = false;
            tb_ChucVu_nv_infonv.Text = dgv_nv_infonv.Rows[i].Cells[5].Value.ToString();

            if (File.Exists(@"Image samples for testing\NV\" + tb_MaNV_nv_infonv.Text + ".jpg"))
            {
                Image image1 = null;
                using (FileStream stream = new FileStream(@"Image samples for testing\NV\" + tb_MaNV_nv_infonv.Text + ".jpg", FileMode.Open))
                {
                    image1 = Image.FromStream(stream);
                }
                pictureBox_image_import_nv.Image = image1;
            }
            else
            {
                Image image1 = null;
                using (FileStream stream = new FileStream(@"Image samples for testing\NV\No Image.jpg", FileMode.Open))
                {
                    image1 = Image.FromStream(stream);
                }
                pictureBox_image_import_nv.Image = image1;
            }
        }

        private void dgv_nv_bangluong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_MaNV_nv_bangluong.ReadOnly = true;
            tb_TenNV_nv_bangluong.ReadOnly = true;
            int i;
            i = dgv_nv_bangluong.CurrentRow.Index;
            tb_MaNV_nv_bangluong.Text = dgv_nv_bangluong.Rows[i].Cells[0].Value.ToString();
            tb_TenNV_nv_bangluong.Text = dgv_nv_bangluong.Rows[i].Cells[1].Value.ToString();
            nud_Luong_nv_bangluong.Value = Convert.ToDecimal(dgv_nv_bangluong.Rows[i].Cells[2].Value.ToString().Replace(",", string.Empty));
            nud_Thuong_nv_bangluong.Value = Convert.ToDecimal(dgv_nv_bangluong.Rows[i].Cells[3].Value.ToString());
            nud_Heso_nv_bangluong.Value = Convert.ToDecimal(dgv_nv_bangluong.Rows[i].Cells[4].Value.ToString());
            if (File.Exists(@"Image samples for testing\NV\" + tb_MaNV_nv_bangluong.Text + ".jpg"))
            {
                Image image1 = null;
                using (FileStream stream = new FileStream(@"Image samples for testing\NV\" + tb_MaNV_nv_bangluong.Text + ".jpg", FileMode.Open))
                {
                    image1 = Image.FromStream(stream);
                }
                pictureBox_image_import_nv2.Image = image1;
            }
            else
            {
                Image image1 = null;
                using (FileStream stream = new FileStream(@"Image samples for testing\NV\No Image.jpg", FileMode.Open))
                {
                    image1 = Image.FromStream(stream);
                }
                pictureBox_image_import_nv2.Image = image1;
            }
        }

        private void cb_searchoption_nv_bangluong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_searchoption_nv_bangluong.Text == "Lương" || cb_searchoption_nv_bangluong.Text == "Hệ số" || cb_searchoption_nv_bangluong.Text == "Thưởng")
            {
                cb_LocLuong_nv_bangluong.Visible = true;
            }
            else
            {
                cb_LocLuong_nv_bangluong.Visible = false;
            }
        }
    }
}