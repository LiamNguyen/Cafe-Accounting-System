using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AccountingSystemEntity;

namespace AccountingSystemDAL
{
    public class Sql_tblPermission
    {
        DBConnection cn = new DBConnection();
        public void insert(EC_tblPermission ecPermission)
        {
            cn.ExecuteSqlQuery(@"INSERT INTO Permission (STAFFID, LOGINID, PASSWORD, PER_ORDER, PER_STAFFS, PER_STOCK, PER_RIGHTSCONTROL,
                                PER_REPORT, PER_MENUITEMS, STATUS) VALUES (N'"
                                + ecPermission.StaffID + "', N'" + ecPermission.LoginID + "', N'" + ecPermission.Password + "', N'"
                                + ecPermission.PerOrder + "', N'" + ecPermission.PerStaffs + "', N'" + ecPermission.PerStock + "', N'"
                                + ecPermission.PerRightsControl + "', N'" + ecPermission.PerReport + "', N'" + ecPermission.PerMenuItems
                                + "', '1')");
        }

        public void update(EC_tblPermission ecPermission)
        {
            cn.ExecuteSqlQuery(@"UPDATE Permission SET LOGINID = N'" + ecPermission.LoginID + "', PASSWORD = N'" 
                                + ecPermission.Password + "', PER_ORDER = N'" + ecPermission.PerOrder + "', PER_STAFFS = N'" 
                                + ecPermission.PerStaffs + "', PER_STOCK = N'" + ecPermission.PerStock + "', PER_RIGHTSCONTROL = N'" 
                                + ecPermission.PerRightsControl + "', PER_REPORT = N'" + ecPermission.PerReport + "', PER_MENUITEMS = N'" 
                                + ecPermission.PerMenuItems + "' where STAFFID = N'" + ecPermission.StaffID + "'");
        }

        public void delete(EC_tblPermission ecPermission)
        {
            cn.ExecuteSqlQuery(@"UPDATE Permission SET STATUS = '0' WHERE STAFFID = N'" + ecPermission.StaffID + "'");
        }
        
        public DataTable select(string condition)
        {
            return cn.GetDataTable(@"SELECT Permission.STAFFID, Staffs.STAFFNAME, Permission.LOGINID, Permission.PASSWORD, 
                                    Permission.PER_ORDER, Permission.PER_STAFFS, Permission.PER_STOCK, Permission.PER_RIGHTSCONTROL, 
                                    Permission.PER_REPORT, Permission.PER_MENUITEMS
                                    FROm Permission INNER JOIN Staffs ON Permission.STAFFID = Staffs.STAFFID " + condition);
        }

        public DataTable authenticateSelect(string username, string password)
        {
            return cn.GetDataTable(@"SELECT Permission.LOGINID, Permission.PASSWORD, Permission.STAFFID, Staffs.STAFFNAME FROM Permission
                                    INNER JOIN Staffs ON  Permission.STAFFID = Staffs.STAFFID WHERE 
                                    LOGINID = '" + username + "' and PASSWORD = '" + password + "'");
        }
    }
}
