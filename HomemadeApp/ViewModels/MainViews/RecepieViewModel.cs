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


        public IngListViewModel RecepieIngList { get; set; }

        public RecepieViewModel(int recId)
        {
            Recepie = DataAccess.Instance.GetRecepieById(recId)[0];
            RecepieIngList = new IngListViewModel();
            RecepieIngList.IngList = new BindableCollection<IngListModel>();
            RecepieIngList.IngList.AddRange(DataAccess.Instance.GetRecepieIngById(recId));
        }


        public RecepieModel Recepie { get; set; }

    }
}
