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
    class AddRecepieViewModel : Screen
    {
        public IngListViewModel RecepieIngList { get; set; }
        public AddIngredientViewModel AddIng { get; set; }

        public TimeEditViewModel PrepTimeEdit { get; set; }
        public TimeEditViewModel TotalTimeEdit { get; set; }

        public string AddIngText { get; set; }
        public string RecepieName { get; set; }
        public string RecepieInstruction { get; set; }
        public string PathToPhoto { get; set; }
        public string PathToVideo { get; set; }
        public AddRecepieViewModel()
        {
            ClearForm();
            AddIng = new AddIngredientViewModel();

        }

        public void AddIngClick()
        {
            ConverterStrItm con = new ConverterStrItm();
            List<IngListModel> itemlist = new List<IngListModel>(con.TextToItemListModel(AddIngText));

            foreach (var item in itemlist)
            {
                item.IngId = con.VerifyName(item);
                if (item.IngId == -1)
                {
                    AddIngText += $"\n*{item.IngName}, not exist in DB*";
                    NotifyOfPropertyChange(() => AddIngText);
                    return;
                }
            }
            RecepieIngList.IngList.AddRange(itemlist);
            AddIngText = "";
            NotifyOfPropertyChange(() => AddIngText);
        }

        public void AddRecepieClick()
        {
            RecepieModel rec = new RecepieModel
                (0, RecepieName, RecepieInstruction, PrepTimeEdit.Time,TotalTimeEdit.Time, PathToVideo, PathToPhoto,2,DateTime.Now,0);

            var recIndx = DataAccess.Instance.InsertRecepie(rec);
            InsertIngredients(recIndx);
            ClearForm();
        }

        public void InsertIngredients(int recIndx)
        {
            List<ContainModel> ings = new List<ContainModel>();
            foreach (var ing in RecepieIngList.IngList)
            {
                ings.Add(new ContainModel(recIndx,ing.IngId,ing.Number,ing.Unit,ing.Notes));
            }
            DataAccess.Instance.InsertRecepieIng(ings);
        
        }

        private void ClearForm()
        {
            AddIngText = "";
            RecepieName = "";
            RecepieInstruction = "";
            PathToPhoto = "";
            PathToVideo = "";

            RecepieIngList = new IngListViewModel();
            RecepieIngList.IngList = new BindableCollection<IngListModel>();

            PrepTimeEdit = new TimeEditViewModel();
            TotalTimeEdit = new TimeEditViewModel();

            NotifyOfPropertyChange(() => AddIngText);
            NotifyOfPropertyChange(() => RecepieName);
            NotifyOfPropertyChange(() => RecepieInstruction);
            NotifyOfPropertyChange(() => PathToPhoto);
            NotifyOfPropertyChange(() => PathToVideo);
            NotifyOfPropertyChange(() => RecepieIngList);
            NotifyOfPropertyChange(() => PrepTimeEdit);
            NotifyOfPropertyChange(() => TotalTimeEdit);
        }

    }
}
