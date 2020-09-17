﻿using Caliburn.Micro;
using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.ViewModels
{
    class SearchRecepieListViewModel : Screen
    {
        public event EventHandler<int> OnRecepieClickSR;

        public BindableCollection<RecepieModel> RecepieList { get; set; }

        public void UpdateList(List<string> tags)
        {
            RecepieList = new BindableCollection<RecepieModel>(
                    DataAccess.Instance.FiltrRecepieByTags(tags));
            NotifyOfPropertyChange(() => RecepieList);

        }

        public void RecepieClick(RecepieModel rec)
        {
            OnRecepieClickSR?.Invoke(this, rec.RecepieId);
        }


    }
}
