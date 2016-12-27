using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingSystemDAL;
using AccountingSystemEntity;
using System.Data;

namespace AccountingSystemBUS
{
    public class Bus_tblPermission
    {
        Sql_tblPermission sql = new Sql_tblPermission();

        public void insert(EC_tblPermission ecPermission)
        {
            sql.insert(ecPermission);
        }

        public void update(EC_tblPermission ecPermission)
        {
            sql.update(ecPermission);
        }

        public void delete(EC_tblPermission ecPermission)
        {
            sql.delete(ecPermission);
        }

        public DataTable select(String condition)
        {
            return sql.select(condition);
        }

        public DataTable authenticateSelect(String username, String password)
        {
            return sql.authenticateSelect(username, password);
        }
    }
}
