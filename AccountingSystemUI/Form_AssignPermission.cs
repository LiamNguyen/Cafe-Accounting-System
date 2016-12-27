using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingSystemEntity;
using AccountingSystemBUS;
using AccountingSystemValidation;

namespace AccountingSystemUI
{
    public partial class Form_AssignPermission : Form
    {
        Form_PopUpSearchStaff popUpForm = new Form_PopUpSearchStaff();
        EC_tblPermission ecPermission = new EC_tblPermission();
        Bus_tblPermission busPermission = new Bus_tblPermission();
        List<CheckBox> listCheckBox = new List<CheckBox>();

        InputValidation validator = new InputValidation();
        List<TextBox> listTxtBox = new List<TextBox>();

        private Boolean isNew = false;
        public String staffID;

        public Form_AssignPermission()
        {
            InitializeComponent();
            listTxtBox.Add(loginIDTxtBox);
            listTxtBox.Add(passwordTxtBox);
        }

        private void Form_AssignPermission_Load(object sender, EventArgs e)
        {
            this.grid.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            this.grid.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);

            grid.DataSource = busPermission.select("WHERE PERMISSION.STATUS = '1' ORDER BY STAFFID");

            hidePass();

            listCheckBox.Add(orderCheckBox);
            listCheckBox.Add(staffCheckBox);
            listCheckBox.Add(stockCheckBox);
            listCheckBox.Add(rightsCheckBox);
            listCheckBox.Add(reportCheckBox);
            listCheckBox.Add(productsCheckBox);

            grid.Columns[1].Width = 200;
            grid.Columns[3].Width = 150;

            lockInput();
        }

        private void search_Click(object sender, EventArgs e)
        {
            if (popUpForm.ShowDialog() == DialogResult.OK)
            {
                unlockInput();
                clear();
                idTxtBox.Text = popUpForm.IDSent;
                nameTxtBox.Text = popUpForm.nameSent;
                isNew = true;
            }
        }

        public void lockInput()
        {
            idTxtBox.Enabled = false;
            nameTxtBox.Enabled = false;
            loginIDTxtBox.Enabled = false;
            passwordTxtBox.Enabled = false;
            orderCheckBox.Enabled = false;
            staffCheckBox.Enabled = false;
            stockCheckBox.Enabled = false;
            rightsCheckBox.Enabled = false;
            reportCheckBox.Enabled = false;
            productsCheckBox.Enabled = false;
            assignNewBtn.Enabled = true;
            assignNewBtn.Enabled = false;
            editBtn.Enabled = false;
            discardBtn.Enabled = false;
        }

        public void unlockInput()
        {
            idTxtBox.Enabled = false;
            nameTxtBox.Enabled = false;
            loginIDTxtBox.Enabled = true;
            passwordTxtBox.Enabled = true;
            orderCheckBox.Enabled = true;
            staffCheckBox.Enabled = true;
            stockCheckBox.Enabled = true;
            rightsCheckBox.Enabled = true;
            reportCheckBox.Enabled = true;
            productsCheckBox.Enabled = true;
            assignNewBtn.Enabled = false;
            assignNewBtn.Enabled = true;
            discardBtn.Enabled = true;
        }

        public void clear()
        {
            idTxtBox.Text = "";
            nameTxtBox.Text = "";
            loginIDTxtBox.Text = "";
            passwordTxtBox.Text = "";
            orderCheckBox.Checked = false;
            staffCheckBox.Checked = false;
            stockCheckBox.Checked = false;
            rightsCheckBox.Checked = false;
            reportCheckBox.Checked = false;
            productsCheckBox.Checked = false;

            foreach (TextBox txtB in listTxtBox) 
            {
                txtB.BackColor = SystemColors.Window;
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (isNew)
                {
                    return;
                }
                editBtn.Enabled = true;

                idTxtBox.Text = grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                nameTxtBox.Text = grid.Rows[e.RowIndex].Cells[1].Value.ToString();
                loginIDTxtBox.Text = grid.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (e.RowIndex == 0)
                {
                    passwordTxtBox.Text = encode(grid.Rows[0].Cells[3].Value.ToString());
                    return;
                }
                passwordTxtBox.Text = grid.Rows[e.RowIndex].Cells[3].Value.ToString();
                showCheckedOrUnchecked(e.RowIndex);
            }
            catch
            {

            }
        }

