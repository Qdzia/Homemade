using Caliburn.Micro;
using HomemadeApp.Controls;
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
    class FreeSearchViewModel : Conductor<object>
    {
        public BindableCollection<TagBoxModel> TagList { get; set; }
        public BindableCollection<string> ActiveTags { get; set; }
        public BindableCollection<IngredientModel> IngredientsList { get; set; }

        public SearchGridIng SGIng { get; set; }
        //public UserControl SearchGrid { get; set; }

        public FreeSearchViewModel()
        {
            TagList = new BindableCollection<TagBoxModel>();
            TagList.AddRange(DataAccess.Instance.GetAllTags());
            ActiveTags = new BindableCollection<string>();
            ActiveTags.Add("TestTag");
            TestText = "Here TagsSSS";

        //https://caliburnmicro.com/documentation/composition
            //IngredientsList = new BindableCollection<IngredientModel>();
            //IngredientsList.AddRange(DataAccess.Instance.GetAllIng());
            //SearchGrid = new SearchGridIng();
        }

        public bool CanChangeRecToIng()
        {
            return true;
        }
        public void ChangeRecToIng()
        {
            ActivateItem(new PlannerViewModel());
        }

        public string TestText { get; set; }
    }
}
