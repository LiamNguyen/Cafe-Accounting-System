using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemEntity
{
    public class EC_tblPermission
    {
        private string _staffID;

        public string StaffID
        {
            get { return _staffID; }
            set { _staffID = value; }
        }

        private string _loginID;

        public string LoginID
        {
            get { return _loginID; }
            set { _loginID = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private bool _perOrder;

        public bool PerOrder
        {
            get { return _perOrder; }
            set { _perOrder = value; }
        }

        private bool _perStaffs;

        public bool PerStaffs
        {
            get { return _perStaffs; }
            set { _perStaffs = value; }
        }

        private bool _perStock;

        public bool PerStock
        {
            get { return _perStock; }
            set { _perStock = value; }
        }

        private bool _perRightsControl;

        public bool PerRightsControl
        {
            get { return _perRightsControl; }
            set { _perRightsControl = value; }
        }

        private bool _perReport;

        public bool PerReport
        {
            get { return _perReport; }
            set { _perReport = value; }
        }

        private bool _perMenuItems;

        public bool PerMenuItems
        {
            get { return _perMenuItems; }
            set { _perMenuItems = value; }
        }
    }
}
