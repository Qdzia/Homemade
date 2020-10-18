using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Models
{
    class MealModel
    {
        public int MealId { get; set; }
        public int RecepieId { get; set; }
        public int UserId { get; set; }
        public DateTime ExpectedDate { get; set; }
        public int NumberOfMeal { get; set; }
        public int Servings { get; set; }
        public string Notes { get; set; }
        public string RecepieName { get; set; }

        public MealModel(int mealId, int recepieId, int userId, DateTime expectedDate, int numberOfMeal, int servings, string notes,string recepieName)
        {
            MealId = mealId;
            RecepieId = recepieId;
            UserId = userId;
            ExpectedDate = expectedDate;
            NumberOfMeal = numberOfMeal;
            Servings = servings;
            Notes = notes;
            RecepieName = recepieName;

        }


    }
}
