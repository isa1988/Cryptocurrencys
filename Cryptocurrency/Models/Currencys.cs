using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cryptocurrency.Models
{
    /// <summary>
    /// Страница криптовлют
    /// </summary>
    public class Currencys : PageInfo
    {
        /// <summary>
        /// Сам список
        /// </summary>
        public List<Currency> MainList { get; set; }
        /// <summary>
        /// Отфильтрованный список
        /// </summary>
        public List<Currency> SearchList { get; set; }
        /// <summary>
        /// Параметры для фильтрации
        /// </summary>
        public CurrencyFilter SearchItem { get; set; }
    }
}