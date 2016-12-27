using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AccountingSystemDAL;
using AccountingSystemEntity;

namespace AccountingSystemBUS
{
    public class Bus_tblStaffShift
    {
        Sql_tblStaffShift sql = new Sql_tblStaffShift();
        public void insert(EC_tblStaffShift ecShift)
        {
            sql.insert(ecShift);
        }

        public DataTable select_StaffsWorkInDay(String condition)
        {
            return sql.select_StaffsWorkInDay(condition);
        }

        public DataTable select_WorkDayOfStaff(String condition)
        {
            return sql.select_WorkDayOfStaff(condition);
        }
    }
}
