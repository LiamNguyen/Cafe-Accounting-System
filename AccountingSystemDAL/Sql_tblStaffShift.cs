using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AccountingSystemEntity;

namespace AccountingSystemDAL
{
    public class Sql_tblStaffShift
    {
        DBConnection cn = new DBConnection();

        public void insert(EC_tblStaffShift ecShift)
        {
            cn.ExecuteSqlQuery(@"INSERT INTO StaffShifts (CHECKINDATE, CHECKINTIME STAFFID) VALUES (" + ecShift.CheckInDate + 
                                ", " + ecShift.CheckInTime + ", " + ecShift.StaffID + ")");
        }

        public DataTable select_StaffsWorkInDay(String condition)
        {
            return cn.GetDataTable(@"SELECT StaffShifts.CHECKINDATE, StaffShifts.CHECKINTIME, Staffs.STAFFNAME
                                    FROM Staffs INNER JOIN StaffShifts ON Staffs.STAFFID = StaffShifts.STAFFID 
                                    WHERE Staffshifs.CHECKINDATE = '" + condition + "'");
        }

        public DataTable select_WorkDayOfStaff(String condition)
        {
            return cn.GetDataTable(@"SELECT StaffShifts.CHECKINDATE, StaffShifts.CHECKINTIME, Staffs.STAFFNAME
                                    FROM Staffs INNER JOIN StaffShifts ON Staffs.STAFFID = StaffShifts.STAFFID 
                                    WHERE Staffshifs.STAFFID = '" + condition + "'");
        }
    }
}
