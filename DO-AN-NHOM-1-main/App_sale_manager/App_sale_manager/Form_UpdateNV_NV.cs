using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_UpdateNV_NV : System.Windows.Forms.Form
    {
        private string NVID;
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        private SqlConnection con = new SqlConnection(strCon);
        private SqlCommand cmd;
        private SqlConnection sqlCon = null;
        private DateTime ngvl = new DateTime();

        public string nvid
        {
            set { NVID = value; }
        }

        public Form_UpdateNV_NV()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            sqlCon = new SqlConnection(strCon);
        }

        public Form_UpdateNV_NV(string NVID)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            sqlCon = new SqlConnection(strCon);
            this.NVID = NVID;
        }

        public event EventHandler Thoat;

        private void LoadData_nv_infonv()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT HOTEN,SDT,NGSINH,USERNAME,NGVL FROM NHANVIEN WHERE NVID='" + this.NVID.ToString() + "'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tb_Hoten.Text = reader.GetString(0);
                tb_sdt.Text = reader.GetString(1);
                dt_Ngaysinh.Text = reader.GetDateTime(2).ToString("dd/MM/yyyy");
                tb_username.Text = reader.GetString(3);
                ngvl = reader.GetDateTime(4);
            }
            sqlCon.Close();
        }

        private void Form_UpdateNV_NV_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }

        private void bt_Sua_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Bạn có chắc chắn muốn sửa?", "Sửa dữ liệu", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                cmd = sqlCon.CreateCommand();
                try
                {
                    cmd.CommandText = "set dateformat dmy " + "update NHANVIEN set HOTEN=N'" + tb_Hoten.Text + "',SDT='" + tb_sdt.Text + "',NGSINH='" + dt_Ngaysinh.Text + "',USERNAME='" + tb_username.Text + "'where NVID='" + this.NVID.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bạn đã chỉnh sửa thành công!");
                }
                catch (SqlException)
                {
                    if (ngvl.Year <= dt_Ngaysinh.Value.Year)
                    {
                        MessageBox.Show("Ngày sinh bạn nhập không đúng!");
                        dt_Ngaysinh.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Tên người dùng có thể đã tồn tại!");
                        tb_username.Focus();
                    }
                }
                sqlCon.Close();
            }
        }

        private void tb_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tb_sdt_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(tb_sdt.Text, @"^\d+$"))
            {
                tb_sdt.Text = "";
            }
        }

        private void tb_sdt_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(tb_sdt.Text, @"^\d+$"))
            {
                tb_sdt.ForeColor = Color.Red;
            }
            else
            {
                tb_sdt.ForeColor = Color.Black;
            }
        }

        private void bt_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_UpdateNV_NV_Load(object sender, EventArgs e)
        {
            LoadData_nv_infonv();
        }

        private void tb_Hoten_TextChanged(object sender, EventArgs e)
        {

        }
    }
}