using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_main_admin : Form
    { // TabPage_Đối tác
        public void DTCC_dtgd_dataInitialize()
        {
            SqlCommand cmd;
            SqlDataAdapter Adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "Select * from DTCC";
            Adapter.SelectCommand = cmd;
            Table.Clear();
            Adapter.Fill(Table);
            dataGridView_DTCC.DataSource = Table;
            dataGridView_DTCC.Columns[0].HeaderText = "Mã đối tác";
            dataGridView_DTCC.Columns[1].HeaderText = "Tên đối tác";
            dataGridView_DTCC.Columns[2].HeaderText = "Số điện thoại";
            dataGridView_DTCC.Columns[3].HeaderText = "Ngày trở thành đối tác";
            dataGridView_DTCC.Columns[4].HeaderText = "Địa chỉ";
            button_modDTCC.Enabled = false;
            button_deleteDTCC.Enabled = false;
            textBox_search.Text = "";
            sqlCon.Close();
        }

        public void DTCC_guest_dataInitialize()
        {
            SqlCommand cmd;
            SqlDataAdapter Adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = " Select KHID,HOTEN,DIACHI,SDT,NGDK, REPLACE(CONVERT(varchar(20), DOANHSO, 1), '.00',''), LOAIKH from KHACHHANG";
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

        public void DTCC_DataRefresh(object sender, EventArgs e)
        {
            DTCC_dtgd_dataInitialize();
        }

        public void Guest_DataRefresh(object sender, EventArgs e)
        {
            DTCC_guest_dataInitialize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            DTCC_modifier A = new DTCC_modifier();
            A.textBox_ID_z.Text = label_IDtext.Text;
            A.dateTimePicker_NGDT_z.Text = label_NGDTtext.Text;
            A.textBox_DIACHI_z.Text = label_DIACHItext.Text;
            A.textBox_SDT_z.Text = label_SDTtext.Text;
            A.textBox_TENDT_z.Text = label_TENDTtext.Text;
            using (FileStream stream = new FileStream(@"Image samples for testing\DTGD\" + label_IDtext.Text + ".jpg", FileMode.Open, FileAccess.Read))
            {
                A.pictureBox_image_import.Image = Image.FromStream(stream);
                stream.Dispose();
            }
            A.RefreshData += DTCC_DataRefresh;
            sqlCon.Close();
            A.Show();
        }

        private void dataGridView_DTCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_DTCC.Rows[e.RowIndex];
                DateTime Date = new DateTime();

                label_IDtext.Text = row.Cells[0].Value.ToString();
                label_TENDTtext.Text = row.Cells[1].Value.ToString();
                label_SDTtext.Text = row.Cells[2].Value.ToString();
                Date = Convert.ToDateTime(row.Cells[3].Value.ToString());
                label_NGDTtext.Text = Date.ToString();
                label_DIACHItext.Text = row.Cells[4].Value.ToString();
                string filepath = @"Image samples for testing\DTGD\" + label_IDtext.Text + ".jpg";
                if (File.Exists(filepath))
                    pictureBox_Logo.Image = Image.FromFile(filepath);
                else
                    pictureBox_Logo.Image = Image.FromFile(@"Image samples for testing\DTGD\No Image.jpg");
                button_modDTCC.Enabled = true;
                button_deleteDTCC.Enabled = true;
            }
        }

        private void button_addDTCC_Click(object sender, EventArgs e)
        {
            DTCC_form A = new DTCC_form();
            A.RefreshData += DTCC_DataRefresh;
            A.Show();
        }

        private void button_deleteDTCC_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xóa dữ liệu", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                string str;
                str = "delete from DTCC where DTID = '" + label_IDtext.Text + "'";
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand newcmd = new SqlCommand(str, sqlCon);
                newcmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "Thông báo");
                /*if(file.exists(@"\image samples for testing\DTGD\"+label_tendttext.text+".jpg"))
                {
                    system.gc.collect();
                    system.gc.waitforpendingfinalizers();
                    file.delete(@"\image samples for testing\DTGD\" + label_tendttext.text + ".jpg");
                }
                */
                DTCC_dtgd_dataInitialize();
            }
        }

        private void button_searchDTCC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_search.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung cần tìm.");
                textBox_search.Focus();
                return;
            }
            if (comboBox_searchOption.Text == "Chưa chọn")
            {
                MessageBox.Show("Vui lòng chọn trường cần tìm");
                comboBox_searchOption.Focus();
                return;
            }
            switch (comboBox_searchOption.Text)
            {
                case "Mã đối tác":
                    Search("DTID");
                    break;

                case "Tên đối tác":
                    Search("TENDT");
                    break;

                case "Số điện thoại":
                    Search("SDT");
                    break;

                case "Địa chỉ":
                    Search("DIACHI");
                    break;

                case "Năm trở thành đối tác":
                    Search("Year(NGDT)");
                    break;
            }
        }

        public void Search(string SearchOption)
        {
            string str;
            str = "select * from DTCC where " + SearchOption + " like '%" + textBox_search.Text + "%'";
            SqlCommand cmd;
            SqlDataAdapter Adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            if (SearchOption == "NGDT")
            {
                cmd.CommandText = "set dateformat dmy";
                cmd.ExecuteNonQuery();
            }
            cmd.CommandText = str;
            Adapter.SelectCommand = cmd;
            Table.Clear();
            Adapter.Fill(Table);
            dataGridView_DTCC.DataSource = Table;
            button_modDTCC.Enabled = false;
            button_deleteDTCC.Enabled = false;
            sqlCon.Close();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            DTCC_dtgd_dataInitialize();
        }

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
                label_guestMoney_Text.Text = String.Format("{0:0,0}", Convert.ToDouble(row.Cells[5].Value.ToString().Replace(",", string.Empty)) + " VND");
                string filepath = @"Image samples for testing\KHDK\" + label_guestID_Text.Text + ".jpg";
                if (File.Exists(filepath))
                    pictureBox_dtcc_guestFace.Image = Image.FromFile(filepath);
                else
                    pictureBox_dtcc_guestFace.Image = Image.FromFile(@"Image samples for testing\KHDK\No Image.jpg");
                button_guest_mod.Enabled = true;
                button_guest_delete.Enabled = true;
            }
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
            A.dateTimePicker_NGDT_z.Text = label_guestReg_Text.Text;
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
                /*if(File.Exists(@"\Image samples for testing\DTGD\"+label_TENDTtext.Text+".jpg"))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    File.Delete(@"\Image samples for testing\DTGD\" + label_TENDTtext.Text + ".jpg");
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
            str = " Select KHID,HOTEN,DIACHI,SDT,NGDK, REPLACE(CONVERT(varchar(20), DOANHSO, 1), '.00',''), LOAIKH from KHACHHANG where " + SearchOption + " like '%" + textBox_guest_search.Text + "%'";
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
            dataGridView_dtcc_guest.Columns[6].HeaderText = "Loại khách hàng";
            button_guest_mod.Enabled = false;
            button_guest_delete.Enabled = false;
            sqlCon.Close();
        }

        private void textBox_search_Click(object sender, EventArgs e)
        {
            textBox_search.SelectAll();
            this.AcceptButton = button_searchDTCC;
        }

        private void textBox_guest_search_Click(object sender, EventArgs e)
        {
            textBox_guest_search.SelectAll();
        }

        private void button_sale_Click(object sender, EventArgs e)
        {
            Sale_viewer A = new Sale_viewer();
            A.Show();
        }
    }
}