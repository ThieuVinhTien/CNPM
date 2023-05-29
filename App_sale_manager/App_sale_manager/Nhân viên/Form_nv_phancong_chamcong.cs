using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_nv_phancong_chamcong : Form
    {
        private SqlConnection sqlCon = null;
        private string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        private SqlCommand cmd;
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private List<string> ngay = new List<string>();

        public Form_nv_phancong_chamcong()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Size = new Size(1230, 570);
            sqlCon = new SqlConnection(strCon);
            cmd = sqlCon.CreateCommand();
            update_table_CT_LAMVIEC();
            Tao_bang();
            load_bangChamCong();
        }

        private void load_ThongtinNV(string NVID)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd.CommandText = "SELECT NVID, HOTEN, SDT, NGSINH, NGVL, CV, USERNAME FROM NHANVIEN WHERE NVID = '" + NVID + "'";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox3.Text = reader.GetString(0);
                textBox4.Text = reader.GetString(1);
                textBox5.Text = reader.GetString(2);
                dateTimePicker1.Value = reader.GetDateTime(3);
                dateTimePicker2.Value = reader.GetDateTime(4);
                textBox6.Text = reader.GetString(5);
                textBox7.Text = reader.GetString(6);
            }
            reader.Close();
            try
            {
                pictureBox3.BackgroundImage = Image.FromFile(@"Image samples for testing\NV\" + NVID + ".jpg");
            }
            catch (Exception)
            {
                pictureBox3.BackgroundImage = Image.FromFile(@"Image samples for testing\NV\No Image.jpg");
            }
            cmd.CommandText = "SELECT COUNT(*) FROM CT_LAMVIEC WHERE NVID= '" + NVID + "' AND MONTH(NGAYLAM) =" + DateTime.Today.Month + " AND NGAYLAM<='" + DateTime.Today.ToString("MM/dd/yyyy") + "' AND TRANGTHAI = N'Đã điểm danh'";
            textBox1.Text = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "SELECT COUNT(*) FROM CT_LAMVIEC WHERE NVID= '" + NVID + "' AND MONTH(NGAYLAM) =" + DateTime.Today.Month + " AND NGAYLAM<='" + DateTime.Today.ToString("MM/dd/yyyy") + "' AND TRANGTHAI = N'Chưa điểm danh'";
            textBox2.Text = cmd.ExecuteScalar().ToString();
            sqlCon.Close();
        }

        private void update_table_CT_LAMVIEC()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            DateTime i = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            for (; i <= DateTime.Today; i = i.AddDays(1))
            {
                cmd.CommandText = "SELECT NVID, CAID FROM CT_LAMVIEC_HANGTUAN WHERE SUBSTRING(CAID,2,1) = '" + ((int)i.DayOfWeek) + "'"
                               + " EXCEPT"
                               + " SELECT NVID, CAID FROM CT_LAMVIEC WHERE NGAYLAM = '" + i.ToString("MM/dd/yyyy") + "'";
                DataTable table = new DataTable();
                table.Clear();
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    try
                    {
                        cmd.CommandText = "INSERT INTO CT_LAMVIEC VALUES('" + table.Rows[j]["NVID"] + "', '" + table.Rows[j]["CAID"] + "', '" + i.ToString("MM/dd/yyyy") + "', N'Chưa điểm danh',N'Lặp lại',N'Lịch làm việc hàng tuần')";
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            sqlCon.Close();
        }

        private void Tao_bang()
        {
            // tạo bảng.
            DateTime i = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            for (; i <= DateTime.Today; i = i.AddDays(1))
            {
                DataGridViewImageColumn clSang = new DataGridViewImageColumn();
                clSang.HeaderText = "Sáng";
                clSang.Image = Image.FromFile("../../icon/white.jpg");
                clSang.ImageLayout = DataGridViewImageCellLayout.Zoom;
                DataGridViewImageColumn clChieu = new DataGridViewImageColumn();
                clChieu.HeaderText = "Chiều";
                clChieu.Image = Image.FromFile("../../icon/white.jpg");
                clChieu.ImageLayout = DataGridViewImageCellLayout.Zoom;
                DataGridViewImageColumn clToi = new DataGridViewImageColumn();
                clToi.HeaderText = "Tối";
                clToi.Image = Image.FromFile("../../icon/white.jpg");
                clToi.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dataGridView1.Columns.Add(clSang);
                dataGridView1.Columns.Add(clChieu);
                dataGridView1.Columns.Add(clToi);
                ngay.Add(i.ToString("d"));
            }
            for (int j = 2; j < this.dataGridView1.ColumnCount; j++)

            {
                this.dataGridView1.Columns[j].Width = 45;
            }

            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            this.dataGridView1.ColumnHeadersHeight = this.dataGridView1.ColumnHeadersHeight * 2;

            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);

            this.dataGridView1.Paint += new PaintEventHandler(dataGridView1_Paint);

            this.dataGridView1.Scroll += new ScrollEventHandler(dataGridView1_Scroll);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd.CommandText = "SELECT NVID, HOTEN FROM NHANVIEN";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1));
            }
            reader.Close();
            sqlCon.Close();
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = this.dataGridView1.DisplayRectangle;

            rtHeader.Height = this.dataGridView1.ColumnHeadersHeight / 2;

            dataGridView1_Paint(sender, new PaintEventArgs((sender as DataGridView).CreateGraphics(), new Rectangle()));
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            for (int j = 2; j < ngay.Count * 3; j += 3)

            {
                Rectangle r1 = this.dataGridView1.GetCellDisplayRectangle(j, -1, true);

                int w2 = this.dataGridView1.GetCellDisplayRectangle(j + 1, -1, true).Width;
                int w3 = this.dataGridView1.GetCellDisplayRectangle(j + 2, -1, true).Width;

                r1.X += 1;

                r1.Y += 1;

                r1.Width = r1.Width + w2 + w3 - 2;

                r1.Height = r1.Height / 2 - 2;

                e.Graphics.FillRectangle(new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1);

                StringFormat format = new StringFormat();

                format.Alignment = StringAlignment.Center;

                format.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(ngay[j / 3],

                    this.dataGridView1.ColumnHeadersDefaultCellStyle.Font,

                    new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor),

                    r1,

                    format);
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)

            {
                Rectangle r2 = e.CellBounds;

                r2.Y += e.CellBounds.Height / 2;

                r2.Height = e.CellBounds.Height / 2;

                e.PaintBackground(r2, true);

                e.PaintContent(r2);

                e.Handled = true;
            }
        }

        private void load_bangChamCong()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            int n = dataGridView1.Rows.Count;
            DateTime i = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            int h = 2;
            for (; i <= DateTime.Today; i = i.AddDays(1))
            {
                for (int j = 0; j < n; j++)
                {
                    cmd.CommandText = "SELECT CAID FROM CT_LAMVIEC WHERE NVID = '" + dataGridView1.Rows[j].Cells[0].Value.ToString() + "' AND NGAYLAM = '" + i.ToString("MM/dd/yyyy") + "' AND TRANGTHAI = N'Đã điểm danh'";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        switch (reader.GetString(0).Substring(2, 1))
                        {
                            case "S":
                                dataGridView1.Rows[j].Cells[h].Value = Image.FromFile("../../icon/tick.png");
                                break;

                            case "C":
                                dataGridView1.Rows[j].Cells[h + 1].Value = Image.FromFile("../../icon/tick.png");
                                break;

                            case "T":
                                dataGridView1.Rows[j].Cells[h + 2].Value = Image.FromFile("../../icon/tick.png");
                                break;
                        }
                    }
                    reader.Close();
                    cmd.CommandText = "SELECT CAID FROM CT_LAMVIEC WHERE NVID = '" + dataGridView1.Rows[j].Cells[0].Value.ToString() + "' AND NGAYLAM = '" + i.ToString("MM/dd/yyyy") + "' AND TRANGTHAI = N'Chưa điểm danh'";
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        switch (reader.GetString(0).Substring(2, 1))
                        {
                            case "S":
                                dataGridView1.Rows[j].Cells[h].Value = Image.FromFile("../../icon/X.png");
                                break;

                            case "C":
                                dataGridView1.Rows[j].Cells[h + 1].Value = Image.FromFile("../../icon/X.png");
                                break;

                            case "T":
                                dataGridView1.Rows[j].Cells[h + 2].Value = Image.FromFile("../../icon/X.png");
                                break;
                        }
                    }
                    reader.Close();
                }
                h += 3;
            }
            sqlCon.Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            load_ThongtinNV(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
        }
    }
}