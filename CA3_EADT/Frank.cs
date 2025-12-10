//Fixer.cs
using CA3_EADT;
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
        public Frank(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<FrankResponse?> CurrentRates()
        {
            return await _httpClient.GetFromJsonAsync<FrankResponse>("api/rates");
        }
    }
}
