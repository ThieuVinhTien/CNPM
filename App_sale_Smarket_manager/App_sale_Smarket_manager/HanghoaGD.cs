using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace App_sale_manager
{
    class HanghoaGD
    {
        public string IDSP;
        public string TenSP;
        public string Soluong;
        public string SLchon;
        public Panel panel;
        PictureBox pictureBox;
        public Label Tien;
        Label Ten;
        public event EventHandler Click;
        public event EventHandler Click2;
        public HanghoaGD()
        {

        }
        public HanghoaGD(Panel panel,PictureBox pictureBox, Label Tien, Label Ten, string IDSP, string TenSP, string Soluong)
        {
            this.panel = panel;
            this.pictureBox = pictureBox;
            this.Ten = Ten;
            this.Tien = Tien;
            this.IDSP = IDSP;
            this.TenSP = TenSP;
            this.Soluong = Soluong;
            Taosukien();
        }
        public void NhapSL(object sender, EventArgs e)
        {
            if(Convert.ToDouble((sender as SL).soluong)==0)
            {
                MessageBox.Show("Cảnh báo : Số lượng không thể bằng 0");
            }    
            if (Convert.ToDouble(Soluong) < Convert.ToDouble((sender as SL).soluong))
            {
                MessageBox.Show("Cảnh báo : Không đủ số lượng hàng trong kho");
            }
            else
            {
                SLchon = (sender as SL).soluong;
                Soluong = Convert.ToString(Convert.ToDouble(Soluong) - Convert.ToDouble(SLchon));
                Click(this, new EventArgs());
            }
        }
        void Taosukien()
        {
            panel.MouseEnter += Panel_MouseEnter;
            panel.MouseLeave += Panel_MouseLeave;
            panel.Click += Panel_Click; 
            pictureBox.MouseEnter += PictureBox_MouseEnter;
            Tien.MouseEnter += Tien_MouseEnter;
            Ten.MouseEnter += Ten_MouseEnter;
            pictureBox.MouseLeave += PictureBox_MouseLeave;
            Tien.MouseLeave += Tien_MouseLeave;
            Ten.MouseLeave += Ten_MouseLeave;
            pictureBox.Click += Panel_Click;
            Tien.Click += Panel_Click;
            Ten.Click += Panel_Click;
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            Click2(this, new EventArgs());
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            panel.BackColor = Color.Transparent;
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            panel.BackColor = Color.WhiteSmoke;
        }

        private void Ten_MouseLeave(object sender, EventArgs e)
        {
            panel.BackColor = Color.Transparent;
        }

        private void Tien_MouseLeave(object sender, EventArgs e)
        {
            panel.BackColor = Color.Transparent;
        }

        private void Ten_MouseEnter(object sender, EventArgs e)
        {
            panel.BackColor = Color.WhiteSmoke;
        }

        private void Tien_MouseEnter(object sender, EventArgs e)
        {
            panel.BackColor = Color.WhiteSmoke;
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            panel.BackColor = Color.Transparent;
        }

        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            panel.BackColor = Color.WhiteSmoke;
        }

        
    }
}
