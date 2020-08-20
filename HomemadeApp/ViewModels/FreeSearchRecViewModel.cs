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
        public BindableCollection<string> ActiveTags { get; set; }
        public BindableCollection<RecepieModel> RecepieList { get; set; }

        private string _searchBarText;

        public string SearchBarText
        {
            get { return _searchBarText; }
            set { _searchBarText = value; }
        }


        public FreeSearchRecViewModel()
        {
            TagList = new BindableCollection<TagBoxModel>();
            TagList.AddRange(DataAccess.Instance.GetAllTags());
            ActiveTags = new BindableCollection<string>();
            ActiveTags.Add("TestTag");
            TestText = "Here TagsSSS";

            RecepieList = new BindableCollection<RecepieModel>(DataAccess.Instance.GetAllRec());
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
