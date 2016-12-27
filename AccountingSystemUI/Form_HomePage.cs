using System;
using System.Runtime.InteropServices;
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

namespace AccountingSystemUI
{
    public partial class Form_HomePage : Form
    {
        Form_UserLogin loginForm = new Form_UserLogin();
        public string staffID;
        List<Boolean> controlClicked = new List<Boolean>();
        Bus_tblStaffs busStaff = new Bus_tblStaffs();
        Bus_tblStaffShift busShift = new Bus_tblStaffShift();
        Bus_tblPermission busPermission = new Bus_tblPermission();
        EC_tblStaffShift ecShift = new EC_tblStaffShift();

        DateTime dateTime = DateTime.Now;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Form_HomePage()
        {
            InitializeComponent();
            Boolean orderIsClicked = false;
            Boolean staffIsClicked = false;
            Boolean permissionIsClicked = false;
            Boolean productIsClicked = false;
            Boolean stockIsClicked = false;
            controlClicked.Add(orderIsClicked);
            controlClicked.Add(staffIsClicked);
            controlClicked.Add(permissionIsClicked);
            controlClicked.Add(productIsClicked);
            controlClicked.Add(stockIsClicked);
        }

        private void Form_HomePage_Load(object sender, EventArgs e)
        {
            loadHomePage();
        }

        private void toOrderFrmBtn_Click(object sender, EventArgs e)
        {
            subFormPanelContainer.Controls.Clear();
            setFalse();
            controlClicked[0] = true;
            setDefault();
            Form_DetailOrderMenu subForm = new Form_DetailOrderMenu();
            subForm.staffID = staffID;
            subForm.TopLevel = false;
            subFormPanelContainer.Controls.Add(subForm);
            subForm.FormBorderStyle = FormBorderStyle.None;
            subForm.Dock = DockStyle.Fill;
            subForm.Show();
        } 

        private void toStaffFrmBtn_Click(object sender, EventArgs e)
        {
            subFormPanelContainer.Controls.Clear();
            setFalse();
            controlClicked[1] = true;
            setDefault();
            Form_Staffs subForm = new Form_Staffs();
            subForm.TopLevel = false;
            subFormPanelContainer.Controls.Add(subForm);
            subForm.FormBorderStyle = FormBorderStyle.None;
            subForm.Dock = DockStyle.Fill;
            subForm.Show();
        }

        private void toAssignFrmBtn_Click(object sender, EventArgs e)
        {
            subFormPanelContainer.Controls.Clear();
            setFalse();
            controlClicked[2] = true;
            setDefault();
            Form_AssignPermission subForm = new Form_AssignPermission();
            subForm.staffID = staffID;
            subForm.TopLevel = false;
            subFormPanelContainer.Controls.Add(subForm);
            subForm.FormBorderStyle = FormBorderStyle.None;
            subForm.Dock = DockStyle.Fill;
            subForm.Show();
        }

        private void toProductFrmBtn_Click(object sender, EventArgs e)
        {
            subFormPanelContainer.Controls.Clear();
            setFalse();
            controlClicked[3] = true;
            setDefault();
            Form_Products subForm = new Form_Products();
            subForm.TopLevel = false;
            subFormPanelContainer.Controls.Add(subForm);
            subForm.FormBorderStyle = FormBorderStyle.None;
            subForm.Dock = DockStyle.Fill;
            subForm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTimeLbl.Text = dateTime.ToString();
        }

        private void signInBtn_Click(object sender, EventArgs e)
        {
            loadHomePage();
        }

        public void loadHomePage()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            WindowState = FormWindowState.Maximized;

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                staffID = loginForm.staffID;
                userInfoLbl.Text = staffID + " - " + loginForm.staffName + " is using system";
                if (!loginForm.per_order)
                {
                    order_Panel.Enabled = false;
                    order_Lbl.Enabled = false;
                    order_Icon.Enabled = false;
                }
                else
                {
                    order_Panel.Enabled = true;
                    order_Lbl.Enabled = true;
                    order_Icon.Enabled = true;
                }

                if (!loginForm.per_staffs)
                {
                    staff_Panel.Enabled = false;
                    staff_Lbl.Enabled = false;
                    staff_Icon.Enabled = false;
                }
                else
                {
                    staff_Panel.Enabled = true;
                    staff_Lbl.Enabled = true;
                    staff_Icon.Enabled = true;
                }

                if (!loginForm.per_rights)
                {
                    per_Panel.Enabled = false;
                    per_Lbl.Enabled = false;
                    per_Icon.Enabled = false;
                }
                else
                {
                    per_Panel.Enabled = true;
                    per_Lbl.Enabled = true;
                    per_Icon.Enabled = true;
                }

                if (!loginForm.per_menuItems)
                {
                    product_Panel.Enabled = false;
                    product_Lbl.Enabled = false;
                    product_Icon.Enabled = false;
                }
                else
                {
                    product_Panel.Enabled = true;
                    product_Lbl.Enabled = true;
                    product_Icon.Enabled = true;
                }

