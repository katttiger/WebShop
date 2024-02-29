using System.Text.Json.Serialization;

namespace WebShop.Common.Classes
{
    public class ExchangeRate
    {
        [JsonPropertyName("exchange_rate")]
        public double Rate { get; set; }

        [JsonPropertyName("currency_pair")]
        public string CurrencyPair { get; set; } = string.Empty;

        private const string apiKey = "oSZAPBiQWuTEFVLaXLzrkQ==SCNxLNPoxMs72JLy";

        //JSON
        //{
        //  "currency_pair": "USD_EUR",
        //  "exchange_rate": 0.826641
        //}
    }

   
}

