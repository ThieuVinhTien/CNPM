using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_CTHD : Form
    {
        private string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        private SqlConnection sqlCon;
        private SqlCommand cmd;
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataTable table = new DataTable();
        private Bitmap bmp;

        public Form_CTHD()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        public Form_CTHD(string mahoadon, string makhachhang, string manhanvien, string loaihd, string trangthai, string tong)
        {
            InitializeComponent();

            l_MaHoadon.Text = mahoadon;
            l_MaKhachhang.Text = makhachhang;
            l_MaNhanVien.Text = manhanvien;
            l_LoaiHoaDon.Text = loaihd;
            l_TrangThai.Text = trangthai;
            l_Tong.Text = string.Format("{0:0,0}", Convert.ToDouble(tong.Replace(",", string.Empty)));

            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            cmd = sqlCon.CreateCommand();

            cmd.CommandText = "select TENSP,SL,REPLACE(CONVERT(varchar(20), GIABAN, 1), '.00','') from CTHDBH, SANPHAM where SOHD_BH = '" + mahoadon + "' and SANPHAM.SPID = CTHDBH.SPID ";
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DataGridViewRow row = (DataGridViewRow)DGV_CTHD.Rows[0].Clone();
                row.Cells[0].Value = reader.GetString(0);
                row.Cells[1].Value = reader.GetByte(1).ToString();
                row.Cells[2].Value = reader.GetString(2);
                DGV_CTHD.Rows.Add(row);
            }

            reader.Close();

            for (int i = 0; i < DGV_CTHD.RowCount; i++)
            {
                DGV_CTHD.AutoResizeRow(i);
            }

            cmd.CommandText = "select HOTEN from KHACHHANG where KHID = '" + makhachhang + "'";
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                l_TenKhachHang.Text = reader.GetString(0);
            }
        }

        private void bnt_trangthai_Click(object sender, EventArgs e)
        {
            if (l_TrangThai.Text == "NHANDON")
            {
                cmd.CommandText = "update HDBH set TRANGTHAI = 'DANGGIAO' where SOHD_BH = '" + l_MaHoadon.Text + "' ";
                adapter.UpdateCommand = cmd;
                l_TrangThai.Text = "DANGGIAO";
            }
            else if (l_TrangThai.Text == "DANGGIAO")
            {
                l_TrangThai.Text = "HOANTAT";
                cmd.CommandText = "update HDBH set TRANGTHAI = 'HOANTAT' where SOHD_BH  = '" + l_MaHoadon.Text + "' ";
            }
            cmd.ExecuteNonQuery();
        }

        private void Form_CTHD_Load(object sender, EventArgs e)
        {
            if (DGV_CTHD.CurrentRow != null)
                DGV_CTHD.CurrentRow.Selected = false;
        }

        private void bnt_Print_Click(object sender, EventArgs e)
        {
            int height = DGV_CTHD.Height;
            DGV_CTHD.Height = DGV_CTHD.RowCount * DGV_CTHD.RowTemplate.Height + DGV_CTHD.RowTemplate.Height;
            bmp = new Bitmap(DGV_CTHD.Width, DGV_CTHD.Height);
            DGV_CTHD.DrawToBitmap(bmp, new Rectangle(0, 0, DGV_CTHD.Width, DGV_CTHD.Height));
            DGV_CTHD.Height = height;
            PrintP_HoaDon.ShowDialog();
        }

        private void Print_HoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font drawFont = new Font("Arial", 20);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            e.Graphics.DrawString("HOA DON THANH TOAN ", drawFont, drawBrush, 90, 10);

            drawFont = new Font("Arial", 12);

            e.Graphics.DrawString("****************************************************************************", drawFont, drawBrush, 0, 100);

            e.Graphics.DrawString("Ma hoa don ", drawFont, drawBrush, 40, 125);
            e.Graphics.DrawString(l_MaHoadon.Text, drawFont, drawBrush, 250, 125);

            e.Graphics.DrawString("Ma khach hang ", drawFont, drawBrush, 40, 150);
            e.Graphics.DrawString(l_MaKhachhang.Text, drawFont, drawBrush, 250, 150);

            e.Graphics.DrawString("Ten Khach Hang ", drawFont, drawBrush, 40, 175);
            e.Graphics.DrawString(l_TenKhachHang.Text, drawFont, drawBrush, 250, 175);

            e.Graphics.DrawString("Ma nhan vien ", drawFont, drawBrush, 40, 200);
            e.Graphics.DrawString(l_MaNhanVien.Text, drawFont, drawBrush, 250, 200);

            e.Graphics.DrawString("Loai hoa don ", drawFont, drawBrush, 40, 225);
            e.Graphics.DrawString(l_LoaiHoaDon.Text, drawFont, drawBrush, 250, 225);

            e.Graphics.DrawString("Trang thai ", drawFont, drawBrush, 40, 250);
            e.Graphics.DrawString(l_TrangThai.Text, drawFont, drawBrush, 250, 250);

            e.Graphics.DrawString("****************************************************************************", drawFont, drawBrush, 0, 275);

            e.Graphics.DrawImage(bmp, 20, 300);

            e.Graphics.DrawString("Tong  ", drawFont, drawBrush, 300, 315 + bmp.Height);
            e.Graphics.DrawString(l_Tong.Text, drawFont, drawBrush, 350, 315 + bmp.Height);
        }
    }
}