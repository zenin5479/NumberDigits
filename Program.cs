using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

// Определить количество цифр, до точки и после точки (.)
// Работает с точкой (.) и не работает с запятой (,)

namespace NumberDigits
{
    internal static class Program
    {
        private static void Main()
        {
            // Входные данные. Определить количество цифр, после точки (.).
            // Выходные данные - число цифр после точки: int digitsNumberAsk = DigitsNumber(ask).
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); // Переводит (,) в (.)
            //const decimal ask = 1.002687m;
            //const decimal ask = 2489m;
            const decimal ask = 75.268m;
            //const decimal ask = 0.00225679m;
            //const decimal ask = 100.42849m;
            //const decimal ask = 0.26885272m;
            int digitsNumberAsk = DigitsNumber(ask);
            Console.WriteLine("DigitsNumber: Число " + ask + " количество цифр " + digitsNumberAsk);
            
            // Преобразовать число с плавающей точкой в строку
            var stringask = ask.ToString(CultureInfo.InvariantCulture);
            var stringasklength = stringask.Length;
            // Определяем позицию точки в строке методом IndexOf()
            var pointask = stringask.IndexOf('.');
            var afterpointask = stringasklength - 1 - pointask;
            if (pointask == -1)
            {
                // Если точка не найдена, находим количество цифр
                Console.WriteLine("Число {0} количество цифр {1}", stringask, stringasklength);
            }
            else
            {
                // Если точка найдена, находим количество цифр после точки
                Console.WriteLine("Число " + stringask + " количество цифр" + " до точки " + pointask + " после точки " + afterpointask);
            }

            // Входные данные. Определить количество цифр, до точки и после точки (.).
            // Выходные данные - массив количества цифр до точки и после точки: int[] specifieddigits = { 2, 3 };
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); // Переводит (,) в (.)
            //const decimal askprice = 1.002687m;
            //const decimal askprice = 2489m;
            const decimal askprice = 75.268m;
            //const decimal askprice = 0.00225679m;
            //const decimal askprice = 100.42849m;
            //const decimal askprice = 0.26885272m;
            var initialdigits = NumberDigits(askprice);
            int[] specifieddigits = { 2, 3 };
            if (initialdigits[0] == 0)
                Console.WriteLine("NumberDigits: Число " + askprice + " количество цифр " + initialdigits[1]);
            else
                Console.WriteLine("NumberDigits: Число " + askprice + " количество цифр" + " до точки " + initialdigits[0] + " после точки " + initialdigits[1]);

            // Преобразовать число с плавающей точкой в строку
            var stringqty = askprice.ToString(CultureInfo.InvariantCulture);
            var stringqtylength = stringqty.Length;
            // Определяем позицию точки в строке методом IndexOf()
            var pointqty = stringqty.IndexOf('.');
            var afterpointqty = stringqtylength - 1 - pointqty;
            if (pointqty == -1)
            {
                // Если точка не найдена, находим количество цифр
                Console.WriteLine("Число {0} количество цифр {1}", askprice, stringqtylength);
            }
            else
            {
                // Если точка найдена, находим количество цифр после точки
                Console.WriteLine("Число " + askprice + " количество цифр" + " до точки " + pointqty + " после точки " + afterpointqty);
            }

            // Использование Enumerable.SequenceEqual. Linq
            var equalityarrays = initialdigits.SequenceEqual(specifieddigits);
            Console.WriteLine(equalityarrays);

            // Сравнение элементов последовательностей с использованием стандартного компаратора равенства. Linq
            var equalityarrays2 = Enumerable.SequenceEqual(initialdigits, specifieddigits);
            Console.WriteLine(equalityarrays2);

            // Использование собственного метода сравнения.
            var equalityarrays3 = initialdigits.CheckingEqualityArrays(specifieddigits);
            Console.WriteLine(equalityarrays3);

            // Использование собственного метода сравнения.  Linq
            var equalityarrays4 = initialdigits.CheckingEqualityArraysLinq(specifieddigits);
            Console.WriteLine(equalityarrays4);

