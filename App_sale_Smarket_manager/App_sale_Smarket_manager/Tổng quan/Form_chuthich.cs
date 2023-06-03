using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_chuthich : Form
    {
        private string manv = string.Empty;
        private string tennv = string.Empty;
        private SqlConnection sqlCon = null;
        private string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        private SqlCommand cmd;
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataTable table = new DataTable();

        public Form_chuthich()
        {
            sqlCon = new SqlConnection(strCon);
            cmd = sqlCon.CreateCommand();
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            load();
        }

        private void load()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            DateTime date = DateTime.Today;
            cmd.CommandText = "SELECT TOP 5 CTHDBH.SPID as 'Mã sản phẩm', TENSP as 'Tên sản phẩm', TENLOAI as 'Loại sản phẩm' FROM HDBH, CTHDBH, SANPHAM, LOAISP WHERE HDBH.SOHD_BH = CTHDBH.SOHD_BH AND CTHDBH.SPID = SANPHAM.SPID AND SANPHAM.LOAIID = LOAISP.LOAIID AND MONTH(HDBH.NGHD)=" + date.Month + " GROUP BY CTHDBH.SPID, TENSP, TENLOAI ORDER BY SUM(CTHDBH.SL*SANPHAM.GIABAN) DESC";
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[0].Width = 100;
            sqlCon.Close();
        }
    }
}