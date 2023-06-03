using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_main_NV : Form
    {
        //NHÓM HÀM TABPAGE CÁ NHÂN
        private void LoadData_nv_infonv()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT NVID,HOTEN,SDT,NGSINH,NGVL,CV,LUONG,THUONG,HESO,USERNAME FROM NHANVIEN WHERE NVID='" + this.NVID.ToString() + "'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tb_MaNV_nv_infonv.Text = reader.GetString(0);
                tb_Hoten_nv_infonv.Text = reader.GetString(1);
                tb_sdt_nv_infonv.Text = reader.GetString(2);
                tb_ngaysinh_nv_infonv.Text = reader.GetDateTime(3).ToString("dd/MM/yyyy");
                tb_ngayvaolam_nv_infonv.Text = reader.GetDateTime(4).ToString("dd/MM/yyyy");
                tb_chucvu_nv_infonv.Text = reader.GetString(5);
                tb_Luong_nv_infonv.Text = String.Format("{0:0,0}", Convert.ToDouble(reader.GetValue(6).ToString()));
                tb_Thuong_nv_infonv.Text = String.Format("{0:0,0}", Convert.ToDouble(reader.GetValue(7).ToString()));
                tb_Heso_nv_infonv.Text = reader.GetValue(8).ToString();
                tb_username_nv_infonv.Text = reader.GetString(9);
                sqlCon.Close();
            }

            if (File.Exists(@"Image samples for testing\CN\" + tb_MaNV_nv_infonv.Text + ".jpg"))
            {
                Image image1 = null;
                using (FileStream stream = new FileStream(@"Image samples for testing\CN\" + this.NVID + ".jpg", FileMode.Open))
                {
                    image1 = Image.FromStream(stream);
                }

                pictureBox_image_anhnv.Image = image1;
            }
            else
            {
                Image image1 = null;
                using (FileStream stream = new FileStream(@"Image samples for testing\CN\No Image.jpg", FileMode.Open))
                {
                    image1 = Image.FromStream(stream);
                }
                pictureBox_image_anhnv.Image = image1;
            }
        }

        private void bt_Them_nv_infonv_Click(object sender, EventArgs e)
        {
            Form_UpdateNV_NV frm = new Form_UpdateNV_NV(NVID);
            frm.Thoat += Thoat_Form_UpdateNV_NV;
            frm.Show();
            this.Hide();
        }

        private void bt_doipass_nv_infonv_Click(object sender, EventArgs e)
        {
            Form_doipass_nv frm = new Form_doipass_nv(this.NVID.ToString());
            frm.Thoat += Thoat_Form_doipass_NV;
            frm.Show();
            this.Hide();
        }

        private void Thoat_Form_UpdateNV_NV(object sender, EventArgs e)
        {
            this.Show();
            LoadData_nv_infonv();
        }

        private void Thoat_Form_doipass_NV(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Thoat_Form_selectphoto_nv(object sender, EventArgs e)
        {
            this.Show();
            LoadData_nv_infonv();
        }

        private void bt_doipass_nv_infonv_Click_1(object sender, EventArgs e)
        {
            Form_doipass_nv frm = new Form_doipass_nv(this.NVID.ToString());
            frm.Thoat += Thoat_Form_doipass_NV;
            frm.Show();
            this.Hide();
        }

        private void pictureBox_image_anhnv_Click_1(object sender, EventArgs e)
        {
            var pictureBox_Position = this.PointToScreen(new Point(pictureBox_image_anhnv.Location.X, pictureBox_image_anhnv.Location.Y + pictureBox_image_anhnv.Size.Height));
            contextMenuStrip_anh_nv.Show(pictureBox_Position);
        }

        private void chonAnhToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog Open1 = new OpenFileDialog();
            Open1.Multiselect = false;
            Open1.Filter = " Image file (*.BMP,*.JPG,*.JPEG)|*.bmp;*.jpg;*.jpeg ";
            if (Open1.ShowDialog() == DialogResult.OK)
            {
                var filepath = Open1.FileName;
                Bitmap bmp = new Bitmap(filepath);
                Form_selectphoto_nv frm = new Form_selectphoto_nv(filepath, tb_MaNV_nv_infonv.Text, tb_Hoten_nv_infonv.Text);
                if (bmp.Width < (frm.panel1.Width + SystemInformation.VerticalScrollBarWidth) * 2 || bmp.Height < (frm.panel1.Height + SystemInformation.HorizontalScrollBarHeight) * 2)
                {
                    MessageBox.Show("Ảnh bạn phải có kích thước tối thiểu " + ((frm.panel1.Width + SystemInformation.VerticalScrollBarWidth) * 2).ToString() + "x" + ((frm.panel1.Height + SystemInformation.HorizontalScrollBarHeight) * 2).ToString());
                    frm.Close();
                }
                else
                {
                    frm.Thoat += Thoat_Form_selectphoto_nv;
                    frm.Show();
                    this.Hide();
                }
            }
        }

        private void xoaAnhToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xóa ảnh", MessageBoxButtons.YesNo);
            var filepath = @"Image samples for testing\CN\" + tb_MaNV_nv_infonv.Text + ".jpg";
            if (Result == DialogResult.Yes)
            {
                pictureBox_image_anhnv.Image = null;
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                    Image image1 = null;
                    using (FileStream stream = new FileStream(@"Image samples for testing\CN\No Image.jpg", FileMode.Open))
                    {
                        image1 = Image.FromStream(stream);
                    }
                    pictureBox_image_anhnv.Image = image1;
                    MessageBox.Show("Đã xoá thành công!");
                }
                else MessageBox.Show("Không có ảnh để xoá!");
            }
        }
    }
}