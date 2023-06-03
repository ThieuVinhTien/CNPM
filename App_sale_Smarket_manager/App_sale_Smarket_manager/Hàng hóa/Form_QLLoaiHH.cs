using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_QLLoaiHH : Form
    {
        public string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        public static SqlConnection sqlCon = null;
        public static SqlDataAdapter adapter = null;
        private static int ModeLHH = 0;

        public Form_QLLoaiHH()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            LoadLoaiHH();
        }

        public void LoadLoaiHH()
        {
            sqlCon = new SqlConnection(strCon);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCon.Open();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from LOAISP ";
            sqlCmd.Connection = sqlCon;
            adapter = new SqlDataAdapter(sqlCmd);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataTable tbLHH = new DataTable();
            tbLHH.Clear();
            adapter.Fill(tbLHH);
            sqlCon.Close();
            dgvLoaiHH.DataSource = tbLHH;

            dgvLoaiHH.Columns[0].HeaderText = "Mã Loại";
            dgvLoaiHH.Columns[1].HeaderText = "Tên Loại";
            dgvLoaiHH.Columns[2].HeaderText = "Mô tả";
        }

        private void dgvLoaiHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox1.Text = dgvLoaiHH.CurrentRow.Cells["LOAIID"].Value.ToString();
            textBox2.Text = dgvLoaiHH.CurrentRow.Cells["TENLOAI"].Value.ToString();
            textBox3.Text = dgvLoaiHH.CurrentRow.Cells["MOTA"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ModeLHH = 1;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLoaiHH.CurrentRow == null)
            {
                MessageBox.Show("Chưa chọn hàng để xoá");
                return;
            }
            else
            {
                DialogResult dar = MessageBox.Show("Xoá loại sản phẩm sẽ kiến tất cả sản phẩm và thông tin liên quan bị xoá \nBạn có chắc chắn xoá ", "Chú ý", MessageBoxButtons.YesNo);

                if (dar == DialogResult.Yes)
                {
                    sqlCon.Open();
                    string strquery = "delete CTHDNH where SPID in (select SPID from SANPHAM where LOAIID = '" + textBox1.Text + "')" +
                                      "delete CTHDBH where SPID in (select SPID from SANPHAM where LOAIID = '" + textBox1.Text + "')" +
                                      "delete SANPHAM " + "where LOAIID ='" + textBox1.Text + "' " +
                                      "delete LOAISP " + "where LOAIID=N'" + textBox1.Text + "'";
                    SqlCommand sqlCmd = new SqlCommand(strquery, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                    LoadLoaiHH();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLoaiHH.CurrentRow == null)
            {
                MessageBox.Show("Chưa chọn hàng để sửa");
                return;
            }
            ModeLHH = 2;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            if (ModeLHH == 1)
            {
                if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
                {
                    MessageBox.Show("Phải điền đủ Mã Loại và Tên Loại");
                    return;
                }
                else
                {
                    sqlCon.Open();
                    string strquery = "insert into LOAISP values(N'" + textBox1.Text + "',N' " + textBox2.Text + "',N'" + textBox3.Text + "')";
                    SqlCommand sqlCmd = new SqlCommand(strquery, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }

                LoadLoaiHH();
                MessageBox.Show("Đã thêm loại hàng hoá");
            }

            if (ModeLHH == 2)
            {
                if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
                {
                    MessageBox.Show("Phải điền đủ Tên Loại");
                    return;
                }
                else
                {
                    sqlCon.Open();
                    string strquery = "update LOAISP set TENLOAI=N' " + textBox2.Text + "',MOTA=N'" + textBox3.Text + "' where LOAIID ='" + textBox1.Text + "'";
                    SqlCommand sqlCmd = new SqlCommand(strquery, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
                LoadLoaiHH();
                MessageBox.Show("Đã sửa thông tin loại hàng hoá");
            }
        }
    }
}