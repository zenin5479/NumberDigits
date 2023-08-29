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
            var inputLength = input.Length;

            // Вариант 1
            var symbolOne = input.Split('.');
            // Найти позицию точки в строке
            var lengthOne = symbolOne.Length > 1 ? symbolOne[1].Length : 0;
            if (lengthOne == 0)
            {
                Console.WriteLine("Вариант 1: Число содержит {0} символов", inputLength);
            }
            else
            {
                // Если точка найдена, найти длину строки после точки
                var placesOne = (inputLength - 1) - lengthOne;
                Console.WriteLine(
                    "Вариант 1: Число содержит {0} символов до точки и {1} символов после точки длина числа {2} символов",
                    placesOne, lengthOne, inputLength);
            }

            // Вариант 1a
            char one = '1';
            var symbolOne2 = input.Split(one);
            // Найти позицию единицы в строке
           
            var lengthOne2 = symbolOne2.Length > 1 ? symbolOne2[1].Length : 0;
            if (lengthOne2 == 0)
            {
                var placesOne1 = (inputLength - 1);
                Console.WriteLine(
                    "Вариант 1a: Число содержит {0} символов до единицы и {1} символов после единицы длина числа {2} символов", placesOne1, inputLength, placesOne1);
            }
            else
            {
                // Если единица найдена, найти длину строки после единицы
                Console.WriteLine("Вариант 1: Число содержит {0} символов", inputLength);
            }

            // Вариант 2
            // Найти позицию точки в строке методом IndexOf()
            var symbolTwo = input.IndexOf('.');
            if (symbolTwo == -1)
            {
                Console.WriteLine("Вариант 1: Число содержит {0} символов", inputLength);
            }
            else
            {
                // Если точка найдена, найти длину строки после точки
                var placesTwo = (inputLength - 1) - symbolTwo;
                Console.WriteLine(
                    "Вариант 2: Число содержит {0} символов до точки и {1} символов после точки длина числа {2} символов",
                    symbolTwo, placesTwo, inputLength);
            }
        }
    }
}