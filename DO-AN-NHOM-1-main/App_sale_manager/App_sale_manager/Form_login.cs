using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_login : Form
    {
        private string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        private SqlConnection sqlCon = null;
        private bool canread = false;

        public Form_login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.AcceptButton = btn_dangnhap;
            textBox_usr.Focus();
            if(Properties.Settings1.Default.username != "")
            {
                textBox_passwd.Text = Properties.Settings1.Default.password.ToString();
                textBox_usr.Text = Properties.Settings1.Default.username.ToString();
                textBox_passwd.PasswordChar = '*';
            }
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            // tạo ra đối tượng thực thi truy vấn.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select PASSWD,NVID,HOTEN,CV,USERNAME from NHANVIEN where USERNAME = '" + textBox_usr.Text + "'";
            // gửi truy vấn tới kết nối.
            sqlCmd.Connection = sqlCon;
            // nhận kết quả
            SqlDataReader reader = sqlCmd.ExecuteReader();
            string passwd = "";
            string CV = "";
            if (reader.Read())
            {
                passwd = reader.GetString(0);
                CV = reader.GetString(3);
            }

            MD5 mh = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(textBox_passwd.Text);
            byte[] hash = mh.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            // kiểm tra passwd
            if (passwd == sb.ToString())
            {

                if (chkNhopass.Checked == true)
                {
                    Properties.Settings1.Default.username = textBox_usr.Text;
                    Properties.Settings1.Default.password = textBox_passwd.Text;
                    Properties.Settings1.Default.Save();
                }
                else
                {
                    Properties.Settings1.Default.username = "";
                    Properties.Settings1.Default.password = "";
                    Properties.Settings1.Default.Save();
                }
                if (CV == "Chủ tiệm" || CV == "Quản lý")
                {
                    Form_main_admin frm = new Form_main_admin(reader.GetString(1), reader.GetString(2), reader.GetString(4));
                    frm.Thoat += Frm_Thoat;
                    frm.Show();
                    this.Hide();
                    if (chkNhopass.Checked == false)
                    {
                        textBox_usr.Clear();
                        textBox_passwd.Clear();
                    }
                }
                else
                {
                    Form_main_NV frm = new Form_main_NV(reader.GetString(1), reader.GetString(2), reader.GetString(4));
                    frm.Thoat += Frm_Thoat;
                    frm.Show();
                    this.Hide();
                    if (chkNhopass.Checked == false)
                    {
                        textBox_usr.Clear();
                        textBox_passwd.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("username hoặc passwd không đúng.");
            }

            sqlCon.Close();
        }

        private void Frm_Thoat(object sender, EventArgs e)
        {
            (sender as Form).Close();
            this.Show();
            textBox_usr.Focus();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void link_frm_doipasswd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_doipass frm = new Form_doipass();
            frm.Thoat += Frm_Thoat;
            frm.Show();
            this.Hide();
        }

        private void Form_login_Load(object sender, EventArgs e)
        {
            textBox_usr.Focus();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (canread == false)
            {
                canread = true;
                (sender as PictureBox).SizeMode = PictureBoxSizeMode.Normal;
                (sender as PictureBox).Image = Image.FromFile("../../icon/matmo.png");
                textBox_passwd.PasswordChar = '\0';
            }
            else
            {
                canread = false;
                (sender as PictureBox).SizeMode = PictureBoxSizeMode.Normal;
                (sender as PictureBox).Image = Image.FromFile("../../icon/matdong.png");
                textBox_passwd.PasswordChar = '*';
            }
        }

        private void textBox_usr_Enter(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox_usr.Tag) == 0)
            {
                textBox_usr.Text = "";
                textBox_usr.Tag = 1;
                textBox_usr.TabStop = true;
                textBox_passwd.TabStop = true;
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

        private void textBox_passwd_Enter(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox_passwd.Tag) == 0)
            {
                textBox_passwd.Text = "";
                textBox_passwd.Tag = 1;
                textBox_passwd.PasswordChar = '*';
                textBox_usr.TabStop = true;
                textBox_passwd.TabStop = true;
            }
        }

        private void textBox_passwd_Leave(object sender, EventArgs e)
        {
            if (textBox_passwd.Text == "")
            {
                textBox_passwd.Text = "password";
                textBox_passwd.PasswordChar = '\0';
                textBox_passwd.Tag = 0;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTieude_Click(object sender, EventArgs e)
        {

        }
    }
}