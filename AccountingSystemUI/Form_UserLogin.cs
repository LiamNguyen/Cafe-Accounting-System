using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingSystemBUS;
using AccountingSystemValidation;

namespace AccountingSystemUI
{
    public partial class Form_UserLogin : Form
    {
        Bus_tblPermission busPermission = new Bus_tblPermission();
        InputValidation validator = new InputValidation();

        public string staffID;
        public string staffName;

        public bool per_order;
        public bool per_staffs;
        public bool per_stock;
        public bool per_rights;
        public bool per_report;
        public bool per_menuItems;

        List<TextBox> listTxtBox = new List<TextBox>();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Form_UserLogin()
        {
            InitializeComponent();
            listTxtBox.Add(txt_Username);
            listTxtBox.Add(txt_Password);
        }

        public async void loginBtnFunc()
        {
            String validationResult = validator.validateInput(listTxtBox);

            if (validationResult != null)
            {
                informLbl.Visible = true;
                informLbl.Text = validationResult;
                informLbl.BackColor = Color.LightPink;
                return;
            }

            try
            {
                int count = busPermission.authenticateSelect(txt_Username.Text, txt_Password.Text).Rows.Count;

                if (count == 0)
                {
                    informLbl.Visible = true;
                    informLbl.Text = "Invalid username and password";
                    informLbl.BackColor = Color.LightPink;
                    return;
                }

                informLbl.Visible = true;
                informLbl.Text = "WELCOME " + busPermission.authenticateSelect(txt_Username.Text, txt_Password.Text).Rows[0][3].ToString();
                informLbl.BackColor = Color.LightGreen;
                foreach (TextBox txtB in listTxtBox)
                {
                    txtB.BackColor = Color.DarkGray;
                }

                staffID = busPermission.authenticateSelect(txt_Username.Text, txt_Password.Text).Rows[0][2].ToString();
                staffName = busPermission.authenticateSelect(txt_Username.Text, txt_Password.Text).Rows[0][3].ToString();
                string sqlCondition = "WHERE LOGINID = N'" + txt_Username.Text + "' AND PASSWORD = N'" + txt_Password.Text + "'";
                per_order = Convert.ToBoolean(busPermission.select(sqlCondition).Rows[0][4].ToString());
                per_staffs = Convert.ToBoolean(busPermission.select(sqlCondition).Rows[0][5].ToString());
                per_stock = Convert.ToBoolean(busPermission.select(sqlCondition).Rows[0][6].ToString());
                per_rights = Convert.ToBoolean(busPermission.select(sqlCondition).Rows[0][7].ToString());
                per_report = Convert.ToBoolean(busPermission.select(sqlCondition).Rows[0][8].ToString());
                per_menuItems = Convert.ToBoolean(busPermission.select(sqlCondition).Rows[0][9].ToString());

                loginBtn.BackColor = Color.White;
                loginBtn.ForeColor = Color.Black;

                int millisecs = 800;
                await Task.Delay(millisecs);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Cannot connect to database");
            }
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            loginBtnFunc();
        }

        private void passwordTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                loginBtnFunc();
            }
        }

        private void Form_UserLogin_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.ActiveControl = txt_Username;
            txt_Username.Clear();
            txt_Password.Clear();
            informLbl.Text = "";
            informLbl.Visible = false;
            this.FormBorderStyle = FormBorderStyle.None;
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

        private void pictureBox_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_Minimize_MouseHover(object sender, EventArgs e)
        {
            System.Drawing.Bitmap bitmap1 = AccountingSystemUI.Properties.Resources.minimize_window1;
            pictureBox_Minimize.Image = bitmap1;
        }

        private void pictureBox_Minimize_MouseLeave(object sender, EventArgs e)
        {
            System.Drawing.Bitmap bitmap1 = AccountingSystemUI.Properties.Resources.Minimize_Window_icon;
            pictureBox_Minimize.Image = bitmap1;
        }

        private void pictureBox_Minimize_Click(object sender, EventArgs e)
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

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.mainPanel.CreateGraphics();
            Brush brush = new SolidBrush(Color.White);
            Pen p = new Pen(brush, 4);
            Rectangle username = new Rectangle(97, 353, 216, 40);
            draw(g, p, username, 10);

            Rectangle password = new Rectangle(97, 400, 216, 40);
            draw(g, p, password, 10);
        }

        public GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        public void draw(Graphics graphics, Pen pen, Rectangle bounds, int cornerRadius)
        {
            if (graphics == null)
                throw new ArgumentNullException("graphics");
            if (pen == null)
                throw new ArgumentNullException("pen");

            GraphicsPath path = RoundedRect(bounds, cornerRadius);
            graphics.DrawPath(pen, path);
        }

        private void loginBtn_MouseHover(object sender, EventArgs e)
        {
            loginBtn.BackColor = Color.White;
            loginBtn.ForeColor = Color.Black;
        }

        private void loginBtn_MouseLeave(object sender, EventArgs e)
        {
            loginBtn.BackColor = Color.Black;
            loginBtn.ForeColor = Color.White;
        }
    }
}
