using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_ThemSuaHangHoa : Form
    {
        public string LoaiID;
        public string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        public SqlConnection sqlCon = null;
        public static SqlDataAdapter adapter = null;
        private static int ModeHH = 0;

        public Form_ThemSuaHangHoa(int n)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            ModeHH = n;
            this.Text = "Thêm hàng hoá";
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            adapter = new SqlDataAdapter("select TENLOAI from [LOAISP] group by TENLOAI", sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cbLoaiSP.DataSource = table;
            cbLoaiSP.DisplayMember = "TenLoai";
            cbLoaiSP.ValueMember = "TenLoai";
            txtSPID.Text = "Chọn lại loại sản phẩm";
            sqlCon.Close();
            ptrbHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            ptrbHinhAnh.Image = Image.FromFile(@"..\..\HangHoa\" + "No Image" + ".jpg");
        }

        public Form_ThemSuaHangHoa(int n, string SPID, string TenSP, string NuocSX, string HangSX, string GiaBan, string GiaNhap, string SLTT, string DVT, string LoaiSP, string MoTa)
        {
            InitializeComponent();
            ModeHH = n;
            txtSPID.Text = SPID;
            txtTenSP.Text = TenSP;
            txtNuocSX.Text = NuocSX;
            txtHang.Text = HangSX;
            txtGiaBan.Text = GiaBan;
            txtSLTT.Text = SLTT;
            txtGiaNhap.Text = GiaNhap;
            txtDVT.Text = DVT;
            cbLoaiSP.Text = LoaiSP;
            txtMoTa.Text = MoTa;
            if (ModeHH == 2)
                txtSPID.ReadOnly = true;
            this.Text = "Sửa hàng hoá";
            Image img = GetCopyImage(@"..\..\HangHoa\" + txtSPID.Text + ".jpg");
            File.Delete(@"..\..\HangHoa\" + txtSPID.Text + ".jpg");
            ptrbHinhAnh.Image = img;
            ptrbHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private Image GetCopyImage(string path)
        {
            try
            {
                using (Image image = Image.FromFile(path))
                {
                    Bitmap bitmap = new Bitmap(image);
                    return bitmap;
                }
            }
            catch
            {
                using (Image image = Image.FromFile(@"..\..\HangHoa\No image.jpg"))
                {
                    Bitmap bitmap = new Bitmap(image);
                    return bitmap;
                }
            }
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(strCon);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "select LOAIID from LOAISP where TENLOAI = N'" + cbLoaiSP.Text + "'";
            sqlCon = new SqlConnection(strCon);
            sqlCmd.Connection = sqlCon;

            if (ModeHH == 1)
            {
                if (txtSPID.Text == string.Empty || txtTenSP.Text == string.Empty || txtNuocSX.Text == string.Empty || txtHang.Text == string.Empty || txtGiaNhap.Text == string.Empty || txtGiaBan.Text == string.Empty || txtDVT.Text == string.Empty)
                {
                    MessageBox.Show("Cần nhập đầy đủ thông tin");
                    return;
                }
                else
                {
                    try
                    {
                        sqlCon.Open();
                        string strquery = "insert into SANPHAM values('" + txtSPID.Text + "',N'" + txtTenSP.Text + "',N'" + LoaiID + "',N'" + txtHang.Text + "',N'" + txtNuocSX.Text + "'," + txtGiaBan.Text + "," + txtGiaNhap.Text
                            + ",N'" + txtDVT.Text + "'," + 0 + "," + txtSLTT.Text + ",N'" + txtMoTa.Text + "')";
                        sqlCmd = new SqlCommand(strquery, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();
                        ptrbHinhAnh.Image.Save(@"..\..\HangHoa\" + txtSPID.Text + ".jpg");
                        MessageBox.Show("Thêm thành công");
                        this.Close();
                    }
                    catch (Exception) {
                        MessageBox.Show("Thông tin không hợp lệ");
                    }
                }
            }
            else if (ModeHH == 2)
            {
                if (txtSPID.Text == string.Empty || txtTenSP.Text == string.Empty || txtNuocSX.Text == string.Empty || txtHang.Text == string.Empty || txtGiaNhap.Text == string.Empty || txtGiaBan.Text == string.Empty || txtDVT.Text == string.Empty)
                {
                    MessageBox.Show("Cần nhập đầy đủ thông tin");
                    return;
                }
                else
                {
                    sqlCon.Open();
                    string strquery = "update SANPHAM set TENSP=N'" + txtTenSP.Text + "',HANGSX='" + txtHang.Text + "',NUOCSX=N'" + txtNuocSX.Text + "',GIANHAP=" + txtGiaNhap.Text.Replace(",", string.Empty) + ",GIABAN=" + txtGiaBan.Text.Replace(",", string.Empty)
                        + ",DVT=N'" + txtDVT.Text + "',SOLUONG=" + 0 + ",SLTT=" + txtSLTT.Text + ",MOTA=N'" + txtMoTa.Text + "'WHERE SPID='" + txtSPID.Text + "'";
                    sqlCmd = new SqlCommand(strquery, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                    ptrbHinhAnh.Image.Save(@"..\..\HangHoa\" + txtSPID.Text + ".jpg");
                    MessageBox.Show("Sửa thành công");
                    this.Close();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (ModeHH == 2)
            { ptrbHinhAnh.Image.Save(@"..\..\HangHoa\" + txtSPID.Text + ".jpg"); }
            this.Close();
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "select LOAIID from LOAISP where TENLOAI = N'" + cbLoaiSP.Text + "'";
            sqlCon = new SqlConnection(strCon);
            sqlCmd.Connection = sqlCon;
            SqlDataAdapter adapter2 = new SqlDataAdapter(sqlCmd);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter2);
            DataTable tbHH = new DataTable();
            tbHH.Clear();
            adapter2.Fill(tbHH);
            LoaiID = tbHH.Rows[0]["LOAIID"].ToString();
            OpenFileDialog open = new OpenFileDialog();
            DialogResult result = open.ShowDialog();
            open.Filter = " Image file (*.BMP,*.JPG,*.JPEG)|*.bmp;*.jpg;*.jpeg ";
            if (result == DialogResult.OK)
            {
                ptrbHinhAnh.Image = Image.FromFile(open.FileName);
            }
            else MessageBox.Show("Chưa chọn hình");
        }

        private void cbLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoaiSP.Text != "Chọn Loại" && cbLoaiSP.Text != "System.Data.DataRowView")
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = "select LOAIID from LOAISP where TENLOAI = N'" + cbLoaiSP.Text + "'";
                sqlCon = new SqlConnection(strCon);
                sqlCmd.Connection = sqlCon;
                SqlDataAdapter adapter2 = new SqlDataAdapter(sqlCmd);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter2);
                DataTable tbHH = new DataTable();
                tbHH.Clear();
                adapter2.Fill(tbHH);
                LoaiID = tbHH.Rows[0]["LOAIID"].ToString();
                txtSPID.Text = LoaiID;
            }
        }

        private void Form_ThemSuaHangHoa_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ModeHH == 2)
            { ptrbHinhAnh.Image.Save(@"..\..\HangHoa\" + txtSPID.Text + ".jpg"); }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (Char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số");
            }
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (Char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số");
            }
        }

        private void txtSLTT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (Char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số");
            }
        }
    }
}