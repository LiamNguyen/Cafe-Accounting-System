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
    public class Sql_tblMenuItems
    {
        //SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=AccountingSystemDb;User ID=sa;Password=ThanhTruc1208");
        SqlTransaction trans = null;
        DBConnection connection = new DBConnection();
        public void insert(EC_tblMenuItems ecMenuItems)
        {
            try
            {
                connection.cnOpen();
                trans = connection.getConnection().BeginTransaction();

                SqlCommand cmd = new SqlCommand(@"INSERT INTO PriceDetail(PRODUCTID, PRODUCTPRICE, PRICETBL_ID, STATUS) VALUES (N'" + ecMenuItems.ProductID 
                                                + "', N'" + ecMenuItems.ProductPrice + "', '" + getActiveTblPrice() + "', '1')", connection.getConnection(), trans);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(@"INSERT INTO MenuItems(PRODUCTID, PRODUCTNAME, STATUS) VALUES (N'" + ecMenuItems.ProductID 
                                                + "', N'" + ecMenuItems.ProductName + "', '1')", connection.getConnection(), trans);
                cmd2.ExecuteNonQuery();

                trans.Commit();
                trans.Dispose();
                connection.cnClose();
            }
            catch
            {
                trans.Rollback();
                trans.Dispose();
            }
        }

        public void update(EC_tblMenuItems ecMenuItems)
        {
            try
            {
                connection.cnOpen();
                trans = connection.getConnection().BeginTransaction();
                SqlCommand cmd = new SqlCommand(@"UPDATE MenuItems SET PRODUCTNAME = N'" + ecMenuItems.ProductName
                                    + "' WHERE PRODUCTID = N'" + ecMenuItems.ProductID + "'", connection.getConnection(), trans);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(@"UPDATE PriceDetail SET PRODUCTPRICE = N'" + ecMenuItems.ProductPrice
                                    + "' WHERE PRODUCTID = N'" + ecMenuItems.ProductID + "'", connection.getConnection(), trans);
                cmd2.ExecuteNonQuery();

                trans.Commit();
                trans.Dispose();
                connection.cnClose();
            }
            catch
            {
                trans.Dispose();
                trans.Rollback();
            }
        }

        public void delete(EC_tblMenuItems ecMenuItems)
        {
            try
            {
                connection.cnOpen();
                trans = connection.getConnection().BeginTransaction();
                SqlCommand cmd = new SqlCommand(@"UPDATE MenuItems SET STATUS = '0' WHERE PRODUCTID = N'" + ecMenuItems.ProductID + "'", connection.getConnection(), trans);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(@"UPDATE PriceDetail SET STATUS = '0' WHERE PRODUCTID = N'" + ecMenuItems.ProductID + "'", connection.getConnection(), trans);
                cmd2.ExecuteNonQuery();

                trans.Commit();
                trans.Dispose();
                connection.cnClose();
            }
            catch
            {
                trans.Rollback();
                trans.Dispose();
            }
        }
        //NOT YET DONE
        public DataTable selectField(string field, string condition) {
            return connection.GetDataTable("SELECT " + field + " FROM MenuItems INNER JOIN PriceDetail ON MenuItems.PRODUCTID = PriceDetail.PRODUCTID " + condition);
        }

        public String getSqlString(string field, string condition) 
        {
            return connection.GetSqlQueryAsStr("SELECT " + field + " FROM PriceDetail " + condition);
        }

        private String getActiveTblPrice()
        {
            SqlCommand cmd = new SqlCommand("SELECT PRICETBL_ID FROM Price WHERE STATUS = '1'", connection.getConnection(), trans);
            string returnStr = cmd.ExecuteScalar().ToString(); 
            return returnStr;
        }
    }
}
