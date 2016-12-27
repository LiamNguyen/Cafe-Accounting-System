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

namespace AccountingSystemUI
{
    public partial class Form_PopUpSearchStaff : Form
    {
        Bus_tblStaffs busStaff = new Bus_tblStaffs();
        public string IDSent = null;
        public string nameSent = null;
            
        public Form_PopUpSearchStaff()
        {
            InitializeComponent();
        }

        private void Form_PopUpSearchStaff_Load(object sender, EventArgs e)
        {
            this.grid.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            this.grid.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);
            grid.DataSource = busStaff.selectField("STAFFID, STAFFNAME, DOB, GENDER, PHONE, EMAIL", "");
            this.ActiveControl = searchIDTxtBox;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDSent = grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                nameSent = grid.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {

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

        public void filterGrid()
        {
            try
            {
                if (searchIDTxtBox.Text == "")
                {
                    grid.DataSource = busStaff.selectField("STAFFID, STAFFNAME, DOB, GENDER, PHONE, EMAIL", "STAFFNAME LIKE '" + searchNameTxtBox.Text + "%' OR STAFFNAME LIKE '%" + searchNameTxtBox.Text + "' AND");
                }
                else if (searchNameTxtBox.Text == "")
                {
                    grid.DataSource = busStaff.selectField("STAFFID, STAFFNAME, DOB, GENDER, PHONE, EMAIL", "STAFFID LIKE '" + searchIDTxtBox.Text + "%' AND");
                }
                else
                {
                    grid.DataSource = busStaff.selectField("STAFFID, STAFFNAME, DOB, GENDER, PHONE, EMAIL", "(STAFFID LIKE '" + searchIDTxtBox.Text + "%' OR STAFFNAME LIKE '" + searchNameTxtBox.Text + "%' OR STAFFNAME LIKE '%" + searchNameTxtBox.Text + "') AND");
                }

                if (searchIDTxtBox.Text == "" && searchNameTxtBox.Text == "")
                {
                    grid.DataSource = busStaff.selectField("STAFFID, STAFFNAME, DOB, GENDER, PHONE, EMAIL", "");
                }
            }
            catch
            {
                MessageBox.Show("Cannot search input");
                return;
            }
        }
    }
}
