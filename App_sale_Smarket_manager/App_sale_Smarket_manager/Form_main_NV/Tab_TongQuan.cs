using System;
using System.Data;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_main_NV : Form
    {
        // TABPAGE TỔNG QUAN.
        private Timer timer = new Timer();

        private void tabctrl_Nhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabctrl_Nhanvien.SelectedIndex == 0)
            {
                load_tongquan();
            }
            else if (tabctrl_Nhanvien.SelectedIndex == 3)
            {
                timer.Tick += Timer_Tick;
                timer.Start();
                timer.Interval = 1000;
                load_lich();
            }
            else if (tabctrl_Nhanvien.SelectedIndex == 1)
            {
                this.Refresh_data_GD();
            }
            else if (tabctrl_Nhanvien.SelectedIndex == 4)
            {
                LoadData_nv_infonv();
            }
        }

        private void load_tongquan_dsNgay()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            DateTime date = DateTime.Today;
            cmd.CommandText = "SELECT COUNT(SOHD_BH) AS SL, SUM(TRIGIA) AS TRIGIA"
                                + " FROM HDBH"
                                + " WHERE LOAIHD = N'Đơn trực tiếp' AND NVID = '" + NVID + "' AND NGHD BETWEEN '" + date.ToString("MM/dd/yyyy 0:00:00") + "' AND '" + date.ToString("MM/dd/yyyy 23:59:59") + "'"
                                + " UNION"
                                + " SELECT COUNT(SOHD_BH), SUM(TRIGIA)"
                                + " FROM HDBH"
                                + " WHERE LOAIHD = N'Đơn đặt hàng' AND TRANGTHAI = 'Hoàn thành' AND NVID = '" + NVID + "' AND NGHD BETWEEN '" + date.ToString("MM/dd/yyyy 0:00:00") + "' AND '" + date.ToString("MM/dd/yyyy 23:59:59") + "'";
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            try
            {
                txt_tongquan_slhdbh.Text = table.Rows[1]["SL"].ToString();
                if (table.Rows[1]["TRIGIA"].ToString() == "")
                    txt_tongquan_trigiabh.Text = "0";
                else txt_tongquan_trigiabh.Text = String.Format("{0:0,0}", table.Rows[1]["TRIGIA"]);
            }
            catch (Exception)
            {
                txt_tongquan_slhdbh.Text = "0";
                txt_tongquan_trigiabh.Text = "0";
            }
            try
            {
                txt_tongquan_slhddh.Text = table.Rows[0]["SL"].ToString();
                if (table.Rows[0]["TRIGIA"].ToString() == "")
                    txt_tongquan_trigiadh.Text = "0";
                else txt_tongquan_trigiadh.Text = string.Format("{0:0,0}", table.Rows[0]["TRIGIA"]);
            }
            catch
            {
                txt_tongquan_slhddh.Text = "0";
                txt_tongquan_trigiadh.Text = "0";
            }
            try
            {
                txt_tongquan_dsNgay.Text = string.Format("{0:0,0}", (Convert.ToDouble(table.Rows[0]["TRIGIA"]) + Convert.ToDouble(table.Rows[0]["TRIGIA"])));
            }
            catch (Exception)
            {
                txt_tongquan_dsNgay.Text = "0";
            }
            sqlCon.Close();
        }

        private void load_tongquan_dsThang()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            DateTime date = DateTime.Today;
            cmd.CommandText = "SELECT DAY(NGHD) as NGAY, SUM(TRIGIA) as TRIGIA"
                                + " FROM HDBH"
                                + " WHERE NVID = '" + NVID + "' AND(LOAIHD = N'Đơn trực tiếp' OR(LOAIHD = N'Đơn đặt hàng' AND TRANGTHAI = N'Hoàn thành')) AND MONTH(NGHD)=" + date.Month.ToString()
                                + " GROUP BY DAY(NGHD)"
                                + " ORDER BY DAY(NGHD) ASC";
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            chart_tongquan.Titles["Title1"].Text = "Doanh số tháng " + date.Month.ToString();
            chart_tongquan.ChartAreas["ChartArea1"].AxisX.Title = "Ngày";
            chart_tongquan.ChartAreas["ChartArea1"].AxisY.Title = "Triệu đồng";
            chart_tongquan.Series["DoanhSo"].Points.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                chart_tongquan.Series["DoanhSo"].Points.AddXY(table.Rows[i]["NGAY"] +"/"+date.ToString("MM/yyyy"), Convert.ToDouble(table.Rows[i]["TRIGIA"]) / 1000000);
            }
            cmd.CommandText = "SELECT SUM(TRIGIA)"
                                + " FROM HDBH"
                                + " WHERE NVID = '" + NVID + "' AND(LOAIHD = N'Đơn trực tiếp' OR(LOAIHD = N'Đơn đặt hàng' AND TRANGTHAI = N'Hoàn thành')) AND MONTH(NGHD)= " + date.Month.ToString();
            txt_tongquan_dsThang.Text = cmd.ExecuteScalar().ToString();
            if (txt_tongquan_dsThang.Text == "")
                txt_tongquan_dsThang.Text = "0";
            else txt_tongquan_dsThang.Text = String.Format("{0:0,0}", Convert.ToDouble(txt_tongquan_dsThang.Text));
            sqlCon.Close();
        }

        private void load_tongquan_xephang()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            DateTime date = DateTime.Today;
            cmd.CommandText = "SELECT TOP 3 HDBH.NVID, HOTEN, SUM(TRIGIA) AS DOANHSO"
                                + " FROM HDBH INNER JOIN NHANVIEN ON HDBH.NVID = NHANVIEN.NVID"
                                + " WHERE(LOAIHD = N'Đơn trực tiếp' OR(LOAIHD = N'Đơn đặt hàng' AND TRANGTHAI = N'Hoàn thành')) AND MONTH(NGHD)= " + date.Month.ToString() + ""
                                + " GROUP BY HDBH.NVID, HOTEN"
                                + " ORDER BY DOANHSO DESC";
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            try
            {
                lbl_tongquan_ten1.Text = table.Rows[0]["HOTEN"].ToString();
                txt_tongquan_ds1.Text = string.Format("{0:0,0}", Convert.ToDouble(table.Rows[0]["DOANHSO"]));
                lbl_tongquan_ten2.Text = table.Rows[1]["HOTEN"].ToString();
                txt_tongquan_ds2.Text = string.Format("{0:0,0}", Convert.ToDouble(table.Rows[1]["DOANHSO"]));
                lbl_tongquan_ten3.Text = table.Rows[2]["HOTEN"].ToString();
                txt_tongquan_ds3.Text = string.Format("{0:0,0}", Convert.ToDouble(table.Rows[1]["DOANHSO"]));
            }
            catch (Exception)
            {
            }
            cmd.CommandText = "SELECT HANG, DOANHSO"
                              + " FROM("
                              + " SELECT DENSE_RANK() OVER(ORDER BY DOANHSO DESC) AS HANG, NVID, DOANHSO"
                                + " FROM("
                                + " SELECT NVID, SUM(TRIGIA) AS DOANHSO"
                                + " FROM HDBH"
                                + " WHERE(LOAIHD = N'Đơn trực tiếp' OR(LOAIHD = N'Đơn đặt hàng' AND TRANGTHAI = N'Hoàn thành')) AND MONTH(NGHD) = " + date.Month.ToString() + ""
                                + " GROUP BY NVID"
                                + " ) AS K"
                                + ") AS H"
                                + " WHERE NVID = '" + NVID + "'";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lbl_tongquan_ten0.Text = reader.GetInt64(0).ToString();
                txt_tongquan_ds0.Text = string.Format("{0:0,0}", Convert.ToDouble(reader.GetDecimal(1)));
            }
            reader.Close();
            sqlCon.Close();
        }

        private void load_tongquan_danhsachdoanhso()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            DateTime date = DateTime.Today;
            cmd.CommandText = "SELECT HDBH.NVID as 'Mã nhân viên', HOTEN as 'Họ tên', REPLACE(CONVERT(varchar(20), SUM(TRIGIA), 1), '.00', '') AS 'Doanh số'"
                                + " FROM HDBH INNER JOIN NHANVIEN ON HDBH.NVID = NHANVIEN.NVID"
                                + " WHERE(LOAIHD = N'Đơn trực tiếp' OR(LOAIHD = N'Đơn đặt hàng' AND TRANGTHAI = N'Hoàn thành')) AND NGHD BETWEEN '" + date.ToString("MM/dd/yyyy 0:00:00") + "' AND '" + date.ToString("MM/dd/yyyy 23:59:59") + "' AND HDBH.NVID <>'" + NVID + "'"
                                + " GROUP BY HDBH.NVID, HOTEN"
                                + " ORDER BY SUM(TRIGIA) DESC";

            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            dgv_tongquan.DataSource = table;
            dgv_tongquan.Columns[0].Width = 50;
            sqlCon.Close();
        }

        private void load_tongquan()
        {
            load_tongquan_dsNgay();
            load_tongquan_dsThang();
            load_tongquan_xephang();
            load_tongquan_danhsachdoanhso();
        }
    }
}