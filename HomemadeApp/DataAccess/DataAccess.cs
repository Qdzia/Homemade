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
        #region Singleton
        private static DataAccess instance = null;
        private static readonly object padlock = new object();

        DataAccess() { }
        public static DataAccess Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DataAccess();
                    }
                    return instance;
                }
            }
        }
        #endregion

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

        public List<TagBoxModel> GetAllTags()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("HomemadeDB")))
            {
                var tags = connection.Query<TagModel>($"spTags_GetAllTags").ToList();

                List<TagBoxModel> output = new List<TagBoxModel>();
                foreach (var tag in tags)
                {
                    output.Add(new TagBoxModel(tag));
                }

                return output;
            }
        }

        public List<IngredientModel> GetAllIng()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("HomemadeDB")))
            {
                var output = connection.Query<IngredientModel>($"spIngredients_GetAll").ToList();
                return output;
            }
        }
    }
}
