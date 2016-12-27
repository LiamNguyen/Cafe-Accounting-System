using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccountingSystemDAL;
using AccountingSystemEntity;

namespace AccountingSystemBUS
{
    public class Bus_tblStaffs
    {
        Sql_tblStaffs sql = new Sql_tblStaffs();
        public void insert(EC_tblStaffs ecStaff)
        {
            sql.insert(ecStaff);
        }

        public void update(EC_tblStaffs ecStaff)
        {
            sql.update(ecStaff);
        }

        public void delete(EC_tblStaffs ecStaff)
        {
            sql.delete(ecStaff);
        }

        public DataTable select(string condition)
        {
            return sql.select(condition);
        }

        public DataTable selectField(string field, string condition)
        {
            return sql.selectField(field, condition);
        }

        public DataTable selectToValidate()
        {
            return sql.selectToValidate();
        }
    }
}
