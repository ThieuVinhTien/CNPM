using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_ChiTietNH : Form
    {
        public string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        public SqlConnection sqlCon = null;
        public static SqlDataAdapter adapter = null;

        public Form_ChiTietNH(string mahd)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select HDNH.SOHD_NH,NGNHAP,HDNH.DTID,DTCC.TENDT,HDNH.NVID,NHANVIEN.HOTEN,REPLACE(CONVERT(varchar(20), TRIGIA, 1), '.00', '') as TRIGIA  from HDNH,DTCC,NHANVIEN where DTCC.DTID=HDNH.DTID and NHANVIEN.NVID=HDNH.NVID and HDNH.SOHD_NH='" + mahd + "'";
            sqlCmd.Connection = sqlCon;
            var reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                txtSoHDNH.Text = reader.GetString(0);
                txtNgayNhap.Text = reader.GetDateTime(1).ToString();
                txtMaDT.Text = reader.GetString(2);
                txtTenDT.Text = reader.GetString(3);
                txtMaNV.Text = reader.GetString(4);
                txtNVNhap.Text = reader.GetString(5);
                txtGiaTriDN.Text = reader.GetString(6);
                reader.Close();
            }
            sqlCon.Close();
            LoadCTDonNhap();
        }

        private void LoadCTDonNhap()
        {
            if (txtSoHDNH.Text != string.Empty)
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                adapter = new SqlDataAdapter("select CTHDNH.SPID,SANPHAM.TENSP,CTHDNH.SL,SANPHAM.GIANHAP from CTHDNH,SANPHAM where SANPHAM.SPID=CTHDNH.SPID and SOHD_NH='" + txtSoHDNH.Text + "'", sqlCon);
                DataTable tableSPNH = new DataTable();
                adapter.Fill(tableSPNH);
                dgvChiTietNH.DataSource = tableSPNH;
                dgvChiTietNH.Columns[0].HeaderText = "Mã Sản Phẩm";
                dgvChiTietNH.Columns[1].HeaderText = "Tên Sản Phẩm";
                dgvChiTietNH.Columns[2].HeaderText = "Số Lượng Nhập";
                dgvChiTietNH.Columns[3].HeaderText = "Đơn Giá";
                sqlCon.Close();
            }
        }

        private void bnt_Print_Click(object sender, EventArgs e)
        {
            PrintP_HoaDon.ShowDialog();
        }

        private void Print_HoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font drawFont = new Font("Arial", 20);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            e.Graphics.DrawString("Hoá Đơn Nhập Hàng ", drawFont, drawBrush, 90, 10);
            int x = 40;
            int y = 100;
            drawFont = new Font("Arial", 12);
            e.Graphics.DrawString("Mã Hoá Đơn: " + txtSoHDNH.Text, drawFont, drawBrush, x, y = y + 25);
            e.Graphics.DrawString("Tên Đối Tác: " + txtTenDT.Text, drawFont, drawBrush, x, y = y + 30);
            e.Graphics.DrawString("Mã Đối Tác: " + txtMaDT.Text, drawFont, drawBrush, x, y = y + 25);
            e.Graphics.DrawString("Tên Nhân Viên:" + txtNVNhap.Text, drawFont, drawBrush, x, y = y + 30);
            e.Graphics.DrawString("Mã Nhân Viên " + txtMaNV.Text, drawFont, drawBrush, x, y = y + 25);
            e.Graphics.DrawString("Sản phẩm đã mua", drawFont, drawBrush, x, y = y + 50);
            for (int i = 0; i < dgvChiTietNH.RowCount - 1; i++)
            {
                e.Graphics.DrawString("Mã SP: " + dgvChiTietNH.Rows[i].Cells[0].Value.ToString(), drawFont, drawBrush, x, y = y + 50);
                e.Graphics.DrawString("Tên SP: " + dgvChiTietNH.Rows[i].Cells[1].Value.ToString(), drawFont, drawBrush, x, y = y + 25);
                e.Graphics.DrawString("Đơn Giá: " + dgvChiTietNH.Rows[i].Cells[3].Value.ToString(), drawFont, drawBrush, x, y = y + 25);
                e.Graphics.DrawString("Số Lượng: " + dgvChiTietNH.Rows[i].Cells[2].Value.ToString(), drawFont, drawBrush, x, y = y + 25);
            }
            e.Graphics.DrawString("Tổng giá trị: " + String.Format("{0:0,0 VND}", Convert.ToDouble(txtGiaTriDN.Text)), drawFont, drawBrush, 300, y = y + 25);
        }
    }
}