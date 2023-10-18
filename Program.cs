﻿using System;
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
            // Входные данные
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); // Переводит (,) в (.)
            //const decimal qty = 1.002687m;
            const decimal qty = 2489m;
            //const decimal qty = 1.002687m;
            //const decimal qty = 0.00225679m;
            //const decimal qty = 5.00000000m;
            //const decimal qty = 100.42849m;
            //const decimal qty = 0.26885272m;
            var roundqty = RoundingParameters(qty);
            int[] roundqty2 = { 0, 4 };
            if (roundqty[0] == 0)
                Console.WriteLine("RoundingParameters: Число " + qty + " количество цифр " + roundqty[1]);
            else
                Console.WriteLine("RoundingParameters: Число " + qty + " количество цифр" + " до точки " + roundqty[0] + " после точки " + roundqty[1]);

            // Преобразовать число с плавающей точкой в строку
            var stringqty = qty.ToString(CultureInfo.InvariantCulture);
            var stringqtylength = stringqty.Length;
            // Определяем позицию точки в строке методом IndexOf()
            var pointqty = stringqty.IndexOf('.');
            if (pointqty == -1)
            {
                // Если точка не найдена, находим количество цифр
                Console.WriteLine("Число {0} количество цифр {1}", qty, stringqtylength);
            }
            else
            {
                // Если точка найдена, находим количество цифр после точки
                var afterpointqty = (stringqtylength - 1) - pointqty;
                Console.WriteLine("Число " + qty + " количество цифр" + " до точки " + pointqty + " после точки " + afterpointqty);
            }

            // Использование Enumerable.SequenceEqual
            // Если массив не нулевой, напрямую вызваем метод SequenceEqual() для массива, чтобы сравнить его содержимое с указанным массивом.
            var equalityarrays = roundqty.SequenceEqual(roundqty2);
            Console.WriteLine(equalityarrays);

            // Сравнение элементов последовательностей с использованием стандартного компаратора равенства.
            var equalityarrays2 = Enumerable.SequenceEqual(roundqty, roundqty2);
            Console.WriteLine(equalityarrays2);

            // Использование собственного метода сравнения
            var equalityarrays3 = roundqty.CheckingEqualityArrays(roundqty2);
            Console.WriteLine(equalityarrays3);

            // Использование собственного метода сравнения
            var equalityarrays4 = roundqty.CheckingEqualityArrays2(roundqty2);
            Console.WriteLine(equalityarrays4);

            // Использование собственного метода сравнения
            var equalityarrays5 = CheckingEqualityArrays3(roundqty, roundqty2, EqualityComparer<int>.Default);
            Console.WriteLine(equalityarrays5);
        }

        // Метод для проверки равенства двух массивов.
        // Перебираем элементы массива и вызываем метод Equals() для каждого элемента.
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

        public static bool CheckingEqualityArrays2<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            return first.SequenceEqual(second, EqualityComparer<TSource>.Default);
        }

        public static bool CheckingEqualityArrays3<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
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

        // Метод для определения количество цифр, идущих после точки (.) (если она имеется)
        private static int[] RoundingParameters(decimal input)
        {
            var qty = input.ToString(CultureInfo.InvariantCulture);
            var qtylength = qty.Length;
            // Определяем позицию точки в строке методом IndexOf()
            var pointqty = qty.IndexOf('.');
            int[] roundingparameters;
            if (pointqty == -1)
            {
                // Если точка не найдена, находим количество цифр - .Length
                const int topointqty = 0;
                roundingparameters = new[] { topointqty, qtylength };
            }
            else
            {
                // Если точка найдена, находим количество цифр после точки
                var afterpointqty = (qtylength - 1) - pointqty;
                // Если точка найдена, находим количество цифр до точки - IndexOf()
                roundingparameters = new[] { pointqty, afterpointqty };
            }

            return roundingparameters;
        }
    }
}