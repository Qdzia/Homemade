using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Models
{
    class WeekMenuModel
    {
        public List<InMenuModel> WeekMealPlan { get; set; }
        public DateTime Week { get; set; }

        public WeekMenuModel()
        {
            WeekMealPlan = new List<InMenuModel>();
        }
        public void SaveMeal(DateTime day, int numOfMeal, RecepieModel rec)
        {
            if (rec.RecepieName == null) return;

            for (int i = 0; i < WeekMealPlan.Count; i++)
            {
                if (WeekMealPlan[i].Number == numOfMeal && WeekMealPlan[i].Day == (int)day.DayOfWeek)
                    WeekMealPlan.RemoveAt(i);
            }
            //if (Week >= day.AddDays(-1)) return;
            //if ((day - Week).TotalDays > 7) return;
          
            WeekMealPlan.Add(new InMenuModel(rec, (int)day.Date.DayOfWeek, numOfMeal));
            
        }
        public List<InMenuModel> GetMealsFromDay(int day)
        {
            var dayRec = new List<InMenuModel>();

            foreach (var meal in WeekMealPlan)
            {
                if (meal.Day == day) dayRec.Add(meal);
            }

            return dayRec;
        }

        public InMenuModel GetMeal(int day, int numOfMeal)
        {
            foreach (var meal in WeekMealPlan)
            {
                if (meal.Day == day && meal.Number == numOfMeal) return meal;
            }
            return null;
        }
    }
}
