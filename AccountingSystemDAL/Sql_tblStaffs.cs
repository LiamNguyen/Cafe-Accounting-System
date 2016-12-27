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
    public class Sql_tblStaffs
    {
        DBConnection cn = new DBConnection();
        public void insert(EC_tblStaffs ecStaff)
        {
            cn.ExecuteSqlQuery(@"INSERT INTO Staffs (STAFFID, STAFFNAME, DOB, GENDER, ADDRESS, PHONE, EMAIL, STARTWORKDAY, STATUS) VALUES (N'"
                                + ecStaff.StaffID + "', N'" + ecStaff.StaffName + "', N'" + ecStaff.Dob + "', N'"
                                + ecStaff.Gender + "', N'" + ecStaff.Address + "', N'" + ecStaff.Phone + "', N'"
                                + ecStaff.Email + "', N'" + ecStaff.StartWorkDay + "', '1')");
        }

        public void update(EC_tblStaffs ecStaff)
        {
            cn.ExecuteSqlQuery(@"UPDATE Staffs SET STAFFNAME = N'" + ecStaff.StaffName + "', DOB = N'" + ecStaff.Dob + 
                                "', GENDER = N'" + ecStaff.Gender + "', ADDRESS = N'" +
                                ecStaff.Address + "', PHONE = N'" + ecStaff.Phone + "', EMAIL = N'" + ecStaff.Email +
                                "', STARTWORKDAY = N'" + ecStaff.StartWorkDay + "' where STAFFID = N'" + ecStaff.StaffID + "'");
        }

        public void delete(EC_tblStaffs ecStaff)
        {
            cn.ExecuteSqlQuery(@"UPDATE Staffs SET STATUS = '0' WHERE STAFFID = N'" + ecStaff.StaffID + "'");
        }

        public DataTable selectToValidate()
        {
            return cn.GetDataTable("SELECT STAFFID FROM Staffs");
        }

        public DataTable selectField(string field, string condition)
        {
            return cn.GetDataTable("SELECT " + field + " FROM Staffs WHERE " + condition + " STATUS = '1' ORDER BY STAFFNAME ASC");
        }

        public DataTable select(string condition)
        {
            return cn.GetDataTable("SELECT STAFFID, STAFFNAME, DOB, GENDER, ADDRESS, PHONE, EMAIL, STARTWORKDAY FROM Staffs WHERE STATUS = '1' ORDER BY STAFFNAME ASC");
        }
    }
}
