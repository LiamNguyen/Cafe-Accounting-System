using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingSystemBUS;
using AccountingSystemEntity;
using AccountingSystemValidation;

namespace AccountingSystemUI
{
    public partial class Form_Products : Form
    {
        EC_tblMenuItems ecItem = new EC_tblMenuItems();
        Bus_tblMenuItems busItem = new Bus_tblMenuItems();
        private bool isNew;
        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
        InputValidation validator = new InputValidation();
        List<TextBox> listTxtBox = new List<TextBox>();

        public Form_Products()
        {
            InitializeComponent();
            listTxtBox.Add(idTxtBox);
            listTxtBox.Add(nameTxtBox);
        }

        private void Form_Products_Load(Object sender, EventArgs e)
        {
            this.grid.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            this.grid.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);

            lockInput();
            grid.DataSource = busItem.selectField("MenuItems.PRODUCTID, MenuItems.PRODUCTNAME, PriceDetail.PRODUCTPRICE", "WHERE MenuItems.STATUS = '1' ORDER BY MenuItems.PRODUCTNAME ASC");
        }

        public void lockInput()
        {
            idTxtBox.Enabled = false;
            nameTxtBox.Enabled = false;
            priceTxtBox.Enabled = false;
            saveBtn.Enabled = false;
            editBtn.Enabled = false;
            deleteBtn.Enabled = false;
            cancelBtn.Enabled = false;
        }

        public void unlockInput()
        {
            idTxtBox.Enabled = true;
            nameTxtBox.Enabled = true;
            priceTxtBox.Enabled = true;
            addBtn.Enabled = false;
            saveBtn.Enabled = true;
            cancelBtn.Enabled = true;
        }

