using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccountingSystemEntity;
using AccountingSystemDAL;

namespace AccountingSystemBUS
{
    public class Bus_tblReceipt
    {
        Sql_tblReceipt sql = new Sql_tblReceipt();
        public void insert(EC_tblReceipt ecReceipt)
        {
            sql.insert(ecReceipt);
        }

        public void update(EC_tblReceipt ecReceipt)
        {
            sql.update(ecReceipt);
        }

        public void delete(EC_tblReceipt ecReceipt)
        {
            sql.delete(ecReceipt);
        }

        public DataTable select(string condition)
        {
            return sql.select(condition);
        }

        public String getQueryString(string field, string condition)
        {
            return sql.getQueryString(field, condition);
        }
    }
}
