﻿using Caliburn.Micro;
using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.ViewModels
{
    class DayPlanListViewModel : Screen
    {
        public BindableCollection<MealModel> MealsOfDay { get; set; }
        public event EventHandler<int> OnRecepieClickDP;
        public string DayName { get; set; }
        public string DateFormat { get; set; }

        private DateTime _date;
        public DayPlanListViewModel(DateTime date)
        {
            _date = date;
            MealsOfDay = new BindableCollection<MealModel>();
            MealsOfDay.AddRange(DataAccess.Instance.GetMealsOfDay(date));
            DayName = date.DayOfWeek.ToString();
            DateFormat =  $"{date.Day}.{date.Month}.{date.Year}";
        }

        public void RecepieClick(MealModel meal) 
        {
            OnRecepieClickDP?.Invoke(this, meal.RecepieId);
        }
        protected override void OnActivate()
        {
            MealsOfDay = new BindableCollection<MealModel>();
            MealsOfDay.AddRange(DataAccess.Instance.GetMealsOfDay(_date));
        }
    }
}
