namespace WebShop.Common.Classes
{
    public class ExchagneConverter
    {
        //APIbaseurl==apibase
        string apiUrlbase = $"https://api.api-ninjas.com/v1/exchangerate?pair=";

        IHttpClientFactory _httpClientFactory;
        public ExchagneConverter(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        public async Task Method(string ToCurrency, string fromCurrency = "USD")
        {
            using var _httpClient = _httpClientFactory.CreateClient();

            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", "oSZAPBiQWuTEFVLaXLzrkQ==SCNxLNPoxMs72JLy");
            string apiUrl = $"{apiUrlbase}{fromCurrency}_{ToCurrency}";
            var response = await _httpClient.GetFromJsonAsync<ExchangeRate>(apiUrl);

            fromCurrency = response.CurrencyPair.Split('_')[0];
            ToCurrency = response.CurrencyPair.Split('_')[1];
        }
    }
}
