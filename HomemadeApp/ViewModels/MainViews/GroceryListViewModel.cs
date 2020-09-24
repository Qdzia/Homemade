using Caliburn.Micro;
using HomemadeApp.Logic;
using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.ViewModels
{
    class GroceryListViewModel : Screen
    {
        public IngListViewModel RecepieIngList { get; set; }
        public GroceryListViewModel()
        {
            RecepieIngList = new IngListViewModel();
            RecepieIngList.IngList = new BindableCollection<IngListModel>();

            IngListHandler handler = new IngListHandler();

            List<RecepieModel> recList = new List<RecepieModel>(DataAccess.Instance.GetAllRec());
            RecepieIngList.IngList.AddRange(handler.SumUpIng(recList));

        }

    }
}
