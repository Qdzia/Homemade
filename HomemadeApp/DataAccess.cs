using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace HomemadeApp
{
    class DataAccess
    {

        public List<RecepieSample> GetRecepie()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("HomemadeDB"))) 
            {
                var output = connection.Query<RecepieSample>($"select * from RecepieSample").ToList();
                return output;
            }
        }
    }
}
