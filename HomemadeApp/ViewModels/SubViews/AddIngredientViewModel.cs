using Caliburn.Micro;
using HomemadeApp.AccessToData;
using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.ViewModels
{
    class AddIngredientViewModel : Screen
    {
        public BindableCollection<UsdaSearchFoodModel> UsdaIngList { get; set; }
        private UsdaSearchModel _searchData;

        public string[] Categories { get; set; } = { "Dark-Green Vegetables", 
            "Red & Orange Vegetables", "Legumes(Beans & Peas)", 
            "Starchy Vegetables", "Other Vegetables", "Protein Foods", 
            "Grains", "Fruits", "Dairy", "Oils", "Others" };
        public string SelectedCategory { get; set; }

        private UsdaSearchFoodModel _selectedFood;

        public UsdaSearchFoodModel SelectedFood
        {
            get { return _selectedFood; }
            set 
            { 
                _selectedFood = value;
                if (value != null) IngName = value.Description.ToLower();
                else IngName = "";
                NotifyOfPropertyChange(() => IngData); 
                NotifyOfPropertyChange(() => IngName); 
            }
        }

        public string IngName { get; set; }

        public string IngData
        {
            get { return PrepareIngData(); }
        }
        public string SearchPhrase { get; set; }

        public AddIngredientViewModel()
        {
            _searchData = new UsdaSearchModel();
            UsdaIngList = new BindableCollection<UsdaSearchFoodModel>();
            _selectedFood = new UsdaSearchFoodModel();
            _selectedFood.FoodNutrients = new List<UsdaSearchFoodNutrientModel>();

        }

        public async void SearchPhraseClick()
        {
            _searchData = await FoodDataCentralProcessor.SearchForFood(SearchPhrase);
            UsdaIngList.Clear();
            UsdaIngList.AddRange(_searchData.Foods);
        }

        string PrepareIngData()
        {
            string result = "";

            if(SelectedFood == null ) return result;

            foreach (var nutrient in SelectedFood.FoodNutrients)
            {
                if (nutrient.NutrientId == 2000 || nutrient.NutrientId == 1003 || nutrient.NutrientId == 1253 || nutrient.NutrientId == 1258 || 
                    nutrient.NutrientId == 1079 || nutrient.NutrientId == 1093 || nutrient.NutrientId == 1005 || nutrient.NutrientId == 1008 || 
                    nutrient.NutrientId == 1004) result += nutrient.ToString() + '\n';
            }
            //Display all labels
            //foreach (var nutrient in SelectedFood.FoodNutrients)
            //{
            //    result += nutrient.ToString()+'\n';
            //}

            return result;
        }

        public void AddToBaseClick()
        {
            IngredientModel ing = new IngredientModel();
            ing.IngName = IngName.ToLower();

            ing.Category = Array.IndexOf(Categories,SelectedCategory);

            foreach (var nutrient in SelectedFood.FoodNutrients)
            {
                if (nutrient.NutrientId == 2000) ing.Sugar = nutrient.Value;
                if (nutrient.NutrientId == 1003) ing.Protein = nutrient.Value;
                if (nutrient.NutrientId == 1253) ing.Cholesterol = nutrient.Value;
                if (nutrient.NutrientId == 1258) ing.TransFat = nutrient.Value;
                if (nutrient.NutrientId == 1079) ing.Fiber = nutrient.Value;
                if (nutrient.NutrientId == 1093) ing.Sodium = nutrient.Value;
                if (nutrient.NutrientId == 1005) ing.Carbs = nutrient.Value;
                if (nutrient.NutrientId == 1008) ing.Calories = nutrient.Value;
                if (nutrient.NutrientId == 1004) ing.Fat = nutrient.Value;
            }

            DataAccess.Instance.InsertIng(ing);

            SelectedFood = null;
        }
    }
}
