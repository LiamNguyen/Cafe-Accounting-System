using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace AccountingSystemUI
{
    public partial class BillPrinter : DevExpress.XtraReports.UI.XtraReport
    {
        public BillPrinter()
        {
            InitializeComponent();
        }

        public void bindData(String billNo, String cashier, String date, String subtotal, String service, String vat, String grandtotal, int record) 
        {
            billNoLbl.Text = billNo;
            cashierLbl.Text = cashier;
            dateLbl.Text = date;
            subtotalLbl.Text = subtotal;
            serviceLbl.Text = service + "%";
            vatLbl.Text = vat + "%";
            grandtotalLbl.Text = grandtotal;
            this.PageHeight = 37 * record + 140 + 200;
        }

        public void bindDataSource()
        {
            productNameLbl.DataBindings.Add("Text", DataSource, "Name");
            quantityLbl.DataBindings.Add("Text", DataSource, "Quantity");
            productPriceLbl.DataBindings.Add("Text", DataSource, "Price");
        }
    }
}
