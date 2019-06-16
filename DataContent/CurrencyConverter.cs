using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContent
{
    /// <summary>
    /// Работа с обраткой JSON запросов
    /// </summary>
    public class CurrencyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Currency));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject dataJO = JObject.Load(reader);

            Currency currency = new Currency();
            currency.ID = int.Parse(dataJO["id"]?.ToString() ?? "0");
            currency.Name = dataJO["name"].GetIfNull();
            currency.Symbol = dataJO["symbol"].GetIfNull();
            currency.CmcRank = dataJO["cmc_rank"].GetIfNull();

            JObject quoteJA = (JObject)dataJO["quote"];
            JObject usdJA = (JObject)quoteJA["USD"];
            currency.Price = usdJA["price"].CheckOnNull();
            currency.PercentChangeOneHour = usdJA["percent_change_1h"].CheckOnNull();
            currency.PercentChangeTwentyFourHour = usdJA["percent_change_24h"].CheckOnNull();
            currency.MarketCap = usdJA["market_cap"].CheckOnNull();
            currency.LastUpdated = Convert.ToDateTime(usdJA["last_updated"]?.ToString() ?? "");

            return currency;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
