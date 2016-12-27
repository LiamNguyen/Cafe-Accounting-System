using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AccountingSystemDAL
{
    public class DBConnection
    {
        public static SqlConnection connect;

        public void cnOpen()
        {
            if (DBConnection.connect == null)
                DBConnection.connect = new SqlConnection("Server=.\\SQLEXPRESS;Database=AccountingSystemDb; User ID=sa;Password=ThanhTruc1208");
            if (DBConnection.connect.State != ConnectionState.Open)
                DBConnection.connect.Open();
        }

        public void cnClose()
        {
            if (DBConnection.connect != null)
            {
                if (DBConnection.connect.State == ConnectionState.Open)
                    DBConnection.connect.Close();
            }
           
        }

        public void ExecuteSqlQuery(string sqlStr)
        {
            try
            {
                cnOpen();
                SqlCommand cmd = new SqlCommand(sqlStr, connect);
                cmd.ExecuteNonQuery();
                cnClose();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string GetSqlQueryAsStr(string sqlStr)
        {
            try
            {
                cnOpen();
                SqlCommand cmd = new SqlCommand(sqlStr, connect);
                string returnStr = cmd.ExecuteScalar().ToString();
                cnClose();
                return returnStr;
            }
            catch
            {
                return "N/A";
            }
        }

        public DataTable GetDataTable(string sqlCmd) //select
        {
            try
            {
                cnOpen();
                DataTable dataTb = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd, connect);
                adapter.Fill(dataTb);
                cnClose();
                return dataTb;
            }
            catch
            {
                return null;
            }
        }

        public SqlConnection getConnection()
        {
            return connect;
        }

    }
}
