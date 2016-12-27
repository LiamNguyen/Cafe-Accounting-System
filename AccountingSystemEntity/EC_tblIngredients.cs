using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemEntity
{
    public class EC_tblIngredients
    {
        private String _ingredientID;

        public String IngredientID
        {
            get { return _ingredientID; }
            set { _ingredientID = value; }
        }

        private String _ingredientName;

        public String IngredientName
        {
            get { return _ingredientName; }
            set { _ingredientName = value; }
        }

        private String _date;

        public String Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private String _staffID;

        public String StaffID
        {
            get { return _staffID; }
            set { _staffID = value; }
        }

        private String _groupID;

        public String GroupID
        {
            get { return _groupID; }
            set { _groupID = value; }
        }

        private int _status;

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
