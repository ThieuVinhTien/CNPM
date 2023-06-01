using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interface_sale_manager
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form_Tao_HD fr = new Form_Tao_HD();
            fr.ShowDialog();
        }
        public event EventHandler Dang_Xuat;
        private void button25_Click(object sender, EventArgs e)
        {
            Dang_Xuat(this, new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_don_nhap_kho fr = new Form_don_nhap_kho();
            fr.ShowDialog();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Form_don_nhap_kho fr = new Form_don_nhap_kho();
            fr.ShowDialog();
        }
    }
}
