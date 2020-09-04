using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Models
{
    class UsdaSearchModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<UsdaSearchFoodModel> Foods { get; set; }

        public override string ToString()
        {
            return $"UsdaSearch Total:{TotalPages} Current:{CurrentPage} Foods:{Foods.Count}";
        }
    }
}