            // Использование собственного метода сравнения.
            var equalityarrays5 = CheckingEqualityArrays(initialdigits, specifieddigits, EqualityComparer<int>.Default);
            Console.WriteLine(equalityarrays5);
        }

        // Метод для проверки равенства двух массивов.
        private static bool CheckingEqualityArrays<TSource>(this IReadOnlyList<TSource> first, IReadOnlyList<TSource> second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if (first == null || second == null)
            {
                return false;
            }

            if (first.Count != second.Count)
            {
                return false;
            }

            var comparer = EqualityComparer<TSource>.Default;
            for (var i = first.Count - 1; i >= 0; i--)
            {
                if (!comparer.Equals(first[i], second[i]))
                {
                    return false;
                }
            }

            return true;
        }

        // Метод для проверки равенства двух массивов. Linq
        public static bool CheckingEqualityArraysLinq<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            return first.SequenceEqual(second, EqualityComparer<TSource>.Default);
        }

        // Метод для проверки равенства двух массивов.
        public static bool CheckingEqualityArrays<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            if (comparer == null)
                comparer = EqualityComparer<TSource>.Default;

            if (first == null && second == null)
                return true;

            if (first == null || second == null)
                return false;

            using (var enumerator1 = first.GetEnumerator())
            {
                using (var enumerator2 = second.GetEnumerator())
                {
                    while (enumerator1.MoveNext())
                    {
                        if (!enumerator2.MoveNext() || !comparer.Equals(enumerator1.Current, enumerator2.Current))
                            return false;
                    }
                    if (enumerator2.MoveNext())
                        return false;
                }
            }
            return true;
        }

        // Метод для определения количество цифр, идущих после точки (.) (если она имеется) NumberDigits(decimal input)
        private static int[] NumberDigits(decimal input)
        {
            var number = input.ToString(CultureInfo.InvariantCulture);
            var numberlength = number.Length;
            // Определяем позицию точки в строке методом IndexOf()
            var pointnumber = number.IndexOf('.');
            int[] parameters;
            var afterpointnumber = numberlength - 1 - pointnumber;
            if (pointnumber == -1)
            {
                // Если точка не найдена, находим количество цифр - .Length
                const int topointnumber = 0;
                parameters = new[] { topointnumber, numberlength };
            }
            else
            {
                // Если точка найдена, находим количество цифр после точки
                // Если точка найдена, находим количество цифр до точки - IndexOf()
                parameters = new[] { pointnumber, afterpointnumber };
            }

            return parameters;
        }

        // Метод для определения количество цифр, идущих после точки (.) (если она имеется) NumberDigits(double input)
        private static int[] NumberDigits(double input)
        {
            var number = input.ToString(CultureInfo.InvariantCulture);
            var numberlength = number.Length;
            // Определяем позицию точки в строке методом IndexOf()
            var pointnumber = number.IndexOf('.');
            int[] parameters;
            var afterpointnumber = numberlength - 1 - pointnumber;
            if (pointnumber == -1)
            {
                // Если точка не найдена, находим количество цифр - .Length
                const int topointqty = 0;
                parameters = new[] { topointqty, numberlength };
            }
            else
            {
                // Если точка найдена, находим количество цифр после точки
                // Если точка найдена, находим количество цифр до точки - IndexOf()
                parameters = new[] { pointnumber, afterpointnumber };
            }

            return parameters;
        }

        // Метод для определения количество цифр, идущих после точки (.) (если она имеется)
        private static int DigitsNumber(decimal input)
        {
            var number = input.ToString(CultureInfo.InvariantCulture);
            var numberlength = number.Length;
            // Определяем позицию точки в строке методом IndexOf()
            var pointnumber = number.IndexOf('.');
            int roundingparameters;
            var placesnumber = numberlength - 1 - pointnumber;
            if (pointnumber == -1)
            {
                roundingparameters = numberlength;
            }
            else
            {
                // Если точка найдена, находим длину строки после точки
                roundingparameters = placesnumber;
            }

            return roundingparameters;
        }

        // Метод для определения количество цифр, идущих после точки (.) (если она имеется)
        private static int DigitsNumberWithUnit(decimal input)
        {
            var number = input.ToString(CultureInfo.InvariantCulture);
            var numberlength = number.Length;
            int roundingparameters;
            // Определяем позицию точки в строке методом IndexOf()
            var pointnumber = number.IndexOf('.');
            var onenumber = number.IndexOf('1');
            var placesonenumber = onenumber - pointnumber;
            if (pointnumber != -1)
            {
                if (pointnumber > onenumber)
                {
                    // Если точка найдена и единица найдена, находим положение единицы до точки
                    roundingparameters = pointnumber;
                }
                else
                {
                    // Если точка найдена и единица найдена, находим положение единицы после точки
                    roundingparameters = placesonenumber;
                }
            }
            else
            {
                // Если точка не найдена а единица найдена, положение единицы будет равно длине строки
                roundingparameters = numberlength;
            }

            return roundingparameters;
        }

        // Метод для определения количество цифр, идущих после точки (.) (если она имеется)
        private static int DigitsNumber(double input)
        {
            var number = input.ToString(CultureInfo.InvariantCulture);
            var numberlength = number.Length;
            // Определяем позицию точки в строке методом IndexOf()
            var pointnumber = number.IndexOf('.');
            int roundingparameters;
            var placesnumber = numberlength - 1 - pointnumber;
            if (pointnumber == -1)
            {
                roundingparameters = numberlength;
            }
            else
            {
                // Если точка найдена, находим длину строки после точки
                roundingparameters = placesnumber;
            }

            return roundingparameters;
        }
    }
}