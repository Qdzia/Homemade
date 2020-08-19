using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Models
{
    public class IngredientModel
    {
        public int IngId { get; set; }
        public string IngName { get; set; }
        public int Category { get; set; }

        public decimal Calories { get; set; }
        public decimal Fat { get; set; }
        public decimal Carbs { get; set; }
        public decimal Fiber { get; set; }
        public decimal Sugar { get; set; }
        public decimal Protein { get; set; }
        public decimal Sodium { get; set; }
        public decimal TransFat { get; set; }
        public decimal Cholesterol { get; set; }


        public IngredientModel(int ingId, string ingName, int category, decimal calories, decimal fat,
            decimal carbs, decimal fiber, decimal sugar, decimal protein, decimal sodium, decimal transFat, decimal cholesterol)
        {
            IngId = ingId;
            IngName = ingName;
            Category = category;
            Calories = calories;
            Fat = fat;
            Carbs = carbs;
            Fiber = fiber;
            Sugar = sugar;
            Protein = protein;
            Sodium = sodium;
            TransFat = transFat;
            Cholesterol = cholesterol;

        }
    }
}
