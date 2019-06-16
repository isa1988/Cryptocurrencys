using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cryptocurrency.Models
{
    /// <summary>
    /// Криптоввалюта Филтьтр
    /// </summary>
    public class CurrencyFilter
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [DisplayName("Наименование")]
        public string Name { get; set; }

        /// <summary>
        /// Символ
        /// </summary>
        [DisplayName("Символ")]
        public string Symbol { get; set; }

        /// <summary>
        /// Логотип
        /// </summary>
        public string CmcRank { get; set; }

        /// <summary>
        /// Логотип полный путь
        /// </summary>
        public string FullCmcRank { get; set; }

        /// <summary>
        /// Участвует Текущая цена в USD 
        /// </summary>
        public bool IsPrice { get; set; }
        /// <summary>
        /// Текущая цена в USD от
        /// </summary>
        [DisplayName("Текущая цена в USD")]
        public decimal PriceFrom { get; set; }
        /// <summary>
        /// Текущая цена в USD до
        /// </summary>
        [DisplayName("Текущая цена в USD")]
        public decimal PriceTo { get; set; }
        /// <summary>
        /// Участвует Насколько цена изменилась за последний час
        /// </summary>
        public bool IsPercentChangeOneHour { get; set; }
        /// <summary>
        /// Насколько цена изменилась за последний час 
        /// </summary>
        [DisplayName("Насколько цена изменилась за последний час")]
        public decimal PercentChangeOneHourFrom { get; set; }
        /// <summary>
        /// Насколько цена изменилась за последний час до 
        /// </summary>
        [DisplayName("Насколько цена изменилась за последний час")]
        public decimal PercentChangeOneHourTo { get; set; }

        /// <summary>
        /// Участвует Насколько цена изменилась за последние 24 часа
        /// </summary>
        public bool IsPercentChangeTwentyFourHour { get; set; }

        /// <summary>
        /// Насколько цена изменилась за последние 24 часа от
        /// </summary>
        [DisplayName("Насколько цена изменилась за последние 24 часа")]
        public decimal PercentChangeTwentyFourHourFrom { get; set; }
        /// <summary>
        /// Насколько цена изменилась за последние 24 часа до
        /// </summary>
        [DisplayName("Насколько цена изменилась за последние 24 часа")]
        public decimal PercentChangeTwentyFourHourTo { get; set; }

        /// <summary>
        /// Участвует капитализации в USD 
        /// </summary>
        public bool IsMarketCap { get; set; }

        /// <summary>
        /// капитализации в USD от
        /// </summary>
        [DisplayName("капитализации в USD")]
        public decimal MarketCapFrom { get; set; }
        /// <summary>
        /// капитализации в USD до
        /// </summary>
        [DisplayName("капитализации в USD")]
        public decimal MarketCapTo { get; set; }

        /// <summary>
        /// Участвует Время обновления данных
        /// </summary>
        public bool IsLastUpdated { get; set; }

        /// <summary>
        /// Время обновления данных от
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Время обновления данных")]
        public DateTime LastUpdatedFrom { get; set; }

        /// <summary>
        /// Время обновления данных до
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Время обновления данных")]
        public DateTime LastUpdatedTo { get; set; }
    }
}