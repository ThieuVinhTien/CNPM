using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Sale_manager : Form
    {
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        private SqlConnection con = new SqlConnection(strCon);

        private void Sale_items_addWithProducts()
        {
            comboBox_Condition.Items.Clear();
            comboBox_Condition.Items.Add("Rau củ - trái cây");
            comboBox_Condition.Items.Add("Thịt, cá, trứng, hải sản");
            comboBox_Condition.Items.Add("Thức ăn chế biến");
            comboBox_Condition.Items.Add("Thực phẩm đông - mát");
            comboBox_Condition.Items.Add("Bánh Kẹo, snack");
            comboBox_Condition.Items.Add("Sữa - sản phẩm từ sữa");
            comboBox_Condition.Items.Add("Thức uống");
            comboBox_Condition.Items.Add("Thực phẩm khô");

        }

        private void Sale_items_addWithProducer()
        {
            comboBox_Condition.Items.Clear();
            comboBox_Condition.Items.Add("Néstle");
            comboBox_Condition.Items.Add("Bobbies");
            comboBox_Condition.Items.Add("Anh ba Long An");
            comboBox_Condition.Items.Add("Như Ý");
            comboBox_Condition.Items.Add("Ngọc Trời");
            comboBox_Condition.Items.Add("Coolmate");
            comboBox_Condition.Items.Add("Acecook");
            comboBox_Condition.Items.Add("Coca-Cola");
            comboBox_Condition.Items.Add("NutiFood");
            comboBox_Condition.Items.Add("Nesvita");
            comboBox_Condition.Items.Add("Vua Gạo");

        }

        public Sale_manager()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            dateTimePicker_endDate.Value = dateTimePicker_startDate.Value.AddDays(1);
            this.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height);
        }

        public event EventHandler dataRefresh;

        private void comboBox_saleCondition_TextChanged(object sender, EventArgs e)
        {
            label_Condition.Text = comboBox_saleCondition.Text + " ưu đãi:";
            if (comboBox_saleCondition.Text == "Mặt hàng")
                Sale_items_addWithProducts();
            else
                Sale_items_addWithProducer();
        }

        private void comboBox_saleMethod_TextChanged(object sender, EventArgs e)
        {
            if (comboBox_saleMethod.Text == "Giảm giá")
                groupBox_gift.Enabled = false;
            else
                groupBox_gift.Enabled = true;
            if (comboBox_saleMethod.Text == "Tặng kèm")
                groupBox_sale.Enabled = false;
            else
                groupBox_sale.Enabled = true;
        }

        private void openconnect()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public event EventHandler RefreshData;

        private void closeconnect()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public Boolean exedata(string cmd)
        {
            openconnect();
            Boolean check = false;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
            }
            closeconnect();
            return check;
        }

        private void numericUpDown_priceReduced_Click(object sender, EventArgs e)
        {
            numericUpDown_priceReduced.Select(0, Convert.ToString(numericUpDown_priceReduced.Value).Length);
        }

        private void numericUpDown_Condition_price_Click(object sender, EventArgs e)
        {
            numericUpDown_Condition_price.Select(0, Convert.ToString(numericUpDown_priceReduced.Value).Length);
        }

        private void numericUpDown_Condition_Quantity_Click(object sender, EventArgs e)
        {
            numericUpDown_Condition_Quantity.Select(0, Convert.ToString(numericUpDown_priceReduced.Value).Length);
        }

        private void checkBox_priceCondition_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_priceCondition.CheckState == CheckState.Checked)
            {
                label_Condition_price.Enabled = true;
                label_Condition_quantity.Enabled = true;
                numericUpDown_Condition_price.Enabled = true;
                numericUpDown_Condition_Quantity.Enabled = true;
                label1.Enabled = true;
            }
            else
            {
                label_Condition_price.Enabled = false;
                label_Condition_quantity.Enabled = false;
                numericUpDown_Condition_price.Enabled = false;
                numericUpDown_Condition_Quantity.Enabled = false;
                label1.Enabled = false;
            }
        }

        private void button_quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool Check_if_existed(string name)
        {
            SqlCommand cmd;
            SqlDataAdapter Adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "Select * from KHUYENMAI where TENKM = N'" + name + "'";
            Adapter.SelectCommand = cmd;
            Table.Clear();
            Adapter.Fill(Table);
            dataGridView_manager.DataSource = Table;
            if (dataGridView_manager.RowCount > 1)
                return true;
            else
                return false;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
          
            string SaleCondition = comboBox_Condition.Text;
            switch (comboBox_Condition.Text)
            {
                case "Rau củ - trái cây":
                    SaleCondition = "RCTC";
                    break;
                case "Thịt, cá, trứng, hải sản":
                    SaleCondition = "TCTH";
                    break;
                case "Thức ăn chế biến":
                    SaleCondition = "TACB";
                    break;
                case "Thực phẩm đông - mát":
                    SaleCondition = "TPDM";
                    break;
                case "Bánh Kẹo, snack":
                    SaleCondition = "BKS";
                    break;
                case "Sữa - sản phẩm từ sữa":
                    SaleCondition = "SSPS";
                    break;
                case "Thức uống":
                    SaleCondition = "TU";
                    break;
                case "Thực phẩm khô":
                    SaleCondition = "TPK";
                    break;
            }
            int Tudongxoa = 0, Codieukien = 0;
            if (checkBox_autoDelete.CheckState == CheckState.Checked)
                Tudongxoa = 1;
            if (checkBox_priceCondition.CheckState == CheckState.Checked)
                Codieukien = 1;
            string commandline;
            if (string.IsNullOrEmpty(textBox_saleName.Text))
                textBox_saleName.Text = "(Chưa đặt tên)";

            if (comboBox_Condition.Text == "- Chưa chọn -")
            {
                MessageBox.Show("Chưa chọn mặt hàng giảm giá");
                return;
            }

            if (Check_if_existed(textBox_saleName.Text))
            {
                int count = 1;
                string name = textBox_saleName.Text + " (" + count + ")";
                while (Check_if_existed(name))
                {
                    count++;
                    name = textBox_saleName.Text + " (" + count + ")";
                }
                DialogResult result = MessageBox.Show("Tên khuyến mãi bị trùng lặp.\nĐể tránh lỗi dữ liệu phát sinh, hệ thống đề cử đổi tên khuyến mãi thành:\n"
                    + name + "\nBạn đồng ý chứ?", "Chú ý", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    textBox_saleName.Text = name;
                else
                {
                    textBox_saleName.Focus();
                    return;
                }
            }
            commandline = "insert into KHUYENMAI values(N'" + textBox_saleName.Text + "', N'" + comboBox_saleObj.Text + "', N'" + comboBox_saleMethod.Text + "', N'"
                + comboBox_saleCondition.Text + "', N'" + SaleCondition + "', '" + dateTimePicker_startDate.Value.ToString("MM/dd/yyyy") + "', '" + dateTimePicker_endDate.Value.ToString("MM/dd/yyyy") + "', N'"
                + textBox_gift.Text + "', N'" + textBox_note.Text + "', N'" + comboBox_priceMethod.Text + "', '" + numericUpDown_priceReduced.Value + "', '" + numericUpDown_Condition_Quantity.Value + "', '"
                + numericUpDown_Condition_price.Value + "', '" + Tudongxoa + "', '" + Codieukien + "')";
            if (con.State == ConnectionState.Closed)
                openconnect();
            if (exedata(commandline))
            {
                MessageBox.Show("Thêm thành công.");
                Close();
            }
            else
                MessageBox.Show("Thêm không thành công");
            dataRefresh(this, e);
        }

        private void comboBox_priceMethod_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox_priceMethod.Text)
            {
                case "Giảm theo số":
                    label_priceReduced.Text = "Số lượng giảm (VND):";
                    numericUpDown_priceReduced.Minimum = 1000;
                    numericUpDown_priceReduced.Maximum = 1000000;
                    break;

                case "Giảm theo phần trăm":
                    label_priceReduced.Text = "Phần trăm giảm (%): ";
                    numericUpDown_priceReduced.Maximum = 100;
                    numericUpDown_priceReduced.Minimum = 0;
                    break;
            }
        }

 
    }
}