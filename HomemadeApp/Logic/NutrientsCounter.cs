using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Logic
{
    class NutrientsCounter
    {
        public IngredientModel CountListNutrients(List<IngListModel> ingList)
        {
            var output = new IngredientModel();
            var allIng = DataAccess.Instance.GetAllIng();

            foreach (var ing in ingList)
            {
                foreach (var ingDB in allIng)
                {
                    if (ing.IngId == ingDB.IngId)
                    {
                        var amount = UnitsConventer(ing.Unit, ing.IngName, ing.Number);
                        output = AddNutrients(output, ingDB, amount);
                    }
                }
            }

            return output;
        }

        public IngredientModel AddNutrients(IngredientModel baseIng, IngredientModel newIng, decimal multiplier)
        {
            multiplier /= 100;

            baseIng.Calories += newIng.Calories * multiplier;
            baseIng.Fat += newIng.Fat * multiplier;
            baseIng.Carbs += newIng.Carbs * multiplier;
            baseIng.Fiber += newIng.Fiber * multiplier;
            baseIng.Sugar += newIng.Sugar * multiplier;
            baseIng.Protein += newIng.Protein * multiplier;
            baseIng.Sodium += newIng.Sodium * multiplier;
            baseIng.TransFat += newIng.TransFat * multiplier;
            baseIng.Cholesterol += newIng.Cholesterol * multiplier;

            return baseIng;
        }

        public decimal UnitsConventer(string unit, string ingName, decimal number)
        {

            if(unit == "g" || unit == "ml") return number;

            decimal conValue;
            if (unit == "tsp")
            {
                if (TspConventer.TryGetValue(ingName, out conValue))
                {
                    return number * conValue;
                }
            }

            if (unit == "tbsp")
            {
                if (TbspConventer.TryGetValue(ingName, out conValue))
                {
                    return number * conValue;
                }
            }

            if (ingName == "garlic" && unit == "cloves") return 4m;

            return 0;
        }

        Dictionary<string, decimal> TspConventer = new Dictionary<string, decimal> 
        { 
            { "salt", 5.9m }, 
            { "pepper", 2.33m },
            { "ginger", 1.76m }
        };

        Dictionary<string, decimal> TbspConventer = new Dictionary<string, decimal>
        {
            { "salt", 17.07m },
            { "pepper", 7m },
            { "sesame seed",9.13m}
        };
    }
}
