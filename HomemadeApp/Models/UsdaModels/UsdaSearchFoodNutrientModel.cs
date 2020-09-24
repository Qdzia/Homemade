using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Models
{
    class UsdaSearchFoodNutrientModel
    {
        public int NutrientId { get; set; }
        public string NutrientName { get; set; }
        public string UnitName { get; set; }
        public decimal Value { get; set; }

        public override string ToString()
        {
            return $"{NutrientName}:  {Value:F} {UnitName.ToLower()}";
        }
    }
}
