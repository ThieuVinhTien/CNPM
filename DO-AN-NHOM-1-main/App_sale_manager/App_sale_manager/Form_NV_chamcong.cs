using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_NV_chamcong : Form
    {
        private string NVID;
        private SqlConnection sqlCon = null;
        private string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        private SqlCommand cmd;
        private SqlDataAdapter adapter = new SqlDataAdapter();

        public Form_NV_chamcong()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
            cmd = sqlCon.CreateCommand();
        }

        public Form_NV_chamcong(string NVID)
        {
            this.NVID = NVID;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            sqlCon = new SqlConnection(strCon);
            cmd = sqlCon.CreateCommand();
            load_ThongtinNV();
            load_bangchamcong();
            load_songay();
        }

        private void load_ThongtinNV()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd.CommandText = "SELECT NVID, HOTEN, SDT, CV, USERNAME FROM NHANVIEN WHERE NVID = '" + NVID + "'";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox3.Text = reader.GetString(0);
                textBox4.Text = reader.GetString(1);
                textBox5.Text = reader.GetString(2);
                textBox6.Text = reader.GetString(3);
                textBox7.Text = reader.GetString(4);
            }
            try
            {
                pictureBox1.BackgroundImage = Image.FromFile(@"Image samples for testing\NV\" + NVID + ".jpg");
            }
            catch (Exception)
            {
                pictureBox1.BackgroundImage = Image.FromFile(@"Image samples for testing\NV\No Image.jpg");
            }
            sqlCon.Close();
        }

        private void load_bangchamcong()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            DateTime i = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dataGridView1.Rows.Add("Ca sáng");
            dataGridView1.Rows.Add("Ca chiều");
            dataGridView1.Rows.Add("Ca tối");
            int j = 1;
            for (; i <= DateTime.Today; i = i.AddDays(1))
            {
                DataGridViewImageColumn column = new DataGridViewImageColumn();
                column.HeaderText = i.ToString("d");
                column.Image = Image.FromFile("../../icon/white.jpg");
                column.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dataGridView1.Columns.Add(column);
                cmd.CommandText = "SELECT CAID FROM CT_LAMVIEC WHERE NVID = '" + NVID + "' AND NGAYLAM = '" + i.ToString("MM/dd/yyyy") + "' AND TRANGTHAI=N'Đã điểm danh'";
                adapter.SelectCommand = cmd;
                DataTable table = new DataTable();
                table.Clear();
                adapter.Fill(table);
                for (int h = 0; h < table.Rows.Count; h++)
                {
                    switch (table.Rows[h]["CAID"].ToString().Substring(2, 1))
                    {
                        case "S":
                            dataGridView1.Rows[0].Cells[j].Value = Image.FromFile("../../icon/tick.png");
                            break;

                        case "C":
                            dataGridView1.Rows[1].Cells[j].Value = Image.FromFile("../../icon/tick.png");
                            break;

                        case "T":
                            dataGridView1.Rows[2].Cells[j].Value = Image.FromFile("../../icon/tick.png");
                            break;
                    }
                }
                cmd.CommandText = "SELECT CAID FROM CT_LAMVIEC WHERE NVID = '" + NVID + "' AND NGAYLAM = '" + i.ToString("MM/dd/yyyy") + "' AND TRANGTHAI=N'Chưa điểm danh'";
                adapter.SelectCommand = cmd;
                table.Rows.Clear();
                adapter.Fill(table);
                for (int h = 0; h < table.Rows.Count; h++)
                {
                    switch (table.Rows[h]["CAID"].ToString().Substring(2, 1))
                    {
                        case "S":
                            dataGridView1.Rows[0].Cells[j].Value = Image.FromFile("../../icon/X.png");
                            break;

                        case "C":
                            dataGridView1.Rows[1].Cells[j].Value = Image.FromFile("../../icon/X.png");
                            break;

                        case "T":
                            dataGridView1.Rows[2].Cells[j].Value = Image.FromFile("../../icon/X.png");
                            break;
                    }
                }
                j++;
            }
            sqlCon.Close();
        }

        private void load_songay()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd.CommandText = "SELECT COUNT(*) FROM CT_LAMVIEC WHERE NVID= '" + NVID + "' AND MONTH(NGAYLAM) =" + DateTime.Today.Month + " AND TRANGTHAI = N'Đã điểm danh'";
            textBox1.Text = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "SELECT COUNT(*) FROM CT_LAMVIEC WHERE NVID= '" + NVID + "' AND MONTH(NGAYLAM) =" + DateTime.Today.Month + " AND TRANGTHAI = N'Chưa điểm danh'";
            textBox2.Text = cmd.ExecuteScalar().ToString();
            sqlCon.Close();
        }
    }
}