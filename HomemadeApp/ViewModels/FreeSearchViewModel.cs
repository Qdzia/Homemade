using Caliburn.Micro;
using HomemadeApp.Controls;
using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HomemadeApp.ViewModels
{
    class FreeSearchViewModel : Screen
    {
        public BindableCollection<TagBoxModel> TagList { get; set; }
        public BindableCollection<string> ActiveTags { get; set; }

        public FreeSearchViewModel()
        {
            TagList = new BindableCollection<TagBoxModel>();
            TagList.AddRange(DataAccess.Instance.GetAllTags());
            ActiveTags = new BindableCollection<string>();
            ActiveTags.Add("TestTag");
            TestText = "Here TagsSSS";
        }

        public bool CanChangeRecToIng()
        {
            return true;
        }
        public void ChangeRecToIng()
        {
            TagList.Add(new TagBoxModel("Meat", new SolidColorBrush(Colors.Red), false));
        
        }

        public string TestText { get; set; }
    }
}
