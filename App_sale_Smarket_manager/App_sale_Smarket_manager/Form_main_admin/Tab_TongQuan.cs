using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_main_admin : Form
    {
        // NHÓM HÀM TABPAGE TỔNG QUAN
        private void load_gdv_HoaDon()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            DateTime date = DateTime.Today;
            cmd.CommandText = "SELECT COUNT(SOHD_BH) as SoHoaDon, SUM(TRIGIA) as DoanhThu FROM HDBH WHERE lOAIHD = N'Đơn trực tiếp' AND NGHD BETWEEN '" + date.ToString("MM/dd/yyyy 0:00:00") + "' and '" + date.ToString("MM/dd/yyyy 23:59:59") + "'";
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            txtSoHD.Text = table.Rows[0]["SoHoaDon"].ToString();
            if (table.Rows[0]["DoanhThu"].ToString() == "")
                txtTrigiaHD.Text = "0";
            else
                txtTrigiaHD.Text = String.Format("{0:0,0}", Convert.ToDouble(table.Rows[0]["DoanhThu"]));
            sqlCon.Close();
        }

        private void load_gv_DonDatHang()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            DateTime date = DateTime.Today;
            cmd.CommandText = "SELECT COUNT(SOHD_BH) as SoDonDatHang, SUM(TRIGIA) as DoanhThu FROM HDBH WHERE LOAIHD = N'Đơn đặt hàng'AND NGHD BETWEEN '" + date.ToString("MM/dd/yyyy 0:00:00") + "' and '" + date.ToString("MM/dd/yyyy 23:59:59") + "'";
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            txtSoDDH.Text = table.Rows[0]["SoDonDatHang"].ToString();
            if (table.Rows[0]["DoanhThu"].ToString() == "")
                txtTrigiaDDH.Text = "0";
            else
                txtTrigiaDDH.Text = String.Format("{0:0,0}", Convert.ToDouble(table.Rows[0]["DoanhThu"].ToString()));
            sqlCon.Close();
        }

        private void load_chart_doanhthuthang()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            DateTime date = DateTime.Today;
            cmd.CommandText = "SELECT DAY(NGAY) as NGAY, SUM(THU) AS TONGTHU, SUM(CHI) AS TONGCHI FROM( SELECT NGHD AS NGAY, SUM(HDBH.TRIGIA) AS THU, CHI = 0 FROM HDBH WHERE (LOAIHD = N'Đơn trực tiếp' OR(LOAIHD = N'Đơn đặt hàng' AND TRANGTHAI = N'Hoàn thành')) AND MONTH(NGHD)=" + date.Month + " GROUP BY NGHD UNION SELECT NGNHAP AS NGAY, THU = 0, SUM(HDNH.TRIGIA) AS CHI FROM HDNH WHERE MONTH(NGNHAP)=" + date.Month + " GROUP BY NGNHAP) AS K GROUP BY DAY(NGAY)";
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            chart_doanhthuthang.DataSource = table;
            chart_doanhthuthang.Titles["Title1"].Text = "Doanh thu tháng " + date.Month + "";
            chart_doanhthuthang.ChartAreas["ChartArea1"].AxisX.Title = "Ngày";
            chart_doanhthuthang.ChartAreas["ChartArea1"].AxisY.Title = "Triệu";
            chart_doanhthuthang.Series["Series_Thu"].Points.Clear();
            chart_doanhthuthang.Series["Series_Chi"].Points.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                chart_doanhthuthang.Series["Series_Thu"].Points.AddXY(table.Rows[i]["NGAY"] + "/" + date.ToString("MM/yyyy"), (Convert.ToDouble(table.Rows[i]["TONGTHU"]) / 1000000));
                chart_doanhthuthang.Series["Series_Chi"].Points.AddXY(table.Rows[i]["NGAY"] + "/" + date.ToString("MM/yyyy"), (Convert.ToDouble(table.Rows[i]["TONGCHI"]) / 1000000));
            }
            sqlCon.Close();
        }

        private void load_chart_hangbanchay()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            DateTime date = DateTime.Today;
            cmd.CommandText = "SELECT CTHDBH.SPID, SUM(CTHDBH.SL*SANPHAM.GIABAN) AS DOANHTHU FROM HDBH, CTHDBH, SANPHAM WHERE HDBH.SOHD_BH = CTHDBH.SOHD_BH AND CTHDBH.SPID = SANPHAM.SPID AND MONTH(HDBH.NGHD)=" + date.Month + " GROUP BY CTHDBH.SPID ORDER BY DOANHTHU DESC";
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            chart_hangbanchay.DataSource = table;
            chart_hangbanchay.Titles["Title_hangbanchay"].Text = "Danh sách hàng hóa bán chạy trong tháng " + date.Month;
            chart_hangbanchay.ChartAreas["ChartArea1"].AxisX.Title = "Hàng hóa";
            chart_hangbanchay.ChartAreas["ChartArea1"].AxisY.Title = " Triệu";
            chart_hangbanchay.Series["Series_hanghoa"].Points.Clear();
            int j = 4;
            if (table.Rows.Count <= 4)
            {
                j = table.Rows.Count - 1;
            }
            for (int i = j; i >= 0; i--)
            {
                chart_hangbanchay.Series["Series_hanghoa"].Points.AddXY(table.Rows[i]["SPID"], (Convert.ToDouble(table.Rows[i]["DOANHTHU"]) / 1000000));
            }
            sqlCon.Close();
        }

        private void load_list_hanhdong()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            DateTime date = DateTime.Today;
            cmd.CommandText = "SELECT NHANVIEN.HOTEN, HDBH.SOHD_BH, NGHD, TRIGIA, LOAIHD FROM HDBH INNER JOIN NHANVIEN ON HDBH.NVID = NHANVIEN.NVID WHERE NGHD>='" + date.AddDays(-5).ToString("MM/dd/yyyy") + "'"
                            + " UNION"
                            + " SELECT NHANVIEN.HOTEN, HDNH.SOHD_NH, NGNHAP, TRIGIA, LOAIHD = 'DNH' FROM HDNH INNER JOIN NHANVIEN ON HDNH.NVID = NHANVIEN.NVID WHERE NGNHAP>='" + date.AddDays(-5).ToString("MM/dd/yyyy") + "'"
                            + " ORDER BY NGHD DESC";
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string Trigia = String.Format("{0:0,0}", Convert.ToInt32(table.Rows[i]["TRIGIA"]));
                FlowLayoutPanel pntemp = new FlowLayoutPanel();
                pntemp.Size = new Size(380, 100);
                PictureBox pttemp = new PictureBox();
                pttemp.Size = new Size(55, 40);
                Button btntemp = new Button();
                btntemp.Size = new Size(300, 80);
                btntemp.FlatStyle = FlatStyle.Flat;
                btntemp.FlatAppearance.BorderSize = 0;
                btntemp.TextAlign = ContentAlignment.TopLeft;
                btntemp.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                if (table.Rows[i]["LOAIHD"].Equals("Đơn trực tiếp"))
                {
                    pttemp.BackgroundImage = Image.FromFile("../../icon/icons8-bill-60.png");
                    pttemp.BackgroundImageLayout = ImageLayout.Zoom;
                    btntemp.Text = table.Rows[i]["HOTEN"].ToString() + " vừa bán được 1 đơn hàng \n" + table.Rows[i]["SOHD_BH"].ToString() + " trị giá " + Trigia + "\nvào ngày " + table.Rows[i]["NGHD"].ToString();
                    pntemp.Controls.Add(pttemp);
                    pntemp.Controls.Add(btntemp);
                    flowLayoutPanel1.Controls.Add(pntemp);
                }
                else if (table.Rows[i]["LOAIHD"].Equals("Đơn đặt hàng"))
                {
                    pttemp.BackgroundImage = Image.FromFile("../../icon/icons8-purchase-order-60.png");
                    pttemp.BackgroundImageLayout = ImageLayout.Zoom;
                    btntemp.Text = table.Rows[i]["HOTEN"].ToString() + " vừa bán được 1 đơn đặt \nhàng" + table.Rows[i]["SOHD_BH"].ToString() + " trị giá \n" + Trigia + "vào ngày " + table.Rows[i]["NGHD"].ToString();
                    pntemp.Controls.Add(pttemp);
                    pntemp.Controls.Add(btntemp);
                    flowLayoutPanel1.Controls.Add(pntemp);
                }
                else
                {
                    pttemp.BackgroundImage = Image.FromFile("../../icon/icons8-packing-60.png");
                    pttemp.BackgroundImageLayout = ImageLayout.Zoom;
                    btntemp.Text = table.Rows[i]["HOTEN"] + " vừa nhập 1 đơn hàng\n " + table.Rows[i]["SOHD_BH"] + " trị giá " + Trigia + "\nvào ngày " + table.Rows[i]["NGHD"];

                    pntemp.Controls.Add(pttemp);
                    pntemp.Controls.Add(btntemp);

                    flowLayoutPanel1.Controls.Add(pntemp);
                }
            }
            sqlCon.Close();
        }

        private void load_tab_Tongquan()
        {
            load_gdv_HoaDon();
            load_gv_DonDatHang();
            load_chart_doanhthuthang();
            load_chart_hangbanchay();
            load_list_hanhdong();
        }
    }
}