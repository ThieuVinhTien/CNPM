using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class DTCC_guest_form : Form
    {
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        private SqlConnection con = new SqlConnection(strCon);

        private void openconnect()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public event EventHandler RefreshData;

        private void closeconnect()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public Boolean exedata(string cmd)
        {
            openconnect();
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
            closeconnect();
            return check;
        }

        public DTCC_guest_form()
        {
            InitializeComponent();
            textBox_budget_z.Text = "0";
            pictureBox_image_import.Image = Image.FromFile(@"Image samples for testing\KHDK\No Image.jpg");
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void button_DTCC_Reject_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_DTCC_Accept_Click(object sender, EventArgs e)
        {
            string loaiKH = "NOR";
            if (string.IsNullOrEmpty(comboBox_loaiKH.Text) != true)
                if (comboBox_loaiKH.Text == "Khách thường")
                    loaiKH = "NOR";
                else
                    loaiKH = "VIP";

            if (exedata("set dateformat dmy\n insert into KHACHHANG values('" + textBox_ID_z.Text + "', N'" + textBox_TENDT_z.Text + "', N'"
                + textBox_DIACHI_z.Text + "', '" + textBox_SDT_z.Text + "', '" + dateTimePicker_NGDT_z.Text + "', '" + textBox_budget_z.Text.Replace("VND", string.Empty) + "', '" + loaiKH + "')") == true)
            {
                MessageBox.Show("Thêm thành công!");
                SaveFileDialog Save = new SaveFileDialog();
                Save.FileName = @"Image samples for testing\KHDK\" + textBox_ID_z.Text + ".jpg";
                pictureBox_image_import.Image.Save(Save.FileName);
                RefreshData(this, new EventArgs());
                Close();
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
            }
        }

        private void button_Image_import_Click(object sender, EventArgs e)
        {
            string filepath;
            OpenFileDialog Open1 = new OpenFileDialog();
            Open1.Filter = " Image file (*.BMP,*.JPG,*.JPEG)|*.bmp;*.jpg;*.jpeg ";
            Open1.Multiselect = false;
            if (Open1.ShowDialog() == DialogResult.OK)
            {
                filepath = Open1.FileName;
                pictureBox_image_import.Image = Image.FromFile(filepath);
                this.label_image_name.Text = filepath;
            }
        }

        private void textBox_budget_z_Click(object sender, EventArgs e)
        {
            textBox_budget_z.SelectAll();
        }
    }
}