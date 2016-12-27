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
    public class Sql_tblReceipt
    {
        DBConnection cn = new DBConnection();
        public void insert(EC_tblReceipt ecReceipt)
        {
            cn.ExecuteSqlQuery(@"INSERT INTO Receipt(RECEIPTID, DATE, STAFFID, TOTAL) VALUES (N'" + ecReceipt.ReceiptID +
                                "', N'" + ecReceipt.Date + "', N'" + ecReceipt.StaffID + "', N'" + ecReceipt.Total + "')");
        }

        public void update(EC_tblReceipt ecReceipt)
        {
            cn.ExecuteSqlQuery(@"UPDATE Receipt SET DATE = N'" + ecReceipt.Date + "', STAFFID = N'" + ecReceipt.StaffID + 
                                "', TOTAL = N'" + ecReceipt.Total + "' WHERE RECEIPTID = N'" + ecReceipt.ReceiptID  + "'");
        }

        public void delete(EC_tblReceipt ecReceipt)
        {
            cn.ExecuteSqlQuery(@"DELETE FROM Receipt WHERE RECEIPTID = N'" + ecReceipt.ReceiptID + "'");
        }

        public DataTable select(string condition)
        {
            return cn.GetDataTable("SELECT * FROM Receipt" + condition);
        }

        public String getQueryString(String field, String condition)
        {
            return cn.GetSqlQueryAsStr("SELECT " + field + " FROM Receipt " + condition);
        }
    }
}
