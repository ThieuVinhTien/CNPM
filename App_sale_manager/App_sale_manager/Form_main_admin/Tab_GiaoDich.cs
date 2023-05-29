using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace App_sale_manager
{
    public partial class Form_main_admin : Form
    {
        //
        // TabPage Giao dịch
        //
        private void BNT_TaoHoaDon_Click(object sender, EventArgs e)
        {           
            Form_GiaoDich F_GD = new Form_GiaoDich(manv);
            F_GD.ShowDialog();
        }

        private void BNT_Refresh_GD_Click(object sender, EventArgs e)
        {
            this.Refresh_data_GD();
        }

        private void Refresh_data_GD()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd.CommandText = "set dateformat dmy";
            adapter.UpdateCommand = cmd;

            cmd.CommandText = "select SOHD_BH,CONVERT(varchar,NGHD,21) as [DD-MM-YYYY HH:MM:SS],KHID,NVID , REPLACE(CONVERT(varchar(20),TRIGIA, 1), '.00','') , LOAIHD,TRANGTHAI from HDBH";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            GridView_Data_GiaoDich.DataSource = table;
            sqlCon.Close();

            GridView_Data_GiaoDich.Columns[0].HeaderText = "Mã hóa đơn";
            GridView_Data_GiaoDich.Columns[1].HeaderText = "Ngày tạo";
            GridView_Data_GiaoDich.Columns[2].HeaderText = "Mã khách hàng";
            GridView_Data_GiaoDich.Columns[3].HeaderText = "Mã nhân viên";
            GridView_Data_GiaoDich.Columns[4].HeaderText = "Trị giá";
            GridView_Data_GiaoDich.Columns[5].HeaderText = "Loại hóa đơn";
            GridView_Data_GiaoDich.Columns[6].HeaderText = "Trạng thái";

            CLB_GD_TrangThai.SetItemChecked(0, true);
            CLB_GD_TrangThai.SetItemChecked(1, true);
            CLB_GD_TrangThai.SetItemChecked(2, true);
            CLB_GD_LoaiDon.SetItemChecked(0, true);
            CLB_GD_LoaiDon.SetItemChecked(1, true);
            Box_GD_MaHoaDon.Text = "";
            Box_GD_MaKhachHang.Text = "";
            BOX_GD_MaNhanVien.Text = "";
        }
       
        private void bnt_Timkiem_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd.CommandText = "select SOHD_BH,CONVERT(varchar,NGHD,21) as [DD-MM-YYYY HH:MM:SS],KHID,NVID , REPLACE(CONVERT(varchar(20),TRIGIA, 1), '.00','') , LOAIHD,TRANGTHAI from HDBH where (SOHD_BH like '%" + Box_GD_MaHoaDon.Text + "%' and KHID like '%" + Box_GD_MaKhachHang.Text + "%'AND NVID like '%" + BOX_GD_MaNhanVien.Text + "%'  ";
            if (CLB_GD_LoaiDon.CheckedIndices.Contains(0) == false)
            {
                cmd.CommandText += " and LOAIHD != N'Đơn đặt hàng'";
            }
            if (CLB_GD_LoaiDon.CheckedIndices.Contains(1) == false)
            {
                cmd.CommandText += " and LOAIHD != N'Đơn trực tiếp'";
            }
            if (CLB_GD_TrangThai.CheckedIndices.Contains(0) == false)
            {
                cmd.CommandText += " and TRANGTHAI != N'Nhận đơn'";
            }
            if (CLB_GD_TrangThai.CheckedIndices.Contains(1) == false)
            {
                cmd.CommandText += " and TRANGTHAI != N'Đang giao'";
            }

            if (CLB_GD_TrangThai.CheckedIndices.Contains(2) == false)
            {
                cmd.CommandText += " and TRANGTHAI != N'Hoàn thành'";
            }

            cmd.CommandText += ") ";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            GridView_Data_GiaoDich.DataSource = table;
            sqlCon.Close();

            GridView_Data_GiaoDich.Columns[0].HeaderText = "Mã hóa đơn";
            GridView_Data_GiaoDich.Columns[1].HeaderText = "Ngày tạo";
            GridView_Data_GiaoDich.Columns[2].HeaderText = "Mã khách hàng";
            GridView_Data_GiaoDich.Columns[3].HeaderText = "Mã nhân viên";
            GridView_Data_GiaoDich.Columns[4].HeaderText = "Trị giá (VNĐ)";
            GridView_Data_GiaoDich.Columns[5].HeaderText = "Loại hóa đơn";
            GridView_Data_GiaoDich.Columns[6].HeaderText = "Trạng thái";
        }



        private void GridView_Data_GiaoDich_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridView_Data_GiaoDich.CurrentRow.Index == GridView_Data_GiaoDich.NewRowIndex)
                return;

            Form_CTHD cthd = new Form_CTHD((string)GridView_Data_GiaoDich.CurrentRow.Cells[0].Value, (string)GridView_Data_GiaoDich.CurrentRow.Cells[2].Value, (string)GridView_Data_GiaoDich.CurrentRow.Cells[3].Value, (string)GridView_Data_GiaoDich.CurrentRow.Cells[5].Value, (string)GridView_Data_GiaoDich.CurrentRow.Cells[6].Value, Convert.ToString(GridView_Data_GiaoDich.CurrentRow.Cells[4].Value));
            cthd.Show();
        }

        private Bitmap bmp;

        private void bnt_inDS_Click(object sender, EventArgs e)
        {
            if (GridView_Data_GiaoDich.RowCount > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel WorkBook|*.xlsx";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;
                    worksheet.Name = "Exported from gridview";

                    for (int i = 1; i < GridView_Data_GiaoDich.Columns.Count + 1; i++)
                    {
                        worksheet.Cells[1, i] = GridView_Data_GiaoDich.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < GridView_Data_GiaoDich.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < GridView_Data_GiaoDich.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = GridView_Data_GiaoDich.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    workbook.SaveAs(save.FileName);
                    app.Quit();
                }
            }
        }
    }
}