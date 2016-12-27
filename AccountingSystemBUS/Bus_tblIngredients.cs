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
    public class Bus_tblIngredients
    {
        Sql_tblIngredients sql = new Sql_tblIngredients();

        public void insert(EC_tblIngredients ecIng, EC_tblIngredientsDetail ecIngDetail)
        {
            sql.insert(ecIng, ecIngDetail);
        }

        public void update(EC_tblIngredients ecIng, EC_tblIngredientsDetail ecIngDetail)
        {
            sql.update(ecIng, ecIngDetail);
        }

        public void delete(EC_tblIngredients ecIng, EC_tblIngredientsDetail ecIngDetail)
        {
            sql.delete(ecIng, ecIngDetail);
        }

        public DataTable select()
        {
            return sql.select();
        }
    }
}
