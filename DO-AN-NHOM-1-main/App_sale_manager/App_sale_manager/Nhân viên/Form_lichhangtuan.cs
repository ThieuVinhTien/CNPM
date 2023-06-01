using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_lichhangtuan : Form
    {
        private GroupBox[] grbs;
        private DataGridView[] dgvs;
        private SqlConnection sqlCon = null;
        private string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        private SqlCommand cmd;
        private SqlDataAdapter adapter = new SqlDataAdapter();

        public event EventHandler Load_form_main;

        private void Load_form(object sender, EventArgs e)
        {
            (sender as Form).Close();
            this.load_fr();
        }

        public Form_lichhangtuan()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            sqlCon = new SqlConnection(strCon);
            grbs = new GroupBox[7] { grb_chunhat, grb_thuhai, grb_thuba, grb_thutu, grb_thunam, grb_thusau, grb_thubay };
            dgvs = new DataGridView[7] { dgv_CN, dgv_2, dgv_3, dgv_4, dgv_5, dgv_6, dgv_7 };
            load_fr();
            this.Size = new Size(1200, 800);
        }

        private void taobang(GroupBox grb, DataGridView dgv)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT GIO_BD, GIO_NGHI FROM CALAMVIEC WHERE THU = '" + grb.Text + "' ORDER BY GIO_NGHI";
            adapter.SelectCommand = cmd;
            DataTable table1 = new DataTable();
            table1.Clear();
            adapter.Fill(table1);
            // tạo bảng dữ liệu.
            DataGridViewTextBoxColumn dgvID = new DataGridViewTextBoxColumn();
            dgvID.HeaderText = "Mã NV";
            dgvID.Frozen = true;
            dgvID.Width = 50;
            DataGridViewTextBoxColumn dgvTen = new DataGridViewTextBoxColumn();
            dgvTen.HeaderText = "Họ tên";
            dgvTen.Frozen = true;
            DataGridViewTextBoxColumn dgvChucvu = new DataGridViewTextBoxColumn();
            dgvChucvu.HeaderText = "Chức vụ";

            DataGridViewCheckBoxColumn dgvSang = new DataGridViewCheckBoxColumn();
            dgvSang.HeaderText = "Ca sáng(" + table1.Rows[0]["GIO_BD"] + " - " + table1.Rows[0]["GIO_NGHI"] + ")";
            DataGridViewCheckBoxColumn dgvChieu = new DataGridViewCheckBoxColumn();
            dgvChieu.HeaderText = "Ca chiều(" + table1.Rows[1]["GIO_BD"] + " - " + table1.Rows[1]["GIO_NGHI"] + ")";
            DataGridViewCheckBoxColumn dgvToi = new DataGridViewCheckBoxColumn();
            dgvToi.HeaderText = "Ca tối(" + table1.Rows[2]["GIO_BD"] + " - " + table1.Rows[2]["GIO_NGHI"] + ")";

            dgv.Columns.AddRange(dgvID, dgvTen, dgvChucvu, dgvSang, dgvChieu, dgvToi);
            sqlCon.Close();
        }

        private void load_fr()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            for (int i = 0; i < 7; i++)
            {
                taobang(grbs[i], dgvs[i]);
                cmd = sqlCon.CreateCommand();
                cmd.CommandText = "SELECT CT_LAMVIEC_HANGTUAN.NVID , HOTEN, CV, CAID FROM CT_LAMVIEC_HANGTUAN, NHANVIEN "
                                    + "WHERE SUBSTRING(CAID,2,1) = '" + i + "' AND CT_LAMVIEC_HANGTUAN.NVID = NHANVIEN.NVID ";
                adapter.SelectCommand = cmd;
                DataTable table = new DataTable();
                table.Clear();
                adapter.Fill(table);
                dgvs[i].Rows.Clear();
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    dgvs[i].Rows.Add(table.Rows[j]["NVID"], table.Rows[j]["HOTEN"], table.Rows[j]["CV"], false, false, false);
                    string NVID = table.Rows[j]["NVID"].ToString();
                    while (table.Rows[j]["NVID"].ToString() == NVID)
                    {
                        switch (table.Rows[j]["CAID"].ToString().Substring(2))
                        {
                            case "S":
                                dgvs[i].Rows[dgvs[i].Rows.Count - 2].Cells[3].Value = true;
                                break;

                            case "C":
                                dgvs[i].Rows[dgvs[i].Rows.Count - 2].Cells[4].Value = true;
                                break;

                            case "T":
                                dgvs[i].Rows[dgvs[i].Rows.Count - 2].Cells[5].Value = true;
                                break;
                        }
                        j++;
                        if (j >= table.Rows.Count)
                            break;
                    }
                    j--;
                }
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            Form_nv_phancong_themlich frm = new Form_nv_phancong_themlich();
            frm.Load_frm_main += Load_form;
            frm.cbo_chedo.SelectedIndex = 1;
            frm.cbo_chedo.Enabled = false;
            frm.ShowDialog();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "DELETE FROM CT_LAMVIEC_HANGTUAN";
            cmd.ExecuteNonQuery();
            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < dgvs[j].Rows.Count - 1; i++)
                {
                    if (dgvs[j].Rows[i].Cells[3].Value.ToString() == "True")
                    {
                        cmd.CommandText = "INSERT INTO CT_LAMVIEC_HANGTUAN VALUES('" + dgvs[j].Rows[i].Cells[0].Value.ToString() + "', 'C" + j + "S', N'Lịch làm việc hàng tuần')";
                        cmd.ExecuteNonQuery();
                    }
                    if (dgvs[j].Rows[i].Cells[4].Value.ToString() == "True")
                    {
                        cmd.CommandText = "INSERT INTO CT_LAMVIEC_HANGTUAN VALUES('" + dgvs[j].Rows[i].Cells[0].Value.ToString() + "', 'C" + j + "C', N'Lịch làm việc hàng tuần')";
                        cmd.ExecuteNonQuery();
                    }
                    if (dgvs[j].Rows[i].Cells[5].Value.ToString() == "True")
                    {
                        cmd.CommandText = "INSERT INTO CT_LAMVIEC_HANGTUAN VALUES('" + dgvs[j].Rows[i].Cells[0].Value.ToString() + "', 'C" + +j + "T', N'Lịch làm việc hàng tuần')";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Đã lưu thành công");
            sqlCon.Close();
        }

        private void btn_Xoatoanbo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                dgvs[i].Rows.Clear();
            }
        }

        private void Form_lichhangtuan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Load_form_main(this, new EventArgs());
        }
    }
}