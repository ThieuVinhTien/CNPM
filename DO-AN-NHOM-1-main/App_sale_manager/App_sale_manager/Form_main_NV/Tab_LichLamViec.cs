using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_main_NV : Form
    {   //TABPAGE LỊCH LÀM VIỆC
        private TimeSpan GIO_BD = new TimeSpan();

        private TimeSpan GIO_KT = new TimeSpan();
        string caid = "";
        private void load_lich_calamHienTai()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            DateTime date = DateTime.Now;
            
            cmd.CommandText = "SELECT CAID, GIO_BD, GIO_NGHI FROM CALAMVIEC WHERE GIO_BD<'" + date.ToString("HH:mm:ss") + "' AND GIO_NGHI>'" + date.ToString("HH:mm:ss") + "' AND SUBSTRING(CAID,2,1)='" + ((int)date.DayOfWeek).ToString() + "'";
            var reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                caid = reader.GetString(0);
                switch (caid.Substring(2))
                {
                    case "S":
                        lbl_lich_buoi.Text = "Sáng";
                        break;

                    case "C":
                        lbl_lich_buoi.Text = "Chiều";
                        break;

                    case "T":
                        lbl_lich_buoi.Text = "Tối";
                        break;
                }
                lbl_lich_BD.Text = reader.GetTimeSpan(1).ToString();
                GIO_BD = reader.GetTimeSpan(1);
                lbl_lich_KT.Text = reader.GetTimeSpan(2).ToString();
                GIO_KT = reader.GetTimeSpan(2);
                
            }
            reader.Close();
            lblLich_ngay.Text = DateTime.Today.Day.ToString();
            lblLich_thang.Text = "Tháng " + DateTime.Today.Month.ToString();
            sqlCon.Close();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lbl_lich_dongho.Text = DateTime.Now.ToString("HH:mm:ss");
            if (DateTime.Now.TimeOfDay > GIO_BD || DateTime.Now.TimeOfDay > GIO_KT)
                load_lich_calamHienTai();
        }

        private void btn_lich_diemdanh_Click(object sender, EventArgs e)
        {
            if (lbl_lich_buoi.Text == "<trống>")
                MessageBox.Show("Vẫn chưa đến ca làm");
            else
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                cmd = sqlCon.CreateCommand();
                String CAID = "C" + ((int)DateTime.Today.DayOfWeek);
                switch (lbl_lich_buoi.Text)
                {
                    case "Sáng":
                        CAID = CAID + "S";
                        break;

                    case "Chiều":
                        CAID = CAID + "C";
                        break;

                    case "Tối":
                        CAID = CAID + "T";
                        break;
                }
                cmd.CommandText = "SELECT TIEUDE, TRANGTHAI FROM CT_LAMVIEC WHERE NVID = '" + NVID + "' AND CAID = '" + CAID + "'";
                adapter.SelectCommand = cmd;
                DataTable table = new DataTable();
                table.Clear();
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    cmd.CommandText = "SELECT TIEUDE FROM CT_LAMVIEC_HANGTUAN WHERE NVID = '" + NVID + "' AND CAID = '" + CAID + "'";
                    adapter.SelectCommand = cmd;
                    table.Rows.Clear();
                    adapter.Fill(table);
                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("Bạn không có ca làm ngày hôm nay");
                        return;
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO CT_LAMVIEC VALUES('" + NVID + "', '" + CAID + "', '" + DateTime.Today.ToString("MM/dd/yyyy") + "', N'Đã điểm danh', N'Lặp lại', '" + table.Rows[0]["TIEUDE"].ToString() + "')";
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (table.Rows[0]["TRANGTHAI"].ToString() == "Đẫ điểm danh")
                    {
                        MessageBox.Show("Bạn đã điểm danh rồi");
                        return;
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE CT_LAMVIEC SET TRANGTHAI = N'Đã điểm danh' WHERE NVID ='"+NVID+"' AND CAID = '"+CAID+"' AND NGAYLAM = '"+DateTime.Today.ToString("MM/dd/yyyy")+"'";
                        cmd.ExecuteNonQuery();
                    }
                }
                
                MessageBox.Show("Điểm danh thành công");
                sqlCon.Close();
            }
        }

        private void week(DateTime today, ref DateTime finish, ref DateTime begin)
        {
            finish = today;
            while (finish.DayOfWeek != DayOfWeek.Sunday)
            {
                finish = finish.AddDays(1);
            }
            begin = today;
            while (begin.DayOfWeek != DayOfWeek.Monday)
            {
                begin = begin.AddDays(-1);
            }
        }

        private struct caID
        {
            public string TIEUDE;
            public string CAID;
        };
        
        private void load_lich_banglichhangtuan(DateTime today)
        {
            
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT GIO_BD, GIO_NGHI FROM CALAMVIEC ";
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            dgv_lich_tuan.Rows.Clear();
            dgv_lich_tuan.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            dgv_lich_tuan.Rows.Add("Sáng \n(" + table.Rows[0]["GIO_BD"] + " - " + table.Rows[0]["GIO_NGHI"] + ")");
            dgv_lich_tuan.Rows[0].Height = 80;
            dgv_lich_tuan.Rows.Add("Nghỉ trưa \n(" + table.Rows[0]["GIO_NGHI"] + " - " + table.Rows[1]["GIO_BD"] + ")");
            dgv_lich_tuan.Rows[1].Height = 40;
            dgv_lich_tuan.Rows.Add("Chiều \n(" + table.Rows[1]["GIO_BD"] + " - " + table.Rows[1]["GIO_NGHI"] + ")");
            dgv_lich_tuan.Rows[2].Height = 80;
            dgv_lich_tuan.Rows.Add("Tối \n(" + table.Rows[2]["GIO_BD"] + " - " + table.Rows[2]["GIO_NGHI"] + ")");
            dgv_lich_tuan.Rows[3].Height = 80;
            DateTime finish = new DateTime();
            DateTime begin = new DateTime();
            week(today, ref finish, ref begin);
            cmd.CommandText = "SELECT CAID, TIEUDE"
                            + " FROM CT_LAMVIEC"
                            + " WHERE NGAYLAM >='" + begin.ToString("MM/dd/yyyy") + "' AND NGAYLAM <= '" + finish.ToString("MM/dd/yyyy") + "' AND NVID = '" + NVID + "'"
                            + " UNION"
                            + " SELECT CAID, TIEUDE"
                            + " FROM CT_LAMVIEC_HANGTUAN"
                            + " WHERE NVID = '" + NVID + "'";

            var reader = cmd.ExecuteReader();
            List<caID> caid = new List<caID>();
            while (reader.Read())
            {
                caID ca = new caID();
                ca.CAID = reader.GetString(0);
                ca.TIEUDE = reader.GetString(1);
                caid.Add(ca);
            }
            reader.Close();
            for (int i = 0; i < caid.Count; i++)
            {
                string Tieude = caid[i].TIEUDE;
                if(Tieude=="")
                {
                    Tieude = "Không có tiêu đề";
                }    
                if (caid[i].CAID.Substring(1, 1) == "0")
                {
                    switch (caid[i].CAID.Substring(2, 1))
                    {
                        case "S":
                            dgv_lich_tuan.Rows[0].Cells[7].Style.BackColor = Color.White;
                            dgv_lich_tuan.Rows[0].Cells[7].Value = Tieude;
                            break;

                        case "C":
                            dgv_lich_tuan.Rows[2].Cells[7].Style.BackColor = Color.White;
                            dgv_lich_tuan.Rows[2].Cells[7].Value = Tieude;
                            break;

                        case "T":
                            dgv_lich_tuan.Rows[3].Cells[7].Style.BackColor = Color.White;
                            dgv_lich_tuan.Rows[3].Cells[7].Value = Tieude;
                            break;
                    }
                }
                else
                {
                    int temp = Convert.ToInt32(caid[i].CAID.Substring(1, 1));
                    switch (caid[i].CAID.Substring(2, 1))
                    {
                        case "S":
                            dgv_lich_tuan.Rows[0].Cells[temp].Style.BackColor = Color.White;
                            dgv_lich_tuan.Rows[0].Cells[temp].Value = Tieude;
                            break;

                        case "C":
                            dgv_lich_tuan.Rows[2].Cells[temp].Style.BackColor = Color.White;
                            dgv_lich_tuan.Rows[2].Cells[temp].Value = Tieude;
                            break;

                        case "T":
                            dgv_lich_tuan.Rows[3].Cells[temp].Style.BackColor = Color.White;
                            dgv_lich_tuan.Rows[3].Cells[temp].Value = Tieude;
                            break;
                    }
                }
            }
            reader.Close();
            // tô màu cho ngày đã làm và ngày nghỉ
            List<string> CAIDS = new List<string>();
            cmd.CommandText = "SELECT CAID FROM CT_LAMVIEC WHERE NVID ='" + NVID + "' AND TRANGTHAI = N'Đã điểm danh' AND NGAYLAM >='" + begin.ToString("MM/dd/yyyy") + "' AND NGAYLAM <='" + today.ToString("MM/dd/yyyy") + "'";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CAIDS.Add(reader.GetString(0));
            }
            for (int i = 0; i < CAIDS.Count; i++)
            {
                if (CAIDS[i].Substring(1, 1) == "0")
                {
                    switch (CAIDS[i].Substring(2, 1))
                    {
                        case "S":
                            dgv_lich_tuan.Rows[0].Cells[8].Style.BackColor = Color.SpringGreen;
                            break;

                        case "C":
                            dgv_lich_tuan.Rows[2].Cells[8].Style.BackColor = Color.SpringGreen;
                            break;

                        case "T":
                            dgv_lich_tuan.Rows[3].Cells[8].Style.BackColor = Color.SpringGreen;
                            break;
                    }
                }
                else
                {
                    int temp = Convert.ToInt32(CAIDS[i].Substring(1, 1));
                    switch (CAIDS[i].Substring(2, 1))
                    {
                        case "S":
                            dgv_lich_tuan.Rows[0].Cells[temp].Style.BackColor = Color.SpringGreen;
                            break;

                        case "C":
                            dgv_lich_tuan.Rows[2].Cells[temp].Style.BackColor = Color.SpringGreen;
                            break;

                        case "T":
                            dgv_lich_tuan.Rows[3].Cells[temp].Style.BackColor = Color.SpringGreen;
                            break;
                    }
                }
            }
            reader.Close();
            CAIDS.Clear();
            cmd.CommandText = "SELECT CAID FROM CT_LAMVIEC WHERE NVID ='" + NVID + "' AND TRANGTHAI = N'Chưa điểm danh' AND NGAYLAM >='" + begin.ToString("MM/dd/yyyy") + "' AND NGAYLAM <='" + today.ToString("MM/dd/yyyy") + "'";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CAIDS.Add(reader.GetString(0));
            }
            for (int i = 0; i < CAIDS.Count; i++)
            {
                if (CAIDS[i].Substring(1, 1) == "0")
                {
                    switch (CAIDS[i].Substring(2, 1))
                    {
                        case "S":
                            dgv_lich_tuan.Rows[0].Cells[8].Style.BackColor = Color.OrangeRed;
                            break;

                        case "C":
                            dgv_lich_tuan.Rows[2].Cells[8].Style.BackColor = Color.OrangeRed;
                            break;

                        case "T":
                            dgv_lich_tuan.Rows[3].Cells[8].Style.BackColor = Color.OrangeRed;
                            break;
                    }
                }
                else
                {
                    int temp = Convert.ToInt32(CAIDS[i].Substring(1, 1));
                    switch (CAIDS[i].Substring(2, 1))
                    {
                        case "S":
                            dgv_lich_tuan.Rows[0].Cells[temp].Style.BackColor = Color.OrangeRed;
                            break;

                        case "C":
                            dgv_lich_tuan.Rows[2].Cells[temp].Style.BackColor = Color.OrangeRed;
                            break;

                        case "T":
                            dgv_lich_tuan.Rows[3].Cells[temp].Style.BackColor = Color.OrangeRed;
                            break;
                    }
                }
            }
            reader.Close();
            sqlCon.Close();
        }

        private void load_lich_songayDiemDanh()
        {
            // update lại bảng CT_LAMVIEC
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            DateTime i = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            for (; i <= DateTime.Today; i = i.AddDays(1))
            {
                cmd.CommandText = "SELECT NVID, CAID, TIEUDE FROM CT_LAMVIEC_HANGTUAN WHERE NVID = '" + NVID + "'AND SUBSTRING(CAID,2,1) = '" + ((int)i.DayOfWeek) + "'"
                                + " EXCEPT"
                                + " SELECT NVID, CAID, TIEUDE FROM CT_LAMVIEC WHERE NVID='" + NVID + "' AND NGAYLAM = '" + i.ToString("MM/dd/yyyy") + "'";
                DataTable table = new DataTable();
                table.Clear();
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    try
                    {
                        if (caid == table.Rows[j]["CAID"].ToString() && i == DateTime.Today)
                        {
                            cmd.CommandText = "INSERT INTO CT_LAMVIEC VALUES('" + NVID + "', '" + table.Rows[j]["CAID"] + "', '" + i.ToString("MM/dd/yyyy") + "', N'Trống',N'Lặp lại',N'" + table.Rows[j]["TIEUDE"] + "')";
                            cmd.ExecuteNonQuery();
                            break;

                        }
                        else
                        {
                            cmd.CommandText = "INSERT INTO CT_LAMVIEC VALUES('" + NVID + "', '" + table.Rows[j]["CAID"] + "', '" + i.ToString("MM/dd/yyyy") + "', N'Chưa điểm danh',N'Lặp lại',N'" + table.Rows[j]["TIEUDE"] + "')";
                            cmd.ExecuteNonQuery();
                        }


                    }
                    catch (Exception) { }
                }
            }
            cmd.CommandText = "SELECT COUNT(*) FROM CT_LAMVIEC WHERE NVID ='" + NVID + "' AND TRANGTHAI = N'Đã điểm danh' AND MONTH(NGAYLAM) =" + DateTime.Today.Month;
            txt_ngaylam.Text = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "SELECT COUNT(*) FROM CT_LAMVIEC WHERE NVID ='" + NVID + "' AND TRANGTHAI = N'Chưa điểm danh' AND MONTH(NGAYLAM) =" + DateTime.Today.Month;
            txt_ngaynghi.Text = cmd.ExecuteScalar().ToString();
            if(caid != "")
            {
                cmd.CommandText = "SELECT TRANGTHAI FROM CT_LAMVIEC WHERE NVID ='" + NVID + "' AND CAID = '" + caid + "' AND NGAYLAM = '" + DateTime.Today.ToString("MM/dd/yyyy") + "'";

                lbl_lich_TT.Text = cmd.ExecuteScalar().ToString();
                if (lbl_lich_TT.Text == "Trống")
                    lbl_lich_TT.Text = "Chưa điểm danh";
            }
        



            sqlCon.Close();
        }

        private void load_lich()
        {
            load_lich_calamHienTai();
            load_lich_songayDiemDanh();
            load_lich_banglichhangtuan(DateTime.Today);
            
        }

        private void btn_lich_xemCT_Click(object sender, EventArgs e)
        {
            Form_NV_chamcong frm = new Form_NV_chamcong(NVID);
            frm.ShowDialog();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            load_lich_banglichhangtuan((sender as MonthCalendar).SelectionStart.Date);
        }
    }
}