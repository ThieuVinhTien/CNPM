using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Sale_viewer : Form
    {
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        private SqlConnection con = new SqlConnection(strCon);
        private string selectedSale = "";

        public void Database_Init()
        {
            SqlCommand cmd;
            SqlDataAdapter Adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "Select * from KHUYENMAI";
            Adapter.SelectCommand = cmd;
            Table.Clear();
            Adapter.Fill(Table);
            dataGridView_sale.DataSource = Table;
        }

        private void openconnect()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

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

        public Sale_manager Sale_get(DataGridViewRow A)
        {
            Sale_manager B = new Sale_manager();
            string SaleCondition = "";
            switch (A.Cells[4].Value.ToString())
            {
                case "RCTC":
                    SaleCondition = "Rau củ - trái cây";
                    break;
                case "TCTH":
                    SaleCondition = "Thịt, cá, trứng, hải sản";
                    break;
                case "TACB":
                    SaleCondition = "Thức ăn chế biến";
                    break;
                case "TPDM":
                    SaleCondition = "Thực phẩm đông - mát";
                    break;
                case "BKS":
                    SaleCondition = "Bánh Kẹo, snack";
                    break;
                case "SSBS":
                    SaleCondition = "Sữa - sản phẩm từ sữa";
                    break;
                case "TU":
                    SaleCondition = "Thức uống";
                    break;
                case "TPK":
                    SaleCondition = "Thực phẩm khô";
                    break;
            }
            B.textBox_saleName.Text = A.Cells[0].Value.ToString();
            B.comboBox_saleObj.Text = A.Cells[1].Value.ToString();
            B.comboBox_saleMethod.Text = A.Cells[2].Value.ToString();
            B.comboBox_saleCondition.Text = A.Cells[3].Value.ToString();
            B.comboBox_Condition.Text = SaleCondition;
            B.dateTimePicker_startDate.Text = A.Cells[5].Value.ToString();
            B.dateTimePicker_endDate.Text = A.Cells[6].Value.ToString();
            B.textBox_gift.Text = A.Cells[7].Value.ToString();
            B.textBox_note.Text = A.Cells[8].Value.ToString();
            B.comboBox_priceMethod.Text = A.Cells[9].Value.ToString();
            B.numericUpDown_priceReduced.Value = Convert.ToInt32(A.Cells[10].Value.ToString());
            B.numericUpDown_Condition_price.Value = Convert.ToInt32(A.Cells[12].Value.ToString());
            B.numericUpDown_Condition_Quantity.Value = Convert.ToInt32(A.Cells[11].Value.ToString());
            if (A.Cells[13].Value.ToString() == "1")
                B.checkBox_autoDelete.CheckState = CheckState.Checked;
            if (A.Cells[14].Value.ToString() == "1")
                B.checkBox_priceCondition.CheckState = CheckState.Checked;
            return B;
        }

        public void DataRefresh(object sender, EventArgs e)
        {
            Database_Init();
            listBox_VIP_ongoing.Items.Clear();
            listBox_VIP_ended.Items.Clear();
            listBox_VIP_waiting.Items.Clear();
            listBox_NOR_ongoing.Items.Clear();
            listBox_NOR_ended.Items.Clear();
            listBox_NOR_waiting.Items.Clear();
            button_saleDelete.Enabled = false;
            selectedSale = "";
            for (int i = 0; i < dataGridView_sale.RowCount - 1; i++)
            {
                if (dataGridView_sale.Rows[i].Cells[1].Value.ToString() == "Khách thường")
                {
                    if (Convert.ToDateTime(dataGridView_sale.Rows[i].Cells[5].Value.ToString()) <= DateTime.Now && Convert.ToDateTime(dataGridView_sale.Rows[i].Cells[6].Value.ToString()) >= DateTime.Now)
                        listBox_NOR_ongoing.Items.Add(dataGridView_sale.Rows[i].Cells[0].Value.ToString());
                    if (Convert.ToDateTime(dataGridView_sale.Rows[i].Cells[6].Value.ToString()) < DateTime.Now)
                    {
                        if (dataGridView_sale.Rows[i].Cells[13].Value.ToString() == "1")
                            continue;
                        else
                            listBox_NOR_ended.Items.Add(dataGridView_sale.Rows[i].Cells[0].Value.ToString());
                    }
                    if (Convert.ToDateTime(dataGridView_sale.Rows[i].Cells[5].Value.ToString()) > DateTime.Now)
                        listBox_NOR_waiting.Items.Add(dataGridView_sale.Rows[i].Cells[0].Value.ToString());
                }

                if (dataGridView_sale.Rows[i].Cells[1].Value.ToString() == "Khách vip")
                {
                    if (Convert.ToDateTime(dataGridView_sale.Rows[i].Cells[5].Value.ToString()) <= DateTime.Now && Convert.ToDateTime(dataGridView_sale.Rows[i].Cells[6].Value.ToString()) >= DateTime.Now)
                        listBox_VIP_ongoing.Items.Add(dataGridView_sale.Rows[i].Cells[0].Value.ToString());
                    if (Convert.ToDateTime(dataGridView_sale.Rows[i].Cells[6].Value.ToString()) < DateTime.Now)
                    {
                        if (dataGridView_sale.Rows[i].Cells[13].Value.ToString() == "1")
                            continue;
                        else
                            listBox_VIP_ended.Items.Add(dataGridView_sale.Rows[i].Cells[0].Value.ToString());
                    }
                    if (Convert.ToDateTime(dataGridView_sale.Rows[i].Cells[5].Value.ToString()) > DateTime.Now)
                        listBox_VIP_waiting.Items.Add(dataGridView_sale.Rows[i].Cells[0].Value.ToString());
                }
                if (dataGridView_sale.Rows[i].Cells[1].Value.ToString() == "Tất cả")
                {
                    if (Convert.ToDateTime(dataGridView_sale.Rows[i].Cells[5].Value.ToString()) <= DateTime.Now && Convert.ToDateTime(dataGridView_sale.Rows[i].Cells[6].Value.ToString()) >= DateTime.Now)
                    {
                        listBox_NOR_ongoing.Items.Add(dataGridView_sale.Rows[i].Cells[0].Value.ToString());
                        listBox_VIP_ongoing.Items.Add(dataGridView_sale.Rows[i].Cells[0].Value.ToString());
                    }
                    if (Convert.ToDateTime(dataGridView_sale.Rows[i].Cells[6].Value.ToString()) < DateTime.Now)
                    {
                        if (dataGridView_sale.Rows[i].Cells[13].Value.ToString() == "1")
                            continue;
                        else
                        {
                            listBox_NOR_ended.Items.Add(dataGridView_sale.Rows[i].Cells[0].Value.ToString());
                            listBox_VIP_ended.Items.Add(dataGridView_sale.Rows[i].Cells[0].Value.ToString());
                        }
                    }
                    if (Convert.ToDateTime(dataGridView_sale.Rows[i].Cells[5].Value.ToString()) > DateTime.Now)
                    {
                        listBox_NOR_waiting.Items.Add(dataGridView_sale.Rows[i].Cells[0].Value.ToString());
                        listBox_VIP_waiting.Items.Add(dataGridView_sale.Rows[i].Cells[0].Value.ToString());
                    }
                }
            }
        }

        public Sale_viewer()
        {
            InitializeComponent();
            DataRefresh(this, null);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sale_manager A = new Sale_manager();
            A.dataRefresh += DataRefresh;
            A.Show();
        }

        private void button_quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox_NOR_ongoing_DoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_sale.RowCount - 1; i++)
            {
                if (dataGridView_sale.Rows[i].Cells[0].Value.ToString() == listBox_NOR_ongoing.SelectedItem.ToString())
                {
                    Sale_manager A = Sale_get(dataGridView_sale.Rows[i]);
                    A.dataRefresh += DataRefresh;
                    SqlCommand cmd = new SqlCommand("delete from KHUYENMAI where TENKM='" + listBox_NOR_ongoing.SelectedItem.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    A.Show();
                }
            }
        }

        private void listBox_NOR_waiting_DoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_sale.RowCount - 1; i++)
            {
                if (dataGridView_sale.Rows[i].Cells[0].Value.ToString() == listBox_NOR_waiting.SelectedItem.ToString())
                {
                    Sale_manager A = Sale_get(dataGridView_sale.Rows[i]);
                    A.dataRefresh += DataRefresh;
                    SqlCommand cmd = new SqlCommand("delete from KHUYENMAI where TENKM='" + listBox_NOR_waiting.SelectedItem.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    A.Show();
                }
            }
        }

        private void listBox_NOR_ended_DoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_sale.RowCount - 1; i++)
            {
                if (dataGridView_sale.Rows[i].Cells[0].Value.ToString() == listBox_NOR_ended.SelectedItem.ToString())
                {
                    Sale_manager A = Sale_get(dataGridView_sale.Rows[i]);
                    A.dataRefresh += DataRefresh;
                    SqlCommand cmd = new SqlCommand("delete from KHUYENMAI where TENKM='" + listBox_NOR_ended.SelectedItem.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    A.Show();
                }
            }
        }

        private void listBox_VIP_ongoing_DoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_sale.RowCount - 1; i++)
            {
                if (dataGridView_sale.Rows[i].Cells[0].Value.ToString() == listBox_VIP_ongoing.SelectedItem.ToString())
                {
                    Sale_manager A = Sale_get(dataGridView_sale.Rows[i]);
                    A.dataRefresh += DataRefresh;
                    SqlCommand cmd = new SqlCommand("delete from KHUYENMAI where TENKM='" + listBox_VIP_ongoing.SelectedItem.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    A.Show();
                }
            }
        }

        private void listBox_VIP_waiting_DoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_sale.RowCount - 1; i++)
            {
                if (dataGridView_sale.Rows[i].Cells[0].Value.ToString() == listBox_VIP_waiting.SelectedItem.ToString())
                {
                    Sale_manager A = Sale_get(dataGridView_sale.Rows[i]);
                    A.dataRefresh += DataRefresh;
                    SqlCommand cmd = new SqlCommand("delete from KHUYENMAI where TENKM='" + listBox_VIP_waiting.SelectedItem.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    A.Show();
                }
            }
        }

        private void listBox_VIP_ended_DoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_sale.RowCount - 1; i++)
            {
                if (dataGridView_sale.Rows[i].Cells[0].Value.ToString() == listBox_VIP_ended.SelectedItem.ToString())
                {
                    Sale_manager A = Sale_get(dataGridView_sale.Rows[i]);
                    A.dataRefresh += DataRefresh;
                    SqlCommand cmd = new SqlCommand("delete from KHUYENMAI where TENKM='" + listBox_VIP_ended.SelectedItem.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    A.Show();
                }
            }
        }

        private void button_saleDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSale) == false)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ưu đãi này?", "Chú ý", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("delete from KHUYENMAI where TENKM = N'" + selectedSale + "'", con);
                    cmd.ExecuteNonQuery();
                    DataRefresh(this, null);
                }
            }
        }

        private void listBox_NOR_ongoing_Leave(object sender, EventArgs e)
        {
            listBox_NOR_ongoing.ClearSelected();
        }

        private void listBox_NOR_waiting_Leave(object sender, EventArgs e)
        {
            listBox_NOR_waiting.ClearSelected();
        }

        private void listBox_NOR_ended_Leave(object sender, EventArgs e)
        {
            listBox_NOR_ended.ClearSelected();
        }

        private void listBox_VIP_ongoing_Leave(object sender, EventArgs e)
        {
            listBox_VIP_ongoing.ClearSelected();
        }

        private void listBox_VIP_waiting_Leave(object sender, EventArgs e)
        {
            listBox_VIP_waiting.ClearSelected();
        }

        private void listBox_VIP_ended_Leave(object sender, EventArgs e)
        {
            listBox_VIP_ended.ClearSelected();
        }

        private void listBox_NOR_ongoing_MouseClick(object sender, EventArgs e)
        {
            if (listBox_NOR_ongoing.SelectedItems.Count != 0)
            {
                selectedSale = listBox_NOR_ongoing.SelectedItem.ToString();
                button_saleDelete.Enabled = true;
            }
        }

        private void listBox_NOR_waiting_MouseClick(object sender, EventArgs e)
        {
            if (listBox_NOR_waiting.SelectedItems.Count != 0)
            {
                selectedSale = listBox_NOR_waiting.SelectedItem.ToString();
                button_saleDelete.Enabled = true;
            }
        }

        private void listBox_NOR_ended_MouseClick(object sender, EventArgs e)
        {
            if (listBox_NOR_ended.SelectedItems.Count != 0)
            {
                selectedSale = listBox_NOR_ended.SelectedItem.ToString();
                button_saleDelete.Enabled = true;
            }
        }

        private void listBox_VIP_ongoing_MouseClick(object sender, EventArgs e)
        {
            if (listBox_VIP_ongoing.SelectedItems.Count != 0)
            {
                selectedSale = listBox_VIP_ongoing.SelectedItem.ToString();
                button_saleDelete.Enabled = true;
            }
        }

        private void listBox_VIP_waiting_MouseClick(object sender, EventArgs e)
        {
            if (listBox_VIP_waiting.SelectedItems.Count != 0)
            {
                selectedSale = listBox_VIP_waiting.SelectedItem.ToString();
                button_saleDelete.Enabled = true;
            }
        }

        private void listBox_VIP_ended_MouseClick(object sender, EventArgs e)
        {
            if (listBox_VIP_ended.SelectedItems.Count != 0)
            {
                selectedSale = listBox_VIP_ended.SelectedItem.ToString();
                button_saleDelete.Enabled = true;
            }
        }
    }
}