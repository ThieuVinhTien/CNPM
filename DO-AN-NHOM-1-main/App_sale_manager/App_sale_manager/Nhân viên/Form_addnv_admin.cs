using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_addnv_admin : Form
    {
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        private SqlConnection con = new SqlConnection(strCon);

        public Form_addnv_admin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        public event EventHandler Thoat;

        private void Form_addnv_admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists(@"Image samples for testing\NV\Anonymous.jpg"))
            {
                File.Delete(@"Image samples for testing\NV\Anonymous.jpg");
            }
            Thoat(this, new EventArgs());
        }

        private void tb_SDT_nv_infonv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tb_SDT_nv_infonv_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(tb_SDT_nv_infonv.Text, @"^\d+$"))
            {
                tb_SDT_nv_infonv.ForeColor = Color.Red;
            }
            else
            {
                tb_SDT_nv_infonv.ForeColor = Color.Black;
            }
        }

        private void tb_SDT_nv_infonv_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(tb_SDT_nv_infonv.Text, @"^\d+$"))
            {
                tb_SDT_nv_infonv.Text = "";
            }
        }

        private void bt_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Image_import_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open1 = new OpenFileDialog();
            Open1.Filter = " Image file (*.BMP,*.JPG,*.JPEG)|*.bmp;*.jpg;*.jpeg ";
            Open1.Multiselect = false;
            if (Open1.ShowDialog() == DialogResult.OK)
            {
                var filepath = Open1.FileName;
                Bitmap bmp = new Bitmap(filepath);
                Form_selectphoto_nv frm = new Form_selectphoto_nv(filepath);
                if (bmp.Width < (frm.panel1.Width + SystemInformation.VerticalScrollBarWidth) * 2 || bmp.Height < (frm.panel1.Height + SystemInformation.HorizontalScrollBarHeight) * 2)
                {
                    MessageBox.Show("Ảnh bạn phải có kích thước tối thiểu " + ((frm.panel1.Width + SystemInformation.VerticalScrollBarWidth) * 2).ToString() + "x" + ((frm.panel1.Height + SystemInformation.HorizontalScrollBarHeight) * 2).ToString());
                    frm.Close();
                }
                else
                {
                    frm.Isnv = 2;
                    frm.Thoat += Thoat_Form_selectphoto_nv;
                    frm.Show();
                    this.Hide();
                }
            }
        }

        private void Thoat_Form_selectphoto_nv(object sender, EventArgs e)
        {
            this.Show();
            if (File.Exists(@"Image samples for testing\NV\Anonymous.jpg"))
            {
                Image image1 = null;
                using (FileStream stream = new FileStream(@"Image samples for testing\NV\Anonymous.jpg", FileMode.Open))
                {
                    image1 = Image.FromStream(stream);
                }

                pictureBox_image_import_nv.Image = image1;
            }
            else
            {
                Image image1 = null;
                using (FileStream stream = new FileStream(@"Image samples for testing\NV\No Image.jpg", FileMode.Open))
                {
                    image1 = Image.FromStream(stream);
                }
                pictureBox_image_import_nv.Image = image1;
            }
        }

        public Boolean exedata(string cmd)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            Boolean check = false;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
            }
            con.Close();
            return check;
        }

        private void bt_dongy_Click(object sender, EventArgs e)
        {

            MD5 mh = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes("1");
            byte[] hash = mh.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            if (exedata("set dateformat dmy " + "insert into NHANVIEN values('" + tb_MaNV_nv_infonv.Text + "',N'" + tb_TenNV_nv_infonv.Text + "','" + tb_SDT_nv_infonv.Text + "',' " + dt_NgayVaoLam_nv_infonv.Text + " ','" + dt_NgaySinh_nv_infonv.Text + "','" + 0 + "',N'" + tb_ChucVu_nv_infonv.Text + "',N'" + tb_MaNV_nv_infonv.Text + "','" + sb.ToString() + "','" + 0 + "','" + 0 + "')") == true)
            {
                MessageBox.Show("Thêm thành công!");
                if (File.Exists(@"Image samples for testing\NV\Anonymous.jpg"))
                {
                    File.Move(@"Image samples for testing\NV\Anonymous.jpg", @"Image samples for testing\NV\" + tb_MaNV_nv_infonv.Text + ".jpg");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
            }
            /*DialogResult Result = MessageBox.Show("Bạn có chắc chắn muốn sửa?", "Sửa dữ liệu", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                cmd = sqlCon.CreateCommand();
                try
                {
                    cmd.CommandText = "set dateformat dmy " + "insert into NHANVIEN values('" + tb_MaNV_nv_infonv.Text + "',N'" + tb_TenNV_nv_infonv.Text + "','" + tb_SDT_nv_infonv.Text + "',' " + dt_NgayVaoLam_nv_infonv.Text + " ','" + dt_NgaySinh_nv_infonv.Text + "','" + 0 + "',N'" + tb_ChucVu_nv_infonv.Text + "',N'" + tb_MaNV_nv_infonv.Text + "','" + 1 + "','" + 0 + "','" + 0 + "')";
                    cmd.ExecuteNonQuery();
                    SaveFileDialog Save = new SaveFileDialog();
                }
                catch (SqlException)
                {
                    if (dt_NgaySinh_nv_infonv.Value.Year >= dt_NgayVaoLam_nv_infonv.Value.Year - 1)
                    {
                        MessageBox.Show("Ngày sinh nhập không đúng!");
                    }
                    else
                        MessageBox.Show("Nhập không đúng dữ liệu hoặc MANV đã có!");
                }
                if (File.Exists(@"Image samples for testing\NV\Anonnymous.jpg"))
                {
                    File.Move(@"Image samples for testing\NV\Anonnymous.jpg", @"Image samples for testing\NV\" + tb_MaNV_nv_infonv.Text+ ".jpg");
                }
                this.Close();
              }*/
        }

        private void Form_addnv_admin_Load(object sender, EventArgs e)
        {
            Image image1 = null;
            using (FileStream stream = new FileStream(@"Image samples for testing\NV\No Image.jpg", FileMode.Open))
            {
                image1 = Image.FromStream(stream);
            }
            dt_NgaySinh_nv_infonv.Value = DateTime.Today;
            dt_NgayVaoLam_nv_infonv.Value = DateTime.Today;
            pictureBox_image_import_nv.Image = image1;
        }
    }
}