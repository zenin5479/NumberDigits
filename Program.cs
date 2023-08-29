using System;
using System.Globalization;

// Определить количество цифр, идущих после точки (.)
// Работает с точкой (.) и не работает с запятой (,)

namespace NumberDigits
{
    internal static class Program
    {
        private static void Main()
        {
            // Преобразовать число с плавающей точкой в строку

            // "minQty": "0.00000100"
            // "maxPrice": "10000000.00000000"
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            decimal minPrice1 = (decimal)0.00000100;
            decimal maxPrice2 = (decimal)(10000000.00000000);

            // Первое число
            string minPrice = minPrice1.ToString(CultureInfo.InvariantCulture);
            string maxPrice = maxPrice2.ToString(CultureInfo.InvariantCulture);
            var minPriceLength = minPrice.Length;
            var maxPriceLength = maxPrice.Length;
            // Найти позицию точки в строке методом IndexOf()
            var pointminPrice = minPrice.IndexOf('.');
            if (pointminPrice == -1)
            {
                Console.WriteLine("Число {0} содержит {1} символов", minPrice, minPriceLength);
            }
            else
            {
                // Если точка найдена, найти длину строки после точки
                var placesminPrice = (minPriceLength - 1) - pointminPrice;
                Console.WriteLine("Число {0} содержит {1} символов после точки", minPrice, placesminPrice);
            }

            // Второе число
            var pointmaxPrice = maxPrice.IndexOf('.');
            if (pointmaxPrice == -1)
            {
                Console.WriteLine("Число {0} содержит {1} символов", maxPrice, maxPriceLength);
            }
            else
            {
                // Если точка найдена, найти длину строки после точки
                var placesmaxPrice = (maxPriceLength - 1) - pointmaxPrice;
                Console.WriteLine("Число {0} содержит {1} символов после точки", maxPrice, placesmaxPrice);
            }
        }
    }
}
