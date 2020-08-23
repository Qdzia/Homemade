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
    class FreeSearchViewModel : Screen
    {
        public TagBarViewModel TagBar { get; set; }

        public string SearchText { get; set; }
        public BindableCollection<TagBoxModel> TagList { get; set; }
        public BindableCollection<string> ActiveTags { get; set; }
        public BindableCollection<IngredientModel> IngredientsList { get; set; }

        public FreeSearchViewModel()
        {
            TagList = new BindableCollection<TagBoxModel>();
            TagList.AddRange(DataAccess.Instance.GetAllTags());
            ActiveTags = new BindableCollection<string>();
            WireUpTagBar();
            SearchText = "Hej";
        }

        private void WireUpTagBar()
        {
            TagBar = new TagBarViewModel();
            TagBar.Tags = new BindableCollection<TagBoxModel>(DataAccess.Instance.GetAllTags());
            TagBar.OnTagChange += SearchByTags;
        
        }

        public void SearchByTags(object sender, EventArgs e)
        {
            SearchText = "Tag event działa";
            NotifyOfPropertyChange(() => SearchText);
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
