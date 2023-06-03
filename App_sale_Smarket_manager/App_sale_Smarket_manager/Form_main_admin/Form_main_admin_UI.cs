using System;
using System.Drawing;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_main_admin : Form
    {
        // Cài đặt UI
        private void tbtnDoictac_DropDownOpening(object sender, EventArgs e)
        {
            tbtnDoictac.Image = Image.FromFile("../../icon/icons8-man-30 (2).png");
            tbtnDoictac.ForeColor = Color.FromArgb(61, 135, 255);
            tbtnDoictac.ImageScaling = ToolStripItemImageScaling.None;
        }

        private void tbtnDoictac_DropDownClosed(object sender, EventArgs e)
        {
            tbtnDoictac.Image = Image.FromFile("../../icon/icons8-man-30 (1).png");
            tbtnDoictac.ForeColor = Color.White;
            tbtnDoictac.ImageScaling = ToolStripItemImageScaling.None;
        }

        private void tbtnGiaodich_DropDownOpening(object sender, EventArgs e)
        {
            tbtnGiaodich.Image = Image.FromFile("../../icon/icons8-exchange-30 (2).png");
            tbtnGiaodich.ForeColor = Color.FromArgb(61, 135, 255);
            tbtnGiaodich.ImageScaling = ToolStripItemImageScaling.None;
        }

        private void tbtnGiaodich_DropDownClosed(object sender, EventArgs e)
        {
            tbtnGiaodich.Image = Image.FromFile("../../icon/icons8-exchange-30 (1).png");
            tbtnGiaodich.ForeColor = Color.White;
            tbtnGiaodich.ImageScaling = ToolStripItemImageScaling.None;
        }

        private void tbtnNhanvien_DropDownOpening(object sender, EventArgs e)
        {
            tbtnNhanvien.Image = Image.FromFile("../../icon/icons8-staff-30 (2).png");
            tbtnNhanvien.ForeColor = Color.FromArgb(61, 135, 255);
            tbtnNhanvien.ImageScaling = ToolStripItemImageScaling.None;
        }

        private void tbtnNhanvien_DropDownClosed(object sender, EventArgs e)
        {
            tbtnNhanvien.Image = Image.FromFile("../../icon/icons8-staff-30 (1).png");
            tbtnNhanvien.ForeColor = Color.White;
            tbtnNhanvien.ImageScaling = ToolStripItemImageScaling.None;
        }

        private void tbtnBaocao_DropDownOpening(object sender, EventArgs e)
        {
            tbtnBaocao.Image = Image.FromFile("../../icon/icons8-increase-30 (2).png");
            tbtnBaocao.ForeColor = Color.FromArgb(61, 135, 255);
            tbtnBaocao.ImageScaling = ToolStripItemImageScaling.None;
        }

        private void tbtnBaocao_DropDownClosed(object sender, EventArgs e)
        {
            tbtnBaocao.Image = Image.FromFile("../../icon/icons8-increase-30 (1).png");
            tbtnBaocao.ForeColor = Color.White;
            tbtnBaocao.ImageScaling = ToolStripItemImageScaling.None;
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

        private void tbtn_click(object sender, EventArgs e)
        {
            foreach (var item in toolStripMain.Items)
            {
                (item as ToolStripDropDownButton).BackColor = Color.FromArgb(61, 135, 255);
            }
            (sender as ToolStripDropDownButton).BackColor = Color.Blue;
        }

        private void tbtnTongquan_Click(object sender, EventArgs e)
        {
            tabCtrl.TabPages.Clear();
            tabCtrl.TabPages.Add(tabPage_tongquan);
            load_tab_Tongquan();
            tbtn_click(sender, new EventArgs());
        }

        private void tbtnHanghoa_Click(object sender, EventArgs e)
        {
            tabCtrl.TabPages.Clear();
            tabCtrl.TabPages.Add(Tabpage_Hanghoa);
            LoadCBBHH();
            LoadHangHoa();
            rbtnXemtatca.Checked = true;
            tbtn_click(sender, new EventArgs());
        }

        private void đốiTácCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabCtrl.TabPages.Clear();
            tabCtrl.TabPages.Add(tabPage_DoiTac);
            tabControl_DTCC_in.TabPages.Clear();
            tabControl_DTCC_in.TabPages.Add(tabPage__DTCC_DTGD);
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabCtrl.TabPages.Clear();
            tabCtrl.TabPages.Add(tabPage_DoiTac);
            tabControl_DTCC_in.TabPages.Clear();
            tabControl_DTCC_in.TabPages.Add(tabPage_DTCC_Guest);
        }

        private void danhMụcHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabCtrl.TabPages.Clear();
            tabCtrl.TabPages.Add(tabPage_GiaoDich);
            this.Refresh_data_GD();
        }

        private void tạoHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BNT_TaoHoaDon_Click(this, new EventArgs());
            if (tabCtrl.TabPages.Contains(tabPage_tongquan))
            {
                tbtn_click(tbtnTongquan, new EventArgs());
            }
        }

        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabCtrl.TabPages.Clear();
            tabCtrl.TabPages.Add(tabPage_NhanVien);
            tab_nv.TabPages.Clear();
            tab_nv.TabPages.Add(tabPage1);
            LoadData_nv_infonv();
            lammoi_tabNhanvien_tracuuinfo();
        }

        private void lịchPhânCôngNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabCtrl.TabPages.Clear();
            tabCtrl.TabPages.Add(tabPage_NhanVien);
            tab_nv.TabPages.Clear();
            tab_nv.TabPages.Add(tabP_nv_bangphancong);
            load_tabpage_phancong();
        }

        private void bảngLươngNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabCtrl.TabPages.Clear();
            tabCtrl.TabPages.Add(tabPage_NhanVien);
            tab_nv.TabPages.Clear();
            tab_nv.TabPages.Add(tabPage3);
            LoadData_nv_bangluong();
            loadanh_nv_bangluong();
        }

        private void cuốiNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabCtrl.TabPages.Clear();
            tabCtrl.TabPages.Add(tabPage_BaoCao);
            tabControl_Baocao.TabPages.Clear();
            tabControl_Baocao.TabPages.Add(tabPage_Baocao_cuoingay);
            rBtn_bc_qt1_CheckedChanged(rBtn_bc_qt1, new EventArgs());
        }

        private void daonhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabCtrl.TabPages.Clear();
            tabCtrl.TabPages.Add(tabPage_BaoCao);
            tabControl_Baocao.TabPages.Clear();
            tabControl_Baocao.TabPages.Add(tabPage_baocao_doanhthu);
            comboBox_bc_Doanhthu_kieutinh.SelectedIndex = 0;
            comboBox_bc_Doanhthu_kieutinh_SelectedIndexChanged(comboBox_bc_Doanhthu_kieutinh, new EventArgs());
        }

        private void nhânViênXuấtSắcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabCtrl.TabPages.Clear();
            tabCtrl.TabPages.Add(tabPage_BaoCao);
            tabControl_Baocao.TabPages.Clear();
            tabControl_Baocao.TabPages.Add(tabPage_Baocao_nhanvien);
            comboBox_bc_Nv_kieutinh.SelectedIndex = 0;
            comboBox_bc_Nv_kieutinh_SelectedIndexChanged(comboBox_bc_Nv_kieutinh, new EventArgs());
        }

        private void btnHanghoaTim_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnHanghoaTim.Tag) == 0)
            {
                btnHanghoaTim.Image = Image.FromFile("../../icon/icons8-triangle-arrow-24 (1).png");
                btnHanghoaTim.ImageAlign = ContentAlignment.MiddleRight;
                btnHanghoaTim.Tag = 1;
                panel5.Visible = false;
            }
            else
            {
                btnHanghoaTim.Image = Image.FromFile("../../icon/icons8-triangle-24.png");
                btnHanghoaTim.ImageAlign = ContentAlignment.MiddleRight;
                btnHanghoaTim.Tag = 0;
                panel5.Visible = true;
            }
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

        private void btnPhancongNV_lich_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnPhancongNV_lich.Tag) == 0)
            {
                btnPhancongNV_lich.Image = Image.FromFile("../../icon/icons8-triangle-arrow-24 (1).png");
                btnPhancongNV_lich.ImageAlign = ContentAlignment.MiddleRight;
                btnPhancongNV_lich.Tag = 1;
                pnPhancongNV_lich.Visible = false;
            }
            else
            {
                btnPhancongNV_lich.Image = Image.FromFile("../../icon/icons8-triangle-24.png");
                btnPhancongNV_lich.ImageAlign = ContentAlignment.MiddleRight;
                btnPhancongNV_lich.Tag = 0;
                pnPhancongNV_lich.Visible = true;
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_doipass frm = new Form_doipass();
            frm.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canExit = false;
            Thoat(this, new EventArgs());
        }

        private void btnTongquan_chuthich_Click(object sender, EventArgs e)
        {
            Form_chuthich frm = new Form_chuthich();
            frm.ShowDialog();
        }

        private void tbtn_click(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (var item in toolStripMain.Items)
            {
                (item as ToolStripDropDownButton).BackColor = Color.FromArgb(61, 135, 255);
            }
            (sender as ToolStripDropDownButton).BackColor = Color.Blue;
        }
    }
}