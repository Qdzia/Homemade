using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace HomemadeApp.ViewModels
{
    class SearchBarViewModel : Screen
    {
        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; NotifyOfPropertyChange(() => IsTextInBar); }
        }

        public Image SearchRecImage { get; set; }

        public bool SearchByRec { get; set; }

        public bool IsTextInBar { get { return !String.IsNullOrWhiteSpace(SearchText); } }
        public SearchBarViewModel()
        {
            SearchByRec = true;
        }

        public void ClearText()
        {
            SearchText = "";
            NotifyOfPropertyChange(() => SearchText);

        }
        public void ChangeSearchMode(object item)
        {
            SearchByRec = !SearchByRec;
            NotifyOfPropertyChange(() => SearchByRec);
        }
    }
}
