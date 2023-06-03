using System;
using System.Drawing;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_selectphoto_nv : System.Windows.Forms.Form
    {
        private string FILEPATH;
        private string NVID;
        private string HOTEN;
        
        //form được gọi từ Form_main_admin thì có gia trị 1, Form_main_NV là 0
        public int Isnv = 0;
        public string filepath
        {
            set { FILEPATH = value; }
        }

        public string nvid
        {
            set { NVID = value; }
        }

        public string hoten
        {
            set { HOTEN = value; }
        }

        public Form_selectphoto_nv(string filePath, string nvid, string hoten)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.FILEPATH = filePath;
            this.NVID = nvid;
            this.HOTEN = hoten;
        }

        public Form_selectphoto_nv(string filePath)
        {
            InitializeComponent();
            this.FILEPATH = filePath;
        }

        public event EventHandler Thoat;

        public void Form_selectphoto_nv_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }

        public void SaveBitmap()
        {
            panel1.Dock = DockStyle.None;
            Bitmap bmp1 = new Bitmap(panel1.Width - SystemInformation.VerticalScrollBarWidth, panel1.Height - SystemInformation.VerticalScrollBarWidth);

            this.panel1.DrawToBitmap(bmp1, new Rectangle(0, 0, this.panel1.Width, this.panel1.Height));

            if (Isnv == 1)
            {
                bmp1.Save(@"Image samples for testing\NV\" + NVID + ".jpg");
            }
            else if (Isnv == 0)
            {
                bmp1.Save(@"Image samples for testing\CN\" + NVID + ".jpg");
            }
            else
            {
                bmp1.Save(@"Image samples for testing\NV\Anonymous.jpg");
            }
        }

        public void fillPictureBox(PictureBox pbox, Bitmap bmp)
        {
            pbox.SizeMode = PictureBoxSizeMode.AutoSize;
            bool source_is_wider = (float)bmp.Width / bmp.Height > panel1.Width / panel1.Height;

            Bitmap resized = new Bitmap(pbox.Width, pbox.Height); ;
            Rectangle dest_rect;
            Rectangle src_rect;

            if (source_is_wider)
            {
                float size_ratio = (float)(panel1.Height - SystemInformation.VerticalScrollBarWidth) / bmp.Height;
                int sample_width = (int)((panel1.Width - SystemInformation.HorizontalScrollBarHeight) / size_ratio);
                src_rect = new Rectangle(0, 0, (int)(sample_width / size_ratio), bmp.Height);
                dest_rect = new Rectangle(0, 0, (int)((panel1.Width - SystemInformation.HorizontalScrollBarHeight) / size_ratio), panel1.Height - SystemInformation.VerticalScrollBarWidth);
                //pictureBox1.Height = panel1.Height - SystemInformation.HorizontalScrollBarHeight-2;
                //pictureBox1.Width = (int)(bmp.Width * size_ratio);
                resized = new Bitmap((int)(bmp.Width * size_ratio), panel1.Height - SystemInformation.HorizontalScrollBarHeight - 2);
            }
            else
            {
                float size_ratio = (float)(panel1.Width - SystemInformation.HorizontalScrollBarHeight) / bmp.Width;
                int sample_height = (int)((panel1.Height - SystemInformation.VerticalScrollBarWidth) / size_ratio);
                src_rect = new Rectangle(0, 0, bmp.Width, (int)(sample_height / size_ratio));
                dest_rect = new Rectangle(0, 0, panel1.Width - SystemInformation.HorizontalScrollBarHeight, (int)((panel1.Height - SystemInformation.VerticalScrollBarWidth) / size_ratio));
                //pictureBox1.Height = (int)(bmp.Height * size_ratio);
                //pictureBox1.Width = panel1.Width - SystemInformation.VerticalScrollBarWidth;
                resized = new Bitmap(panel1.Width - SystemInformation.VerticalScrollBarWidth, (int)(bmp.Height * size_ratio));
            }

            var g = Graphics.FromImage(resized);
            g.DrawImage(bmp, dest_rect, src_rect, GraphicsUnit.Pixel);
            g.Dispose();

            pbox.Image = resized;
        }

        public void Form_selectphoto_nv_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(FILEPATH);
            fillPictureBox(pictureBox1, bmp);
            label1.Text = HOTEN;
        }

        public void bt_OK_Click(object sender, EventArgs e)
        {
            SaveBitmap();
            this.Close();
        }
    }
}