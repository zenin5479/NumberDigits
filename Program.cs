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
            // "minQty": "0.00001000"
            // "maxQty": "1.00000000"
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); // Переводит (,) в (.)
            const decimal inputminQty = 0.00001000m;
            //const decimal inputminQty = 0.00001000m;
            //const decimal inputmaxQty = 1.00000000m;
            //const decimal inputmaxQty = 10000000m;

            int roundminQty = RoundingParameters(inputminQty);
            Console.WriteLine("RoundingParameters: Число {0} округляем до {1} знака", inputminQty, roundminQty);

            // Преобразовать число с плавающей точкой в строку
            string minQty = inputminQty.ToString(CultureInfo.InvariantCulture);
            int minQtyLength = minQty.Length;
            // Определяем позицию точки в строке методом IndexOf()
            int pointminQty = minQty.IndexOf('.');
            int oneminQty = minQty.IndexOf('1');
            if (pointminQty != -1)
            {
                if (pointminQty > oneminQty)
                {
                    // Если точка найдена и единица найдена, находим положение единицы до точки
                    Console.WriteLine("Число {0} округляем до {1} знака", minQty, pointminQty);
                }
                else
                {
                    // Если точка найдена и единица найдена, находим положение единицы после точки
                    int placesoneminQty = oneminQty - pointminQty;
                    Console.WriteLine("Число {0} округляем до {1} знака", minQty, placesoneminQty);
                }
            }
            else
            {
                // Если точка не найдена а единица найдена, положение единицы будет равно длине строки
                Console.WriteLine("Число {0} округляем до {1} знака", minQty, minQtyLength);
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
    }
}