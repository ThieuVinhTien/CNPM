using System.Drawing;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_ChiTietHH : Form
    {
        public Form_ChiTietHH()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        public Form_ChiTietHH(string SPID, string TenSP, string SL, string NuocSX, string Hang, string GiaBan, string GiaNhap, string DVT, string SLTT, string LoaiSP, string MoTa)
        {
            InitializeComponent();
            txtNDMaSP.Text = SPID;
            txtNDTenSP.Text = TenSP;
            txtNDSoLuong.Text = SL;
            txtNDNuocSX.Text = NuocSX;
            txtNDHang.Text = Hang;
            txtNDGiaBan.Text = GiaNhap;
            txtNDGiaNhap.Text = GiaBan;
            txtNDDVT.Text = DVT;
            txtNDSLToiThieu.Text = SLTT;
            txtNDLoaiID.Text = LoaiSP;
            txtNDMoTa.Text = MoTa;
            Image img = GetCopyImage(@"..\..\HangHoa\" + txtNDMaSP.Text + ".jpg");
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

        private void Form_ChiTietHH_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}