using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using AccountingSystemBUS;
using AccountingSystemEntity;
using AccountingSystemValidation;

namespace AccountingSystemUI
{
    public partial class Form_StockManagement : Form
    {
        EC_tblIngredientsGroup ecGroup = new EC_tblIngredientsGroup();
        EC_tblIngredients ecIng = new EC_tblIngredients();
        EC_tblIngredientsDetail ecIngDetail = new EC_tblIngredientsDetail();

        Bus_tblIngredientsGroup busGroup = new Bus_tblIngredientsGroup();
        Bus_tblIngredients busIng = new Bus_tblIngredients();

        Form_Products form = new Form_Products();

        List<TextBox> allTxtBox = new List<TextBox>();
        List<TextBox> dateTxtBox = new List<TextBox>();
        List<TextBox> listGroupTxtbox = new List<TextBox>();
        InputValidation validator = new InputValidation();

        private bool isNew, isNewIng;

        public String staffID;
        private DateTime datetime;

        public Form_StockManagement()
        {
            InitializeComponent();

            allTxtBox.Add(txt_IngID);
            allTxtBox.Add(txt_IngName);
            allTxtBox.Add(txt_PackageNo);
            allTxtBox.Add(txt_Quantity);
            allTxtBox.Add(txt_Vat);

            listGroupTxtbox.Add(groupIdTxtBox);
            listGroupTxtbox.Add(groupNameTxtBox);

            dateTxtBox.Add(txt_ExpDate);
        }

        private void Form_StockManagement_Load(object sender, System.EventArgs e)
        {
            this.grid_Group.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            this.grid_Group.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);
            this.grid_Ingredients.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            this.grid_Ingredients.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14);


