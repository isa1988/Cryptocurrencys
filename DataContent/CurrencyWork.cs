using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using DataContent.xml;

namespace DataContent
{
    /// <summary>
    /// Вернуть криптовалюты
    /// </summary>
    public class CurrencyWork
    {
        private string dataBaseKey;
        public CurrencyWork()
        {
            Configuration cfg = null;
            if (HttpContext.Current != null)
            {
                cfg =
                    System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            }
            else
            {
                cfg =
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
            KeyOfDataBaseConfigSection section = (KeyOfDataBaseConfigSection)cfg.GetSection("KeyOfDataBaseCon");
            if (section == null) return;
            dataBaseKey = section.FolderItems[0].Key;
        }

        /// <summary>
        /// Сделать запрос на сервер
        /// </summary>
        /// <returns>Строку JSon</returns>
        public string makeAllCur()
        {
            var url = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "5000";
            queryString["convert"] = "USD";

            url.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", dataBaseKey);
            client.Headers.Add("Accept", "application/json");
            return client.DownloadString(url.ToString());
        }

        /// <summary>
        /// Сделать запрос на сервер
        /// </summary>
        /// <returns>JSon</returns>
        public JObject GetAllCur()
        {
            return JObject.Parse(makeAllCur());
        }

        /// <summary>
        /// Сделать запрос на сервер
        /// </summary>
        /// <returns>JSon</returns>
        public JObject GetAllCur(string line)
        {
            return JObject.Parse(line);
        }

        /// <summary>
        /// Вернуть список криптовалют
        /// </summary>
        /// <returns></returns>
        public List<Currency> GetCurrenciesOfUSD()
        {
            JObject lsJObject = GetAllCur();
            JArray lstCurr = (JArray)lsJObject["data"];

            //return lstCurr.ToObject<List<Currency>>();
            return JsonConvert.DeserializeObject<List<Currency>>(lstCurr.ToString(),
                new CurrencyConverter());
        }

        
    }
}
