using Caliburn.Micro;
using HomemadeApp.Models;
using HomemadeApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.ViewModels
{
    class RecepieViewModel : Screen
    {
        public IngListViewModel RecepieIngList { get; set; }

        public NutrientsLabelViewModel NutrientsLabel { get; set; }

        public RecepieViewModel(int recId)
        {
            Recepie = DataAccess.Instance.GetRecepieById(recId)[0];
            RecepieIngList = new IngListViewModel();
            RecepieIngList.IngList = new BindableCollection<IngListModel>();
            RecepieIngList.IngList.AddRange(DataAccess.Instance.GetRecepieIngById(recId));

            NutrientsCounter nutrientsCounter = new NutrientsCounter();
            NutrientsLabel = new NutrientsLabelViewModel();
            NutrientsLabel.Nutrients = nutrientsCounter.CountListNutrients(RecepieIngList.IngList.ToList());
            //NutrientsLabel.Nutrients = new IngredientModel(1,"xd",1,2345,23,34,45,56,67,78,89,7);
        }


        public RecepieModel Recepie { get; set; }

    }
}
