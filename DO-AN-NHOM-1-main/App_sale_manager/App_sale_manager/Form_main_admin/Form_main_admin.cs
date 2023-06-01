using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_main_admin : Form
    {
        public string filepath = "";
        private string manv = string.Empty;
        private string tennv = string.Empty;
        private SqlConnection sqlCon = null;
        private string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        private SqlCommand cmd;
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private bool canExit;
        private DataTable table = new DataTable();
        private DataTable table_nv_bangluong = new DataTable();

        private DataTable table_nv_infonv = new DataTable();

        public Form_main_admin()
        {
            sqlCon = new SqlConnection(strCon);
            cmd = sqlCon.CreateCommand();
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            DTCC_dtgd_dataInitialize();
            DTCC_guest_dataInitialize();
            canExit = true;
            pictureBox_Logo.Image = Image.FromFile(@"Image samples for testing\DTGD\No Image.jpg");
            pictureBox_dtcc_guestFace.Image = Image.FromFile(@"Image samples for testing\KHDK\No Image.jpg");
            button_refresh.BackgroundImage = Image.FromFile(@"Image samples for testing\DTGD\refresh.jpg");
            this.Size = new Size(1275, 740);
            
        }

        public Form_main_admin(string manv, string tennv, string username)
        {
            this.manv = manv;
            this.tennv = tennv;
            sqlCon = new SqlConnection(strCon);
            cmd = sqlCon.CreateCommand();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            InitializeComponent();
            DTCC_dtgd_dataInitialize();
            DTCC_guest_dataInitialize();
            canExit = true;
            pictureBox_Logo.Image = Image.FromFile(@"Image samples for testing\DTGD\No Image.jpg");
            pictureBox_dtcc_guestFace.Image = Image.FromFile(@"Image samples for testing\KHDK\No Image.jpg");
            this.Size = new Size(1275, 740);
            tbtnUser.Text = username;
        }

        public event EventHandler Thoat;

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            canExit = false;
            Thoat(this, new EventArgs());
        }

        private void Form_main_admin_Load(object sender, EventArgs e)
        {
            load_tab_Tongquan();
            tao_datgridview_lich_lamviec();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void Form_main_admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (canExit == true)
                Application.Exit();
        }

        private void CLB_GD_LoaiDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            bnt_Timkiem_Click(sender, e);
        }

        private void CLB_GD_TrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            bnt_Timkiem_Click(sender, e);
        }
    }
}