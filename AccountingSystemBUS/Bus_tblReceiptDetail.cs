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
    public class Bus_tblReceiptDetail
    {
        Sql_tblReceiptDetail sql = new Sql_tblReceiptDetail();
        public void insert(EC_tblReceiptDetail ecReceiptDetail)
        {
            sql.insert(ecReceiptDetail);
        }

        public void update(EC_tblReceiptDetail ecReceiptDetail)
        {
            sql.update(ecReceiptDetail);
        }

        public void delete(EC_tblReceiptDetail ecReceiptDetail)
        {
            sql.delete(ecReceiptDetail);
        }

        public DataTable select(string condition)
        {
            return sql.select(condition);
        }
    }
}