        public void setNull()
        {
            idTxtBox.Text = "";
            nameTxtBox.Text = "";
            priceTxtBox.Text = "";
            if (!isNew)
            {
                foreach (TextBox txtB in listTxtBox)
                {
                    txtB.BackColor = SystemColors.Window;
                }
            }
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                unlockInput();
                editBtn.Enabled = false;
                deleteBtn.Enabled = false;
                isNew = true;
                setNull();
            }
            catch (Exception)
            {
                MessageBox.Show("Error when requiring to add");
            }
        }

        private void saveFunction()
        {
            try
            {
                String validateResult = validator.validateInput(listTxtBox);

                if (validateResult != null)
                {
                    MessageBox.Show(validateResult);
                    return;
                }

                if (isNew)
                {
                    if (priceTxtBox.TextLength < 4)
                    {
                        MessageBox.Show("Are you sure the product's price is correct?");
                        return;
                    }

                    if (busItem.selectField("MenuItems.PRODUCTID", "WHERE MenuItems.STATUS = '1'").Rows.Count > 0)
                    {
                        for (int i = 0; i < busItem.selectField("MenuItems.PRODUCTID", "WHERE MenuItems.STATUS = '1'").Rows.Count; i++)
                        {
                            if (idTxtBox.Text == busItem.selectField("MenuItems.PRODUCTID", "WHERE MenuItems.STATUS = '1'").Rows[i][0].ToString())
                            {
                                MessageBox.Show("ID has already existed");
                                return;
                            }
                        }
                    }

                    ecItem.ProductID = idTxtBox.Text;
                    ecItem.ProductName = nameTxtBox.Text;
                    ecItem.ProductPrice = priceTxtBox.Text;

                    busItem.insert(ecItem);
                    grid.DataSource = busItem.selectField("MenuItems.PRODUCTID, MenuItems.PRODUCTNAME, PriceDetail.PRODUCTPRICE", "WHERE MenuItems.STATUS = '1' ORDER BY MenuItems.PRODUCTNAME ASC");
                    MessageBox.Show("Successfully added new product.");
                    isNew = false;
                }
                else
                {
                    if (priceTxtBox.TextLength < 4)
                    {
                        MessageBox.Show("Are you sure the product's price is correct?");
                        return;
                    }

                    ecItem.ProductID = idTxtBox.Text;
                    ecItem.ProductName = nameTxtBox.Text;
                    ecItem.ProductPrice = priceTxtBox.Text;

                    busItem.update(ecItem);
                    grid.DataSource = busItem.selectField("MenuItems.PRODUCTID, MenuItems.PRODUCTNAME, PriceDetail.PRODUCTPRICE", "WHERE MenuItems.STATUS = '1' ORDER BY MenuItems.PRODUCTNAME ASC");
                    MessageBox.Show("Successfully edited new product.");
                }

                setNull();
                lockInput();
                addBtn.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Error while saving new product");
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveFunction();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            isNew = false;
            unlockInput();
            idTxtBox.Enabled = false;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ecItem.ProductID = idTxtBox.Text;
                    busItem.delete(ecItem);
                    setNull();
                    grid.DataSource = busItem.selectField("MenuItems.PRODUCTID, MenuItems.PRODUCTNAME, PriceDetail.PRODUCTPRICE", "WHERE MenuItems.STATUS = '1' ORDER BY PRODUCTNAME ASC");
                    MessageBox.Show("Successfully deleted product.");
                    lockInput();
                }
                else
                {
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Error while deleting product.");
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isNew)
            {
                return;
            }
            editBtn.Enabled = true;
            deleteBtn.Enabled = true;
            
            try
            {
                idTxtBox.Text = grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                nameTxtBox.Text = grid.Rows[e.RowIndex].Cells[1].Value.ToString();
                priceTxtBox.Text = priceTxtBoxFormat(grid.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
            catch
            {

            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            setNull();
            lockInput();
            addBtn.Enabled = true;
            isNew = false;
        }

        public String priceTxtBoxFormat(String unformatStr)
        {
            String modifiedStr = "";
            int dotIndex = 0;

            if (unformatStr.Contains("."))
                dotIndex = unformatStr.IndexOf(".");
            else
                dotIndex = unformatStr.IndexOf(",");

            for (int i = 0; i < dotIndex; i++)
            {
                modifiedStr += unformatStr[i];
            }
                return modifiedStr;
        }

        public String txtBoxFormat(string unformatStr)
        {
            Double value;
            if (Double.TryParse(unformatStr, out value))
            {
                return string.Format(culture, "{0:n0}", value);
            }
            else
            {
                return string.Empty;
            }
        }

        private void priceTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                {
                    saveFunction();
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void priceTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            validator.validateNumberOnly(sender, e);
        }

        private void addBtn_MouseHover(object sender, EventArgs e)
        {
            addBtn.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            addBtn.BackColor = SystemColors.ActiveBorder;
        }

        private void addBtn_MouseLeave(object sender, EventArgs e)
        {
            addBtn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            addBtn.BackColor = SystemColors.Control;
        }

        private void saveBtn_MouseHover(object sender, EventArgs e)
        {
            saveBtn.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            saveBtn.BackColor = SystemColors.ActiveBorder;
        }

        private void saveBtn_MouseLeave(object sender, EventArgs e)
        {
            saveBtn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            saveBtn.BackColor = SystemColors.Control;
        }

        private void editBtn_MouseHover(object sender, EventArgs e)
        {
            editBtn.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            editBtn.BackColor = SystemColors.ActiveBorder;
        }

        private void editBtn_MouseLeave(object sender, EventArgs e)
        {
            editBtn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            editBtn.BackColor = SystemColors.Control;
        }

        private void deleteBtn_MouseHover(object sender, EventArgs e)
        {
            deleteBtn.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            deleteBtn.BackColor = SystemColors.ActiveBorder;
        }

        private void deleteBtn_MouseLeave(object sender, EventArgs e)
        {
            deleteBtn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            deleteBtn.BackColor = SystemColors.Control;
        }

        private void cancelBtn_MouseHover(object sender, EventArgs e)
        {
            cancelBtn.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            cancelBtn.BackColor = SystemColors.ActiveBorder;
        }

        private void cancelBtn_MouseLeave(object sender, EventArgs e)
        {
            cancelBtn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            cancelBtn.BackColor = SystemColors.Control;
        }
    }
}
