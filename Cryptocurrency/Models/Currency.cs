using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cryptocurrency.Models
{
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
        /// Текущая цена в USD
        /// </summary>
        [DisplayName("Текущая цена в USD")]
        public decimal Price { get; set; }
        /// <summary>
        /// Насколько цена изменилась за последний час
        /// </summary>
        [DisplayName("Насколько цена изменилась за последний час")]
        public decimal PercentChangeOneHour { get; set; }
        /// <summary>
        /// Насколько цена изменилась за последние 24 часа
        /// </summary>
        [DisplayName("Насколько цена изменилась за последние 24 часа")]
        public decimal PercentChangeTwentyFourHour { get; set; }
        /// <summary>
        /// капитализации в USD
        /// </summary>
        [DisplayName("капитализации в USD")]
        public decimal MarketCap { get; set; }
        /// <summary>
        /// Время обновления данных
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Время обновления данных")]
        public DateTime LastUpdated { get; set; }
        
    }
}