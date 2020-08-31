using Caliburn.Micro;
using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.ViewModels
{
    class RecepieViewModel : Screen
    {
        //D:\Documents\RecepieDB\AppTest\ChickenChowMein.mp4

        public BindableCollection<ItemListModel> Ingredients { get; }

        public RecepieViewModel()
        {
            Ingredients = new BindableCollection<ItemListModel>();
            DataAccess da = DataAccess.Instance;
            Recepie = da.GetRecepieById(5)[0];

            Ingredients.AddRange(da.GetRecepieIngById(5));
        }


        public RecepieModel Recepie { get; set; }

    }
}