            lockInput();
            lockInputIng();
            grid_Group.DataSource = busGroup.select();
            grid_Ingredients.DataSource = busIng.select();
            cmbBox_Group.DataSource = busGroup.select();
            cmbBox_Group.ValueMember = "GROUP_ID";
            cmbBox_Group.DisplayMember = "GROUP_NAME";
            timer1.Start();
        }

        #region GroupTab

        public void lockInput()
        {
            groupIdTxtBox.Enabled = false;
            groupNameTxtBox.Enabled = false;
            saveBtn.Enabled = false;
            editBtn.Enabled = false;
            deleteBtn.Enabled = false;
            cancelBtn.Enabled = false;
        }

        public void unlockInput()
        {
            groupIdTxtBox.Enabled = true;
            groupNameTxtBox.Enabled = true;
            addNewGroupBtn.Enabled = false;
            saveBtn.Enabled = true;
            cancelBtn.Enabled = true;
        }

        public void setNull()
        {
            groupIdTxtBox.Text = "";
            groupNameTxtBox.Text = "";

            if (!isNew)
            {
                foreach (TextBox txtB in allTxtBox)
                {
                    txtB.BackColor = SystemColors.Window;
                }
            }
        }

        private void addNewGroupBtn_Click(object sender, EventArgs e)
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
                String validatorResult = validator.validateInput(listGroupTxtbox);
                if (validatorResult != null)
                {
                    MessageBox.Show(validatorResult);
                    return;
                }

                if (isNew)
                {
                    if (groupIdTxtBox.Text == "" || groupNameTxtBox.Text == "")
                    {
                        MessageBox.Show("Please fill in all the compulsory information.");
                        return;
                    }

                    if (busGroup.select().Rows.Count > 0)
                    {
                        for (int i = 0; i < busGroup.select().Rows.Count; i++)
                        {
                            if (groupIdTxtBox.Text == busGroup.select().Rows[i][0].ToString())
                            {
                                MessageBox.Show("ID has already existed");
                                return;
                            }
                        }
                    }

                    ecGroup.GroupID = groupIdTxtBox.Text;
                    ecGroup.GroupName = groupNameTxtBox.Text;
                    ecGroup.Date = datetime.ToString();
                    ecGroup.StaffID = staffID;
                    ecGroup.UpdatedAt = datetime; 

                    busGroup.insert(ecGroup);
                    grid_Group.DataSource = busGroup.select();
                    MessageBox.Show("Successfully added new group.");
                    isNew = false;
                }
                else
                {
                    if (groupIdTxtBox.Text == "" || groupNameTxtBox.Text == "")
                    {
                        MessageBox.Show("Please fill in all the compulsory information.");
                        return;
                    }

                    ecGroup.GroupID = groupIdTxtBox.Text;
                    ecGroup.GroupName = groupNameTxtBox.Text;
                    ecGroup.UpdatedAt = datetime;

                    busGroup.update(ecGroup);
                    grid_Group.DataSource = busGroup.select();
                    MessageBox.Show("Successfully edited new group.");
                }
                setNull();
                lockInput();
                addNewGroupBtn.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Error while saving new group. Please check the input above. Thank You.");
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
            groupIdTxtBox.Enabled = false;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ecGroup.GroupID = groupIdTxtBox.Text;
                    busGroup.delete(ecGroup);
                    grid_Group.DataSource = busGroup.select();
                    setNull();
                    lockInput();
                }
                else
                {
                    return;
                }
            }
            catch 
            {
                MessageBox.Show("Error while deleting group");
            }
        }

        private void grid_Group_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isNew)
            {
                return;
            }
            editBtn.Enabled = true;
            deleteBtn.Enabled = true;

            try
            {
                groupIdTxtBox.Text = grid_Group.Rows[e.RowIndex].Cells[0].Value.ToString();
                groupNameTxtBox.Text = grid_Group.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch
            {

            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            setNull();
            lockInput();
            addNewGroupBtn.Enabled = true;
            isNew = false;
        }

        private void groupNameTxtBox_KeyDown(object sender, KeyEventArgs e)
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

        #endregion

        #region IngredientsTab

        private void lockInputIng()
        {
            txt_IngID.Enabled = false;
            txt_IngName.Enabled = false;
            txt_PackageNo.Enabled = false;
            txt_ExpDate.Enabled = false;
            txt_Quantity.Enabled = false;
            cmb_Unit.Enabled = false;
            txt_Vat.Enabled = false;
            txt_Price.Enabled = false;
            cmbBox_Group.Enabled = false;
            saveIngBtn.Enabled = false;
            editIngBtn.Enabled = false;
            deleteIngBtn.Enabled = false;
            cancelIngBtn.Enabled = false;
        }

        private void unlockInputIng()
        {
            txt_IngID.Enabled = true;
            txt_IngName.Enabled = true;
            txt_PackageNo.Enabled = true;
            txt_ExpDate.Enabled = true;
            txt_Quantity.Enabled = true;
            cmb_Unit.Enabled = true;
            txt_Vat.Enabled = true;
            txt_Price.Enabled = true;
            cmbBox_Group.Enabled = true;
            addNewIngBtn.Enabled = false;
            saveIngBtn.Enabled = true;
            cancelIngBtn.Enabled = true;
        }

        private void setNullIng()
        {
            txt_IngID.Text = "";
            txt_IngName.Text = "";
            txt_PackageNo.Text = "";
            txt_ExpDate.Text = "";
            txt_Quantity.Text = "";
            cmb_Unit.Text = "";
            txt_Vat.Text = "";
            txt_Price.Text = "";

            if (!isNew)
            {
                foreach (TextBox txtB in allTxtBox)
                {
                    txtB.BackColor = SystemColors.Window;
                }

                foreach (TextBox txtB in dateTxtBox)
                {
                    txtB.BackColor = SystemColors.Window;
                }
            }
        }

        private void addNewIngBtn_Click(object sender, EventArgs e)
        {
            try
            {
                unlockInputIng();
                editBtn.Enabled = false;
                deleteBtn.Enabled = false;
                isNewIng = true;
                setNullIng();
            }
            catch (Exception)
            {
                MessageBox.Show("Error when requiring to add");
            }
        }

        private void saveIngBtn_Click(object sender, EventArgs e)
        {
            try
            {
                String validatorResult = validator.validateInput(allTxtBox);
                String validatorDateResult = validator.validateDateFormatOnly(dateTxtBox);

                if (validatorResult != null)
                {
                    MessageBox.Show(validatorResult);
                    return;
                }

                if (validatorDateResult != null)
                {
                    MessageBox.Show(validatorDateResult);
                    return;
                }

                if (isNewIng)
                {
                    if (busIng.select().Rows.Count > 0)
                    {
                        for (int i = 0; i < busIng.select().Rows.Count; i++)
                        {
                            if (txt_IngID.Text == busIng.select().Rows[i][0].ToString())
                            {
                                MessageBox.Show("ID has already existed");
                                return;
                            }
                        }
                    }

                    if (datetime.Date > Convert.ToDateTime(txt_ExpDate.Text).Date)
                    {
                        MessageBox.Show("The Exp. Date is less than today");
                        return;
                    }

                    ecIng.IngredientID = txt_IngID.Text;
                    ecIng.IngredientName = txt_IngName.Text;
                    ecIng.Date = datetime.ToString();
                    ecIng.StaffID = staffID;
                    ecIng.GroupID = cmbBox_Group.SelectedValue.ToString();
                    
                    ecIngDetail.IngredientID = txt_IngID.Text;
                    ecIngDetail.PkgNo = txt_PackageNo.Text;
                    ecIngDetail.ExpiredDate = txt_ExpDate.Text;
                    ecIngDetail.Quantity = txt_Quantity.Text;
                    ecIngDetail.QuantityInput = txt_Quantity.Text;
                    ecIngDetail.Unit = cmb_Unit.Text;
                    ecIngDetail.Vat = txt_Vat.Text;
                    ecIngDetail.IngredientPrice = txt_Price.Text;

                    busIng.insert(ecIng, ecIngDetail);
                    grid_Ingredients.DataSource = busIng.select();
                    MessageBox.Show("Successfully added new ingredients.");
                    isNewIng = false;
                }
                else
                {
                    if (datetime.Date > Convert.ToDateTime(txt_ExpDate.Text).Date)
                    {
                        MessageBox.Show("The Exp. Date is less than today");
                        return;
                    }

                    ecIng.IngredientID = txt_IngID.Text;
                    ecIng.IngredientName = txt_IngName.Text;
                    ecIng.Date = datetime.ToString();
                    ecIng.StaffID = staffID;
                    ecIng.GroupID = cmbBox_Group.SelectedValue.ToString();

                    ecIngDetail.IngredientID = txt_IngID.Text;
                    ecIngDetail.PkgNo = txt_PackageNo.Text;
                    ecIngDetail.ExpiredDate = txt_ExpDate.Text;
                    ecIngDetail.Quantity = txt_Quantity.Text;
                    ecIngDetail.QuantityInput = txt_Quantity.Text;
                    ecIngDetail.Unit = cmb_Unit.Text;
                    ecIngDetail.Vat = txt_Vat.Text;
                    ecIngDetail.IngredientPrice = txt_Price.Text;

                    busIng.update(ecIng, ecIngDetail);
                    grid_Ingredients.DataSource = busIng.select();
                    MessageBox.Show("Successfully edited new ingredients.");
                }
                setNullIng();
                lockInputIng();
                addNewIngBtn.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Error while saving new ingredients. Please check the input above. Thank You.");
            }
        }

        private void editIngBtn_Click(object sender, EventArgs e)
        {
            isNewIng = false;
            unlockInputIng();
            txt_IngID.Enabled = false;
        }

        private void deleteIngBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ecIng.IngredientID = txt_IngID.Text;
                    ecIngDetail.IngredientID = txt_IngID.Text;
                    busIng.delete(ecIng, ecIngDetail);
                    grid_Ingredients.DataSource = busIng.select();
                    setNullIng();
                    lockInputIng();
                }
                else
                {
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Error while deleting ingredients.");
            }
        }

        private void grid_Ingredients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isNewIng)
            {
                return;
            }
            editIngBtn.Enabled = true;
            deleteIngBtn.Enabled = true;

            try
            {
                txt_IngID.Text = grid_Ingredients.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_IngName.Text = grid_Ingredients.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_PackageNo.Text = grid_Ingredients.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_ExpDate.Text = grid_Ingredients.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_Quantity.Text = grid_Ingredients.Rows[e.RowIndex].Cells[5].Value.ToString();
                cmb_Unit.Text = grid_Ingredients.Rows[e.RowIndex].Cells[6].Value.ToString();
                txt_Vat.Text = grid_Ingredients.Rows[e.RowIndex].Cells[7].Value.ToString();
                txt_Price.Text = form.txtBoxFormat(grid_Ingredients.Rows[e.RowIndex].Cells[8].Value.ToString());
                cmbBox_Group.Text = busGroup.getQueryAsString("GROUP_NAME", "WHERE GROUP_ID = '" + grid_Ingredients.Rows[e.RowIndex].Cells[9].Value.ToString() + "'");
            }
            catch
            {

            }
        }

        private void cancelIngBtn_Click(object sender, EventArgs e)
        {
            setNullIng();
            lockInputIng();
            addNewIngBtn.Enabled = true;
            isNewIng = false;
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            datetime = DateTime.Now;
        }

        private void tab_GroupIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab_GroupIngredients.SelectedTab == tabPg_Ingredients)
            {
                cmbBox_Group.DataSource = busGroup.select();
            }
        }

        private void txt_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            validator.validateNumberOnly(sender, e);

        }

        #region Hover Effect Group's Buttons
        private void addNewGroupBtn_MouseHover(object sender, EventArgs e)
        {
            addNewGroupBtn.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            addNewGroupBtn.BackColor = SystemColors.ActiveBorder;
        }

        private void addNewGroupBtn_MouseLeave(object sender, EventArgs e)
        {
            addNewGroupBtn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            addNewGroupBtn.BackColor = SystemColors.Control;
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
        #endregion

        #region Hover Effect Ingredients's Buttons
        private void addNewIngBtn_MouseHover(object sender, EventArgs e)
        {
            addNewIngBtn.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            addNewIngBtn.BackColor = SystemColors.ActiveBorder;
        }

        private void addNewIngBtn_MouseLeave(object sender, EventArgs e)
        {
            addNewIngBtn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            addNewIngBtn.BackColor = SystemColors.Control;
        }

        private void saveIngBtn_MouseHover(object sender, EventArgs e)
        {
            saveIngBtn.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            saveIngBtn.BackColor = SystemColors.ActiveBorder;
        }

        private void saveIngBtn_MouseLeave(object sender, EventArgs e)
        {
            saveIngBtn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            saveIngBtn.BackColor = SystemColors.Control;
        }

        private void editIngBtn_MouseHover(object sender, EventArgs e)
        {
            editIngBtn.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            editIngBtn.BackColor = SystemColors.ActiveBorder;
        }

        private void editIngBtn_MouseLeave(object sender, EventArgs e)
        {
            editIngBtn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            editIngBtn.BackColor = SystemColors.Control;
        }

        private void deleteIngBtn_MouseHover(object sender, EventArgs e)
        {
            deleteIngBtn.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            deleteIngBtn.BackColor = SystemColors.ActiveBorder;
        }

        private void deleteIngBtn_MouseLeave(object sender, EventArgs e)
        {
            deleteIngBtn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            deleteIngBtn.BackColor = SystemColors.Control;
        }

        private void cancelIngBtn_MouseHover(object sender, EventArgs e)
        {
            cancelIngBtn.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            cancelIngBtn.BackColor = SystemColors.ActiveBorder;
        }

        private void cancelIngBtn_MouseLeave(object sender, EventArgs e)
        {
            cancelIngBtn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            cancelIngBtn.BackColor = SystemColors.Control;
        }
        #endregion

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(grid_Ingredients, sfd.FileName); // Here dataGridview1 is your grid view name
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
