using Caliburn.Micro;
using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.ViewModels
{
    class RestrictionsPanelViewModel : Screen
    {
        public List<RestrictionsModel> Restrictions { get; set; }
        public string[] Categories { get; set; }

        public string SelectedCategory { get; set; }
        public int MaxNum { get; set; }
        public int MinNum { get; set; }

        public RestrictionsPanelViewModel()
        {
            Restrictions = DataAccess.Instance.GetRestrictionsByUserId(2);
            Categories = DataAccess.Instance.Restrictions;
        }

        public void AddRestriction()
        {
            int resId = Array.IndexOf(Categories, SelectedCategory);
            var res = new RestrictionsModel(resId, 2, MaxNum, MinNum);
            DataAccess.Instance.InsertRestriction(res);
            Restrictions = DataAccess.Instance.GetRestrictionsByUserId(2);
        }


    }
}
