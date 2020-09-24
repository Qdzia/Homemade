using HomemadeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HomemadeApp.AccessToData
{
    class FoodDataCentralProcessor
    {
        public static async Task<UsdaSearchModel> SearchForFood(string searchPhrase)
        {
            searchPhrase = searchPhrase.Trim().Replace(" ", "%20");

            string url = $"https://api.nal.usda.gov/fdc/v1/foods/search?api_key=LnbdPI6vn3uaV18pf42eem8u5d3anRW6olmNk2Vr&query=" 
                + searchPhrase + "&dataType=SR%20Legacy&pageSize=25&sortBy=dataType.keyword";
            
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    //string content = await response.ToString();
                    UsdaSearchModel searchResult = await response.Content.ReadAsAsync<UsdaSearchModel>();
                    return searchResult;
                }
                else 
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }
    }
}
