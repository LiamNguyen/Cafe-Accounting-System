using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AccountingSystemEntity;

namespace AccountingSystemDAL
{
    public class Sql_tblIngredients
    {
        //SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=AccountingSystemDb;User ID=sa;Password=ThanhTruc1208");
        SqlTransaction trans = null;
        DBConnection connection = new DBConnection();

        public void insert(EC_tblIngredients ecIng, EC_tblIngredientsDetail ecIngDetail)
        {
            try
            {
                connection.cnOpen();
                trans = connection.getConnection().BeginTransaction();
                SqlCommand cmd3 = new SqlCommand(@"INSERT INTO PriceDetail(PRODUCTID, PRODUCTPRICE, PRICETBL_ID, STATUS) VALUES (N'" + ecIng.IngredientID
                                                + "', N'" + ecIngDetail.IngredientPrice + "', '" + getActiveTblPrice() + "', '1')", connection.getConnection(), trans);
                cmd3.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand(@"INSERT INTO Ingredients(ING_ID, ING_NAME, DATE, STAFFID, GROUP_ID, STATUS) VALUES(N'"
                                                + ecIng.IngredientID + "', N'" + ecIng.IngredientName+ "', N'" + ecIng.Date + "', N'" + ecIng.StaffID + "', N'" + ecIng.GroupID + "', '1')", connection.getConnection(), trans);
                cmd.ExecuteNonQuery();
                
                SqlCommand cmd2 = new SqlCommand(@"INSERT INTO IngredientsDetail(ING_ID, PKG_NO, EXPIRED_DATE, QUANTITY, QUANTITY_INPUT, UNIT, VAT, STATUS) VALUES(N'"
                                                + ecIngDetail.IngredientID + "', N'" + ecIngDetail.PkgNo + "', N'" + ecIngDetail.ExpiredDate + "', N'" + ecIngDetail.Quantity + "', N'"
                                                + ecIngDetail.QuantityInput + "', N'" + ecIngDetail.Unit + "', N'" + ecIngDetail.Vat + "', '1')", connection.getConnection(), trans);
                cmd2.ExecuteNonQuery();

                trans.Commit();
                trans.Dispose();
                connection.cnClose();
            }
            catch (Exception)
            {
                trans.Rollback();
                trans.Dispose();
            }
        }

        public void update(EC_tblIngredients ecIng, EC_tblIngredientsDetail ecIngDetail)
        {
            try
            {
                connection.cnOpen();
                trans = connection.getConnection().BeginTransaction();
                SqlCommand cmd = new SqlCommand(@"UPDATE Ingredients SET ING_NAME = N'" + ecIng.IngredientName + "', GROUP_ID = N'" + ecIng.GroupID + "' WHERE ING_ID = N'" 
                                                + ecIng.IngredientID + "'", connection.getConnection(), trans);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(@"UPDATE IngredientsDetail SET PKG_NO = N'" + ecIngDetail.PkgNo + "', EXPIRED_DATE = N'" + ecIngDetail.ExpiredDate 
                                                + "', QUANTITY = N'" + ecIngDetail.Quantity + "', QUANTITY_INPUT = N'" + ecIngDetail.QuantityInput + "', UNIT = N'" 
                                                + ecIngDetail.Unit + "', VAT = N'" + ecIngDetail.Vat + "' WHERE ING_ID = N'" + ecIngDetail.IngredientID + "'", connection.getConnection(), trans);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand(@"UPDATE PriceDetail SET PRODUCTPRICE = N'" + ecIngDetail.IngredientPrice
                                                + "' WHERE PRODUCTID = N'" + ecIngDetail.IngredientID + "'", connection.getConnection(), trans);
                cmd3.ExecuteNonQuery();

                trans.Commit();
                trans.Dispose();
                connection.cnClose();
            }
            catch (Exception)
            {
                trans.Dispose();
                trans.Rollback();
            }
        }

        public void delete(EC_tblIngredients ecIng, EC_tblIngredientsDetail ecIngDetail)
        {
            try
            {
                connection.cnOpen();
                trans = connection.getConnection().BeginTransaction();
                SqlCommand cmd = new SqlCommand("UPDATE Ingredients SET STATUS = '0' WHERE ING_ID = N'" + ecIng.IngredientID + "'", connection.getConnection(), trans);

                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("UPDATE IngredientsDetail SET STATUS = '0' WHERE ING_ID = N'" + ecIngDetail.IngredientID + "'", connection.getConnection(), trans);

                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand("UPDATE PriceDetail SET STATUS = '0' WHERE PRODUCTID = N'" + ecIngDetail.IngredientID + "'", connection.getConnection(), trans);

                cmd3.ExecuteNonQuery();

                trans.Commit();
                trans.Dispose();
                connection.cnClose();
            }
            catch (Exception)
            {
                trans.Dispose();
                trans.Rollback();
            }
        }

        public DataTable select()
        {
            return connection.GetDataTable(@"SELECT IngredientsDetail.ING_ID, Ingredients.ING_NAME, IngredientsDetail.PKG_NO, IngredientsDetail.EXPIRED_DATE, IngredientsDetail.QUANTITY, 
                                            IngredientsDetail.QUANTITY_INPUT, IngredientsDetail.UNIT, IngredientsDetail.VAT, PriceDetail.PRODUCTPRICE, Ingredients.GROUP_ID
                                            FROM Ingredients 
                                            INNER JOIN IngredientsDetail ON Ingredients.ING_ID = IngredientsDetail.ING_ID 
                                            INNER JOIN IngredientsGroup ON Ingredients.GROUP_ID = IngredientsGroup.GROUP_ID
                                            INNER JOIN PriceDetail ON Ingredients.ING_ID = PriceDetail.PRODUCTID
                                            WHERE Ingredients.STATUS = '1'
                                            ORDER BY IngredientsDetail.ING_ID ASC");
        }

        private String getActiveTblPrice()
        {
            SqlCommand cmd = new SqlCommand("SELECT PRICETBL_ID FROM Price WHERE STATUS = '1'", connection.getConnection(), trans);
            string returnStr = cmd.ExecuteScalar().ToString();
            return returnStr;
        }
    }
}
