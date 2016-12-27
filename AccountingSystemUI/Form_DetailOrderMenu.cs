using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingSystemEntity;
using AccountingSystemBUS;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using AccountingSystemDAL;

namespace AccountingSystemUI
{
    public partial class Form_DetailOrderMenu : Form
    {
        EC_tblMenuItems ecItem = new EC_tblMenuItems();
        EC_tblReceipt ecReceipt = new EC_tblReceipt();
        EC_tblReceiptDetail ecReceiptDetail = new EC_tblReceiptDetail();
        EC_tblStaffs ecStaff = new EC_tblStaffs();

        Bus_tblMenuItems busItem = new Bus_tblMenuItems();
        Bus_tblReceipt busReceipt = new Bus_tblReceipt();
        Bus_tblReceiptDetail busReceiptDetail = new Bus_tblReceiptDetail();
        Bus_tblStaffs busStaff = new Bus_tblStaffs();

        DataTable rptDataTable;
        BillPrinter report = new BillPrinter();
        Form_Products form = new Form_Products();

        List<String> chosenItem = new List<String>();
        public string staffID;
        private bool saveSuccess = false;
        DBConnection cn = new DBConnection();

        int row = 0;
        string subtotal;
        double vatPercent, discountPercent, servicePercent;
        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");

        SqlTransaction trans = null;

        public Form_DetailOrderMenu()
        {
            InitializeComponent();
        }

