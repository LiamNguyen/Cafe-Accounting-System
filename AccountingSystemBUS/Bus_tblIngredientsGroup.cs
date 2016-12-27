using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using AccountingSystemDAL;
using AccountingSystemEntity;

namespace AccountingSystemBUS
{
    public class Bus_tblIngredientsGroup
    {
        Sql_tblIngredientsGroup sql = new Sql_tblIngredientsGroup();

        public void insert(EC_tblIngredientsGroup ecGroup)
        {
            sql.insert(ecGroup);
        }

        public void update(EC_tblIngredientsGroup ecGroup)
        {
            sql.update(ecGroup);
        }

        public void delete(EC_tblIngredientsGroup ecGroup)
        {
            sql.delete(ecGroup);
        }

        public DataTable select()
        {
            return sql.select();
        }

        public String getQueryAsString(String field, String condition)
        {
            return sql.getQueryAsString(field, condition);
        }
    }
}
