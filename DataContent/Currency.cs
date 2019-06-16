using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContent
{
    [JsonConverter(typeof(CurrencyConverter))]
    /// <summary>
    /// Криптоввалюта
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Символ
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Логотип
        /// </summary>
        public string CmcRank { get; set; }

        /// <summary>
        /// Текущая цена в USD
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Насколько цена изменилась за последний час
        /// </summary>
        public decimal PercentChangeOneHour { get; set; }
        /// <summary>
        /// Насколько цена изменилась за последние 24 часа
        /// </summary>
        public decimal PercentChangeTwentyFourHour { get; set; }
        /// <summary>
        /// капитализации в USD
        /// </summary>
        public decimal MarketCap { get; set; }
        /// <summary>
        /// Время обновления данных
        /// </summary>
        public DateTime LastUpdated { get; set; }

    }
}
