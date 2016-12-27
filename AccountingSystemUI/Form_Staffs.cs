using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingSystemEntity;
using AccountingSystemBUS;
using AccountingSystemValidation;

namespace AccountingSystemUI
{
    public partial class Form_Staffs : Form
    {
        EC_tblStaffs ecStaff = new EC_tblStaffs();
        EC_tblPermission ecPermission = new EC_tblPermission();
        Bus_tblStaffs busStaff = new Bus_tblStaffs();
        Bus_tblPermission busPermission = new Bus_tblPermission();
        InputValidation validator = new InputValidation();
        List<TextBox> listTxtBox = new List<TextBox>();
        List<TextBox> listAllowNull = new List<TextBox>();
        List<TextBox> listDateTxtBox = new List<TextBox>();

        private bool isNew;
        public Form_Staffs()
        {
            InitializeComponent();
            listTxtBox.Add(idTxtBox);
            listTxtBox.Add(nameTxtBox);
            listTxtBox.Add(phoneTxtBox);

            listAllowNull.Add(addressTxtBox);

            listDateTxtBox.Add(dobTxtBox);
            listDateTxtBox.Add(startDayTxtBox);

            dobTxtBox.MaxLength = 10;
            startDayTxtBox.MaxLength = 10;
        }

        private void Form_Staffs_Load(object sender, EventArgs e)
        {
            this.grid.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            this.grid.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);

            this.grid.Columns[0].Width = 70; //id
            this.grid.Columns[1].Width = 160; //name
            this.grid.Columns[2].Width = 100; //dob
            this.grid.Columns[3].Width = 80; //gender
            this.grid.Columns[4].Width = 200; //address
            this.grid.Columns[5].Width = 110; //phone
            this.grid.Columns[6].Width = 200; //email
            this.grid.Columns[7].Width = 100; //start day

            lockInput();
            grid.DataSource = busStaff.select("");
        }

        public void lockInput()
        {
            idTxtBox.Enabled = false;
            nameTxtBox.Enabled = false;
            dobTxtBox.Enabled = false;
            genderComboBox.Enabled = false;
            addressTxtBox.Enabled = false;
            phoneTxtBox.Enabled = false;
            emailTxtBox.Enabled = false;
            startDayTxtBox.Enabled = false;
            saveBtn.Enabled = false;
            editBtn.Enabled = false;
            deleteBtn.Enabled = false;
            cancelBtn.Enabled = false;
        }

        public void unlockInput()
        {
            idTxtBox.Enabled = true;
            nameTxtBox.Enabled = true;
            dobTxtBox.Enabled = true;
            genderComboBox.Enabled = true;
            addressTxtBox.Enabled = true;
            phoneTxtBox.Enabled = true;
            emailTxtBox.Enabled = true;
            startDayTxtBox.Enabled = true;
            addBtn.Enabled = false;
            saveBtn.Enabled = true;
            cancelBtn.Enabled = true;
        }

