using Caliburn.Micro;
using HomemadeApp.Models;
using HomemadeApp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HomemadeApp.ViewModels
{
    class FreeSearchViewModel : Screen
    {
        public TagBarViewModel TagBar { get; set; }
        public SearchBarViewModel SearchBar { get; set; }

        public SearchRecepieListViewModel SearchRecepieList { get; set; }
        public SearchIngListViewModel SearchIngList { get; set; }

        public string SearchText { get; set; }
        public BindableCollection<TagBoxModel> TagList { get; set; }
        public BindableCollection<string> ActiveTags { get; set; }
        public BindableCollection<IngredientModel> IngredientsList { get; set; }

        public Visibility SearchVisibilityRec
        { 
            get 
            {
                if (SearchBar.LookForRecepie) return Visibility.Visible;
                else return Visibility.Collapsed;
            } 
        }
        public Visibility SearchVisibilityIng
        {
            get
            {
                if (SearchBar.LookForRecepie) return Visibility.Collapsed;
                else return Visibility.Visible; 
            }
        }
        public string LookForText 
        { 
            get
            {
                if (SearchBar.LookForRecepie) return "Looking for recepies";
                else return "Looking for ingredients";
            } 
        }


        public FreeSearchViewModel()
        {
            TagList = new BindableCollection<TagBoxModel>();
            TagList.AddRange(DataAccess.Instance.GetAllTags());
            ActiveTags = new BindableCollection<string>();
            WireUpTagBar();
            SearchText = "Hej";

            SearchBar = new SearchBarViewModel();


            SearchRecepieList = new SearchRecepieListViewModel();
            SearchRecepieList.RecepieList = new BindableCollection<RecepieModel>();
            SearchRecepieList.RecepieList.AddRange(DataAccess.Instance.GetAllRec());

            SearchIngList = new SearchIngListViewModel();
            SearchIngList.IngList = new BindableCollection<IngredientModel>();
            SearchIngList.IngList.AddRange(DataAccess.Instance.GetAllIng());


            

        }
        public void ChangeLookingMode()
        {
            SearchBar.LookForRecepie = !SearchBar.LookForRecepie;
            NotifyOfPropertyChange(() => SearchVisibilityIng);
            NotifyOfPropertyChange(() => SearchVisibilityRec);
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

            SearchRecepieList.UpdateList(TagBar.ActiveTags.ToList());
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
