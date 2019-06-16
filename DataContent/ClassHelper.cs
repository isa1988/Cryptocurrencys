using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContent
{
    /// <summary>
    /// Вспомогательныцй класс расширения
    /// </summary>
    public static class ClassHelper
    {
        /// <summary>
        /// Проверка на нуль для строки
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string GetIfNull(this object line)
        {
            return line?.ToString() ?? "";
        }

        /// <summary>
        /// Проверка на нуль для числа
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static decimal CheckOnNull(this object line)
        {
            decimal value = 0;
            decimal.TryParse(line?.ToString(), out value);
            return value;
        }
    }
}
