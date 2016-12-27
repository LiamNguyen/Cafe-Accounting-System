using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemEntity
{
    public class EC_tblIngredientsGroup
    {
        private String _groupID;

        public String GroupID
        {
            get { return _groupID; }
            set { _groupID = value; }
        }

        private String _groupName;

        public String GroupName
        {
            get { return _groupName; }
            set { _groupName = value; }
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

        private int _status;

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public DateTime UpdatedAt
        {
            get
            {
                return _updatedAt;
            }

            set
            {
                _updatedAt = value;
            }
        }

        private DateTime _updatedAt;
    }
}
