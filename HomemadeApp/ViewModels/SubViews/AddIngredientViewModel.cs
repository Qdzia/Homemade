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


        private UsdaSearchFoodModel _selectedFood;

        public UsdaSearchFoodModel SelectedFood
        {
            get { return _selectedFood; }
            set 
            { 
                _selectedFood = value;
                IngName = value.Description;
                NotifyOfPropertyChange(() => IngData); 
                NotifyOfPropertyChange(() => IngName); 
            }
        }

        public string IngName { get; set; }

        public string IngData
        {
            get { return PrepareIngData(); }
        }

        public AddIngredientViewModel()
        {
            _searchData = new UsdaSearchModel();
            UsdaIngList = new BindableCollection<UsdaSearchFoodModel>();
            _selectedFood = new UsdaSearchFoodModel();
            _selectedFood.FoodNutrients = new List<UsdaSearchFoodNutrientModel>();


        }

        public async void SearchIngClick()
        {
            _searchData = await FoodDataCentralProcessor.LoadFood();
            UsdaIngList.AddRange(_searchData.Foods);
        }

        string PrepareIngData()
        {
            string result = "";

            foreach (var nutrient in SelectedFood.FoodNutrients)
            {
                result += nutrient.ToString()+'\n';
            }

            return result;
        }
    }
}
