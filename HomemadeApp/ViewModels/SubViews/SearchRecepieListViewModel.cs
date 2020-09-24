using Caliburn.Micro;
using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace HomemadeApp.ViewModels
{
    class SearchRecepieListViewModel : Screen
    {
        public event EventHandler<int> OnRecepieClickSR;
        public event EventHandler OnRecepieSelectSR;

        public BindableCollection<RecepieModel> RecepieList { get; set; }

        public RecepieModel SelectedRecepie { get; set; }

        private Border _previousBorder;

        public SearchRecepieListViewModel()
        {
            _previousBorder = new Border();
            RecepieList = new BindableCollection<RecepieModel>();
            SelectedRecepie = new RecepieModel();
        }
        public void UpdateList(List<string> tags)
        {
            RecepieList = new BindableCollection<RecepieModel>(
                    DataAccess.Instance.FiltrRecepieByTags(tags));
            NotifyOfPropertyChange(() => RecepieList);

        }

        public void RecepieClick(RecepieModel rec, Border border)
        {
            _previousBorder.BorderBrush = Brushes.Black;
            _previousBorder = border;
            border.BorderBrush = Brushes.Blue;
            
            if (SelectedRecepie == rec) 
                OnRecepieClickSR?.Invoke(this, rec.RecepieId);

            SelectedRecepie = rec;
            OnRecepieSelectSR?.Invoke(this, null);
        }

        public void ClearSelectedRecepie()
        {
            RecepieClick(new RecepieModel(), new Border());
        }


    }
}
