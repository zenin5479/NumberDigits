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
                    "Вариант 1: Число содержит {0} символов до точки и {1} символов после точки длина числа {2} символов",
                    symbolTwo, placesTwo, inputLength);
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
