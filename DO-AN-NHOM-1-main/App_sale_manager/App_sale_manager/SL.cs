using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class SL : Form
    {
        public event EventHandler NhapSL;
        public string soluong;
        public SL()
        {
            InitializeComponent();
            soluong = "1";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            soluong = numericUpDown_fc1.Value.ToString();
            NhapSL(this, new EventArgs());
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
