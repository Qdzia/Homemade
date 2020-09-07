﻿using Caliburn.Micro;
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
            RecepieIngList = new IngListViewModel();
            RecepieIngList.IngList = new BindableCollection<ItemListModel>();
            RecepieIngList.IngList.Add(new ItemListModel("Carrot", 23, "Kg", "To jest to"));

            AddIng = new AddIngredientViewModel();

            PrepTimeEdit = new TimeEditViewModel();
            TotalTimeEdit = new TimeEditViewModel();

        }

        public void AddIngClick()
        {
            ConverterStrItm con = new ConverterStrItm();
            List<ItemListModel> itemlist = new List<ItemListModel>(con.TextToItemListModel(AddIngText));

            foreach (var item in itemlist)
            {
                if (!con.IsNameExistInDB(item.IngName))
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

            DataAccess.Instance.InsertRecepie(rec);
            ClearForm();
        }

        private void ClearForm()
        {
            AddIngText = "";
            NotifyOfPropertyChange(() => AddIngText);
            RecepieName = "";
            NotifyOfPropertyChange(() => RecepieName);
            RecepieInstruction = "";
        }

    }
}
