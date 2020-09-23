using Caliburn.Micro;
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

        public string DayName { get { return _currentDay.DayOfWeek.ToString(); } }
        public string MealName { get { return $"Meal {_mealNumber}"; } }
        public string WeekName { get; set; }
        public int Servings { get; set; }
        public string RecepieName { get { return GetSelectedRecepieName(); } }

        private DateTime _currentDay;
        private DateTime _currentWeek;
        private int _mealNumber;

        public DayPlannerViewModel()
        {
            FreeSearch = new FreeSearchViewModel();
            _currentDay = DateTime.Now;
            _currentWeek = DateTime.Now;
            _mealNumber = 2;
        }
        private string GetSelectedRecepieName()
        {
            if (FreeSearch.SearchRecepieList.SelectedRecepie.RecepieName != null)
                return FreeSearch.SearchRecepieList.SelectedRecepie.RecepieName;
            else
                return "Recepie Not Selected";
        }

        public void NextMeal()
        { 
            
        }
        public void PreviousMeal()
        {

        }
        public void NextDay()
        {

        }
        public void PreviousDay()
        {

        }

    }
}
