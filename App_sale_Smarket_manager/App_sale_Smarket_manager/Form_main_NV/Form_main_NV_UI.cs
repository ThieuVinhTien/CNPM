using System;
using System.Drawing;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_main_NV : Form
    {
        // cài đặt UI
        private void tbtn_click(object sender, EventArgs e)
        {
            foreach (var item in toolStripMainNV.Items)
            {
                (item as ToolStripDropDownButton).BackColor = Color.FromArgb(61, 135, 255);
            }
            (sender as ToolStripDropDownButton).BackColor = Color.Blue;
        }

        private void tbtnUser_DropDownOpening(object sender, EventArgs e)
        {
            tbtnUser.Image = Image.FromFile("../../icon/icons8-male-user-30 (1).png");
            tbtnUser.ForeColor = Color.FromArgb(61, 135, 255);
            tbtnUser.ImageScaling = ToolStripItemImageScaling.None;
        }

        private void tbtnUser_DropDownClosed(object sender, EventArgs e)
        {
            tbtnUser.Image = Image.FromFile("../../icon/icons8-male-user-30 (2).png");
            tbtnUser.ForeColor = Color.White;
            tbtnUser.ImageScaling = ToolStripItemImageScaling.None;
        }

        private void tbtnTongquan_Click(object sender, EventArgs e)
        {
            tabctrl_Nhanvien.TabPages.Clear();
            tabctrl_Nhanvien.TabPages.Add(tabP_Tongquan);
            load_tongquan();
            tbtn_click(sender, new EventArgs());
        }

        private void tbtnKhachhang_Click(object sender, EventArgs e)
        {
            tabctrl_Nhanvien.TabPages.Clear();
            tabctrl_Nhanvien.TabPages.Add(tabP_Khachhang);
            tbtn_click(sender, new EventArgs());
        }

        private void tbtnGiaodich_Click(object sender, EventArgs e)
        {
            tabctrl_Nhanvien.TabPages.Clear();
            tabctrl_Nhanvien.TabPages.Add(tabP_Banhang);
            this.Refresh_data_GD();
            tbtn_click(sender, new EventArgs());
        }

        private void tbtnLich_Click(object sender, EventArgs e)
        {
            tabctrl_Nhanvien.TabPages.Clear();
            tabctrl_Nhanvien.TabPages.Add(tabP_lichlamviec);
            timer.Tick += Timer_Tick;
            timer.Start();
            timer.Interval = 1000;
            load_lich();
            tbtn_click(sender, new EventArgs());
        }

        private void tbtnCanhan_Click(object sender, EventArgs e)
        {
            tabctrl_Nhanvien.TabPages.Clear();
            tabctrl_Nhanvien.TabPages.Add(tabP_Canhan);
            LoadData_nv_infonv();
            tbtn_click(sender, new EventArgs());
        }

        private void btnGiaodich_Tim_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnGiaodich_Tim.Tag) == 0)
            {
                btnGiaodich_Tim.Image = Image.FromFile("../../icon/icons8-triangle-arrow-24 (1).png");
                btnGiaodich_Tim.ImageAlign = ContentAlignment.MiddleRight;
                btnGiaodich_Tim.Tag = 1;
                pnGiaodich_Tim.Visible = false;
            }
            else
            {
                btnGiaodich_Tim.Image = Image.FromFile("../../icon/icons8-triangle-24.png");
                btnGiaodich_Tim.ImageAlign = ContentAlignment.MiddleRight;
                btnGiaodich_Tim.Tag = 0;
                pnGiaodich_Tim.Visible = true;
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canExit = false;
            Thoat(this, new EventArgs());
        }
    }
}