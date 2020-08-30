using Caliburn.Micro;
using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.ViewModels
{
    class AddRecepieViewModel : Screen
    {
        public IngListViewModel RecepieIngList { get; set; }
        public AddIngredientViewModel AddIng { get; set; }
        public AddRecepieViewModel()
        {
            RecepieIngList = new IngListViewModel();
            RecepieIngList.IngList = new BindableCollection<ItemListModel>();
            RecepieIngList.IngList.Add(new ItemListModel("Carrot", 23, "Kg", "To jest to"));

            AddIng = new AddIngredientViewModel();


        }
    }
}
