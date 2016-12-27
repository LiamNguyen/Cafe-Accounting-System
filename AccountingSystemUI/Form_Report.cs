using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingSystemDAL;

namespace AccountingSystemUI
{
    public partial class Form_Report : Form
    {
        DBConnection cn = new DBConnection();
        public Form_Report()
        {
            InitializeComponent();
        }

        private void Form_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.grid_detail.Columns[0].Width = 250;
            this.grid_detail.Columns[3].Width = 200;
            this.grid_totalById.Columns[0].Width = 120;
            this.grid_totalById.Columns[1].Width = 150;
            this.grid_revenueByMonth.Columns[0].Width = 85;
            this.grid_revenueByYear.Columns[0].Width = 85;
            this.grid_numOfOrderByID.Columns[0].Width = 150;
            this.grid_numOfReceipt.Columns[0].Width = 150;
            bindGridDataSource();
        }

        private void bindGridDataSource()
        {
            //Select for grid_detail
            try
            {
                string sql = @"SELECT Receipt.DATE, Receipt.RECEIPTID, ReceiptDetail.PRODUCTID, MenuItems.PRODUCTNAME,
                                PriceDetail.PRODUCTPRICE, ReceiptDetail.AMOUNT, ReceiptDetail.TOTAL, Receipt.STAFFID
                                FROM MenuItems INNER JOIN ReceiptDetail ON MenuItems.PRODUCTID = ReceiptDetail.PRODUCTID 
				                INNER JOIN Receipt ON ReceiptDetail.RECEIPTID = Receipt.RECEIPTID
                                INNER JOIN PriceDetail ON ReceiptDetail.PRODUCTID = PriceDetail.PRODUCTID
                                ORDER BY Receipt.RECEIPTID ASC";
                grid_detail.DataSource = cn.GetDataTable(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error while viewing report");
                throw;
            }

            //Select for grid_totalById
            try
            {
                string sql = @"SELECT substring(Receipt.DATE,1, 10) as 'DATE', Receipt.RECEIPTID, Receipt.STAFFID, Receipt.TOTAL
                                FROM Receipt 
                                ORDER BY SUBSTRING(Receipt.DATE, 4, 2) ASC";
                grid_totalById.DataSource = cn.GetDataTable(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error while viewing report");
                throw;
            }

            //Select for grid_numOfReceipt
            try
            {
                string sql = @"SELECT substring(DATE, 1, 10) as 'DATE', COUNT(RECEIPTID) AS 'Number'
                                FROM Receipt
                                GROUP BY substring(DATE, 1, 10)
                                ORDER BY DATE";
                grid_numOfReceipt.DataSource = cn.GetDataTable(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error while viewing report");
                throw;
            }

            //Select for grid_numOfOrderById
            try
            {
                string sql = @"SELECT ReceiptDetail.RECEIPTID, COUNT(ReceiptDetail.PRODUCTID) AS 'Number'
                                FROM Receipt INNER JOIN ReceiptDetail ON Receipt.RECEIPTID = ReceiptDetail.RECEIPTID
                                GROUP BY ReceiptDetail.RECEIPTID
                                ORDER BY ReceiptDetail.RECEIPTID";
                grid_numOfOrderByID.DataSource = cn.GetDataTable(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error while viewing report");
                throw;
            }

            //Select for grid_revenueByDay
            try
            {
                string sql = @"SELECT SUBSTRING(Receipt.DATE,1, 10) as 'DATE', sum(Receipt.TOTAL) AS 'DATEREVENUE'
                                FROM Receipt
                                GROUP BY SUBSTRING(ReceipT.DATE,1, 10)";
                grid_revenueByDate.DataSource = cn.GetDataTable(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error while viewing report");
                throw;
            }

            //Select for grid_revenueByMonth
            try
            {
                string sql = @"SELECT SUBSTRING(Receipt.DATE,4, 7) as 'DATE', sum(Receipt.TOTAL) AS 'MONTHREVENUE'
                                FROM Receipt
                                GROUP BY SUBSTRING(ReceipT.DATE,4, 7)";
                grid_revenueByMonth.DataSource = cn.GetDataTable(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error while viewing report");                
                throw;
            }

            //Select for grid_revenueByYear
            try
            {
                string sql = @"SELECT SUBSTRING(Receipt.DATE,7, 4) as 'DATE', sum(Receipt.TOTAL) AS 'YEARREVENUE'
                                FROM Receipt
                                GROUP BY SUBSTRING(ReceipT.DATE,7, 4)";
                grid_revenueByYear.DataSource = cn.GetDataTable(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error while viewing report");                
                throw;
            }
        }

        private void searchReceiptIDTxtBox_TextChanged(object sender, EventArgs e)
        {
            filterGrid();
        }

        private void searchDateTxtBox_TextChanged(object sender, EventArgs e)
        {
            filterGrid();
        }

        private void suportFilter(string whereCondition)
        {
            grid_detail.DataSource = cn.GetDataTable(@"SELECT Receipt.DATE, Receipt.RECEIPTID, ReceiptDetail.PRODUCTID, MenuItems.PRODUCTNAME,
                                                        PriceDetail.PRODUCTPRICE, ReceiptDetail.AMOUNT, ReceiptDetail.TOTAL, Receipt.STAFFID
                                                        FROM MenuItems INNER JOIN ReceiptDetail ON MenuItems.PRODUCTID = ReceiptDetail.PRODUCTID 
				                                        INNER JOIN Receipt ON ReceiptDetail.RECEIPTID = Receipt.RECEIPTID
                                                        INNER JOIN PriceDetail ON ReceiptDetail.PRODUCTID = PriceDetail.PRODUCTID
                                                        WHERE " + whereCondition + " ORDER BY Receipt.RECEIPTID ASC");

            grid_totalById.DataSource = cn.GetDataTable(@"SELECT substring(Receipt.DATE,1, 10) as 'DATE', Receipt.RECEIPTID, Receipt.STAFFID, Receipt.TOTAL
                                                        FROM Receipt 
                                                        WHERE " + whereCondition + " ORDER BY SUBSTRING(Receipt.DATE, 4, 2) ASC");
            grid_numOfOrderByID.DataSource = cn.GetDataTable(@"SELECT ReceiptDetail.RECEIPTID, COUNT(ReceiptDetail.PRODUCTID) AS 'Number'
                                                        FROM Receipt INNER JOIN ReceiptDetail ON Receipt.RECEIPTID = ReceiptDetail.RECEIPTID
                                                        WHERE ReceiptDetail.RECEIPTID LIKE '" + searchReceiptIDTxtBox.Text + "%' GROUP BY ReceiptDetail.RECEIPTID ORDER BY ReceiptDetail.RECEIPTID");
            grid_numOfReceipt.DataSource = cn.GetDataTable(@"SELECT substring(DATE, 1, 10) as 'DATE', COUNT(RECEIPTID) AS 'Number'
                                                        FROM Receipt
                                                        WHERE Receipt.DATE LIKE '" + searchDateTxtBox.Text + "%'GROUP BY substring(DATE, 1, 10) ORDER BY DATE");
            grid_revenueByDate.DataSource = cn.GetDataTable(@"SELECT SUBSTRING(Receipt.DATE,1, 10) as 'DATE', sum(Receipt.TOTAL) AS 'DATEREVENUE'
                                                        FROM Receipt
                                                        WHERE Receipt.DATE LIKE '" + searchDateTxtBox.Text + "%' GROUP BY SUBSTRING(ReceipT.DATE,1, 10)");
        }

        private void filterGrid()
        {
            try
            {
                if (searchDateTxtBox.Text == "")
                {
                    suportFilter("Receipt.RECEIPTID LIKE '" + searchReceiptIDTxtBox.Text + "%'");
                }
                else if (searchReceiptIDTxtBox.Text == "")
                {
                    suportFilter("Receipt.DATE LIKE '" + searchDateTxtBox.Text + "%'");
                }
                else
                {
                    suportFilter("Receipt.DATE LIKE '" + searchDateTxtBox.Text + "%' AND Receipt.RECEIPTID LIKE '" + searchReceiptIDTxtBox.Text + "%'");
                }
            }
            catch
            {
                
            }

        }

        private void grid_detail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                searchReceiptIDTxtBox.Text = grid_detail.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch
            {

            }
        }

        private void searchDateTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            searchReceiptIDTxtBox.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(grid_detail, sfd.FileName); // Here dataGridview1 is your grid view name
                MessageBox.Show("Successfully Exported");
            }
        }

        private void ToCsV(DataGridView dGV, string filename)
        {
            try
            {
                string stOutput = "";
                // Export titles:
                string sHeaders = "";

                for (int j = 0; j < dGV.Columns.Count; j++)
                    sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
                stOutput += sHeaders + "\r\n";
                // Export data.
                for (int i = 0; i < dGV.RowCount; i++)
                {
                    string stLine = "";
                    for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                        stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                    stOutput += stLine + "\r\n";
                }
                Encoding utf16 = Encoding.GetEncoding(1254);
                byte[] output = utf16.GetBytes(stOutput);
                FileStream fs = new FileStream(filename, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(output, 0, output.Length); //write the encoded file
                bw.Flush();
                bw.Close();
                fs.Close();
            }
            catch
            {
                return;
            }
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            System.Drawing.Bitmap bitmap1 = AccountingSystemUI.Properties.Resources.excelIcon1_hover_ico_256x256;
            pictureBox2.Image = bitmap1;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            System.Drawing.Bitmap bitmap1 = AccountingSystemUI.Properties.Resources.excelIcon1;
            pictureBox2.Image = bitmap1;
        }
    }
}
