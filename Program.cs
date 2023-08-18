using System;
using System.Globalization;

namespace NumberDigits
{
    internal class Program
    {
        private static void Main()
        {
            const decimal number = (decimal)10.12345454;
            var numberAsString = number.ToString(CultureInfo.InvariantCulture);
            var decimalPlaces = 0;
            var decimalPosition = numberAsString.IndexOf('.');

            if (decimalPosition > 0)
            {
                decimalPlaces = numberAsString.Length - decimalPosition - 1;
            }

            Console.WriteLine(decimalPlaces);
        }
    }
}