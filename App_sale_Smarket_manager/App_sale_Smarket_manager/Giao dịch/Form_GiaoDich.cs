using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace App_sale_manager
{
    public partial class Form_GiaoDich : Form
    {
        private string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        private SqlConnection sqlCon;
        private SqlCommand cmd;
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataTable table;
        private DataTable Table_GiamGia;
        List<HanghoaGD> hanghoas = new List<HanghoaGD>();

        bool flag = false;
        public Form_GiaoDich()
        {
            InitializeComponent();
            this.Size = new Size(1250, 770);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        public Form_GiaoDich(string Manv)
        {
            InitializeComponent();
            this.Size = new Size(1250, 790);
            flowLayoutPanel1.Hide();
            Box_IDNV.Text = Manv;

            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            cmd = sqlCon.CreateCommand();

            table = new DataTable();
            cmd.CommandText = "select * from HDBH";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            Box_IDHD.Text = "#" + Convert.ToString(table.Rows.Count + 1);
            cmd.CommandText = "insert into HDBH values ('"+Box_IDHD.Text+"',' ',' ','"+Box_IDNV.Text+"',' ',N' ',N' ') ";
            cmd.ExecuteNonQuery();
            table = new DataTable();
            cmd.CommandText = "Select KHID,HOTEN from KHACHHANG";
            adapter.SelectCommand = cmd;
            table.Clear();
            if (adapter != null)
            {
                adapter.Fill(table);
                DGV_LuaChon.DataSource = table;
                foreach (DataGridViewRow i in DGV_LuaChon.Rows)
                {
                    if (i.Cells[0].Value != null)
                    {
                        Box_IDKH.Items.Add(i.Cells[0].Value);
                        Box_TenKH.Items.Add(i.Cells[1].Value);
                    }
                }
            }

            cmd.CommandText = "Select SPID, TENSP ,REPLACE(CONVERT(varchar(20), GIABAN, 1), '.00','') as TIEN, SOLUONG from SANPHAM";
            adapter.SelectCommand = cmd;
            table = new DataTable();
            adapter.Fill(table);
            DGV_LuaChon.DataSource = table;
            DGV_LuaChon.Columns[0].HeaderText = "Mã sản phẩm";
            DGV_LuaChon.Columns[1].HeaderText = "Tên sản phẩm";
            DGV_LuaChon.Columns[2].HeaderText = "Giá (VND)";
            DGV_LuaChon.Columns[3].Visible = false;
            hanghoas.Clear();
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Panel panel = new Panel();
                panel.Size = new Size(284, 139);
                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new Size(133, 132);
                pictureBox.Location = new Point(4, 4);
                //pictureBox.Image = Image.FromFile(@"..\..\HangHoa\" + table.Rows[i]["SPID"] + ".jpg");

                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                
                Label Tien = new Label();
                Tien.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
                Tien.ForeColor = Color.Blue;
                Tien.Text = table.Rows[i]["TIEN"].ToString();
                Tien.Location = new Point(143, 36);
                Label Ten = new Label();
                Ten.Text = chenlable(table.Rows[i]["TENSP"].ToString());
                Ten.Location = new Point(145, 65);
                panel.Controls.Add(pictureBox);
                panel.Controls.Add(Tien);
                panel.Controls.Add(Ten);

                HanghoaGD hanghoa = new HanghoaGD(panel, pictureBox, Tien, Ten, table.Rows[i]["SPID"].ToString(), table.Rows[i]["TENSP"].ToString(), table.Rows[i]["SOLUONG"].ToString());
                hanghoa.Click += button1_Click;
                hanghoa.Click2 += click;
                hanghoas.Add(hanghoa);
                flowLayoutPanel1.Controls.Add(panel);
            }
            Box_LoaiHD.Text = "Đơn trực tiếp";
            Box_TrangThai.Text = "Hoàn thành";
            Table_GiamGia = new DataTable();
            cmd.CommandText = "Select * from KHUYENMAI WHERE NGAYKT > '" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "' ";
            adapter.SelectCommand = cmd;
            Table_GiamGia.Clear();
            if (adapter != null)
            {
                adapter.Fill(Table_GiamGia);
                foreach (DataRow i in Table_GiamGia.Rows)
                {
                    Box_TenUuDai.Items.Add(i.ItemArray[0]);
                }
            }
            Box_TenUuDai.Items.Add("<Trống>");
        }
        private void click(object sender, EventArgs e)
        {
            Point position = new Point();
            position.X = this.Location.X + panel2.Location.X + flowLayoutPanel1.Location.X + (sender as HanghoaGD).panel.Location.X;
            position.Y = this.Location.Y + panel2.Location.Y + flowLayoutPanel1.Location.Y + (sender as HanghoaGD).panel.Location.Y;
            SL sl = new SL();
            sl.Location = position;
            sl.NhapSL += (sender as HanghoaGD).NhapSL;
            sl.ShowDialog();

        }
        string chenlable(string Ten)
        {
            string chuoi = Ten;
            for(int i = 1; (i * 18) < Ten.Length; i++)
            {
                if(i==4)
                {
                    chuoi.Substring(0, i * 18 - 4);
                    chuoi = chuoi + "...";
                }  
                else chuoi = chuoi.Insert(i * 18, "\n");
            }
            return chuoi;
        }
        private void CT_HD_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Update_Tong();
        }


        public void reset_DGV_luachon()
        {
            cmd.CommandText = "Select SPID, TENSP ,REPLACE(CONVERT(varchar(20), GIABAN, 1), '.00','') as TIEN, SOLUONG from SANPHAM";
            adapter.SelectCommand = cmd;
            table = new DataTable();
            adapter.Fill(table);
            DGV_LuaChon.DataSource = table;
            DGV_LuaChon.Columns[0].HeaderText = "Mã sản phẩm";
            DGV_LuaChon.Columns[1].HeaderText = "Tên sản phẩm";
            DGV_LuaChon.Columns[2].HeaderText = "Giá (VND)";
            DGV_LuaChon.Columns[3].Visible = false;
        }

        public void Update_Tong()
        {
            Double sum = 0;
            foreach (DataGridViewRow i in CT_HD.Rows)
            {
                if (i.Cells[2].Value != null)
                    sum += Convert.ToDouble(Convert.ToDouble(i.Cells[3].Value) * Convert.ToDouble(i.Cells[2].Value.ToString().Replace(",", string.Empty)));
            }
            Box_Tong.Text = String.Format("{0:0,0}", sum);
            Gia_Giam();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(rbtndanhsach.Checked==true)
            {
                if (DGV_LuaChon.CurrentRow != null)
                {
                    foreach (DataGridViewRow temp in CT_HD.Rows)
                    {
                        if (Convert.ToDouble(DGV_LuaChon.CurrentRow.Cells[3].Value) >= Convert.ToDouble(numericUpDown1.Value))
                        {
                            DGV_LuaChon.CurrentRow.Cells[3].Value = Convert.ToString(Convert.ToDouble(DGV_LuaChon.CurrentRow.Cells[3].Value) - Convert.ToDouble(numericUpDown1.Value));
                            cmd.CommandText = "  UPDATE SANPHAM SET SOLUONG = " + DGV_LuaChon.CurrentRow.Cells[3].Value + " WHERE SPID = '" + DGV_LuaChon.CurrentRow.Cells[0].Value + "'";
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("Cảnh báo : Không đủ số lượng hàng trong kho");
                            return;
                        }
                        if (DGV_LuaChon.CurrentRow.Cells[0].Value == temp.Cells[0].Value)
                        {
                            temp.Cells[3].Value = numericUpDown1.Value + Convert.ToInt32(temp.Cells[3].Value);
                            Update_Tong();
                            return;
                        }
                    }
                    DataGridViewRow row = (DataGridViewRow)CT_HD.Rows[0].Clone();
                    row.Cells[0].Value = DGV_LuaChon.CurrentRow.Cells[0].Value;
                    row.Cells[1].Value = DGV_LuaChon.CurrentRow.Cells[1].Value;
                    row.Cells[2].Value = DGV_LuaChon.CurrentRow.Cells[2].Value;
                    row.Cells[3].Value = numericUpDown1.Value;
                    CT_HD.Rows.Add(row);
                }
                else
                    MessageBox.Show("Phai lua chon san pham truoc");
            }
            else
            {
                cmd.CommandText = "  UPDATE SANPHAM SET SOLUONG = " + (sender as HanghoaGD).Soluong + " WHERE SPID = '" + (sender as HanghoaGD).IDSP + "'";
                cmd.ExecuteNonQuery();
           
              
                DataGridViewRow row = (DataGridViewRow)CT_HD.Rows[0].Clone();
                row.Cells[0].Value = (sender as HanghoaGD).IDSP;
                row.Cells[1].Value = (sender as HanghoaGD).TenSP;
                row.Cells[2].Value = (sender as HanghoaGD).Tien.Text;
                row.Cells[3].Value = (sender as HanghoaGD).SLchon;

                foreach (DataGridViewRow temp in CT_HD.Rows)
                {
                    if (row.Cells[0].Value == temp.Cells[0].Value)
                    {
                        temp.Cells[3].Value = numericUpDown1.Value + Convert.ToInt32(temp.Cells[3].Value);
                        Update_Tong();
                        return;
                    }
                }

                CT_HD.Rows.Add(row);
            } 
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            table = new DataTable();
            cmd.CommandText = "Select SPID, TENSP ,REPLACE(CONVERT(varchar(20), GIABAN, 1), '.00','') as TIEN, SOLUONG from SANPHAM WHERE (SPID like '%" + Box_MASP.Text + "%' and TENSP like '%" + Box_TenSP.Text + "%')";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            if(rbtndanhsach.Checked ==true)
            {
                DGV_LuaChon.DataSource = table;
                DGV_LuaChon.Columns[0].HeaderText = "Mã sản phẩm";
                DGV_LuaChon.Columns[1].HeaderText = "Tên sản phẩm";
                DGV_LuaChon.Columns[2].HeaderText = "Giá (VND)";
                DGV_LuaChon.Columns[3].Visible = false;
            }
            else
            {
                hanghoas.Clear();
                flowLayoutPanel1.Controls.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Panel panel = new Panel();
                    panel.Size = new Size(284, 139);
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Size = new Size(133, 132);
                    pictureBox.Location = new Point(4, 4);
                    pictureBox.Image = Image.FromFile(@"..\..\HangHoa\" + table.Rows[i]["SPID"] + ".jpg");
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    Label Tien = new Label();
                    Tien.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
                    Tien.ForeColor = Color.Blue;
                    Tien.Text = table.Rows[i]["TIEN"].ToString();
                    Tien.Location = new Point(143, 36);
                    Label Ten = new Label();
                    Ten.Text = chenlable(table.Rows[i]["TENSP"].ToString());
                    Ten.Location = new Point(145, 65);
                    panel.Controls.Add(pictureBox);
                    panel.Controls.Add(Tien);
                    panel.Controls.Add(Ten);
                    
                    HanghoaGD hanghoa = new HanghoaGD(panel, pictureBox, Tien, Ten, table.Rows[i]["SPID"].ToString(), table.Rows[i]["TENSP"].ToString(), table.Rows[i]["SOLUONG"].ToString());
                    hanghoa.Click += button1_Click;
                    hanghoa.Click2 += click;
                    hanghoas.Add(hanghoa);
                    flowLayoutPanel1.Controls.Add(panel);
                }
            } 
                
        }

        private void bnt_xoaSP_Click(object sender, EventArgs e)
        {
            if(rbtndanhsach.Checked==true)
            {
                try
                {
                    for (int i = 0; i < DGV_LuaChon.RowCount - 1; i++)
                        if (DGV_LuaChon.Rows[i].Cells[0].Value == CT_HD.CurrentRow.Cells[0].Value)
                        {
                            DGV_LuaChon.Rows[i].Cells[3].Value = Convert.ToString(Convert.ToDouble(DGV_LuaChon.Rows[i].Cells[3].Value) + Convert.ToDouble(CT_HD.CurrentRow.Cells[3].Value));
                            cmd.CommandText = "  UPDATE SANPHAM SET SOLUONG = " + DGV_LuaChon.Rows[i].Cells[3].Value + " WHERE SPID = '" + DGV_LuaChon.Rows[i].Cells[0].Value + "'";
                            cmd.ExecuteNonQuery();
                            CT_HD.Rows.Remove(CT_HD.CurrentRow);
                            return;
                        }
                    cmd.CommandText = "  UPDATE SANPHAM SET SOLUONG = SOLUONG + " + CT_HD.CurrentRow.Cells[3].Value + " WHERE SPID = '" + CT_HD.CurrentRow.Cells[0].Value + "'";
                    CT_HD.Rows.Remove(CT_HD.CurrentRow);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Khong co san pham nao");
                }
            }
            else
            {
                try
                {
                    for (int i = 0; i < hanghoas.Count; i++)
                        if (hanghoas[i].IDSP == CT_HD.CurrentRow.Cells[0].Value.ToString())
                        {
                            hanghoas[i].Soluong = Convert.ToString(Convert.ToDouble(hanghoas[i].Soluong) + Convert.ToDouble(CT_HD.CurrentRow.Cells[3].Value.ToString()));
                            cmd.CommandText = "  UPDATE SANPHAM SET SOLUONG = SOLUONG + " + CT_HD.CurrentRow.Cells[3].Value + " WHERE SPID = '" + CT_HD.CurrentRow.Cells[0].Value + "'";
                            cmd.ExecuteNonQuery();
                            CT_HD.Rows.Remove(CT_HD.CurrentRow);
                            return;
                        }
                    cmd.CommandText = "  UPDATE SANPHAM SET SOLUONG = SOLUONG + " + CT_HD.CurrentRow.Cells[3].Value + " WHERE SPID = '" + CT_HD.CurrentRow.Cells[0].Value + "'";
                    cmd.ExecuteNonQuery();
                    CT_HD.Rows.Remove(CT_HD.CurrentRow);
                }
                catch (Exception)
                {
                    MessageBox.Show("Khong co san pham nao");
                }
            } 
                
        }

        private void CT_HD_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Update_Tong();
        }

        private void bnt_tao_Click(object sender, EventArgs e)
        {

            if (CT_HD.RowCount < 2)
            {
                MessageBox.Show("Khong co san pham nao trong gio hang");
                return;
            }

            if (Box_LoaiHD.Text == "" || Box_TrangThai.Text == "")
            {
                MessageBox.Show("vui long nhap day du du lieu");
                return;
            }
            string x = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            cmd.CommandText = "set dateformat dmy";
            adapter.SelectCommand = cmd;
            //try
            //{
            cmd.CommandText = "update HDBH SET NGHD = '"+x+"',KHID ='" + Box_IDKH.Text + "',TRIGIA='" + Box_GiaDaGiam.Text.Replace(".", string.Empty) + "',LOAIHD= N'" + Box_LoaiHD.Text + "',TRANGTHAI=N'" + Box_TrangThai.Text + "' WHERE SOHD_BH='" + Box_IDHD.Text + "' ";
            cmd.ExecuteNonQuery();
            foreach (DataGridViewRow i in CT_HD.Rows)
            {
                if (i.Index == CT_HD.RowCount - 1)
                {
                    break;
                }

                cmd.CommandText = "insert into CTHDBH values ('" + Box_IDHD.Text + "','" + i.Cells[0].Value + "','" + i.Cells[3].Value + "')";
                cmd.ExecuteNonQuery();
            }
            if (Box_LoaiHD.SelectedItem.ToString() == "Đơn trực tiếp")
            {
                DialogResult dialogResult = MessageBox.Show("In hóa đơn không ?", "Yes/No ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Form_CTHD cthd = new Form_CTHD(Box_IDHD.Text, Box_IDKH.Text, Box_IDNV.Text, Box_LoaiHD.Text, Box_TrangThai.Text, Box_GiaDaGiam.Text);
                    cthd.ShowDialog();
                }
            }
            //}
            //catch (SqlException)
            //{
            //    this.Close();
            //}
            flag = true;
            this.Close();
        }

        private void DGV_LuaChon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.button1_Click(sender, e);
        }

        private void CT_HD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.bnt_xoaSP_Click(sender, e);
        }

        private void Box_LoaiHD_TextChanged(object sender, EventArgs e)
        {
            if (Box_LoaiHD.Text == "Đơn trực tiếp")
            {
                Box_TrangThai.Text = "Hoàn thành";
            }
            else
            {
                Box_TrangThai.Text = "Nhận đơn";
            }
        }

        private void Box_IDKH_TextChanged(object sender, EventArgs e)
        {
            table = new DataTable();
            cmd.CommandText = "Select KHID from KHACHHANG WHERE (KHID like '%" + Box_IDKH.Text + "%')";
            adapter.SelectCommand = cmd;
            table.Clear();
            if (adapter != null)
            {
                adapter.Fill(table);
                foreach (DataRow i in table.Rows)
                {
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox1_TextChanged(sender, e);
        }

        private void Box_IDKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            Box_TenKH.SelectedIndex = Box_IDKH.SelectedIndex;
        }

        private void Box_TenKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            Box_IDKH.SelectedIndex = Box_TenKH.SelectedIndex;
        }

        private void DGV_LuaChon_SelectionChanged(object sender, EventArgs e)
        {
            if (DGV_LuaChon.CurrentRow == null)
                return;

            try
            {
                Bitmap bmp = new Bitmap(Image.FromFile(@"..\..\HangHoa\" + DGV_LuaChon.CurrentRow.Cells[0].Value + ".jpg"));
                PTX_SanPham.Image = bmp;
                PTX_SanPham.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception)
            {
                PTX_SanPham.Image = Image.FromFile(@"..\..\HangHoa\No Image.jpg");
                PTX_SanPham.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void Box_TenUuDai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Box_TenUuDai.Text == "<Trống>")
            {
                Box_DoiTuong.Text = "";
                Box_Giam.Text = "";
                Box_QuaTang.Text = "";
                Label_Loai.Text = " ";
                Box_SP.Text = "";
            }
            else
            {
                Box_DoiTuong.Text = Table_GiamGia.Rows[Box_TenUuDai.SelectedIndex].ItemArray[1].ToString();
                Box_QuaTang.Text = Table_GiamGia.Rows[Box_TenUuDai.SelectedIndex].ItemArray[7].ToString();
                Box_Giam.Text = Table_GiamGia.Rows[Box_TenUuDai.SelectedIndex].ItemArray[10].ToString();
                Box_SP.Text = Table_GiamGia.Rows[Box_TenUuDai.SelectedIndex].ItemArray[4].ToString();
                if (Table_GiamGia.Rows[Box_TenUuDai.SelectedIndex].ItemArray[9].ToString() == "Giảm theo phần trăm")
                {
                    Label_Loai.Text = "%";
                }
                else
                {
                    Label_Loai.Text = "VNĐ";
                }
            }
            if (Box_QuaTang.Text == string.Empty)
                Box_QuaTang.Enabled = false;
            else
                Box_QuaTang.Enabled = true;

            if (Box_Giam.Text == string.Empty)
                Box_Giam.Enabled = false;
            else
                Box_Giam.Enabled = true;
            if (Box_DoiTuong.Text == string.Empty)
                Box_DoiTuong.Enabled = false;
            else
                Box_DoiTuong.Enabled = true;
            if (Box_SP.Text == string.Empty)
            {
                Box_SP.Enabled = false;
            }
            else
            {
                Box_SP.Enabled = true;
            }

            Gia_Giam();
        }

        private void Gia_Giam()
        {
            Box_GiaDaGiam.Text = Box_Tong.Text;

            if (Box_SP.Text == string.Empty)
                return;

            //neu giam gia theo mat hang la mat hang
            if (Table_GiamGia.Rows[Box_TenUuDai.SelectedIndex].ItemArray[3].ToString() == "Mặt hàng")
            {
              
                string x = Table_GiamGia.Rows[Box_TenUuDai.SelectedIndex].ItemArray[4].ToString();
         
                for (int i = 0; i < CT_HD.RowCount - 1; i++)
                {
                    if (CT_HD.Rows[i].Cells[0].Value.ToString().Contains(x))
                    {
                        //kiem tra dieu kien giam gia
                        if (Table_GiamGia.Rows[Box_TenUuDai.SelectedIndex].ItemArray[14].ToString() == "1")
                        {
                            if ( Convert.ToInt32( CT_HD.Rows[i].Cells[3].Value) < Convert.ToInt32(Table_GiamGia.Rows[Box_TenUuDai.SelectedIndex].ItemArray[11]) || Convert.ToDouble(Box_Tong.Text) < Convert.ToDouble(Table_GiamGia.Rows[Box_TenUuDai.SelectedIndex].ItemArray[12].ToString()))
                            {
                                return;
                            }
                        }
                        if (Label_Loai.Text == "%")
                        {
                            Box_GiaDaGiam.Text = Convert.ToString(Convert.ToDouble(Box_GiaDaGiam.Text.Replace(",", string.Empty)) - Convert.ToDouble(CT_HD.Rows[i].Cells[2].Value.ToString().Replace(",", string.Empty)) * Convert.ToDouble(CT_HD.Rows[i].Cells[3].Value.ToString()) * Convert.ToDouble(Box_Giam.Text) / 100 );
                            Box_GiaDaGiam.Text = String.Format("{0:0,0}", Convert.ToDouble(Box_GiaDaGiam.Text));
                        }
                        else
                        {
                            Box_GiaDaGiam.Text = Convert.ToString(Convert.ToDouble(Box_GiaDaGiam.Text.Replace(",", string.Empty)) - Convert.ToDouble(Box_Giam.Text) * Convert.ToDouble(CT_HD.Rows[i].Cells[3].Value.ToString()));
                            Box_GiaDaGiam.Text = String.Format("{0:0,0}", Convert.ToDouble(Box_GiaDaGiam.Text));
                        }
                    }
                }
            }
            //giam theo nha sx
            if (Table_GiamGia.Rows[Box_TenUuDai.SelectedIndex].ItemArray[3].ToString() == "Nhà cung cấp")
            {
                for (int i = 0; i < CT_HD.RowCount - 1; i++)
                {
                    cmd.CommandText = "select * FROM SANPHAM WHERE SPID = '" + CT_HD.Rows[i].Cells[0].Value.ToString() + "' AND HANGSX = '"+Box_SP.Text+"' ";
                    adapter.SelectCommand = cmd;
                    DataTable selectdatatabletemp = new DataTable();
                    adapter.Fill(selectdatatabletemp);
                    if (selectdatatabletemp.Rows.Count > 0)
                    {
                        //kiem tra dieu kien giam gia
                        if (Table_GiamGia.Rows[Box_TenUuDai.SelectedIndex].ItemArray[14].ToString() == "1")
                        {
                            if (Convert.ToInt32(CT_HD.Rows[i].Cells[3].Value) < Convert.ToInt32(Table_GiamGia.Rows[Box_TenUuDai.SelectedIndex].ItemArray[11]) || Convert.ToDouble(Box_Tong.Text) < Convert.ToDouble(Table_GiamGia.Rows[Box_TenUuDai.SelectedIndex].ItemArray[12].ToString()))
                            {
                                return;
                            }
                        }
                        //giam gia
                        if (Label_Loai.Text == "%")
                        {
                            Box_GiaDaGiam.Text = Convert.ToString(Convert.ToDouble(Box_GiaDaGiam.Text) - Convert.ToDouble(CT_HD.Rows[i].Cells[2].Value) * Convert.ToDouble(Box_Giam.Text) / 100 * Convert.ToDouble(CT_HD.Rows[i].Cells[3].Value));
                            Box_GiaDaGiam.Text = String.Format("{0:0,0}", Convert.ToDouble(Box_GiaDaGiam.Text));
                        }
                        else
                        {
                            Box_GiaDaGiam.Text = Convert.ToString(Convert.ToDouble(Box_GiaDaGiam.Text) - Convert.ToDouble(Box_Giam.Text) * Convert.ToDouble(CT_HD.Rows[i].Cells[3].Value.ToString()));
                            Box_GiaDaGiam.Text = String.Format("{0:0,0}", Convert.ToDouble(Box_GiaDaGiam.Text));
                        }
                    }
                }
            }
        }

        private void Box_LoaiHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Box_LoaiHD.SelectedIndex == 0)
                Box_TrangThai.SelectedIndex = 0;
            else
                Box_TrangThai.SelectedIndex = 1;
        }

        private void Form_GiaoDich_FormClosing(object sender, FormClosingEventArgs e)
        {

            

            if (flag == false)
            {
                cmd.CommandText = "delete  HDBH WHERE SOHD_BH ='" + Box_IDHD.Text + "'";
                cmd.ExecuteNonQuery();

                foreach (DataGridViewRow i in CT_HD.Rows)
                {
                    try
                    {
                        cmd.CommandText = "  UPDATE SANPHAM SET SOLUONG = SOLUONG + " + i.Cells[3].Value + " WHERE SPID = '" + i.Cells[0].Value + "'";
                        CT_HD.Rows.Remove(CT_HD.CurrentRow);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        return;                  
                    }
                }
            }


        }

        private void rbtndanhsach_CheckedChanged(object sender, EventArgs e)
        {
            this.reset_DGV_luachon();
            if((sender as RadioButton).Checked == true)
            {
                flowLayoutPanel1.Hide();
                textBox1_TextChanged(this, e);
            }    
        }

        private void rbtnHinhanh_CheckedChanged(object sender, EventArgs e)
        {
            this.reset_DGV_luachon();
            if((sender as RadioButton).Checked == true)
            {
                flowLayoutPanel1.Show();
                textBox1_TextChanged(this, e);
            }    
        }
    }
}