using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Client.Components.Pages
{
    public partial class CoffeeShop : ComponentBase
    {
        private List<CoffeeShopModel> Shops = new();

        [Inject] private HttpClient HttpClient { get; set; }
         //Helps to send http requests
        [Inject] private IConfiguration Config { get; set; }
        // Helps to access configured settings
        protected override async Task OnInitializedAsync()
        {
            var result = await HttpClient.GetAsync(Config["apiUrl"] + "/api/CoffeeShop");
            //makes API call to get all coffee shops from given URL

            if (result.IsSuccessStatusCode)
            {
                Shops = await result.Content.ReadFromJsonAsync<List<CoffeeShopModel>>();
            }
            //loads all coffee shops into the list if fetched from api
        }

    } 
}
