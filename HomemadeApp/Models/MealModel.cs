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

    }
}
