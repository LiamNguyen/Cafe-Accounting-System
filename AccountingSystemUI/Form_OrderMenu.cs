using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystemUI
{
    public partial class Form_OrderMenu : Form
    {
        public Form_OrderMenu()
        {
            InitializeComponent();
        }

        private void OrderMenu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void GroupE_Click(object sender, EventArgs e)
        {

        }

        private void GroupSM_Click(object sender, EventArgs e)
        {

        }

        private void GroupO_Click(object sender, EventArgs e)
        {

        }

        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }

    }
}
