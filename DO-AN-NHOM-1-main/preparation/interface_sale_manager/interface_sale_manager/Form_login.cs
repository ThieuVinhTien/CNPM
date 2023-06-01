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
    public partial class Form_login : Form
    {
        public Form_login()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Main fr = new Form_Main();
            fr.Show();
            fr.Dang_Xuat += Fr_Dang_Xuat;
        }

        private void Fr_Dang_Xuat(object sender, EventArgs e)
        {
            (sender as Form_Main).Close();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
