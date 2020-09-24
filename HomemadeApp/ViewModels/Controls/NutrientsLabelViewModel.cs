using Caliburn.Micro;
using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.ViewModels
{
    class NutrientsLabelViewModel : Screen
    {
        public IngredientModel Nutrients { get; set; }

        public NutrientsLabelViewModel()
        {
            Nutrients = new IngredientModel();
        }
    }
}
