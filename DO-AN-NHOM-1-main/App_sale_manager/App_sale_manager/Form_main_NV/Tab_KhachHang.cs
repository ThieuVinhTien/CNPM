using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_main_NV : Form
    {
        private void dataGridView_dtcc_guest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_dtcc_guest.Rows[e.RowIndex];
                DateTime Date = new DateTime();
                string loaiKH = row.Cells[6].Value.ToString();
                if (string.IsNullOrEmpty(loaiKH) != true)
                    if (loaiKH == "NOR")
                        label_guestSpec_Text.Text = "Khách thường";
                    else
                        label_guestSpec_Text.Text = "Khách vip";
                label_guestID_Text.Text = row.Cells[0].Value.ToString();
                label_guestName_Text.Text = row.Cells[1].Value.ToString();
                label_guestSDT_Text.Text = row.Cells[3].Value.ToString();
                Date = Convert.ToDateTime(row.Cells[4].Value.ToString());
                label_guestReg_Text.Text = Date.ToString();
                label_guestAddress_Text.Text = row.Cells[2].Value.ToString();
                label_guestMoney_Text.Text = row.Cells[5].Value.ToString();
                string filepath = @"Image samples for testing\KHDK\" + label_guestName_Text.Text + ".jpg";
                if (File.Exists(filepath))
                    pictureBox_dtcc_guestFace.Image = Image.FromFile(filepath);
                else
                    pictureBox_dtcc_guestFace.Image = Image.FromFile(@"Image samples for testing\KHDK\No Image.jpg");
                button_guest_mod.Enabled = true;
                button_guest_delete.Enabled = true;
            }
        }

        public void DTCC_guest_dataInitialize()
        {
            SqlCommand cmd;
            SqlDataAdapter Adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "Select KHID,HOTEN,DIACHI,SDT,NGDK, REPLACE(CONVERT(varchar(20), DOANHSO, 1), '.00',''), LOAIKH from KHACHHANG";
            Adapter.SelectCommand = cmd;
            Table.Clear();
            Adapter.Fill(Table);
            dataGridView_dtcc_guest.DataSource = Table;
            dataGridView_dtcc_guest.Columns[0].HeaderText = "Mã khách hàng";
            dataGridView_dtcc_guest.Columns[0].Width = 50;
            dataGridView_dtcc_guest.Columns[1].HeaderText = "Họ tên";
            dataGridView_dtcc_guest.Columns[1].Width = 150;
            dataGridView_dtcc_guest.Columns[2].HeaderText = "Địa chỉ";
            dataGridView_dtcc_guest.Columns[3].HeaderText = "Số điện thoại";
            dataGridView_dtcc_guest.Columns[4].HeaderText = "Ngày đăng kí";
            dataGridView_dtcc_guest.Columns[5].HeaderText = "Doanh số";
            dataGridView_dtcc_guest.Columns[6].HeaderText = "Loại khách hàng";
            button_guest_mod.Enabled = false;
            button_guest_delete.Enabled = false;
            textBox_guest_search.Text = "";
            sqlCon.Close();

    
        }

        public void Guest_DataRefresh(object sender, EventArgs e)
        {
            DTCC_guest_dataInitialize();
        }

        private void button_guest_refresh_Click(object sender, EventArgs e)
        {
            DTCC_guest_dataInitialize();
        }

        private void button_guest_add_Click(object sender, EventArgs e)
        {
            DTCC_guest_form A = new DTCC_guest_form();
            A.RefreshData += Guest_DataRefresh;
            A.Show();
        }

        private void button_guest_mod_Click(object sender, EventArgs e)
        {
            DTCC_guest_modifier A = new DTCC_guest_modifier();
            A.textBox_ID_z.Text = label_guestID_Text.Text;
            A.dateTimePicker_NGDT_z.Value = Convert.ToDateTime(label_guestReg_Text.Text);
            A.textBox_DIACHI_z.Text = label_guestAddress_Text.Text;
            A.textBox_SDT_z.Text = label_guestSDT_Text.Text;
            A.textBox_TENDT_z.Text = label_guestName_Text.Text;
            A.textBox_budget_z.Text = label_guestMoney_Text.Text;
            A.comboBox_loaiKH.Text = label_guestSpec_Text.Text;
            A.pictureBox_image_import.Image = pictureBox_dtcc_guestFace.Image;
            A.RefreshData += Guest_DataRefresh;
            A.Show();
        }

        private void button_guest_delete_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xóa dữ liệu", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                string str;
                str = "delete from KHACHHANG where KHID = '" + label_guestID_Text.Text + "'";
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand newcmd = new SqlCommand(str, sqlCon);
                newcmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "Thông báo");
                /*if(File.Exists(@"\Image samples for testing\Đối tác giao dịch\"+label_TENDTtext.Text+".jpg"))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    File.Delete(@"\Image samples for testing\Đối tác giao dịch\" + label_TENDTtext.Text + ".jpg");
                }
                */
                DTCC_guest_dataInitialize();
            }
        }

        private void button_guest_search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_guest_search.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung cần tìm.");
                textBox_guest_search.Focus();
                return;
            }
            if (comboBox_guest_filter.Text == "Chưa chọn")
            {
                MessageBox.Show("Vui lòng chọn trường cần tìm.");
                comboBox_guest_filter.Focus();
                return;
            }
            switch (comboBox_guest_filter.Text)
            {
                case "Mã khách hàng":
                    Search_guest("KHID");
                    break;

                case "Tên khách hàng":
                    Search_guest("HOTEN");
                    break;

                case "Số điện thoại":
                    Search_guest("SDT");
                    break;

                case "Địa chỉ":
                    Search_guest("DIACHI");
                    break;

                case "Năm đăng kí":
                    Search_guest("Year(NGDK)");
                    break;

                case "Loại khách hàng":
                    Search_guest("LOAIKH");
                    break;
            }
        }

        public void Search_guest(string SearchOption)
        {
            string str;
            str = "Select KHID,HOTEN,DIACHI,SDT,NGDK, REPLACE(CONVERT(varchar(20), DOANHSO, 1), '.00',''), LOAIKH from KHACHHANG where " + SearchOption + " like '%" + textBox_guest_search.Text + "%'";
            SqlCommand cmd;
            SqlDataAdapter Adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = str;
            Adapter.SelectCommand = cmd;
            Table.Clear();
            Adapter.Fill(Table);
            dataGridView_dtcc_guest.DataSource = Table;
            dataGridView_dtcc_guest.Columns[0].HeaderText = "Mã khách hàng";
            dataGridView_dtcc_guest.Columns[0].Width = 50;
            dataGridView_dtcc_guest.Columns[1].HeaderText = "Họ tên";
            dataGridView_dtcc_guest.Columns[1].Width = 150;
            dataGridView_dtcc_guest.Columns[2].HeaderText = "Địa chỉ";
            dataGridView_dtcc_guest.Columns[3].HeaderText = "Số điện thoại";
            dataGridView_dtcc_guest.Columns[4].HeaderText = "Ngày đăng kí";
            dataGridView_dtcc_guest.Columns[5].HeaderText = "Doanh số";
            dataGridView_dtcc_guest.Columns[6].HeaderText = "Loại khách hàng"; button_guest_mod.Enabled = false;
            button_guest_delete.Enabled = false;
            sqlCon.Close();
        }

        private void textBox_guest_search_Click(object sender, EventArgs e)
        {
            textBox_guest_search.SelectAll();
            this.AcceptButton = button_guest_search;
        }

        private void button_sale_Click(object sender, EventArgs e)
        {
            Sale_viewer A = new Sale_viewer();
            A.Show();
        }

        //     ////////////////////    Tabpage Ban hang //////
        private void BNT_TaoHoaDon_Click(object sender, EventArgs e)
        {
            Form_GiaoDich F_GD = new Form_GiaoDich(NVID);
            F_GD.Show();
        }

        private void BNT_Refresh_GD_Click(object sender, EventArgs e)
        {
            this.Refresh_data_GD();
        }

        private void Refresh_data_GD()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd.CommandText = "set dateformat dmy";
            adapter.UpdateCommand = cmd;

            cmd.CommandText = "select SOHD_BH,CONVERT(varchar,NGHD,21) as [DD-MM-YYYY HH:MM:SS],KHID,NVID , REPLACE(CONVERT(varchar(20),TRIGIA, 1), '.00','') , LOAIHD,TRANGTHAI from HDBH";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            GridView_Data_GiaoDich.DataSource = table;
            sqlCon.Close();

            GridView_Data_GiaoDich.Columns[0].HeaderText = "Mã hóa đơn";
            GridView_Data_GiaoDich.Columns[1].HeaderText = "Ngày tạo";
            GridView_Data_GiaoDich.Columns[2].HeaderText = "Mã khách hàng";
            GridView_Data_GiaoDich.Columns[3].HeaderText = "Mã nhân viên";
            GridView_Data_GiaoDich.Columns[4].HeaderText = "Trị giá (VNĐ)";
            GridView_Data_GiaoDich.Columns[5].HeaderText = "Loại hóa đơn";
            GridView_Data_GiaoDich.Columns[6].HeaderText = "Trạng thái";

            CLB_GD_TrangThai.SetItemChecked(0, true);
            CLB_GD_TrangThai.SetItemChecked(1, true);
            CLB_GD_TrangThai.SetItemChecked(2, true);
            CLB_GD_LoaiDon.SetItemChecked(0, true);
            CLB_GD_LoaiDon.SetItemChecked(1, true);
            Box_GD_MaHoaDon.Text = "";
            Box_GD_MaKhachHang.Text = "";
            BOX_GD_MaNhanVien.Text = "";
            CB_GD_HDCB.Checked = false;
        }

        private void bnt_Timkiem_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd.CommandText = "select SOHD_BH,CONVERT(varchar,NGHD,21) as [DD-MM-YYYY HH:MM:SS],KHID,NVID , REPLACE(CONVERT(varchar(20),TRIGIA, 1), '.00','') , LOAIHD,TRANGTHAI from HDBH where (SOHD_BH like '%" + Box_GD_MaHoaDon.Text + "%' and KHID like '%" + Box_GD_MaKhachHang.Text + "%'AND NVID like '%" + BOX_GD_MaNhanVien.Text + "%'  ";
            if (CLB_GD_LoaiDon.CheckedIndices.Contains(0) == false)
            {
                cmd.CommandText += " and LOAIHD != N'Đơn đặt hàng'";
            }
            if (CLB_GD_LoaiDon.CheckedIndices.Contains(1) == false)
            {
                cmd.CommandText += " and LOAIHD != N'Đơn trực tiếp'";
            }
            if (CLB_GD_TrangThai.CheckedIndices.Contains(0) == false)
            {
                cmd.CommandText += " and TRANGTHAI != N'Nhận đơn'";
            }
            if (CLB_GD_TrangThai.CheckedIndices.Contains(1) == false)
            {
                cmd.CommandText += " and TRANGTHAI != N'Đang giao'";
            }

            if (CLB_GD_TrangThai.CheckedIndices.Contains(2) == false)
            {
                cmd.CommandText += " and TRANGTHAI != N'Hoàn thành'";
            }

            if (CB_GD_HDCB.Checked == true)
            {
                cmd.CommandText += "and NVID = '" + NVID + "' ";
            }

            cmd.CommandText += ") ";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            GridView_Data_GiaoDich.DataSource = table;
            sqlCon.Close();

            GridView_Data_GiaoDich.Columns[0].HeaderText = "Mã hóa đơn";
            GridView_Data_GiaoDich.Columns[1].HeaderText = "Ngày tạo";
            GridView_Data_GiaoDich.Columns[2].HeaderText = "Mã khách hàng";
            GridView_Data_GiaoDich.Columns[3].HeaderText = "Mã nhân viên";
            GridView_Data_GiaoDich.Columns[4].HeaderText = "Trị giá (VNĐ)";
            GridView_Data_GiaoDich.Columns[5].HeaderText = "Loại hóa đơn";
            GridView_Data_GiaoDich.Columns[6].HeaderText = "Trạng thái";
        }

        private void GridView_Data_GiaoDich_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridView_Data_GiaoDich.CurrentRow.Index == GridView_Data_GiaoDich.NewRowIndex)
                return;

            Form_CTHD cthd = new Form_CTHD((string)GridView_Data_GiaoDich.CurrentRow.Cells[0].Value, (string)GridView_Data_GiaoDich.CurrentRow.Cells[2].Value, (string)GridView_Data_GiaoDich.CurrentRow.Cells[3].Value, (string)GridView_Data_GiaoDich.CurrentRow.Cells[5].Value, (string)GridView_Data_GiaoDich.CurrentRow.Cells[6].Value, Convert.ToString(GridView_Data_GiaoDich.CurrentRow.Cells[4].Value));
            cthd.Show();
        }

        private Bitmap bmp;

        private void bnt_inDS_Click(object sender, EventArgs e)
        {
            if (GridView_Data_GiaoDich.RowCount > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel WorkBook|*.xlsx";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;
                    worksheet.Name = "Exported from gridview";

                    for (int i = 1; i < GridView_Data_GiaoDich.Columns.Count + 1; i++)
                    {
                        worksheet.Cells[1, i] = GridView_Data_GiaoDich.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < GridView_Data_GiaoDich.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < GridView_Data_GiaoDich.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = GridView_Data_GiaoDich.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    workbook.SaveAs(save.FileName);
                    app.Quit();
                }
            }
        }
    }
}