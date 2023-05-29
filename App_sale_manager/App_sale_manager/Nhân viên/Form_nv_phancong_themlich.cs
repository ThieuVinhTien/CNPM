using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_nv_phancong_themlich : Form
    {
        private DateTime Day;
        private SqlConnection sqlCon = null;
        private string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        private SqlCommand cmd;
        private SqlDataAdapter adapter = new SqlDataAdapter();

        public event EventHandler Load_frm_main;

        public DateTime day
        {
            get { return Day; }
            set { Day = value; }
        }

        private DataTable table;

        public Form_nv_phancong_themlich()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            cbo_chedo.SelectedIndex = 0;
            sqlCon = new SqlConnection(strCon);
            dgv_phancong_nvid.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT NVID, HOTEN, CV, SDT FROM NHANVIEN";
            adapter.SelectCommand = cmd;
            table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            dgv_phancong_nvid.Hide();
        }

        private bool KiemtralistCAID(string thu)
        {
            DateTime date = new DateTime();
            date = dtp_phancong_ngay.Value;
            while (date.DayOfWeek != DayOfWeek.Sunday)
            {
                if (date.DayOfWeek.ToString() == thu)
                    return true;
                date = date.AddDays(1);
            }
            if (thu == "Sunday")
                return true;
            return false;
        }

        private DateTime chuyenNglam(string thu)
        {
            DateTime date = new DateTime();
            date = dtp_phancong_ngay.Value;
            while (date.DayOfWeek != DayOfWeek.Sunday)
            {
                if (date.DayOfWeek.ToString() == thu)
                    return date;
                date = date.AddDays(1);
            }
            return date;
        }

        private struct CAID
        {
            public string CA;
            public DateTime Nglam;
        };

        private void btn_phancong_hoantat_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();

            List<CAID> CAIDs = new List<CAID>();
            while (txt_phancong_sang.Text != "")
            {
                if (KiemtralistCAID(txt_phancong_sang.Text.Substring(0, txt_phancong_sang.Text.IndexOf(" "))) || cbo_chedo.Text == "Lặp lại hàng tuần")
                {
                    cmd.CommandText = "SELECT CAID FROM CALAMVIEC WHERE THU = '" + txt_phancong_sang.Text.Substring(0, txt_phancong_sang.Text.IndexOf(" ")) + "' AND GIO_BD BETWEEN '6:00:00' AND '9:00:00'";
                    CAID ca = new CAID();
                    ca.CA = (string)cmd.ExecuteScalar();
                    ca.Nglam = chuyenNglam(txt_phancong_sang.Text.Substring(0, txt_phancong_sang.Text.IndexOf(" ")));
                    CAIDs.Add(ca);
                }
                txt_phancong_sang.Text = txt_phancong_sang.Text.Substring(txt_phancong_sang.Text.IndexOf(" ") + 1);
            }
            while (txt_phancong_Chieu.Text != "")
            {
                if (KiemtralistCAID(txt_phancong_Chieu.Text.Substring(0, txt_phancong_Chieu.Text.IndexOf(" "))) || cbo_chedo.Text == "Lặp lại hàng tuần")
                {
                    cmd.CommandText = "SELECT CAID FROM CALAMVIEC WHERE THU = '" + txt_phancong_Chieu.Text.Substring(0, txt_phancong_Chieu.Text.IndexOf(" ")) + "' AND GIO_BD BETWEEN '12:00:00' AND '15:00:00'";
                    CAID ca = new CAID();
                    ca.CA = (string)cmd.ExecuteScalar();
                    ca.Nglam = chuyenNglam(txt_phancong_Chieu.Text.Substring(0, txt_phancong_Chieu.Text.IndexOf(" ")));
                    CAIDs.Add(ca);
                }
                txt_phancong_Chieu.Text = txt_phancong_Chieu.Text.Substring(txt_phancong_Chieu.Text.IndexOf(" ") + 1);
            }
            while (txt_phancong_Toi.Text != "")
            {
                if (KiemtralistCAID(txt_phancong_Toi.Text.Substring(0, txt_phancong_Toi.Text.IndexOf(" "))) || cbo_chedo.Text == "Lặp lại hàng tuần")
                {
                    cmd.CommandText = "SELECT CAID FROM CALAMVIEC WHERE THU = '" + txt_phancong_Toi.Text.Substring(0, txt_phancong_Toi.Text.IndexOf(" ")) + "' AND GIO_BD BETWEEN '17:00:00' AND '23:00:00'";
                    CAID ca = new CAID();
                    ca.CA = (string)cmd.ExecuteScalar();
                    ca.Nglam = chuyenNglam(txt_phancong_Toi.Text.Substring(0, txt_phancong_Toi.Text.IndexOf(" ")));
                    CAIDs.Add(ca);
                }
                txt_phancong_Toi.Text = txt_phancong_Toi.Text.Substring(txt_phancong_Toi.Text.IndexOf(" ") + 1);
            }
            if (CAIDs.Count == 0 || cbo_chedo.Text == "" || chkL_phancong_NVID.Items.Count == 0)
            {
                MessageBox.Show("Ban chưa điền đủ thông tin.", "Thông báo");
                return;
            }
            string CHEDO = "";
            if (cbo_chedo.Text == "Chỉ một lần trong tuần này")
            {
                CHEDO = "Không lặp";
                if (dtp_phancong_ngay.Value < DateTime.Today)
                {
                    MessageBox.Show("Ngày này đã qua. Bạn không thêm vào được!", "Thông báo");
                    return;
                }
                for (int i = 0; i < chkL_phancong_NVID.Items.Count; i++)
                {
                    for (int j = 0; j < CAIDs.Count; j++)
                    {
                        cmd.CommandText = "SELECT * FROM CT_LAMVIEC_HANGTUAN WHERE NVID = '" + chkL_phancong_NVID.Items[i].ToString() + "' AND CAID ='" + CAIDs[j].CA + "'";
                        adapter.SelectCommand = cmd;
                        DataTable table = new DataTable();
                        table.Clear();
                        adapter.Fill(table);
                        if (table.Rows.Count == 0)
                        {
                            try
                            {
                                cmd.CommandText = "INSERT INTO CT_LAMVIEC VALUES('" + chkL_phancong_NVID.Items[i].ToString() + "', '" + CAIDs[j].CA + "', '" + CAIDs[j].Nglam.ToString("MM/dd/yyyy") + "', N'Chưa điểm danh', N'" + CHEDO + "', N'" + txt_tieude.Text + "')";
                            
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            cmd.CommandText = "SELECT GIO_BD, GIO_NGHI FROM CALAMVIEC WHERE CAID ='" + CAIDs[j].CA + "'";
                            var reader = cmd.ExecuteReader();
                            string giobd = "";
                            string gionghi = "";
                            while (reader.Read())
                            {
                                giobd = reader.GetString(0);
                                gionghi = reader.GetString(1);
                            }
                            string THU = "";
                            if (((int)CAIDs[j].Nglam.DayOfWeek) == 0)
                                THU = "CN";
                            else THU = THU + "Thứ " + ((int)CAIDs[j].Nglam.DayOfWeek + 1);
                            DialogResult dlg = MessageBox.Show("Ca lam viec " + THU + " " + giobd + " đến " + gionghi + " của " + chkL_phancong_NVID.Items[i].ToString() + " đã có trong lịch hàng tuần.\nBạn có muốn tiếp tục thay đổi không?", "Thông báo", MessageBoxButtons.YesNo);
                            if (dlg == DialogResult.Yes)
                            {
                                cmd.CommandText = "INSERT INTO CT_LAMVIEC VALUES('" + chkL_phancong_NVID.Items[i].ToString() + "', '" + CAIDs[j].CA + "', '" + CAIDs[j].Nglam.ToString("d") + "', N'Chưa điểm danh', N'" + CHEDO + "', N'" + txt_tieude.Text + "')";
                                cmd.ExecuteNonQuery();
                                cmd.CommandText = "DELETE FROM CT_LAM_VIEC_HANGTUAN WHERE NVID = '" + chkL_phancong_NVID.Items[i].ToString() + "' AND CAID ='" + CAIDs[j].CA + "'";
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            else if (cbo_chedo.Text == "Lặp lại hàng tuần")
            {
                CHEDO = "Lặp lại";
                for (int i = 0; i < chkL_phancong_NVID.Items.Count; i++)
                {
                    for (int j = 0; j < CAIDs.Count; j++)
                    {
                        try
                        {
                            cmd.CommandText = "INSERT INTO CT_LAMVIEC_HANGTUAN VALUES('" + chkL_phancong_NVID.Items[i].ToString() + "', '" + CAIDs[j].CA + "',N'Lịch làm việc hàng tuần')";
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            sqlCon.Close();
            Load_frm_main(this, new EventArgs());
        }

        private void cbo_phancong_NVID_TextUpdate(object sender, EventArgs e)
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("NVID");
            table1.Columns.Add("Tên");
            table1.Columns.Add("Chức vụ");
            table1.Columns.Add("Số DT");

            table1.Rows.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i]["NVID"].ToString().IndexOf((sender as ComboBox).Text) != -1 && (sender as ComboBox).Text != "")
                {
                    table1.Rows.Add(table.Rows[i]["NVID"].ToString(), table.Rows[i]["HOTEN"].ToString(), table.Rows[i]["CV"].ToString(), table.Rows[i]["SDT"].ToString());
                }
            }
            dgv_phancong_nvid.DataSource = table1;
            if (table1.Rows.Count != 0)
                dgv_phancong_nvid.Show();
            else dgv_phancong_nvid.Hide();
            sqlCon.Close();
        }

        private void dgv_phancong_nvid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbo_phancong_NVID.Text = dgv_phancong_nvid.Rows[e.RowIndex].Cells[0].Value.ToString();
            chkL_phancong_NVID.Items.Add(dgv_phancong_nvid.Rows[e.RowIndex].Cells[0].Value.ToString());
            dgv_phancong_nvid.Hide();
        }

        private void btn_phancong_thu_Click(object sender, EventArgs e)
        {
            bool Sang = false, Chieu = false, Toi = false;
            if (txt_phancong_sang.Text == "")
                Sang = true;
            if (txt_phancong_Chieu.Text == "")
                Chieu = true;
            if (txt_phancong_Toi.Text == "")
                Toi = true;
            for (int i = 0; i < chkL_phancong_thu.CheckedItems.Count; i++)
            {
                if (chk_phancong_sang.Checked == true && Sang == true)
                {
                    txt_phancong_sang.Text = txt_phancong_sang.Text + chkL_phancong_thu.CheckedItems[i].ToString() + " ";
                }
                if (chk_phancong_chieu.Checked == true && Chieu == true)
                {
                    txt_phancong_Chieu.Text = txt_phancong_Chieu.Text + chkL_phancong_thu.CheckedItems[i].ToString() + " ";
                }
                if (chk_phancong_toi.Checked == true && Toi == true)
                {
                    txt_phancong_Toi.Text = txt_phancong_Toi.Text + chkL_phancong_thu.CheckedItems[i].ToString() + " ";
                }
            }
            for (int i = 0; i < chkL_phancong_thu.Items.Count; i++)
            {
                chkL_phancong_thu.SetItemChecked(i, false);
            }
        }

        private void btn_phancong_xoaNVID_Click(object sender, EventArgs e)
        {
            int n = chkL_phancong_NVID.CheckedItems.Count;
            for (int i = 0; i < n; i++)
            {
                int j = 0;
                chkL_phancong_NVID.Items.Remove(chkL_phancong_NVID.CheckedItems[j].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbo_chedo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_chedo.SelectedIndex == 0)
            {
                txt_tieude.Enabled = true ;
            }
            else txt_tieude.Enabled = false;
        }
    }
}