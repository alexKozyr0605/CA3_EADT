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
    public class Frank
    {
        private readonly HttpClient _httpClient;
        //private readonly IConfiguration _config;
        //private readonly string _apiKey = "5cf7a2ea2eb7e25f4eceb9c158876116";
        public Frank(HttpClient httpClient)
        {
            _httpClient = httpClient;
            //_config = config;
            //_httpClient.BaseAddress = new Uri("https://data.fixer.io/api/");
        }
        public async Task<FrankResponse?> CurrentRates()
        {
            return await _httpClient.GetFromJsonAsync<FrankResponse>("api/rates");
        }
    }
}
