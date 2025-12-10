//Fixer.cs
using CA3_EADT;
using Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
//using System.Net.Http;
//using System.Net.Http.Json;

namespace Currency
{
    public class Fixer
    {
        private readonly HttpClient _httpClient;
        //private readonly IConfiguration _config;
        //private readonly string _apiKey = "5cf7a2ea2eb7e25f4eceb9c158876116";
        public Fixer(HttpClient httpClient)
        {
            _httpClient = httpClient;
            //_config = config;
            //_httpClient.BaseAddress = new Uri("https://data.fixer.io/api/");
        }
        public async Task<FixerResponse?> CurrentRates()
        {
            return await _httpClient.GetFromJsonAsync<FixerResponse>("api/rates");
        }
        //protected override async Task OnInitializedAsync()
        //{
        //    //HttpClient.GetFromJsonAsync<FixerResponse>("https://localhost:7254")
        //    var response = await CurrentRates("EUR");
        //    if (response != null && response.Success)
        //    {
        //        var conversion = new ConvertCurrency
        //        {
        //            Amount = 1,
        //            Quote = CurrencyTypes.GBP
        //        };
        //        await conversion.LoadRateAsync(response);
        //    }
        //}
    }
}
