using System;
using System.Data;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_main_admin : Form
    {
        //
        // NHÓM HÀM TABPAGE BÁO CÁO
        // nhóm hàm tabpage Báo cáo cuối ngày
        private void event_Cuoingay_radio1()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            DateTime day = dtp_bc_time.Value;
            cmd.CommandText = "SELECT SOHD_BH AS 'Số hóa đơn', NGHD as 'Ngày mua', KHID as 'Mã khách hàng', NVID as 'Mã nhân viên', REPLACE(CONVERT(varchar(20), TRIGIA, 1), '.00', '') as 'Trị giá', LOAIHD as 'Loại hóa đơn', TRANGTHAI as 'Trạng thái' FROM HDBH WHERE HDBH.NGHD BETWEEN '" + day.ToString("MM/dd/yyyy 0:00:00") + "' AND '" + day.ToString("MM/dd/yyyy 23:59:59") + "' ORDER BY HDBH.LOAIHD DESC";
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            dgv_bc_cuoingay.DataSource = table;
            cmd.CommandText = "SELECT LOAIHD, SUM(TRIGIA) AS TONGTIEN FROM HDBH WHERE NGHD BETWEEN '" + day.ToString("MM/dd/yyyy 0:00:00") + "' AND '" + day.ToString("MM/dd/yyyy 23:59:59") + "' GROUP BY LOAIHD ORDER BY LOAIHD DESC";
            adapter.SelectCommand = cmd;
            DataTable table1 = new DataTable();
            table1.Clear();
            adapter.Fill(table1);
            if (table1.Rows.Count == 0)
            {
                textBox_bcCuoingay1.Text = "0";
                textBox_bcCuoingay2.Text = "0";
            }
            else if (table1.Rows.Count == 1)
            {
                textBox_bcCuoingay1.Text = String.Format("{0:0,0}", Convert.ToDouble(table1.Rows[0]["TONGTIEN"]));
                textBox_bcCuoingay2.Text = "0";
            }
            else
            {
                textBox_bcCuoingay1.Text = String.Format("{0:0,0}", Convert.ToDouble(table1.Rows[0]["TONGTIEN"]));
                textBox_bcCuoingay2.Text = String.Format("{0:0,0}", Convert.ToDouble(table1.Rows[1]["TONGTIEN"]));
            }
            cmd.CommandText = "SELECT SUM(TRIGIA) AS TONG FROM HDBH WHERE (LOAIHD=N'Đơn trực tiếp' OR (LOAIHD=N'Đơn đặt hàng' AND TRANGTHAI=N'Hoàn thành')) AND NGHD BETWEEN '" + day.ToString("MM/dd/yyyy 0:00:00") + "' AND '" + day.ToString("MM/dd/yyyy 23:59:59") + "'";
            adapter.SelectCommand = cmd;
            DataTable table2 = new DataTable();
            table2.Clear();
            adapter.Fill(table2);
            label_bcCuoingay2.Show();
            label_bcCuoingay3.Show();
            textBox_bcCuoingay2.Show();
            textBox_bcCuoingay3.Show();
            if (table2.Rows[0]["TONG"].ToString() == "")
            {
                textBox_bcCuoingay3.Text = "0";
            }
            else
            {
                textBox_bcCuoingay3.Text = String.Format("{0:0,0}", Convert.ToDouble(table2.Rows[0]["TONG"]));
            }

            sqlCon.Close();
        }

        private void event_Cuoingay_radio2()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            DateTime day = dtp_bc_time.Value;
            cmd.CommandText = "SELECT SOHD_NH as 'Số hóa đơn', NGNHAP as 'Ngày nhập', DTID as 'Mã đối tác', NVID as 'Mã nhân viên', REPLACE(CONVERT(varchar(20), TRIGIA, 1), '.00', '') as 'Trị giá' FROM HDNH WHERE NGNHAP BETWEEN '" + day.ToString("MM/dd/yyyy 0:00:00") + "' AND '" + day.ToString("MM/dd/yyyy 23:59:59") + "'";
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            dgv_bc_cuoingay.DataSource = table;
            cmd.CommandText = "SELECT SUM(TRIGIA) AS TONG FROM HDNH WHERE NGNHAP BETWEEN '" + day.ToString("MM/dd/yyyy 0:00:00") + "' AND '" + day.AddDays(1).ToString("MM/dd/yyyy 23:59:59") + "'";
            adapter.SelectCommand = cmd;
            DataTable table1 = new DataTable();
            table1.Clear();
            adapter.Fill(table1);
            label_bcCuoingay1.Text = "Tong Chi";
            label_bcCuoingay2.Hide();
            label_bcCuoingay3.Hide();
            textBox_bcCuoingay2.Hide();
            textBox_bcCuoingay3.Hide();
            if (table1.Rows[0]["TONG"].ToString() == "")
            {
                textBox_bcCuoingay1.Text = "0";
            }
            else
            {
                textBox_bcCuoingay1.Text = String.Format("{0:0,0}", Convert.ToDouble(table1.Rows[0]["TONG"]));
            }
            sqlCon.Close();
        }

        private void event_Cuoingay_radio3()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            DateTime day = dtp_bc_time.Value;
            cmd.CommandText = "SELECT SOHD_BH AS 'Số hóa đơn', NGHD as 'Ngày thực hiện', KHID AS 'Mã đối tác', NVID as 'Mã nhân viên', REPLACE(CONVERT(varchar(20), TRIGIA, 1), '.00', '') as 'Trị giá' FROM HDBH WHERE(LOAIHD = N'Đơn trực tiếp' OR(LOAIHD = N'Đơn đặt hàng' AND TRANGTHAI = N'Hoàn thành')) AND NGHD BETWEEN '" + day.ToString("MM/dd/yyyy 0:00:00") + "' AND '" + day.ToString("MM/dd/yyyy 23:59:59") + "' UNION SELECT SOHD_NH, NGNHAP, DTID, NVID, REPLACE(CONVERT(varchar(20), TRIGIA, 1), '.00', '') FROM HDNH WHERE NGNHAP BETWEEN '" + day.ToString("MM/dd/yyyy 0:00:00") + "' AND '" + day.ToString("MM/dd/yyyy 23:59:59") + "'";
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            dgv_bc_cuoingay.DataSource = table;
            cmd.CommandText = "SELECT (THU-CHI) AS DOANHTHU FROM (SELECT SUM(THU) AS THU, SUM(CHI) AS CHI FROM( SELECT NGHD AS NGAY, SUM(HDBH.TRIGIA) AS THU, CHI = 0 FROM HDBH WHERE (LOAIHD = N'Đơn trực tiếp' OR(LOAIHD = N'Đơn đặt hàng' AND TRANGTHAI = N'Hoàn thành')) AND NGHD BETWEEN '" + day.ToString("MM/dd/yyyy 0:00:00") + "' AND '" + day.ToString("MM/dd/yyyy 23:59:59") + "' GROUP BY NGHD UNION SELECT NGNHAP AS NGAY, THU = 0, SUM(HDNH.TRIGIA) AS CHI FROM HDNH WHERE NGNHAP BETWEEN '" + day.ToString("MM/dd/yyyy 0:00:00") + "' AND '" + day.ToString("MM/dd/yyyy 23:59:59") + "' GROUP BY NGNHAP) AS K) AS H";
            adapter.SelectCommand = cmd;
            DataTable table1 = new DataTable();
            table1.Clear();
            adapter.Fill(table1);
            label_bcCuoingay1.Text = "Doanh Thu";
            label_bcCuoingay2.Hide();
            label_bcCuoingay3.Hide();
            textBox_bcCuoingay2.Hide();
            textBox_bcCuoingay3.Hide();
            if (table1.Rows[0]["DOANHTHU"].ToString() == "")
                textBox_bcCuoingay1.Text = "0";
            else textBox_bcCuoingay1.Text = String.Format("{0:0,0}", Convert.ToDouble(table1.Rows[0]["DOANHTHU"]));
            sqlCon.Close();
        }

        private void rBtn_bc_qt1_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtn_bc_qt1.Checked)
            {
                event_Cuoingay_radio1();
            }
            else if (rBtn_bc_qt2.Checked)
            {
                event_Cuoingay_radio2();
            }
            else if (rBtn_bc_qt3.Checked)
            {
                event_Cuoingay_radio3();
            }
        }

        private void dtp_bc_time_ValueChanged(object sender, EventArgs e)
        {
            rBtn_bc_qt1_CheckedChanged(rBtn_bc_qt1, new EventArgs());
        }

        // Nhóm hàm tabpage Báo cáo doanh thu
        private void event_bc_DoanhThu_TheoThang()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT DAY(NGAY) AS NGAY, SUM(THU) AS TONGTHU, SUM(CHI) AS TONGCHI FROM( SELECT NGHD AS NGAY, SUM(HDBH.TRIGIA) AS THU, CHI = 0 FROM HDBH WHERE (LOAIHD = N'Đơn trực tiếp' OR(LOAIHD = N'Đơn đặt hàng' AND TRANGTHAI = N'Hoàn thành')) AND MONTH(NGHD)=" + comboBox_bc_Doanhthu_nhap1.Text + " AND YEAR(NGHD)=" + textBox_bc_DoanhThu_nhap2.Text + " GROUP BY NGHD UNION SELECT NGNHAP AS NGAY, THU = 0, SUM(HDNH.TRIGIA) AS CHI FROM HDNH WHERE MONTH(NGNHAP)=" + comboBox_bc_Doanhthu_nhap1.Text + "AND YEAR(NGNHAP)=" + textBox_bc_DoanhThu_nhap2.Text + " GROUP BY NGNHAP) AS K GROUP BY DAY(NGAY)";
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            chart_bc_Doanhthu.Titles["Title_chart_bc_Doanhthu"].Text = "Biểu đồ doanh thu tháng " + comboBox_bc_Doanhthu_nhap1.Text + " năm " + textBox_bc_DoanhThu_nhap2.Text;
            chart_bc_Doanhthu.ChartAreas["ChartArea1"].AxisX.Title = "Ngày";
            chart_bc_Doanhthu.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            chart_bc_Doanhthu.ChartAreas["ChartArea1"].AxisX.Maximum = DateTime.DaysInMonth(Convert.ToInt32(textBox_bc_DoanhThu_nhap2.Text), Convert.ToInt32(comboBox_bc_Doanhthu_nhap1.Text)) + 1;
            chart_bc_Doanhthu.ChartAreas["ChartArea1"].AxisX.Interval = 2;
            chart_bc_Doanhthu.ChartAreas["ChartArea1"].AxisY.Title = "Triệu";
            chart_bc_Doanhthu.Series["Series_Thu"].Points.Clear();
            chart_bc_Doanhthu.Series["Series_Chi"].Points.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                chart_bc_Doanhthu.Series["Series_Thu"].Points.AddXY(table.Rows[i]["NGAY"], (Convert.ToDouble(table.Rows[i]["TONGTHU"]) / 1000000));
                chart_bc_Doanhthu.Series["Series_Chi"].Points.AddXY(table.Rows[i]["NGAY"], (Convert.ToDouble(table.Rows[i]["TONGCHI"]) / 1000000));
            }
            cmd.CommandText = "SELECT SUM(THU) AS TONGTHU, SUM(CHI) AS TONGCHI FROM( SELECT NGHD AS NGAY, SUM(HDBH.TRIGIA) AS THU, CHI = NULL FROM HDBH WHERE (LOAIHD = N'Đơn trực tiếp' OR(LOAIHD = N'Đơn đặt hàng' AND TRANGTHAI = N'Hoàn thành')) AND MONTH(NGHD)=" + comboBox_bc_Doanhthu_nhap1.Text + " AND YEAR(NGHD)=" + textBox_bc_DoanhThu_nhap2.Text + " GROUP BY NGHD UNION SELECT NGNHAP AS NGAY, THU = NULL, SUM(HDNH.TRIGIA) AS CHI FROM HDNH WHERE MONTH(NGNHAP)=" + comboBox_bc_Doanhthu_nhap1.Text + " AND YEAR(NGNHAP)=" + textBox_bc_DoanhThu_nhap2.Text + " GROUP BY NGNHAP) AS K ";
            adapter.SelectCommand = cmd;
            DataTable table1 = new DataTable();
            table1.Clear();
            adapter.Fill(table1);
            if (table1.Rows[0]["TONGTHU"].ToString() == "")
                textBox_bc_Doanhthu_thu.Text = "0";
            else textBox_bc_Doanhthu_thu.Text = String.Format("{0:0,0}", Convert.ToDouble(table1.Rows[0]["TONGTHU"]));
            if (table1.Rows[0]["TONGCHI"].ToString() == "")
                textBox_bc_Doanhthu_chi.Text = "0";
            else textBox_bc_Doanhthu_chi.Text = String.Format("{0:0,0}", Convert.ToDouble(table1.Rows[0]["TONGCHI"]));
            cmd.CommandText = "SELECT (TONGTHU-TONGCHI) AS DOANHTHU FROM (SELECT SUM(THU) AS TONGTHU, SUM(CHI) AS TONGCHI FROM( SELECT SUM(HDBH.TRIGIA) AS THU, CHI = 0 FROM HDBH WHERE (LOAIHD = N'Đơn trực tiếp' OR(LOAIHD = N'Đơn đặt hàng' AND TRANGTHAI = N'Hoàn thành')) AND MONTH(NGHD)=" + comboBox_bc_Doanhthu_nhap1.Text + " AND YEAR(NGHD)=" + textBox_bc_DoanhThu_nhap2.Text + " UNION SELECT THU = 0, SUM(HDNH.TRIGIA) AS CHI FROM HDNH WHERE MONTH(NGNHAP)=" + comboBox_bc_Doanhthu_nhap1.Text + " AND YEAR(NGNHAP)=" + textBox_bc_DoanhThu_nhap2.Text + " GROUP BY NGNHAP) AS K) AS H";
            adapter.SelectCommand = cmd;
            DataTable table2 = new DataTable();
            table2.Clear();
            adapter.Fill(table2);
            if (table2.Rows[0]["DOANHTHU"].ToString() == "")
                textBox_bc_Doanhthu_doanhthu.Text = "0";
            else textBox_bc_Doanhthu_doanhthu.Text = String.Format("{0:0,0}", Convert.ToDouble(table2.Rows[0]["DOANHTHU"]));
            sqlCon.Close();
        }

        private void event_bc_DoanhThu_TheoQuy()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            int Quy = Convert.ToInt32(comboBox_bc_Doanhthu_nhap1.Text);
            cmd.CommandText = "SELECT THANG, SUM(THU) AS TONGTHU, SUM(CHI) AS TONGCHI FROM( SELECT MONTH(NGHD) AS THANG, SUM(HDBH.TRIGIA) AS THU, CHI = 0 FROM HDBH WHERE (LOAIHD = N'Đơn trực tiếp' OR(LOAIHD = N'Đơn đặt hàng' AND TRANGTHAI = N'Hoàn thành')) AND MONTH(NGHD) BETWEEN (" + Quy * 3 + "-2) AND " + Quy * 3 + " GROUP BY MONTH(NGHD) UNION SELECT MONTH(NGNHAP), THU = 0, SUM(HDNH.TRIGIA) AS CHI FROM HDNH WHERE MONTH(NGNHAP) BETWEEN (" + Quy * 3 + " -2) AND " + Quy * 3 + " GROUP BY NGNHAP) AS K GROUP BY THANG";
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            chart_bc_Doanhthu.Titles["Title_chart_bc_Doanhthu"].Text = "Biểu đồ doanh thu quý " + comboBox_bc_Doanhthu_nhap1.Text;
            chart_bc_Doanhthu.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";
            chart_bc_Doanhthu.ChartAreas["ChartArea1"].AxisX.Minimum = Quy * 3 - 3;
            chart_bc_Doanhthu.ChartAreas["ChartArea1"].AxisX.Maximum = Quy * 3 + 1;
            chart_bc_Doanhthu.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chart_bc_Doanhthu.ChartAreas["ChartArea1"].AxisY.Title = "VND";
            chart_bc_Doanhthu.Series["Series_Thu"].Points.Clear();
            chart_bc_Doanhthu.Series["Series_Chi"].Points.Clear();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                chart_bc_Doanhthu.Series["Series_Thu"].Points.AddXY(table.Rows[i]["THANG"], (Convert.ToDouble(table.Rows[i]["TONGTHU"]) / 1000000));
                chart_bc_Doanhthu.Series["Series_Chi"].Points.AddXY(table.Rows[i]["THANG"], (Convert.ToDouble(table.Rows[i]["TONGCHI"]) / 1000000));
            }

            sqlCon.Close();
        }

        private void comboBox_bc_Doanhthu_kieutinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_bc_Doanhthu_kieutinh.SelectedIndex == 0)
            {
                label_bc_Doanhthu_nhap1.Text = "Nhập tháng";
                DateTime date = DateTime.Today;
                comboBox_bc_Doanhthu_nhap1.Items.Clear();
                comboBox_bc_Doanhthu_nhap1.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
                comboBox_bc_Doanhthu_nhap1.Text = date.Month.ToString();
                textBox_bc_DoanhThu_nhap2.Text = date.Year.ToString();
                event_bc_DoanhThu_TheoThang();
            }
            else if (comboBox_bc_Doanhthu_kieutinh.SelectedIndex == 1)
            {
                label_bc_Doanhthu_nhap1.Text = "Nhập Quý";
                DateTime date = DateTime.Today;
                comboBox_bc_Doanhthu_nhap1.Items.Clear();
                comboBox_bc_Doanhthu_nhap1.Items.AddRange(new object[] { "1", "2", "3", "4" });
                if (date.Month <= 3)
                    comboBox_bc_Doanhthu_nhap1.Text = "1";
                else if (date.Month <= 6)
                    comboBox_bc_Doanhthu_nhap1.Text = "2";
                else if (date.Month <= 9)
                    comboBox_bc_Doanhthu_nhap1.Text = "3";
                else comboBox_bc_Doanhthu_nhap1.Text = "4";
                textBox_bc_DoanhThu_nhap2.Text = date.Year.ToString();
                event_bc_DoanhThu_TheoQuy();
            }
        }

        private void btn_bc_Doanhthu_Click(object sender, EventArgs e)
        {
            if (comboBox_bc_Doanhthu_kieutinh.SelectedIndex == 0)
            {
                try
                {
                    if (comboBox_bc_Doanhthu_nhap1.Text == "" || textBox_bc_DoanhThu_nhap2.Text == "")
                    {
                        MessageBox.Show("Bạn vẫn chưa nhập xong", "Thông báo");
                        return;
                    }
                    else if (Convert.ToInt32(comboBox_bc_Doanhthu_nhap1.Text) < 1 || Convert.ToInt32(comboBox_bc_Doanhthu_nhap1.Text) > 12 || Convert.ToInt32(textBox_bc_DoanhThu_nhap2.Text) < 1)
                    {
                        MessageBox.Show("Thông tin không hợp lệ", "Thông báo");
                        return;
                    }
                    else
                    {
                        event_bc_DoanhThu_TheoThang();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Thông tin không hợp lệ", "Thông báo");
                }
            }
            else if (comboBox_bc_Doanhthu_kieutinh.SelectedIndex == 1)
            {
                try
                {
                    if (comboBox_bc_Doanhthu_nhap1.Text == "" || textBox_bc_DoanhThu_nhap2.Text == "")
                    {
                        MessageBox.Show("Bạn vẫn chưa nhập xong", "Thông báo");
                        return;
                    }
                    else if (Convert.ToInt32(comboBox_bc_Doanhthu_nhap1.Text) < 1 || Convert.ToInt32(comboBox_bc_Doanhthu_nhap1.Text) > 4 || Convert.ToInt32(textBox_bc_DoanhThu_nhap2.Text) < 1)
                    {
                        MessageBox.Show("Thông tin không hợp lệ", "Thông báo");
                        return;
                    }
                    else
                    {
                        event_bc_DoanhThu_TheoQuy();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Thông tin không hợp lệ", "Thông báo");
                }
            }
        }

        // nhóm hàm tabpage báo cáo nhân viên
        private void event_bc_nv_TheoThang()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT HDBH.NVID AS MANV, SUM(TRIGIA)AS DOANHSO, HOTEN FROM HDBH inner join NHANVIEN on HDBH.NVID=NHANVIEN.NVID WHERE (LOAIHD = N'Đơn trực tiếp' OR(LOAIHD = N'Đơn đặt hàng' AND TRANGTHAI = N'Hoàn thành')) AND MONTH(NGHD)=" + comboBox_bc_nv_nhap1.Text + " GROUP BY HDBH.NVID, HOTEN ORDER BY DOANHSO DESC";
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            adapter.Fill(table);
            chart_bc_nv.Titles["Title1"].Text = "Biểu đồ daonh số bán hàng nhân viên tháng " + comboBox_bc_nv_nhap1.Text;
            chart_bc_nv.ChartAreas["ChartArea1"].AxisX.Title = "Tên NV";
            chart_bc_nv.ChartAreas["ChartArea1"].AxisY.Title = "Triệu";
            chart_bc_nv.Series["Series1"].Points.Clear();
            if (table.Rows.Count == 0)
            {
                textBox_bc_nv_kq1.Text = "0";
                textBox_bc_nv_kq2.Text = "0";
                textBox_bc_nv_kq3.Text = "0";
                return;
            }
            int i = 4;
            if (table.Rows.Count < 5)
            {
                i = table.Rows.Count - 1;
            }
            for (; i >= 0; i--)
            {
                chart_bc_nv.Series["Series1"].Points.AddXY(table.Rows[i]["HOTEN"], (Convert.ToDouble(table.Rows[i]["DOANHSO"]) / 1000000));
            }

            textBox_bc_nv_kq1.Text = table.Rows[0]["MANV"].ToString();
            textBox_bc_nv_kq2.Text = table.Rows[0]["HOTEN"].ToString();
            textBox_bc_nv_kq3.Text = String.Format("{0:0,0}", Convert.ToDouble(table.Rows[0]["DOANHSO"]));

            sqlCon.Close();
        }

        private void event_bc_nv_TheoQuy()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            int Quy = Convert.ToInt32(comboBox_bc_nv_nhap1.Text);
            cmd.CommandText = "SELECT HDBH.NVID AS MANV, HOTEN, SUM(TRIGIA) AS DOANHSO FROM HDBH INNER JOIN NHANVIEN ON HDBH.NVID = NHANVIEN.NVID WHERE MONTH(NGHD) BETWEEN " + (Quy * 3 - 2) + " AND " + Quy * 3 + " AND YEAR(NGHD)= " + textBox_bc_nv_nhap2.Text + " GROUP BY HDBH.NVID, HOTEN ORDER BY DOANHSO DESC";
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            chart_bc_nv.Titles["Title1"].Text = "Biểu đồ doanh số bán hàng nhân viên quý " + comboBox_bc_nv_nhap1.Text;
            chart_bc_nv.ChartAreas["ChartArea1"].AxisX.Title = "Tên NV";
            chart_bc_nv.ChartAreas["ChartArea1"].AxisY.Title = "Triệu";
            chart_bc_nv.Series["Series1"].Points.Clear();
            if (table.Rows.Count == 0)
            {
                textBox_bc_nv_kq1.Text = "0";
                textBox_bc_nv_kq2.Text = "0";
                textBox_bc_nv_kq3.Text = "0";
                return;
            }
            int i = 4;
            if (table.Rows.Count < 5)
            {
                i = table.Rows.Count - 1;
            }
            for (; i >= 0; i--)
            {
                chart_bc_nv.Series["Series1"].Points.AddXY(table.Rows[i]["HOTEN"], (Convert.ToDouble(table.Rows[i]["DOANHSO"]) / 1000000));
            }
            textBox_bc_nv_kq1.Text = table.Rows[0]["MANV"].ToString();
            textBox_bc_nv_kq2.Text = table.Rows[0]["HOTEN"].ToString();
            textBox_bc_nv_kq3.Text = String.Format("{0:0,0}", Convert.ToDouble(table.Rows[0]["DOANHSO"]).ToString());

            sqlCon.Close();
        }

        private void comboBox_bc_Nv_kieutinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_bc_Nv_kieutinh.SelectedIndex == 0)
            {
                label_bc_nv_nhap1.Text = "Nhập tháng";
                DateTime date = DateTime.Today;
                comboBox_bc_nv_nhap1.Items.Clear();
                comboBox_bc_nv_nhap1.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
                comboBox_bc_nv_nhap1.Text = date.Month.ToString();
                textBox_bc_nv_nhap2.Text = date.Year.ToString();
                event_bc_nv_TheoThang();
            }
            else if (comboBox_bc_Nv_kieutinh.SelectedIndex == 1)
            {
                label_bc_nv_nhap1.Text = "Nhập quý";
                DateTime date = DateTime.Today;
                comboBox_bc_nv_nhap1.Items.Clear();
                comboBox_bc_nv_nhap1.Items.AddRange(new object[] { "1", "2", "3", "4" });
                if (date.Month <= 3)
                    comboBox_bc_nv_nhap1.Text = "1";
                else if (date.Month <= 6)
                    comboBox_bc_nv_nhap1.Text = "2";
                else if (date.Month <= 9)
                    comboBox_bc_nv_nhap1.Text = "3";
                else comboBox_bc_nv_nhap1.Text = "4";
                textBox_bc_nv_nhap2.Text = date.Year.ToString();
                event_bc_nv_TheoQuy();
            }
        }

        private void btn_bc_nv_xem_Click(object sender, EventArgs e)
        {
            if (comboBox_bc_Nv_kieutinh.SelectedIndex == 0)
            {
                try
                {
                    if (comboBox_bc_nv_nhap1.Text == "" || textBox_bc_nv_nhap2.Text == "")
                    {
                        MessageBox.Show("Bạn vẫn chưa nhập xong", "Thông báo");
                        return;
                    }
                    else if (Convert.ToInt32(comboBox_bc_nv_nhap1.Text) < 1 || Convert.ToInt32(comboBox_bc_nv_nhap1.Text) > 12 || Convert.ToInt32(textBox_bc_nv_nhap2.Text) < 1)
                    {
                        MessageBox.Show("Thông tin không hợp lệ", "Thông báo");
                        return;
                    }
                    else
                    {
                        event_bc_nv_TheoThang();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Thông tin không hợp lệ", "Thông báo");
                }
            }
            else if (comboBox_bc_Nv_kieutinh.SelectedIndex == 1)
            {
                try
                {
                    if (comboBox_bc_nv_nhap1.Text == "" || textBox_bc_nv_nhap2.Text == "")
                    {
                        MessageBox.Show("Bạn vẫn chưa nhập xong", "Thông báo");
                        return;
                    }
                    else if (Convert.ToInt32(comboBox_bc_nv_nhap1.Text) < 1 || Convert.ToInt32(comboBox_bc_nv_nhap1.Text) > 4 || Convert.ToInt32(textBox_bc_nv_nhap2.Text) < 1)
                    {
                        MessageBox.Show("Thông tin không hợp lệ", "Thông báo");
                        return;
                    }
                    else
                    {
                        event_bc_nv_TheoQuy();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Thông tin không hợp lệ", "Thông báo");
                }
            }
        }
    }
}