using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_main_NV : Form
    {
        private string NVID;
        private string Ten;
        private SqlConnection sqlCon = null;
        private string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        private SqlCommand cmd;
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private bool canExit = true;
        private DataTable table = new DataTable();

        public string nvid
        {
            set { NVID = value; }
        }

        public Form_main_NV()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            sqlCon = new SqlConnection(strCon);
            DTCC_guest_dataInitialize();
            pictureBox_dtcc_guestFace.Image = Image.FromFile(@"Image samples for testing\NV\No Image.jpg");
            this.Size = new Size(1275, 740);
        }

        public Form_main_NV(string NVID, string Ten, string username)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            sqlCon = new SqlConnection(strCon);
            this.NVID = NVID;
            this.Ten = Ten;
            tbtnUser.Text = username;
            DTCC_guest_dataInitialize();
            this.Size = new Size(1275, 740);
        }

        public event EventHandler Thoat;

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            canExit = false;
            Thoat(this, new EventArgs());
        }

        private void Form_main_NV_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (canExit == true)
                Application.Exit();
        }

        private void Form_main_NV_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            tabctrl_Nhanvien_SelectedIndexChanged(this, new EventArgs());
        }

        
    }
}