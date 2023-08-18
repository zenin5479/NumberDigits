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
            if (double.TryParse(input, out var number))
            {
                // Описатель общего формата G
                // Описатель десятичного формата D
                // Описатель формата с фиксированной запятой F
                var symbol = number.ToString("G", CultureInfo.InvariantCulture).Split('.');
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
            var numberAsString = number.ToString(CultureInfo.InvariantCulture);
            var decimalPlaces = 0;
            // Найти позицию запятой в строке методом IndexOf().
            var decimalPosition = numberAsString.IndexOf('.');
            // Если точка не найдена, вернуть 0.
            if (decimalPosition > 0)
            {
                decimalPlaces = numberAsString.Length - decimalPosition - 1;
            }
            // Если точка найдена, найти длину строки после запятой.
            Console.WriteLine("Вариант 2: Число содержит {0} символов после запятой", decimalPlaces);

            string str = number.ToString(CultureInfo.InvariantCulture);
            int countBefore = str.IndexOf('.');
            int countAfter = str.Length - countBefore - 1;
            Console.WriteLine("Вариант 3: Число содержит {0} символов после запятой и {1} символов до запятой", countAfter, countBefore );

        }
    }
}