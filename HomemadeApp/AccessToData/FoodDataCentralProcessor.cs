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
        public async Task LoadFood()
        {
            string url = "";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    //Model model = await response.Content.ReadAsAsync<Model>();
                }
                else 
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        
        }
    }
}
