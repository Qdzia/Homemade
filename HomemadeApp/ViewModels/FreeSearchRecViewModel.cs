using Caliburn.Micro;
using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.ViewModels
{
    class FreeSearchRecViewModel : Screen
    {

        public BindableCollection<TagBoxModel> TagList { get; set; }
        public BindableCollection<RecepieModel> RecepieList { get; set; }

        private string _searchBarText;

        public string SearchBarText
        {
            get { return _searchBarText; }
            set 
            { 
                _searchBarText = value;
                NotifyOfPropertyChange(() => SearchBarText);
                RecepieList.Clear();
                RecepieList.AddRange(DataAccess.Instance.FiltrRecepieByName(value));
            }
        }
        private BindableCollection<string> _activeTags;

        public BindableCollection<string> ActiveTags
        {
            get { return _activeTags; }
            set
            {
                _activeTags = value;
            }

        }

     


        public FreeSearchRecViewModel()
        {
            RecepieList = new BindableCollection<RecepieModel>();
            TagList = new BindableCollection<TagBoxModel>();
            TagList.AddRange(DataAccess.Instance.GetAllTags());
            ActiveTags = new BindableCollection<string>();
            TestText = "Here TagsSSS";

           
            

            //SearchBarText = "T";
        }

        public bool CanChangeRecToIng()
        {
            return true;
        }
        public void ChangeRecToIng()
        {

        }

        public string TestText { get; set; }
    }
}