                if (!loginForm.per_report)
                {
                    report_Panel.Enabled = false;
                    report_Lbl.Enabled = false;
                    report_Icon.Enabled = false;
                }
                else
                {
                    report_Panel.Enabled = true;
                    report_Lbl.Enabled = true;
                    report_Icon.Enabled = true;
                }

                if (!loginForm.per_stock)
                {
                    stock_Panel.Enabled = false;
                    stock_Lbl.Enabled = false;
                    stock_Icon.Enabled = false;
                }
                else
                {
                    stock_Panel.Enabled = true;
                    stock_Lbl.Enabled = true;
                    stock_Icon.Enabled = true;
                }

                in_Panel.Enabled = false;
                in_Lbl.Enabled = false;
                in_Icon.Enabled = false;

                out_Panel.Enabled = true;
                out_Lbl.Enabled = true;
                out_Icon.Enabled = true;

                this.Opacity = 100;

                cmb_Username.DataSource = busPermission.select("WHERE STATUS = '1'");
                cmb_Username.DisplayMember = "LOGINID";
                cmb_Username.ValueMember = "STAFFID";
            }
            else
            {
                disableAllControls();

                this.Opacity = 100;
                MessageBox.Show("You did not sign in to system");
                userInfoLbl.Text = "No active user is using system";
                out_Icon.Enabled = false;
                out_Lbl.Enabled = false;
                out_Panel.Enabled = false;
            }

