using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemEntity
{
    public class EC_tblReceipt
    {
        private string _receiptID;

        public string ReceiptID
        {
            get { return _receiptID; }
            set { _receiptID = value; }
        }

        private string _date;

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private string _staffID;

        public string StaffID
        {
            get { return _staffID; }
            set { _staffID = value; }
        }

        private decimal _total;

        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }
    }
}
