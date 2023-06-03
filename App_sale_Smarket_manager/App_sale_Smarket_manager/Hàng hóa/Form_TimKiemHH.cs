using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace App_sale_manager
{
    public partial class Form_TimKiemHH : Form
    {
        public string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        public SqlConnection sqlCon = null;
        static public SqlDataAdapter adapter = null; 
        public Form_TimKiemHH()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
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
        }
        
        public DataTable TimKiem()
        {
            DataTable tb = new DataTable();
            string query;
            if (txtGiaBan.Text == String.Empty)
            {
                txtGiaBan.Text = "999999999999999999";
            }
            if (cbbChonGia.Text == "Tối Đa")
            {
               query = "select SANPHAM.SPID,SANPHAM.TENSP,LOAISP.TENLOAI,SANPHAM.NUOCSX,SANPHAM.HANGSX,SANPHAM.GIABAN,SANPHAM.GIANHAP,SANPHAM.DVT,SANPHAM.SOLUONG,SANPHAM.SLTT,SANPHAM.MOTA from SANPHAM,LOAISP" +
                  " where (SANPHAM.LOAIID = LOAISP.LOAIID and LOAISP.TENLOAI like N'%" + cbbLoaiSP.Text + "%' and GIABAN < " + txtGiaBan.Text + "and  TENSP Like N'%" + txtTenSP.Text + "%' and NUOCSX Like N'%" + cbbNuocSX.Text + "%'" + "and HANGSX Like N'%" + cbbHang.Text + "%')";
            }
            else if (cbbChonGia.Text == "Tối Thiểu")
            {
               query = "select SANPHAM.SPID,SANPHAM.TENSP,LOAISP.TENLOAI,SANPHAM.NUOCSX,SANPHAM.HANGSX,SANPHAM.GIABAN,SANPHAM.GIANHAP,SANPHAM.DVT,SANPHAM.SOLUONG,SANPHAM.SLTT,SANPHAM.MOTA from SANPHAM,LOAISP" +
                  " where (SANPHAM.LOAIID = LOAISP.LOAIID and LOAISP.TENLOAI like N'%" + cbbLoaiSP.Text + "%' and GIABAN > " + txtGiaBan.Text + "and  TENSP Like N'%" + txtTenSP.Text + "%' and NUOCSX Like N'%" + cbbNuocSX.Text + "%'" + "and HANGSX Like N'%" + cbbHang.Text + "%')";

            }
            else
            {
               query = "select SANPHAM.SPID,SANPHAM.TENSP,LOAISP.TENLOAI,SANPHAM.NUOCSX,SANPHAM.HANGSX,SANPHAM.GIABAN,SANPHAM.GIANHAP,SANPHAM.DVT,SANPHAM.SOLUONG,SANPHAM.SLTT,SANPHAM.MOTA from SANPHAM,LOAISP" +
                " where (SANPHAM.LOAIID = LOAISP.LOAIID and LOAISP.TENLOAI like N'%" + cbbLoaiSP.Text + "%'" + "and  TENSP Like N'%" + txtTenSP.Text + "%' and NUOCSX Like N'%" + cbbNuocSX.Text + "%'" + "and HANGSX Like N'%" + cbbHang.Text + "%')";

            }
            adapter = new SqlDataAdapter(query, sqlCon);
            adapter.Fill(tb);
            sqlCon.Close();
            return tb;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
