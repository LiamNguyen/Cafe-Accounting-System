using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemEntity
{
    public class EC_tblStaffShift
    {
        private String _checkInDate;

        public String CheckInDate
        {
            get { return _checkInDate; }
            set { _checkInDate = value; }
        }

        private String _checkInTime;

        public String CheckInTime
        {
            get { return _checkInTime; }
            set { _checkInTime = value; }
        }

        private String _staffID;

        public String StaffID
        {
            get { return _staffID; }
            set { _staffID = value; }
        }
    }
}
