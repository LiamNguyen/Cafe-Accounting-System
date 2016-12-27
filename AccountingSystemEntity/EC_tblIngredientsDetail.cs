using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemEntity
{
    public class EC_tblIngredientsDetail
    {
        private String _ingredientID;

        public String IngredientID
        {
            get { return _ingredientID; }
            set { _ingredientID = value; }
        }

        private String _pkgNo;

        public String PkgNo
        {
            get { return _pkgNo; }
            set { _pkgNo = value; }
        }

        private String _expiredDate;

        public String ExpiredDate
        {
            get { return _expiredDate; }
            set { _expiredDate = value; }
        }

        private String _quantity;

        public String Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        private String _quantityInput;

        public String QuantityInput
        {
            get { return _quantityInput; }
            set { _quantityInput = value; }
        }

        private String _unit;

        public String Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        private String _vat;

        public String Vat
        {
            get { return _vat; }
            set { _vat = value; }
        }

        private String _ingredientPrice;

        public String IngredientPrice
        {
            get { return _ingredientPrice; }
            set { _ingredientPrice = value; }
        }

        private int _status;

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
