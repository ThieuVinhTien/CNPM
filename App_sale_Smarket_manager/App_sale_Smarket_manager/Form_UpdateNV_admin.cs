using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_UpdateNV_admin : Form
    {
        private string NVID;
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        private SqlConnection con = new SqlConnection(strCon);
        private SqlCommand cmd;
        private SqlConnection sqlCon = null;

        public string nvid
        {
            set { NVID = value; }
        }

        public Form_UpdateNV_admin(string nvid)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            sqlCon = new SqlConnection(strCon);
            this.NVID = nvid;
        }

        public event EventHandler Thoat;

        private void Form_UpdateNV_admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists(@"Image samples for testing\NV\Anonymous.jpg"))
            {
                File.Delete(@"Image samples for testing\NV\Anonymous.jpg");
            }
            Thoat(this, new EventArgs());
        }

        private void LoadData_nv_infonv()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT HOTEN,SDT,NGSINH,NGVL,CV FROM NHANVIEN WHERE NVID='" + this.NVID.ToString() + "'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tb_MaNV_nv_infonv.Text = this.NVID.ToString();
                tb_TenNV_nv_infonv.Text = reader.GetString(0);
                tb_SDT_nv_infonv.Text = reader.GetString(1);
                dt_NgaySinh_nv_infonv.Value = reader.GetDateTime(2);
                dt_NgayVaoLam_nv_infonv.Value = reader.GetDateTime(3);
                tb_ChucVu_nv_infonv.Text = reader.GetString(4);
            }
            sqlCon.Close();
        }

        private void LoadPicture(string filepath)
        {
            if (File.Exists(filepath))
            {
                Image image1 = null;
                using (FileStream stream = new FileStream(filepath, FileMode.Open))
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
                    cmd.CommandText = "set dateformat dmy " + "update NHANVIEN set HOTEN=N'" + tb_TenNV_nv_infonv.Text + "',SDT='" + tb_SDT_nv_infonv.Text + "',NGSINH='" + dt_NgaySinh_nv_infonv.Text + "',NGVL='" + dt_NgayVaoLam_nv_infonv.Text + "',CV=N'" + tb_ChucVu_nv_infonv.Text + "'where NVID='" + this.NVID.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bạn đã chỉnh sửa thành công!");
                    if (File.Exists(@"Image samples for testing\NV\Anonymous.jpg"))
                    {
                        if (File.Exists(@"Image samples for testing\NV\" + this.NVID.ToString() + ".jpg"))
                        {
                            File.Delete(@"Image samples for testing\NV\" + this.NVID.ToString() + ".jpg");
                        }
                        File.Move(@"Image samples for testing\NV\Anonymous.jpg", @"Image samples for testing\NV\" + this.NVID.ToString() + ".jpg");
                        File.Delete(@"Image samples for testing\NV\Anonymous.jpg");
                    }
                    this.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Sửa không thành công!");
                }
                sqlCon.Close();
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

        private void tb_SDT_nv_infonv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
            LoadData_nv_infonv();
            if (File.Exists(@"Image samples for testing\NV\Anonymous.jpg"))
            {
                LoadPicture(@"Image samples for testing\NV\Anonymous.jpg");
            }
            else if (File.Exists(@"Image samples for testing\NV\" + this.NVID.ToString() + ".jpg"))
            {
                LoadPicture(@"Image samples for testing\NV\" + this.NVID.ToString() + ".jpg");
            }
        }

        private void Form_UpdateNV_admin_Load(object sender, EventArgs e)
        {
            LoadData_nv_infonv();
            LoadPicture(@"Image samples for testing\NV\" + this.NVID.ToString() + ".jpg");
        }

        private void bt_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}