using System;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class NumericUpDown_fc : NumericUpDown
    {
        public NumericUpDown_fc()
        {
            InitializeComponent();
        }

        protected override void UpdateEditText()
        {
            this.Text = String.Format("{0:0,0}", Convert.ToDouble(Value.ToString()));
            // base.UpdateEditText();
        }
    }
}