using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using HomemadeApp.Models;

namespace HomemadeApp
{
    class DataAccess
    {

        public List<RecepieModel> GetRecepieById(int recepieId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("HomemadeDB"))) 
            {
                var output = connection.Query<RecepieModel>($"spRecepies_GetById @RecepieId", new { RecepieId = recepieId }).ToList();
                return output;
            }
        }

        public List<ItemListModel> GetRecepieIngById(int recepieId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("HomemadeDB")))
            {
                var output = connection.Query<ItemListModel>($"spContain_GetRecepieIngById @RecepieId", new { RecepieId = recepieId }).ToList();
                return output;
            }
        }
    }
}
