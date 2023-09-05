using System;
using System.Globalization;
using System.Threading;

// Определить количество цифр, идущих после точки (.)
// Работает с точкой (.) и не работает с запятой (,)

namespace NumberDigits
{
    internal static class Program
    {
        private static void Main()
        {
            // Входные данные
            // "minQty": "0.00000100"
            // "maxQty": "10000000.00000000"
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); // Переводит (,) в (.)
            const double inputQty = 0.00100000;
            //const double inputQty = 10000000.00000000;

            int roundminQty = RoundingParameters(inputQty);
            Console.WriteLine("RoundingParameters: Число {0} округляем до {1} знака", inputQty, roundminQty);

            // Первое число
            // Преобразовать число с плавающей точкой в строку
            string minQty = inputQty.ToString(CultureInfo.InvariantCulture);
            var minQtyLength = minQty.Length;
            // Определяем позицию точки в строке методом IndexOf()
            var pointminQty = minQty.IndexOf('.');
            if (pointminQty == -1)
            {
                Console.WriteLine("Число {0} округляем до {1} знака", minQty, minQtyLength);
            }
            else
            {
                // Если точка найдена, находим длину строки после точки
                var placesminQty = (minQtyLength - 1) - pointminQty;
                Console.WriteLine("Число {0} округляем до {1} знака", minQty, placesminQty);
            }

            // Входные данные
            // "minQty": "0.00001000"
            // "maxQty": "1.00000000"
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); // Переводит (,) в (.)
            const decimal inputminQty2 = 0.00001000m;
            //const decimal inputminQty2 = 0.00001000m;
            //const decimal inputmaxQty2 = 1.00000000m;
            //const decimal inputmaxQty2 = 10000000m;

            int roundminQty2 = RoundingParameters(inputminQty2);
            Console.WriteLine("RoundingParameters: Число {0} округляем до {1} знака", inputminQty2, roundminQty2);

            // Преобразовать число с плавающей точкой в строку
            string minQty2 = inputminQty2.ToString(CultureInfo.InvariantCulture);
            int minQtyLength2 = minQty2.Length;
            // Определяем позицию точки в строке методом IndexOf()
            int pointminQty2 = minQty2.IndexOf('.');
            int oneminQty2 = minQty2.IndexOf('1');
            if (pointminQty2 != -1)
            {
                if (pointminQty2 > oneminQty2)
                {
                    // Если точка найдена и единица найдена, находим положение единицы до точки
                    Console.WriteLine("Число {0} округляем до {1} знака", minQty2, pointminQty2);
                }
                else
                {
                    // Если точка найдена и единица найдена, находим положение единицы после точки
                    int placesoneminQty = oneminQty2 - pointminQty2;
                    Console.WriteLine("Число {0} округляем до {1} знака", minQty2, placesoneminQty);
                }
            }
            else
            {
                // Если точка не найдена а единица найдена, положение единицы будет равно длине строки
                Console.WriteLine("Число {0} округляем до {1} знака", minQty2, minQtyLength2);
            }
        }

        // Метод для определения количество цифр, идущих после точки (.) (если она имеется)
        private static int RoundingParameters(decimal inputQty)
        {
            string qty = inputQty.ToString(CultureInfo.InvariantCulture);
            int qtyLength = qty.Length;
            int roundingparameters;
            // Определяем позицию точки в строке методом IndexOf()
            int pointQty = qty.IndexOf('.');
            int oneQty = qty.IndexOf('1');
            if (pointQty != -1)
            {
                if (pointQty > oneQty)
                {
                    // Если точка найдена и единица найдена, находим положение единицы до точки
                    roundingparameters = pointQty;
                }
                else
                {
                    // Если точка найдена и единица найдена, находим положение единицы после точки
                    int placesoneQty = oneQty - pointQty;
                    roundingparameters = placesoneQty;
                }
            }
            else
            {
                // Если точка не найдена а единица найдена, положение единицы будет равно длине строки
                roundingparameters = qtyLength;
            }

            return roundingparameters;
        }

        // Метод для определения количество цифр, идущих после точки (.) (если она имеется)
        private static int RoundingParameters(double inputQty)
        {
            string qty = inputQty.ToString(CultureInfo.InvariantCulture);
            var qtyLength = qty.Length;
            // Определяем позицию точки в строке методом IndexOf()
            var pointQty = qty.IndexOf('.');
            int roundingparameters;
            if (pointQty == -1)
            {
                roundingparameters = qtyLength;
            }
            else
            {
                // Если точка найдена, находим длину строки после точки
                var placesQty = (qtyLength - 1) - pointQty;
                roundingparameters = placesQty;
            }

            return roundingparameters;
        }
    }
}
