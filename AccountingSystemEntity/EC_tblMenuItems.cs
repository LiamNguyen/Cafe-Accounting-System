using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemEntity
{
    public class EC_tblMenuItems
    {
        private string _productID;

        public string ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        private string _productName;

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        private string _productPrice;

        public string ProductPrice
        {
            get { return _productPrice; }
            set { _productPrice = value; }
        }
    }
}