        public void setNull()
        {
            idTxtBox.Text = "";
            nameTxtBox.Text = "";
            dobTxtBox.Text = "";
            genderComboBox.Text = "Male";
            addressTxtBox.Text = "";
            phoneTxtBox.Text = "";
            emailTxtBox.Text = "";
            startDayTxtBox.Text = "";

            if (!isNew)
            {
                foreach (TextBox txtB in listTxtBox)
                {
                    txtB.BackColor = SystemColors.Window;
                }

                foreach (TextBox txtB in listAllowNull)
                {
                    txtB.BackColor = SystemColors.Window;
                }

                foreach (TextBox txtB in listDateTxtBox)
                {
                    txtB.BackColor = SystemColors.Window;
                }
            }
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            unlockInput();
            editBtn.Enabled = false;
            deleteBtn.Enabled = false;
            isNew = true;
            setNull();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                String validatorResult = validator.validateInput(listTxtBox);
                String validatorResultAllowNull = validator.validateInputAllowNull(listAllowNull);
                String validatorResultDate = validator.validateDateFormatOnly(listDateTxtBox);

                if (validatorResult != null)
                {
                    MessageBox.Show(validatorResult);
                    return;
                }

                if (validatorResultAllowNull != null)
                {
                    MessageBox.Show(validatorResultAllowNull);
                    return;
                }

                if (validatorResultDate != null)
                {
                    MessageBox.Show(validatorResultDate);
                    return;
                }

                if (isNew)
                {
                    if (idTxtBox.Text == "" || nameTxtBox.Text == "" || dobTxtBox.Text == "" || phoneTxtBox.Text == "")
                    {
                        MessageBox.Show("Please fill in all the compulsory information.");
                        return;
                    }

                    if (busStaff.selectToValidate().Rows.Count > 0)
                    {
                        for (int i = 0; i < busStaff.selectToValidate().Rows.Count; i++)
                        {
                            if (idTxtBox.Text == busStaff.selectToValidate().Rows[i][0].ToString())
                            {
                                MessageBox.Show("ID has already existed");
                                return;
                            }
                        }
                    }

                    ecStaff.StaffID = idTxtBox.Text;
                    ecStaff.StaffName = nameTxtBox.Text;
                    ecStaff.Dob = dobTxtBox.Text;
                    ecStaff.Gender = genderComboBox.Text;
                    ecStaff.Address = addressTxtBox.Text;
                    ecStaff.Email = emailTxtBox.Text;
                    ecStaff.Phone = phoneTxtBox.Text;
                    ecStaff.StartWorkDay = startDayTxtBox.Text;
                    
                    busStaff.insert(ecStaff);
                    grid.DataSource = busStaff.select("");
                    MessageBox.Show("Successfully added new staff.");
                    isNew = false;
                }
                else
                {
                    if (idTxtBox.Text == "" || nameTxtBox.Text == "" || dobTxtBox.Text == "" || phoneTxtBox.Text == "")
                    {
                        MessageBox.Show("Please fill in all the compulsory information.");
                        return;
                    }

                    ecStaff.StaffID = idTxtBox.Text;
                    ecStaff.StaffName = nameTxtBox.Text;
                    ecStaff.Dob = dobTxtBox.Text;
                    ecStaff.Gender = genderComboBox.Text;
                    ecStaff.Address = addressTxtBox.Text;
                    ecStaff.Email = emailTxtBox.Text;
                    ecStaff.Phone = phoneTxtBox.Text;
                    ecStaff.StartWorkDay = startDayTxtBox.Text;

                    busStaff.update(ecStaff);
                    grid.DataSource = busStaff.select("");
                    MessageBox.Show("Successfully edited new staff.");
                }

                setNull();
                lockInput();
                addBtn.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Error while saving new staff. Please check the input above. Thank You.");
            }
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
                    ecStaff.StaffID = idTxtBox.Text;
                    ecPermission.StaffID = idTxtBox.Text;
                    busStaff.delete(ecStaff);
                    busPermission.delete(ecPermission);
                    setNull();
                    grid.DataSource = busStaff.select("");
                    MessageBox.Show("Successfully deleted staff.");
                    lockInput();
                }
                else
                {
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Error while deleting staff.");
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
                dobTxtBox.Text = grid.Rows[e.RowIndex].Cells[2].Value.ToString();
                genderComboBox.Text = grid.Rows[e.RowIndex].Cells[3].Value.ToString();
                addressTxtBox.Text = grid.Rows[e.RowIndex].Cells[4].Value.ToString();
                phoneTxtBox.Text = grid.Rows[e.RowIndex].Cells[5].Value.ToString();
                emailTxtBox.Text = grid.Rows[e.RowIndex].Cells[6].Value.ToString();
                startDayTxtBox.Text = grid.Rows[e.RowIndex].Cells[7].Value.ToString();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(grid, sfd.FileName); // Here dataGridview1 is your grid view name
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
    }
}
