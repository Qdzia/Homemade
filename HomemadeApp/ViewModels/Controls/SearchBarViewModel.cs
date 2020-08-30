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

        private bool _lookForRecepies;
        public bool LookForRecepie
        {
            get { return _lookForRecepies; }
            set { _lookForRecepies = value; NotifyOfPropertyChange(() => LookForRecepie); }
        }



        public SearchBarViewModel()
        {
            SearchByRec = true;
            LookForRecepie = false;
        }

        public void ClearText()
        {
            SearchText = "";
            NotifyOfPropertyChange(() => SearchText);

        }
        public void ChangeSearchMode(object image)
        {
            var icon = image as Image;

            //soon gonna add this feature
            //if (SearchForRecepie) icon.Visibility = Visibility.Visible;
            //else icon.Visibility = Visibility.Collapsed;

            SearchByRec = !SearchByRec;
            NotifyOfPropertyChange(() => SearchByRec);
        }

        public bool CanChangeSearchMode()
        {
            if (LookForRecepie) return true;
            else return true;
        }
    }
}
