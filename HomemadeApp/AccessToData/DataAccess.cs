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

        public List<IngListModel> GetRecepieIngById(int recepieId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("HomemadeDB")))
            {
                var output = connection.Query<IngListModel>($"spContain_GetRecepieIngById @RecepieId", new { RecepieId = recepieId }).ToList();
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

        public List<RecepieModel> GetAllRec()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("HomemadeDB")))
            {
                var output = connection.Query<RecepieModel>($"spRecepies_GetAllRec").ToList();
                return output;
            }
        }

        public List<RecepieModel> FiltrRecepieByTags(List<string> tags)
        {
            if (tags.Count == 0) return GetAllRec();

            string tagList = "";

            foreach (var tag in tags)
            {
                tagList += tag.Trim() + "|";
            }
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("HomemadeDB")))
            {
                var output = connection.Query<RecepieModel>($"spTaged_SearchRecepieByTags @Tags", new { Tags = tagList }).ToList();
                return output;
            }

        }

       
        public List<RecepieModel> FiltrRecepieByName(string name)
        {
            name = "%" + name.Trim() + "%";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("HomemadeDB")))
            {
                var output = connection.Query<RecepieModel>($"spRecepies_SearchRecepieByName @Name", new { Name = name }).ToList();
                return output;
            }
        }

        public int InsertRecepie(RecepieModel rec)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("HomemadeDB")))
            {
                List<RecepieModel> recList = new List<RecepieModel>();
                recList.Add(rec);

                connection.Execute("spRecepies_Insert @RecepieName, @Instruction, @PrepTime, @TotalTime,@Video,@Photo,@UserId,@CreatedAt", recList);
                var indx = connection.Query<InsertedIdModel>("SELECT IDENT_CURRENT ('Recepies') AS InsertedId");

                return indx.ToArray()[0].InsertedId;
            }
        }

        public void InsertRecepieIng(List<ContainModel> ings)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("HomemadeDB")))
            {
                connection.Execute("spContain_Insert @RecepieId, @IngId, @Number, @Unit, @Notes", ings);

            }
        }
        //spIngredients_Insert
        public void InsertIng(IngredientModel ing)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("HomemadeDB")))
            {
                List<IngredientModel> ingList = new List<IngredientModel>();
                ingList.Add(ing);

                connection.Execute("spIngredients_Insert @IngName, @Category, @Calories, @Fat, @Carbs, @Fiber, @Sugar, @Protein, @Sodium, @TransFat, @Cholesterol", ingList);
            }
        }
    }
}
