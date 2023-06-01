using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class DTCC_modifier : Form
    {
        public string filepath = "";
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

        public DTCC_modifier()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void button_Image_import_Click(object sender, EventArgs e)
        {
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

        private void button_DTCC_Accept_Click(object sender, EventArgs e)
        {
            if (exedata("set dateformat dmy\n Update DTCC set TENDT = N'" + textBox_TENDT_z.Text + "', SDT = '"
                + textBox_SDT_z.Text + "', NGDT = '" + dateTimePicker_NGDT_z.Text + "', DIACHI = N'"
                + textBox_DIACHI_z.Text + "' where DTID = '" + textBox_ID_z.Text + "'") == true)
            {
                MessageBox.Show("Cập nhật thành công!");
                SaveFileDialog Save = new SaveFileDialog();
                if (filepath != "")
                {
                    Save.FileName = @"Image samples for testing\DTGD\" + textBox_ID_z.Text + ".jpg";
                    using (System.IO.FileStream fstream = new System.IO.FileStream(Save.FileName, System.IO.FileMode.Create))
                    {
                        pictureBox_image_import.Image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        fstream.Close();
                    }
                }
                RefreshData(this, new EventArgs());
                Close();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công");
            }
        }

        private void button_DTCC_Reject_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}