            timer1.Start();
        }

        private void signOutBtn_Click(object sender, EventArgs e)
        {
            subFormPanelContainer.Controls.Clear();
            disableAllControls();

            in_Panel.Enabled = true;
            in_Lbl.Enabled = true;
            in_Icon.Enabled = true;

            out_Panel.Enabled = false;
            out_Lbl.Enabled = false;
            out_Icon.Enabled = false;

            userInfoLbl.Text = "No active user is using system";
        }

        private void toReportFrmBtn_Click(object sender, EventArgs e)
        {
            Form_Report form = new Form_Report();
            form.Show();
        }

        private void toStockFrmBtn_Click(object sender, EventArgs e)
        {
            subFormPanelContainer.Controls.Clear();
            setFalse();
            controlClicked[4] = true;
            setDefault();
            Form_StockManagement subForm = new Form_StockManagement();
            subForm.staffID = staffID;
            subForm.TopLevel = false;
            subFormPanelContainer.Controls.Add(subForm);
            subForm.FormBorderStyle = FormBorderStyle.None;
            subForm.Dock = DockStyle.Fill;
            subForm.Show();
        }

        public void disableAllControls()
        {
            order_Panel.Enabled = false;
            order_Lbl.Enabled = false;
            order_Icon.Enabled = false;

            staff_Panel.Enabled = false;
            staff_Lbl.Enabled = false;
            staff_Icon.Enabled = false;

            per_Panel.Enabled = false;
            per_Lbl.Enabled = false;
            per_Icon.Enabled = false;

            product_Panel.Enabled = false;
            product_Lbl.Enabled = false;
            product_Icon.Enabled = false;

            report_Panel.Enabled = false;
            report_Lbl.Enabled = false;
            report_Icon.Enabled = false;

            stock_Panel.Enabled = false;
            stock_Lbl.Enabled = false;
            stock_Icon.Enabled = false;
        }

        public void setDefault()
        {
            if (!controlClicked[0])
            {
                order_Panel.BackColor = SystemColors.ActiveBorder;
                order_Lbl.ForeColor = Color.Black;
            }
            if (!controlClicked[1])
            {
                staff_Panel.BackColor = SystemColors.ActiveBorder;
                staff_Lbl.ForeColor = Color.Black;
            }
            if (!controlClicked[2])
            {
                per_Panel.BackColor = SystemColors.ActiveBorder;
                per_Lbl.ForeColor = Color.Black;
            }
            if (!controlClicked[3])
            {
                product_Panel.BackColor = SystemColors.ActiveBorder;
                product_Lbl.ForeColor = Color.Black;
            }
            if (!controlClicked[4])
            {
                stock_Panel.BackColor = SystemColors.ActiveBorder;
                stock_Lbl.ForeColor = Color.Black;
            }
        }

        private void setFalse()
        {
            for (int i = 0; i < controlClicked.Count; i++)
            {
                controlClicked[i] = false;
            }
        }

        private void order_Panel_MouseHover(object sender, EventArgs e)
        {
            order_Panel.BackColor = SystemColors.ButtonShadow;
            order_Lbl.ForeColor = Color.White;
        }

        private void order_Panel_MouseLeave(object sender, EventArgs e)
        {
            if (!controlClicked[0])
            {
                order_Panel.BackColor = SystemColors.ActiveBorder;
                order_Lbl.ForeColor = Color.Black;
            }
        }

        private void staff_Panel_MouseHover(object sender, EventArgs e)
        {
            staff_Panel.BackColor = SystemColors.ButtonShadow;
            staff_Lbl.ForeColor = Color.White;
        }

        private void staff_Panel_MouseLeave(object sender, EventArgs e)
        {
            if (!controlClicked[1])
            {
                staff_Panel.BackColor = SystemColors.ActiveBorder;
                staff_Lbl.ForeColor = Color.Black;
            }
        }

        private void per_Panel_MouseHover(object sender, EventArgs e)
        {
            per_Panel.BackColor = SystemColors.ButtonShadow;
            per_Lbl.ForeColor = Color.White;
        }

        private void per_Panel_MouseLeave(object sender, EventArgs e)
        {
            if (!controlClicked[2])
            {
                per_Panel.BackColor = SystemColors.ActiveBorder;
                per_Lbl.ForeColor = Color.Black;
            }
        }

        private void product_Panel_MouseHover(object sender, EventArgs e)
        {
            product_Panel.BackColor = SystemColors.ButtonShadow;
            product_Lbl.ForeColor = Color.White;
        }

        private void product_Panel_MouseLeave(object sender, EventArgs e)
        {
            if (!controlClicked[3])
            {
                product_Panel.BackColor = SystemColors.ActiveBorder;
                product_Lbl.ForeColor = Color.Black;
            }
        }

        private void report_Panel_MouseHover(object sender, EventArgs e)
        {
            report_Panel.BackColor = SystemColors.ButtonShadow;
            report_Lbl.ForeColor = Color.White;
        }

        private void report_Panel_MouseLeave(object sender, EventArgs e)
        {
            report_Panel.BackColor = SystemColors.ActiveBorder;
            report_Lbl.ForeColor = Color.Black;
        }

        private void stock_Panel_MouseHover(object sender, EventArgs e)
        {
            stock_Panel.BackColor = SystemColors.ButtonShadow;
            stock_Lbl.ForeColor = Color.White;
        }

        private void stock_Panel_MouseLeave(object sender, EventArgs e)
        {
            if (!controlClicked[4])
            {
                stock_Panel.BackColor = SystemColors.ActiveBorder;
                stock_Lbl.ForeColor = Color.Black;
            }
        }

        private void in_Lbl_MouseHover(object sender, EventArgs e)
        {
            in_Panel.BackColor = SystemColors.ButtonShadow;
            in_Lbl.ForeColor = Color.White;
        }

        private void in_Lbl_MouseLeave(object sender, EventArgs e)
        {
            in_Panel.BackColor = SystemColors.ActiveBorder;
            in_Lbl.ForeColor = Color.Black;
        }

        private void out_Panel_MouseHover(object sender, EventArgs e)
        {
            out_Panel.BackColor = SystemColors.ButtonShadow;
            out_Lbl.ForeColor = Color.White;
        }

        private void out_Panel_MouseLeave(object sender, EventArgs e)
        {
            out_Panel.BackColor = SystemColors.ActiveBorder;
            out_Lbl.ForeColor = Color.Black;
        }

        private void tableLayoutPanel2_Click(object sender, EventArgs e)
        {
            subFormPanelContainer.Controls.Clear();
            setFalse();
            setDefault();
        }

        private void pictureBox_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_Minimize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {          
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void pictureBox_Close_MouseHover(object sender, EventArgs e)
        {
            System.Drawing.Bitmap bitmap1 = AccountingSystemUI.Properties.Resources.close_window1600;
            pictureBox_Close.Image = bitmap1;
        }

        private void pictureBox_Close_MouseLeave(object sender, EventArgs e)
        {
            System.Drawing.Bitmap bitmap1 = AccountingSystemUI.Properties.Resources.Close_Window_icon;
            pictureBox_Close.Image = bitmap1;
        }

        private void pictureBox_Minimize_MouseHover(object sender, EventArgs e)
        {
            System.Drawing.Bitmap bitmap1 = AccountingSystemUI.Properties.Resources.minimizeIcon;
            pictureBox_Minimize.Image = bitmap1;
        }

        private void pictureBox_Minimize_MouseLeave(object sender, EventArgs e)
        {
            System.Drawing.Bitmap bitmap1 = AccountingSystemUI.Properties.Resources.maximizeIcon;
            pictureBox_Minimize.Image = bitmap1;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            System.Drawing.Bitmap bitmap1 = AccountingSystemUI.Properties.Resources.minimize_window1;
            pictureBox2.Image = bitmap1;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            System.Drawing.Bitmap bitmap1 = AccountingSystemUI.Properties.Resources.Minimize_Window_icon;
            pictureBox2.Image = bitmap1;
        }

        public void checkIn()
        {
            try
            {
                Console.WriteLine("WINDOW STATEEEE: " + this.WindowState);
            }
            catch
            {
                MessageBox.Show("Cannot check in this user");
            }
            
        }

        private void txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {

            }
        }

        private void btn_CheckIn_Click(object sender, EventArgs e)
        {
            checkIn();
        }
    }
}
