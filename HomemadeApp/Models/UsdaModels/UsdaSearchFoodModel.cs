using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Models
{
    class UsdaSearchFoodModel
    {
        public int FdcId { get; set; }
        public string Description { get; set; }
        public List<UsdaSearchFoodNutrientModel> FoodNutrients { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