        public void showCheckedOrUnchecked(int rowIndex)
        {
            for (int i = 4; i <= 9; i++)
            {
                listCheckBox[i - 4].Checked = Convert.ToBoolean(grid.Rows[rowIndex].Cells[i].Value.ToString());
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            isNew = false;
            unlockInput();
            idTxtBox.Enabled = false;
            nameTxtBox.Enabled = false;
            if (staffID != "AD01" && loginIDTxtBox.Text == "admin")
            {
                loginIDTxtBox.Enabled = false;
                passwordTxtBox.Enabled = false;
                MessageBox.Show("Only administrator is able to edit his account. Thank you");
            }
        }

        private void discardBtn_Click(object sender, EventArgs e)
        {
            clear();
            lockInput();
            isNew = false;
        }

        private void assignNewBtn_Click(object sender, EventArgs e)
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
                    ecPermission.StaffID = idTxtBox.Text;
                    ecPermission.LoginID = loginIDTxtBox.Text;
                    ecPermission.Password = passwordTxtBox.Text;
                    ecPermission.PerOrder = orderCheckBox.Checked;
                    ecPermission.PerStaffs = staffCheckBox.Checked;
                    ecPermission.PerStock = stockCheckBox.Checked;
                    ecPermission.PerRightsControl = rightsCheckBox.Checked;
                    ecPermission.PerReport = reportCheckBox.Checked;
                    ecPermission.PerMenuItems = productsCheckBox.Checked;

                    busPermission.insert(ecPermission);
                    grid.DataSource = busPermission.select("WHERE PERMISSION.STATUS = '1' ORDER BY STAFFID");
                    hidePass();
                    MessageBox.Show("Successfully assigned permission for new staff");
                    isNew = false;
                }
                else
                {
                    ecPermission.StaffID = idTxtBox.Text;
                    ecPermission.LoginID = loginIDTxtBox.Text;
                    ecPermission.Password = passwordTxtBox.Text;
                    ecPermission.PerOrder = orderCheckBox.Checked;
                    ecPermission.PerStaffs = staffCheckBox.Checked;
                    ecPermission.PerStock = stockCheckBox.Checked;
                    ecPermission.PerRightsControl = rightsCheckBox.Checked;
                    ecPermission.PerReport = reportCheckBox.Checked;
                    ecPermission.PerMenuItems = productsCheckBox.Checked;

                    busPermission.update(ecPermission);
                    grid.DataSource = busPermission.select("WHERE PERMISSION.STATUS = '1' ORDER BY STAFFID");
                    hidePass();
                    MessageBox.Show("Successfully edited assigning permission for new staff");
                }
                lockInput();
                clear();
            }
            catch
            {
                MessageBox.Show("Error while assigning permission");
                return;
            }
        }

        private void assignNewBtn_MouseHover(object sender, EventArgs e)
        {
            assignNewBtn.BackColor = SystemColors.ActiveBorder;
            assignNewBtn.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
        }

        private void assignNewBtn_MouseLeave(object sender, EventArgs e)
        {
            assignNewBtn.BackColor = SystemColors.Control;
            assignNewBtn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
        }

        private void editBtn_MouseHover(object sender, EventArgs e)
        {
            editBtn.BackColor = SystemColors.ActiveBorder;
            editBtn.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
        }

        private void editBtn_MouseLeave(object sender, EventArgs e)
        {
            editBtn.BackColor = SystemColors.Control;
            editBtn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
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

        public void hidePass()
        {
            grid.Rows[0].Cells[3].Value = encode(grid.Rows[0].Cells[3].Value.ToString());
        }

        public String encode(String str)
        {
            String modifiedStr = str;

            if (staffID == "AD01")
            {
                return str;
            }

            for (int i = 0; i < str.Length; i++)
            {
                modifiedStr = modifiedStr.Replace(str[i], '*');
            }
            return modifiedStr;
        }
    }
}
