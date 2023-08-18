using System;
using System.Globalization;

// Как получить количество цифр, идущих после точки (.)
// Работает с точкой (.) и не работает с запятой (,)

namespace NumberDigits
{
    internal static class Program
    {
        private static void Main()
        {
            // Вариант 1
            Console.Write("Введите число: ");
            // Преобразовать число с плавающей точкой в строку.
            var input = Convert.ToString(Console.ReadLine());

            if (input != null)
            {
                var symbol = input.Split('.');
                // Найти позицию точки в строке. Если точка не найдена - "Не удалось распознать число"
                var length = symbol.Length > 1 ? symbol[1].Length : 0;
                Console.WriteLine("Вариант 1: Число содержит {0} символов после запятой", length);
            }
            else
            {
                Console.WriteLine("Не удалось распознать число");
            }

            // Вариант 2
            try
            {
                // Преобразовать число с плавающей точкой в строку.
                var numberAsString = input.ToString(CultureInfo.CurrentCulture);
                var decimalPlaces = 0;
                // Найти позицию точки в строке методом IndexOf().
                var decimalPosition = numberAsString.IndexOf('.');
                // Если точка не найдена, вернуть 0.
                if (decimalPosition > 0)
                {
                    decimalPlaces = (numberAsString.Length - 1) - decimalPosition;
                }
                // Если точка найдена, найти длину строки после точки.
                Console.WriteLine("Вариант 2: Число содержит {0} символов после запятой и {1} символов до запятой", decimalPlaces, decimalPosition);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Не удалось распознать число");
                throw;
            }

            // Вариант 3
            try
            {
                var str = input.ToString(CultureInfo.InvariantCulture);
                var countBefore = str.IndexOf('.');
                var countAfter = (str.Length - 1) - countBefore;
                Console.WriteLine("Вариант 3: Число содержит {0} символов после запятой и {1} символов до запятой", countAfter, countBefore);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Не удалось распознать число");
                throw;
            }
        }
    }
}