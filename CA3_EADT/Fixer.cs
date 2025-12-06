using static System.Net.WebRequestMethods;

namespace Currency
{
    public class Fixer
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "5cf7a2ea2eb7e25f4eceb9c158876116";
        public Fixer(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://data.fixer.io/api/");
        }
        //public async Task<FixerResponse> GetLatestRatesAsync()
        //{
        //    return await _http.GetFromJsonAsync<FixerResponse>($"latest?access_key={_apiKey}");
        //}

        //// GET https://data.fixer.io/api/symbols?access_key=YOUR_KEY
        //public async Task<FixerSymbolsResponse> GetSymbolsAsync()
        //{
        //    return await _http.GetFromJsonAsync<FixerSymbolsResponse>($"symbols?access_key={_apiKey}");
        //}
    }
}
