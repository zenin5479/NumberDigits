using System;
using System.Globalization;
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
            const decimal qty = 1.002687m;
            //const decimal qty = 2489m;
            //const decimal qty = 1.002687m;
            //const decimal qty = 0.00225679m;
            //const decimal qty = 5.00000000m;
            //const decimal qty = 100.42849m;
            //const decimal qty = 0.26885272m;
            var roundqty = RoundingParameters(qty);
            Console.WriteLine("RoundingParameters: Число {0} округляем до {1} знака", qty, roundqty);

            // Преобразовать число с плавающей точкой в строку
            var stringqty = qty.ToString(CultureInfo.InvariantCulture);
            var stringqtylength = stringqty.Length;
            // Определяем позицию точки в строке методом IndexOf()
            var pointqty = stringqty.IndexOf('.');
            var oneqty = stringqty.IndexOf('1');
            if (pointqty != -1)
            {
                if (pointqty > oneqty)
                {
                    // Если точка найдена и единица найдена, находим положение единицы до точки
                    Console.WriteLine("Число {0} округляем до {1} знака", stringqty, pointqty);
                }
                else
                {
                    // Если точка найдена и единица найдена, находим положение единицы после точки
                    var placesoneminQty = oneqty - pointqty;
                    Console.WriteLine("Число {0} округляем до {1} знака", stringqty, placesoneminQty);
                }
            }
            else
            {
                // Если точка не найдена а единица найдена, положение единицы будет равно длине строки
                Console.WriteLine("Число {0} округляем до {1} знака", stringqty, stringqtylength);
            }
        }

        // Метод для определения количество цифр, идущих после точки (.) (если она имеется)
        private static int RoundingParameters(decimal input)
        {
            var qty = input.ToString(CultureInfo.InvariantCulture);
            var qtylength = qty.Length;
            int roundingparameters;
            // Определяем позицию точки в строке методом IndexOf()
            var pointqty = qty.IndexOf('.');
            var oneqty = qty.IndexOf('1');
            if (pointqty != -1)
            {
                if (pointqty > oneqty)
                {
                    // Если точка найдена и единица найдена, находим положение единицы до точки
                    roundingparameters = pointqty;
                }
                else
                {
                    // Если точка найдена и единица найдена, находим положение единицы после точки
                    var placesoneqty = oneqty - pointqty;
                    roundingparameters = placesoneqty;
                }
            }
            else
            {
                // Если точка не найдена а единица найдена, положение единицы будет равно длине строки
                roundingparameters = qtylength;
            }

            return roundingparameters;
        }

        // Метод для определения количество цифр, идущих после точки (.) (если она имеется)
        private static int RoundingParameters(double input)
        {
            var qty = input.ToString(CultureInfo.InvariantCulture);
            var qtylength = qty.Length;
            // Определяем позицию точки в строке методом IndexOf()
            var pointqty = qty.IndexOf('.');
            int roundingparameters;
            if (pointqty == -1)
            {
                roundingparameters = qtylength;
            }
            else
            {
                // Если точка найдена, находим длину строки после точки
                var placesqty = (qtylength - 1) - pointqty;
                roundingparameters = placesqty;
            }

            return roundingparameters;
        }
    }
}