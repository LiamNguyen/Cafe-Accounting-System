using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemEntity
{
    public class EC_tblReceiptDetail
    {
        private string _receiptID;

        public string ReceiptID
        {
            get { return _receiptID; }
            set { _receiptID = value; }
        }

        private string _productID;

        public string ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        private int _amount;

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        

        private decimal _total;

        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }
    }
}
