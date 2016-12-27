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
    public class Bus_tblMenuItems
    {
        Sql_tblMenuItems sql = new Sql_tblMenuItems();
        public void insert(EC_tblMenuItems ecMenuItems)
        {
            sql.insert(ecMenuItems);
        }

        public void update(EC_tblMenuItems ecMenuItems)
        {
            sql.update(ecMenuItems);
        }

        public void delete(EC_tblMenuItems ecMenuItems)
        {
            sql.delete(ecMenuItems);
        }

        public DataTable selectField(string field, string condition)
        {
            return sql.selectField(field, condition);
        }

        public String getSqlString(string field, string condition)
        {
            return sql.getSqlString(field, condition);
        }
    }
}
