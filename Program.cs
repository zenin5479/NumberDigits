using System;

// Определить количество цифр, идущих после точки (.)
// Работает с точкой (.) и не работает с запятой (,)

namespace NumberDigits
{
    internal static class Program
    {
        private static void Main()
        {

            Console.Write("Введите число: ");
            // Преобразовать число с плавающей точкой в строку
            var input = Convert.ToString(Console.ReadLine());

            // Вариант 1
            if (input != null)
            {
                var symbol = input.Split('.');
                // Найти позицию точки в строке
                var length = symbol.Length > 1 ? symbol[1].Length : 0;
                // Если точка найдена, найти длину строки после точки
                var places = (input.Length - 1) - length;
                Console.WriteLine("Вариант 1: Число содержит {0} символов до точки и {1} символов после точки", places, length);
            }
            else
            {
                Console.WriteLine("Не удалось распознать число");
            }

            // Вариант 2
            if (input != null)
            {
                // Найти позицию точки в строке методом IndexOf()
                var decimalPosition = input.IndexOf('.');
                // Если точка найдена, найти длину строки после точки
                var decimalPlaces = (input.Length - 1) - decimalPosition;
                Console.WriteLine("Вариант 2: Число содержит {0} символов до точки и {1} символов после точки", decimalPosition, decimalPlaces);
            }
            else
            {
                Console.WriteLine("Не удалось распознать число");
            }
        }
    }
}