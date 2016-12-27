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
    public class Sql_tblReceiptDetail
    {
        DBConnection cn = new DBConnection();
        public void insert(EC_tblReceiptDetail ecReceiptDetail)
        {
            cn.ExecuteSqlQuery(@"INSERT INTO ReceiptDetail(RECEIPTID, PRODUCTID, AMOUNT, TOTAL) VALUES (N'" + 
                                ecReceiptDetail.ReceiptID + "',N'" + ecReceiptDetail.ProductID + "',N'" + 
                                ecReceiptDetail.Amount + "',N'" + ecReceiptDetail.Total + "')");
        }

        public void update(EC_tblReceiptDetail ecReceiptDetail)
        {
            cn.ExecuteSqlQuery(@"UPDATE ReceiptDetail SET PRODUCTID = N'" + ecReceiptDetail.ProductID +
                                 "', AMOUNT = N'" + ecReceiptDetail.Amount + "', TOTAL = N'" + 
                                 ecReceiptDetail.Total + "' WHERE RECEIPTID = N'" + ecReceiptDetail.ReceiptID + "'");
        }

        public void delete(EC_tblReceiptDetail ecReceiptDetail)
        {
            cn.ExecuteSqlQuery(@"DELETE FROM ReceiptDetail WHERE RECEIPTID = N'" + ecReceiptDetail.ReceiptID + "'");
        }

        public DataTable select(string condition)
        {
            return cn.GetDataTable("SELECT * FROM ReceiptDetail" + condition);
        }
    }
}
