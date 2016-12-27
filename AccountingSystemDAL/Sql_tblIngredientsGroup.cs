using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using AccountingSystemEntity;

namespace AccountingSystemDAL
{
    public class Sql_tblIngredientsGroup
    {
        DBConnection cn = new DBConnection();

        public void insert(EC_tblIngredientsGroup ecGroup)
        {
            cn.ExecuteSqlQuery(@"INSERT INTO IngredientsGroup(GROUP_ID, GROUP_NAME, DATE, STAFFID, UPDATEDAT, STATUS) VALUES 
                                 (N'" + ecGroup.GroupID + "', N'" + ecGroup.GroupName + "', N'" + ecGroup.Date + 
                                 "', N'" + ecGroup.StaffID + "', N'" + ecGroup.UpdatedAt + "' '1')");
        }

        public void update(EC_tblIngredientsGroup ecGroup)
        {
            cn.ExecuteSqlQuery(@"UPDATE IngredientsGroup SET GROUP_NAME = N'" + ecGroup.GroupName 
                                 + "', UPDATEDAT = '" + ecGroup.UpdatedAt + "' WHERE GROUP_ID = N'" + ecGroup.GroupID + "'");
        }

        public void delete(EC_tblIngredientsGroup ecGroup)
        {
            cn.ExecuteSqlQuery(@"UPDATE IngredientsGroup SET STATUS = '0' WHERE GROUP_ID = N'" 
                                + ecGroup.GroupID + "'");
        }

        public DataTable select()
        {
            return cn.GetDataTable(@"SELECT GROUP_ID, GROUP_NAME, DATE, STAFFID FROM IngredientsGroup WHERE STATUS = '1' ORDER BY GROUP_ID ASC");
        }

        public String getQueryAsString(String field, String condition)
        {
            return cn.GetSqlQueryAsStr("SELECT " + field + " FROM IngredientsGroup " + condition);
        }
    }
}
