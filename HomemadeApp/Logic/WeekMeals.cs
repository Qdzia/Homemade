using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.Logic
{
    class WeekMeals
    {
        public List<MealModel> WeekMealPlan { get; set; }
        public DateTime Week { get; set; }
        public int WeekNum { get; set; }

        public WeekMeals(DateTime numOfWeek)
        {
            Week = numOfWeek;
            WeekMealPlan = new List<MealModel>();
            for (int i = 0; i < 7; i++)
            {
                WeekMealPlan.AddRange(DataAccess.Instance.GetMealsOfDay(numOfWeek.AddDays(i)));
            }
        }
        public void SaveMeal(DateTime day, int numOfMeal, RecepieModel rec,int servings)
        {
            if (rec.RecepieName == null) return;

            for (int i = 0; i < WeekMealPlan.Count; i++)
            {
                if (WeekMealPlan[i].NumberOfMeal == numOfMeal && WeekMealPlan[i].ExpectedDate.DayOfWeek == day.DayOfWeek)
                    WeekMealPlan.RemoveAt(i);
            }

            WeekMealPlan.Add(new MealModel(0,rec.RecepieId,2,day,numOfMeal,servings,"",rec.RecepieName));

        }

        public void SendChanges()
        {
           DataAccess.Instance.InsertMeal(WeekMealPlan);
        }
        public List<MealModel> GetMealsFromDay(int day)
        {
            var dayRec = new List<MealModel>();

            foreach (var meal in WeekMealPlan)
            {
                if ((int)meal.ExpectedDate.DayOfWeek == day) dayRec.Add(meal);
            }

            return dayRec;
        }

        public MealModel GetMeal(int day, int numOfMeal)
        {
            foreach (var meal in WeekMealPlan)
            {
                if ((int)meal.ExpectedDate.DayOfWeek == day && meal.NumberOfMeal == numOfMeal) return meal;
            }
            return null;
        }
    }
}
