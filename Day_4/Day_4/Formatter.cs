using System;
using System.Text;

namespace Day_4
{
    /// <summary>
    /// Provides methods that allows represent numbers in different formats
    /// </summary>
    public class Formatter
    {
        /// <summary>
        /// Transform <see cref="double"/> values to string
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string[] TransformToWords(double[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            string[] result = new string[array.Length];
            for (int j = 0; j < array.Length; j++)
            {
                result[j] = ProcessNumber(array[j]);
            }

            return result;
        }

        private static string ProcessNumber(double number)
        {
            var stringBuilder = new StringBuilder();
            string numberChar = number.ToString();
            int i;
            CheckIfMinus(numberChar[0], stringBuilder, out i);
            while (i < numberChar.Length)
            {
                ProcessDigit(numberChar[i], stringBuilder);
                i++;
            }

            stringBuilder.Remove(stringBuilder.Length - 1, 1);

            return stringBuilder.ToString();
        }

        private static void CheckIfMinus(char symbol, StringBuilder stringBuilder, out int index)
        {
            if (symbol.ToString() == "-")
            {
                stringBuilder.Append("minus" + " ");
                index = 1;
                return;
            }

            index = 0;
        }

        private static void ProcessDigit(char symbol, StringBuilder stringBuilder)
        {
            int digit;
            if (int.TryParse(symbol.ToString(), out digit))
            {
                stringBuilder.Append((Digits)digit + " ");
                return;
            }

            stringBuilder.Append("point" + " ");
        }
    }
}
