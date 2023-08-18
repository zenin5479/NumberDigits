using System;
using System.Globalization;

// Как получить количество цифр, идущих после запятой?

namespace NumberDigits
{
    internal static class Program
    {
        private static void Main()
        {
            // Вариант 1
            Console.Write("Введите число: ");
            // Преобразовать число с плавающей точкой в строку.
            var input = Console.ReadLine();
            if (input != null && double.TryParse(input, out var number))
            {
                // Описатель общего формата G
                // Описатель десятичного формата D
                // Описатель формата с фиксированной запятой F
                var symbol = number.ToString("D", CultureInfo.CurrentCulture).Split('.');
                // Найти позицию запятой в строке. Если точка не найдена - "Не удалось распознать число"
                var length = symbol.Length > 1 ? symbol[1].Length : 0;
                Console.WriteLine("Вариант 1: Число содержит {0} символов после запятой", length);
            }
            else
            {
                Console.WriteLine("Не удалось распознать число");
            }

            // Вариант 2
            // Преобразовать число с плавающей точкой в строку.
            if (input != null)
            {
                var numberAsString = input.ToString(CultureInfo.CurrentCulture);
                var decimalPlaces = 0;
                // Найти позицию запятой в строке методом IndexOf().
                var decimalPosition = numberAsString.IndexOf('.');
                // Если точка не найдена, вернуть 0.
                if (decimalPosition > 0)
                {
                    decimalPlaces = (numberAsString.Length - 1) - decimalPosition;
                }
                // Если точка найдена, найти длину строки после запятой.
                Console.WriteLine("Вариант 2: Число содержит {0} символов после запятой и {1} символов до запятой", decimalPlaces, decimalPosition);
            }

            // Вариант 3
            if (input != null)
            {
                var str = input.ToString(CultureInfo.InvariantCulture);
                var countBefore = str.IndexOf('.');
                var countAfter = (str.Length - 1) - countBefore;
                Console.WriteLine("Вариант 3: Число содержит {0} символов после запятой и {1} символов до запятой", countAfter, countBefore);
            }
        }
    }
}