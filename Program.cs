using System;
using System.Globalization;
using System.Threading;

// Определить количество цифр, идущих после точки (.)
// Работает с точкой (.) и не работает с запятой (,)

namespace NumberDigits
{
    internal static class Program
    {
        private static void Main()
        {
            // Входные данные
            // "minQty": "0.00000100"
            // "maxQty": "10000000.00000000"
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); // Переводит (,) в (.)
            const decimal inputminQty = (decimal)0.00000100;
            const decimal inputmaxQty = (decimal)(10000000.00000000);

            int roundminQty = RoundingParameters(inputminQty);
            Console.WriteLine("RoundingParameters: Число {0} содержит {1} символов", inputminQty, roundminQty);
            int roundmaxQty = RoundingParameters(inputmaxQty);
            Console.WriteLine("RoundingParameters: Число {0} содержит {1} символов", inputmaxQty, roundmaxQty);

            // Первое число
            // Преобразовать число с плавающей точкой в строку
            string minQty = inputminQty.ToString(CultureInfo.InvariantCulture);
            string maxQty = inputmaxQty.ToString(CultureInfo.InvariantCulture);
            var minQtyLength = minQty.Length;
            var maxQtyLength = maxQty.Length;
            // Определяем позицию точки в строке методом IndexOf()
            var pointminQty = minQty.IndexOf('.');
            if (pointminQty == -1)
            {
                Console.WriteLine("Число {0} содержит {1} символов", minQty, minQtyLength);
            }
            else
            {
                // Если точка найдена, находим длину строки после точки
                var placesminQty = (minQtyLength - 1) - pointminQty;
                Console.WriteLine("Число {0} содержит {1} символов после точки", minQty, placesminQty);
            }

            // Второе число
            var pointmaxQty = maxQty.IndexOf('.');
            if (pointmaxQty == -1)
            {
                Console.WriteLine("Число {0} содержит {1} символов", maxQty, maxQtyLength);
            }
            else
            {
                // Если точка найдена, находим длину строки после точки
                var placesmaxQty = (maxQtyLength - 1) - pointmaxQty;
                Console.WriteLine("Число {0} содержит {1} символов после точки", maxQty, placesmaxQty);
            }
        }

        private static int RoundingParameters(decimal inputQty)
        {
            string qty = inputQty.ToString(CultureInfo.InvariantCulture);
            var qtyLength = qty.Length;
            // Определяем позицию точки в строке методом IndexOf()
            var pointQty = qty.IndexOf('.');
            int par;
            if (pointQty == -1)
            {
                par = qtyLength;
            }
            else
            {
                // Если точка найдена, находим длину строки после точки
                var placesQty = (qtyLength - 1) - pointQty;
                par = placesQty;
            }
            return par;
        }
    }
}