        private void grid_Order_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String chosenName = grid_Order.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (chosenItem.Contains(chosenName))
                {
                    for (int i = 0; i < chosenItem.Count; i++)
                    {
                        if (chosenItem[i].Equals(chosenName))
                        {
                            row = i;
                        }
                    }
                    grid_Receipt.Rows[row].Cells[1].Value = Convert.ToInt32(grid_Receipt.Rows[row].Cells[1].Value) + 1;
                    grid_Receipt.Rows[row].Cells[4].Value = Convert.ToInt32(grid_Receipt.Rows[row].Cells[1].Value) * Convert.ToDouble(grid_Receipt.Rows[row].Cells[2].Value);
                }
                else
                {
                    int n = grid_Receipt.Rows.Add();
                    chosenItem.Add(chosenName);
                    string productID = grid_Order.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string productPrice = form.txtBoxFormat(busItem.getSqlString("PRODUCTPRICE", "where PRODUCTID = '" + productID + "'"));
                    grid_Receipt.Rows[n].Cells[0].Value = grid_Order.Rows[e.RowIndex].Cells[1].Value.ToString();
                    grid_Receipt.Rows[n].Cells[1].Value = 1;
                    grid_Receipt.Rows[n].Cells[2].Value = productPrice;
                    grid_Receipt.Rows[n].Cells[3].Value = 0;
                    grid_Receipt.Rows[n].Cells[4].Value = productPrice;
                    grid_Receipt.Rows[n].Cells[6].Value = productID;
                }
                grid_Receipt.Update();
                calculateTotal();
            }
            catch
            {
                MessageBox.Show("Error while add to purchase list.");
            }
        }

        public void filterGrid()
        {
            try
            {
                if (searchIDTxtBox.Text == "")
                {
                    grid_Order.DataSource = busItem.selectField("MenuItems.PRODUCTID, MenuItems.PRODUCTNAME", "WHERE MenuItems.PRODUCTNAME LIKE '" + searchNameTxtBox.Text + "%' AND MenuItems.STATUS = '1'");
                }
                else if (searchNameTxtBox.Text == "")
                {
                    grid_Order.DataSource = busItem.selectField("MenuItems.PRODUCTID, MenuItems.PRODUCTNAME", "WHERE MenuItems.PRODUCTID like '" + searchIDTxtBox.Text + "%' AND MenuItems.STATUS = '1'");
                }
                else
                {
                    grid_Order.DataSource = busItem.selectField("MenuItems.PRODUCTID, MenuItems.PRODUCTNAME", "WHERE MenuItems.PRODUCTID like '" + searchIDTxtBox.Text + "%' AND MenuItems.PRODUCTNAME LIKE '" + searchNameTxtBox.Text + "%' AND MenuItems.STATUS = '1'");
                }
            }
            catch
            {
                MessageBox.Show("Cannot search from input");
            }
        }

        private void searchIDTxtBox_TextChanged(object sender, EventArgs e)
        {
            filterGrid();
        }

        private void searchNameTxtBox_TextChanged(object sender, EventArgs e)
        {
            filterGrid();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            dateTxtBox.Text = dateTime.ToString();
        }

        private void grid_Receipt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String chosenName = grid_Receipt.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (Convert.ToInt32(grid_Receipt.Rows[e.RowIndex].Cells[1].Value) == 1)
                {
                    grid_Receipt.Rows.RemoveAt(e.RowIndex);
                    chosenItem.Remove(chosenName);
                    calculateTotal();
                    return;
                }

                grid_Receipt.Rows[e.RowIndex].Cells[1].Value = Convert.ToInt32(grid_Receipt.Rows[e.RowIndex].Cells[1].Value) - 1;
                grid_Receipt.Rows[e.RowIndex].Cells[4].Value = Convert.ToInt32(grid_Receipt.Rows[e.RowIndex].Cells[1].Value) * Convert.ToDouble(grid_Receipt.Rows[e.RowIndex].Cells[2].Value);
                calculateTotal();
            }
            catch
            {
                MessageBox.Show("Error while deleting item");
                return;
            }
        }

        private void grid_Receipt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String chosenName = grid_Receipt.Rows[e.RowIndex].Cells[0].Value.ToString();

                var senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    grid_Receipt.Rows.RemoveAt(e.RowIndex);
                    chosenItem.Remove(chosenName);
                    calculateTotal();
                }
            }
            catch
            {
                MessageBox.Show("Cannot delete item from list");
            }
        }

        public void calculateTotal()
        {
            try
            {
                double total = 0;
                for (int i = 0; i < grid_Receipt.RowCount; i++)
                {
                    total += Convert.ToDouble(grid_Receipt.Rows[i].Cells[4].Value.ToString());
                }
                subtotal = form.txtBoxFormat(total.ToString());
                totalTxtBox.Text = form.txtBoxFormat((total + total * servicePercent + total * vatPercent + total * discountPercent).ToString());
            }
            catch
            {
                totalTxtBox.Text = "0";
                MessageBox.Show("Error while calculating total");
            }
        }

        private void saveAndPrint(bool isPrinted)
        {
            rptDataTable = new DataTable("Report");
            if (grid_Receipt.RowCount == 0)
            {
                MessageBox.Show("No order is chosen");
                return;
            }
            try
            {
                cn.cnOpen();
                trans = cn.getConnection().BeginTransaction();
                SqlCommand cmd = new SqlCommand("INSERT INTO Receipt(RECEIPTID, DATE, STAFFID, TOTAL) VALUES (N'" + receiptIDTxtBox.Text
                                                + "', N'" + dateTxtBox.Text + "', N'" + staffIDTxtBox.Text + "', N'" + totalTxtBox.Text + "')", cn.getConnection(), trans);
                cmd.ExecuteNonQuery();
                for (int i = 0; i < grid_Receipt.RowCount; i++)
                {
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO ReceiptDetail(RECEIPTID, PRODUCTID, AMOUNT, TOTAL) VALUES (N'"
                                                    + receiptIDTxtBox.Text + "', N'" + grid_Receipt.Rows[i].Cells[6].Value.ToString()
                                                    + "', N'" + Convert.ToInt32(grid_Receipt.Rows[i].Cells[1].Value.ToString()) + "', N'"
                                                    + Convert.ToDecimal(grid_Receipt.Rows[i].Cells[4].Value.ToString()) + "')", cn.getConnection(), trans);
                    cmd2.ExecuteNonQuery();
                }
                trans.Commit();
                trans.Dispose();
                cn.cnClose();

                //Condition for button
                printBtn.Enabled = false;
                saveBtn.Enabled = false;

                if (!isPrinted)
                {
                    MessageBox.Show("Successfully save receipt");
                    return;
                }

                //Provide data for report
                rptDataTable.Columns.Add("Name");
                rptDataTable.Columns.Add("Quantity");
                rptDataTable.Columns.Add("Price");
                for (int i = 0; i < grid_Receipt.RowCount; i++)
                {
                    DataRow row = rptDataTable.NewRow();
                    row["Name"] = grid_Receipt.Rows[i].Cells[0].Value.ToString();
                    row["Quantity"] = grid_Receipt.Rows[i].Cells[1].Value.ToString();
                    row["Price"] = grid_Receipt.Rows[i].Cells[2].Value.ToString();
                    rptDataTable.Rows.Add(row);
                }
                saveSuccess = true;
            }
            catch
            {
                trans.Rollback();
                trans.Dispose();
                MessageBox.Show("Error while saving receipt");
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveAndPrint(false);
        }

        private void discardBtn_Click(object sender, EventArgs e)
        {
            try
            {
                printBtn.Enabled = true;
                saveBtn.Enabled = true;

                int totalOfReceipt = Convert.ToInt32(busReceipt.getQueryString("count(RECEIPTID)", ""));
                generateReceiptID(busReceipt.select("").Rows[totalOfReceipt - 1][0].ToString());
                grid_Receipt.Rows.Clear();
                totalTxtBox.Text = "";
                chosenItem = new List<string>();
                row = 0;
            }
            catch
            {
                MessageBox.Show("Cannot discard this receipt at the moment");
                return;
            }
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid_Receipt.RowCount == 0)
                {
                    MessageBox.Show("No order is chosen");
                    return;
                }

                saveAndPrint(true);
                if (!saveSuccess)
                {
                    return;
                }
                report.DataSource = rptDataTable;
                report.DataMember = "Report";
                report.bindDataSource();
                report.bindData(receiptIDTxtBox.Text, staffIDTxtBox.Text, dateTxtBox.Text, subtotal, serviceTxtBox.Text, vatTxtBox.Text, totalTxtBox.Text, Convert.ToInt32(grid_Receipt.RowCount));
                report.CreateDocument();
                report.ShowPreview();
            }
            catch
            {
                MessageBox.Show("Error while printing");
                return;
            }
        }

        private void Form_DetailOrderMenu_Load(object sender, EventArgs e)
        {
            try
            {
                this.grid_Order.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
                this.grid_Order.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);
                //this.grid_Order.Columns[0].Width = 120;
                this.grid_Receipt.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
                this.grid_Receipt.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);
                this.grid_Receipt.Columns[0].Width = 200;


                grid_Order.DataSource = busItem.selectField("MenuItems.PRODUCTID, MenuItems.PRODUCTNAME", "WHERE MenuItems.STATUS = '1' ORDER BY PRODUCTNAME ASC");
                int totalOfReceipt = Convert.ToInt32(busReceipt.getQueryString("count(RECEIPTID)", ""));
                generateReceiptID(busReceipt.select("").Rows[totalOfReceipt - 1][0].ToString());

                serviceTxtBox.Text = "5";
                servicePercent = Convert.ToDouble(serviceTxtBox.Text) / 100;
                vatTxtBox.Text = "10";
                vatPercent = Convert.ToDouble(vatTxtBox.Text) / 100;
                discountTxtBox.Text = "0";
                discountPercent = Convert.ToDouble(discountTxtBox.Text) / 100;

                staffIDTxtBox.Text = staffID;
                timer1.Start();
            }
            catch
            {
                MessageBox.Show("Error while loading menu");
            }
        }

        public void generateReceiptID(String numReceipt)
        {
            String p1 = "";
            int subP1;
            String p2 = "";
            String p3 = "";
            int newestNum;
            int maxP1 = 2;
            int maxP2 = 4;


            if (busReceipt.select("").Rows.Count == 0)
            {
                numReceipt = "HD01-0000";
            }

            newestNum = Convert.ToInt32(numReceipt.Substring(numReceipt.Length - 5 + 1));
            subP1 = Convert.ToInt32(numReceipt.Substring(2, numReceipt.Length - 7));

            if (newestNum != 9999)
                p3 = (newestNum + 1).ToString();
            else
            {
                p3 = "1";
                subP1 += 1;
            }

            for (int i = 1; i <= (maxP2 - p3.Length); i++)
            {
                p2 += "0";
            }

            for (int i = 1; i <= (maxP1 - subP1.ToString().Length); i++)
            {
                p1 += "0";
            }

            receiptIDTxtBox.Text = "HD" + p1 + subP1 + "-" + p2 + p3;
        }

        private void printBtn_MouseHover(object sender, EventArgs e)
        {
            printBtn.BackColor = SystemColors.ActiveBorder;
            printBtn.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
        }

        private void printBtn_MouseLeave(object sender, EventArgs e)
        {
            printBtn.BackColor = SystemColors.Control;
            printBtn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
        }

        private void saveBtn_MouseHover(object sender, EventArgs e)
        {
            saveBtn.BackColor = SystemColors.ActiveBorder;
            saveBtn.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
        }

        private void saveBtn_MouseLeave(object sender, EventArgs e)
        {
            saveBtn.BackColor = SystemColors.Control;
            saveBtn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
        }

        private void discardBtn_MouseHover(object sender, EventArgs e)
        {
            discardBtn.BackColor = SystemColors.ActiveBorder;
            discardBtn.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
        }

        private void discardBtn_MouseLeave(object sender, EventArgs e)
        {
            discardBtn.BackColor = SystemColors.Control;
            discardBtn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
        }
    }
}

