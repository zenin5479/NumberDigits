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
            // Преобразовать число с плавающей точкой в строку

            // "minQty": "0.00000100"
            // "maxPrice": "10000000.00000000"
            const string minPrice = "0.00000100";
            const string maxPrice = "10000000.00000000";
            var minPriceLength = minPrice.Length;
            var maxPriceLength = minPrice.Length;
            // Найти позицию точки в строке методом IndexOf()
            var pointminPrice = minPrice.IndexOf('.');
            if (pointminPrice == -1)
            {
                Console.WriteLine("Число {0} содержит {1} символов", minPrice, minPriceLength);
            }
            else
            {
                // Если точка найдена, найти длину строки после точки
                var placesTwo = (minPriceLength - 1) - pointminPrice;
                Console.WriteLine(
                    "Число {0} содержит {1} символов до точки и {2} символов после точки длина числа {3} символов",
                    minPrice, pointminPrice, placesTwo, minPriceLength);
            }

            const string s1 = "Быстрая бурая лиса перепрыгивает через ленивую собаку";
            const string s2 = "лиса";
            bool b = s1.Contains(s2);
            Console.WriteLine("'{0}' находится в строке '{1}': {2}", s2, s1, b);
            if (b)
            {
                int index = s1.IndexOf(s2);
                if (index >= 0)
                    Console.WriteLine("'{0} начинается с позиции символа {1}", s2, index + 1);
            }

            const string br1 = "0----+----1";
            const string br2 = "01234567890";
            const string str = "100000.0000";
            const string target = ".";
            char[] anyOf = target.ToCharArray();
            const string target1 = "1";
            char[] anyOf1 = target1.ToCharArray();

            const int start = 0;
            Console.WriteLine();
            Console.WriteLine("Первое вхождение символа с позиции {0} к {1}.", start, str.Length - 1);
            Console.WriteLine("{1}{0}{2}{0}{3}{0}", Environment.NewLine, br1, br2, str);

            var at = str.IndexOfAny(anyOf, start);
            Console.Write("Символ в '{0}' встречается в позиции: ", target);
            if (at > -1)
                Console.Write(at);
            else
                Console.Write("(Не найдено)");
            Console.WriteLine();

            var at1 = str.IndexOfAny(anyOf1, start);
            Console.Write("Символ в '{0}' встречается в позиции: ", target1);
            if (at1 > -1)
                Console.Write(at1);
            else
                Console.Write("(Не найдено)");
            Console.WriteLine();
        }
    }
}
