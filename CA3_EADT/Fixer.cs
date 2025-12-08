using static System.Net.WebRequestMethods;
using CA3_EADT;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace Currency
{
    public class Fixer : ComponentBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        //private readonly string _apiKey = "5cf7a2ea2eb7e25f4eceb9c158876116";
        public Fixer(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            //_httpClient.BaseAddress = new Uri("https://data.fixer.io/api/");
        }
        public async Task<FixerResponse?> CurrentRates(string Base = "EUR")
        {
            string apiKey = _config["FixerApiKey"];
            string url = $"https://data.fixer.io/api/latest?access_key={apiKey}";
            return await _httpClient.GetFromJsonAsync<FixerResponse>(url);
        }
        protected override async Task OnInitializedAsync()
        {
            var response = await CurrentRates("EUR");
            if (response != null && response.Success)
            {
                var conversion = new Conversion
                {
                    Amount = 1,
                    Quote = CurrencyTypes.GBP
                };
                await conversion.LoadRateAsync(response);
            }
        }
    }
    public class FixerResponse
    {
        public bool Success { get; set; }
        public string Base { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
    }
}
