namespace NumberDigits
{
    internal class Draft
    {

        // Использование Enumerable.SequenceEqual. Linq
        //var equalityarrays = initialdigits.SequenceEqual(specifieddigits);
        //Console.WriteLine(equalityarrays);

        // Сравнение элементов последовательностей с использованием стандартного компаратора равенства. Linq
        //var equalityarrays2 = Enumerable.SequenceEqual(initialdigits, specifieddigits);
        //Console.WriteLine(equalityarrays2);

        // Использование собственного метода сравнения.
        //var equalityarrays3 = initialdigits.CheckingEqualityArrays(specifieddigits);
        //Console.WriteLine(equalityarrays3);

        // Использование собственного метода сравнения.  Linq
        //var equalityarrays4 = initialdigits.CheckingEqualityArraysLinq(specifieddigits);
        //Console.WriteLine(equalityarrays4);

        // Использование собственного метода сравнения.
        //var equalityarrays5 = CheckingEqualityArrays(initialdigits, specifieddigits, EqualityComparer<int>.Default);
        //Console.WriteLine(equalityarrays5);

        // Метод для проверки равенства двух массивов.
        //private static bool CheckingEqualityArrays<TSource>(this IReadOnlyList<TSource> first, IReadOnlyList<TSource> second)
        //{
        //    if (first == null && second == null)
        //    {
        //        return true;
        //    }

        //    if (first == null || second == null)
        //    {
        //        return false;
        //    }

        //    if (first.Count != second.Count)
        //    {
        //        return false;
        //    }

        //    var comparer = EqualityComparer<TSource>.Default;
        //    for (var i = first.Count - 1; i >= 0; i--)
        //    {
        //        if (!comparer.Equals(first[i], second[i]))
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        // Метод для проверки равенства двух массивов. Linq
        //public static bool CheckingEqualityArraysLinq<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        //{
        //    return first.SequenceEqual(second, EqualityComparer<TSource>.Default);
        //}

        // Метод для проверки равенства двух массивов.
        //public static bool CheckingEqualityArrays<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        //{
        //    if (comparer == null)
        //        comparer = EqualityComparer<TSource>.Default;

        //    if (first == null && second == null)
        //        return true;

        //    if (first == null || second == null)
        //        return false;

        //    using (var enumerator1 = first.GetEnumerator())
        //    {
        //        using (var enumerator2 = second.GetEnumerator())
        //        {
        //            while (enumerator1.MoveNext())
        //            {
        //                if (!enumerator2.MoveNext() || !comparer.Equals(enumerator1.Current, enumerator2.Current))
        //                    return false;
        //            }
        //            if (enumerator2.MoveNext())
        //                return false;
        //        }
        //    }
        //    return true;
        //}

        // Метод для определения количество цифр, идущих после точки (.) (если она имеется) NumberDigits(decimal input)
        //private static int[] NumberDigits(decimal input)
        //{
        //    var number = input.ToString(CultureInfo.InvariantCulture);
        //    var numberlength = number.Length;
        //    // Определяем позицию точки в строке методом IndexOf()
        //    var pointqty = number.IndexOf('.');
        //    int[] parameters;
        //    if (pointqty == -1)
        //    {
        //        // Если точка не найдена, находим количество цифр - .Length
        //        const int topointqty = 0;
        //        parameters = new[] { topointqty, numberlength };
        //    }
        //    else
        //    {
        //        // Если точка найдена, находим количество цифр после точки
        //        var afterpointqty = (numberlength - 1) - pointqty;
        //        // Если точка найдена, находим количество цифр до точки - IndexOf()
        //        parameters = new[] { pointqty, afterpointqty };
        //    }

        //    return parameters;
        //}

        // Метод для определения количество цифр, идущих после точки (.) (если она имеется) NumberDigits(double input)
        //private static int[] NumberDigits(double input)
        //{
        //    var number = input.ToString(CultureInfo.InvariantCulture);
        //    var numberlength = number.Length;
        //    // Определяем позицию точки в строке методом IndexOf()
        //    var pointqty = number.IndexOf('.');
        //    int[] parameters;
        //    if (pointqty == -1)
        //    {
        //        // Если точка не найдена, находим количество цифр - .Length
        //        const int topointqty = 0;
        //        parameters = new[] { topointqty, numberlength };
        //    }
        //    else
        //    {
        //        // Если точка найдена, находим количество цифр после точки
        //        var afterpointqty = (numberlength - 1) - pointqty;
        //        // Если точка найдена, находим количество цифр до точки - IndexOf()
        //        parameters = new[] { pointqty, afterpointqty };
        //    }

        //    return parameters;
        //}
    }
}
