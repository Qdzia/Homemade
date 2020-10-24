using Caliburn.Micro;
using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.ViewModels
{
    class PlannerViewModel : Conductor<Screen>.Collection.AllActive
    {
        public event EventHandler<int> OnRecepieClick;
        public DayPlanListViewModel WeekPlanList { get; set; }
        public List<DayPlanListViewModel> DaysList { get; set; }
        public List<RestrictionsModel> Restrictions { get; set; }
        public PlannerViewModel()
        {
            DaysList = new List<DayPlanListViewModel>();

            for (int i = 0; i < 7; i++)
            {
                DayPlanListViewModel dp = new DayPlanListViewModel(new DateTime(2020, 09, 21+i));
                dp.OnRecepieClickDP += RecepieClick;
                DaysList.Add(dp);
            }

            Restrictions = new List<RestrictionsModel>();
            Restrictions.AddRange(DataAccess.Instance.GetRestrictionsByUserId(2));
            CountRestrictions();
        }

        protected override void OnActivate()
        {
            foreach (var item in DaysList)
            {
                ActivateItem(item);
            }
        }
        public void RecepieClick(object sender, int recId)
        {
            OnRecepieClick?.Invoke(this, recId);
        }

        public void CountRestrictions()
        {
            foreach (var res in Restrictions)
            {
                foreach (var day in DaysList)
                {
                    res.Num += (int)day.CountNutrientsOfDay(res.ResId);
                }
            }
        
        }
    }
}
