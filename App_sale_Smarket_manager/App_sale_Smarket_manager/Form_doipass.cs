using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_doipass : Form
    {
        private SqlConnection sqlCon = null;
        private string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        private SqlCommand cmd;
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataTable table = new DataTable();

        public Form_doipass()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void Form_doipass_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(strCon);
        }

        public event EventHandler Thoat;

        private void btn_hoantat_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            cmd = sqlCon.CreateCommand();
            if (textBox_usr.Text == "" || textBox_pass_old.Text == "" || textBox_pass_new.Text == "" || textBox_pass_new2.Text == "")
            {
                MessageBox.Show("Ban chua dien du thong tin");
                return;
            }
            cmd.CommandText = "select PASSWD from NHANVIEN where USERNAME = '" + textBox_usr.Text + "'";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            DataTableReader reader = new DataTableReader(table);
            string passwd = "";

            MD5 mh = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(textBox_pass_old.Text);
            byte[] hash = mh.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            if (reader.Read())
            {
                passwd = reader.GetString(0);
            }
            if (passwd != sb.ToString())
            {
                MessageBox.Show("user hay mật khẩu nhập không đúng.");
                return;
            }

            inputBytes = System.Text.Encoding.ASCII.GetBytes(textBox_pass_new.Text);
            hash = mh.ComputeHash(inputBytes);
            sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            if (sb.ToString() == passwd)
            {
                MessageBox.Show("mật khẩu mới giống mật khẩu cũ.");
                return;
            }
            if (textBox_pass_new.Text != textBox_pass_new2.Text)
            {
                MessageBox.Show("mật khẩu lặp lại không đúng.");
                return;
            }
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "update NHANVIEN set PASSWD = '" + sb.ToString() + "' where USERNAME = '" + textBox_usr.Text + "'";
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            MessageBox.Show(" Đổi mật khẩu thành công ");
            this.Close();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_usr_Enter(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox_usr.Tag) == 0)
            {
                textBox_usr.Text = "";
                textBox_usr.Tag = 1;
            }
        }

        private void textBox_usr_Leave(object sender, EventArgs e)
        {
            if (textBox_usr.Text == "")
            {
                textBox_usr.Text = "username";
                textBox_usr.Tag = 0;
            }
        }

        private void textBox_pass_old_Enter(object sender, EventArgs e)
        {
            if (Convert.ToInt32((sender as TextBox).Tag) == 0)
            {
                (sender as TextBox).Text = "";
                (sender as TextBox).Tag = 1;
                (sender as TextBox).PasswordChar = '*';
                textBox_usr.TabStop = true;
                textBox_pass_old.TabStop = true;
                textBox_pass_new.TabStop = true;
                textBox_pass_new2.TabStop = true;
            }
        }

        private void textBox_pass_old_Leave(object sender, EventArgs e)
        {
            if (textBox_pass_old.Text == "")
            {
                textBox_pass_old.Text = "mật khẩu cũ";
                textBox_pass_old.Tag = 0;
                textBox_pass_old.PasswordChar = '\0';
            }
        }

        private void textBox_pass_new_Leave(object sender, EventArgs e)
        {
            if (textBox_pass_new.Text == "")
            {
                textBox_pass_new.Text = "mật khẩu mới";
                textBox_pass_new.Tag = 0;
                textBox_pass_new.PasswordChar = '\0';
            }
        }

        private void textBox_pass_new2_Leave(object sender, EventArgs e)
        {
            if (textBox_pass_new2.Text == "")
            {
                textBox_pass_new2.Text = "nhập lại mật khẩu";
                textBox_pass_new2.Tag = 0;
                textBox_pass_new2.PasswordChar = '\0';
            }
        }
    }
}