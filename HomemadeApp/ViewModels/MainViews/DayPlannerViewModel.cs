﻿using Caliburn.Micro;
using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.ViewModels
{
    class DayPlannerViewModel : Screen
    {
        public FreeSearchViewModel FreeSearch { get; set; }
        public event EventHandler<int> OnRecepieClick;

        public string DayName { get { return _currentDay.DayOfWeek.ToString(); } }
        public string MealName { get { return $"Meal {_mealNumber}"; } }
        public string WeekName { get { return GetWeekDateFormat(); } }
        public int Servings { get; set; }
        public string RecepieName { get { return GetSelectedRecepieName(); } }

        private DateTime _currentDay;
        private DateTime _currentWeek;
        private int _mealNumber;

        public DayPlannerViewModel()
        {
            FreeSearch = new FreeSearchViewModel();
            FreeSearch.SearchRecepieList.OnRecepieSelectSR += UpdateRecepieName;
            FreeSearch.SearchRecepieList.OnRecepieClickSR += RecepieClick;

            _currentDay = DateTime.Now;
            _currentWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1); 
            _mealNumber = 2;
        }

        public void RecepieClick(object sender, int recId)
        {
            OnRecepieClick?.Invoke(this, recId);
        }

        private string GetSelectedRecepieName()
        {
            if (FreeSearch.SearchRecepieList.SelectedRecepie.RecepieName != null)
                return FreeSearch.SearchRecepieList.SelectedRecepie.RecepieName;
            else
                return "Recepie Not Selected";
        }

        private string GetWeekDateFormat()
        {
            int startOfWeek = _currentWeek.Day;
            int endOfWeek = _currentWeek.AddDays(6).Day;

            string month = _currentWeek.Month.ToString();
            if (_currentWeek.Month < 10) month = "0" + month;

            string year = _currentWeek.Year.ToString();
            year = year.Substring(Math.Max(0, year.Length - 2));

            return $"{startOfWeek}-{endOfWeek}.{month}.{year}";
        }
        public void UpdateRecepieName(object obj,EventArgs e)
        {
            NotifyOfPropertyChange(() => RecepieName);
        }
        public void NextMeal()
        {
            if (_mealNumber == 8) return;
            _mealNumber++;
            NotifyOfPropertyChange(() => MealName);
            FreeSearch.SearchRecepieList.ClearSelectedRecepie();
        }
        public void PreviousMeal()
        {
            if (_mealNumber == 1) return;
            _mealNumber--;
            NotifyOfPropertyChange(() => MealName);
            FreeSearch.SearchRecepieList.ClearSelectedRecepie();
        }
        public void NextDay()
        {
            if (_currentDay.DayOfWeek == DayOfWeek.Sunday) return;
            _currentDay = _currentDay.AddDays(1);
            NotifyOfPropertyChange(() => DayName);
            FreeSearch.SearchRecepieList.ClearSelectedRecepie();
        }
        public void PreviousDay()
        {
            _currentDay = _currentDay.AddDays(-1);
            NotifyOfPropertyChange(() => DayName);
            FreeSearch.SearchRecepieList.ClearSelectedRecepie();
        }

        public void ServingsPlus()
        {
            Servings++;
            NotifyOfPropertyChange(() => Servings);
        }

        public void ServingsMinus()
        {
            if (Servings == 1) return;
            Servings--;
            NotifyOfPropertyChange(() => Servings);
        }

        public void NextWeek()
        {
            _currentWeek = _currentWeek.AddDays(7);
            NotifyOfPropertyChange(() => WeekName);
        }
        public void PreviousWeek()
        {
            _currentWeek = _currentWeek.AddDays(-7);
            NotifyOfPropertyChange(() => WeekName);
        }

    }
}
