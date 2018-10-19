using System;
using System.Linq;
using System.Text;

namespace Day_4_DoubleToIEEE754
{
    /// <summary>
    /// Provides methods that extend <see cref="double"/>
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Get IEEE754 format of <see cref="double"/>
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ToIEEE754(this double number)
        {
            if (number == double.PositiveInfinity)
            {
                return "0111111111110000000000000000000000000000000000000000000000000000";
            }

            if (number == double.NegativeInfinity)
            {
                return "1111111111110000000000000000000000000000000000000000000000000000";
            }

            if (number == double.Epsilon)
            {
                return "0000000000000000000000000000000000000000000000000000000000000001";
            }

            if (number == 0)
            {
                return "0000000000000000000000000000000000000000000000000000000000000000";
            }

            if (double.IsNaN(number))
            {
                return "1111111111111000000000000000000000000000000000000000000000000000";
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(CheckIfNegative(ref number));
            int pow = Normalize(ref number);
            string exponent = GetIntPartInBinary(1023 + pow);
            string mantiss = GetFractionalPartinBinary(number % 1, 52);
            return stringBuilder.Append(exponent + mantiss).ToString();
        }

        private static int Normalize(ref double number)
        {
            double base2 = 2;
            int controller = 1;
            if (number < 1)
            {
                base2  = 1 / base2;
                controller = -1;
            }

            int pow = 0;
            while (number >= 2 || number < 1)
            {
                number /= base2;
                pow++;
            }

            return pow * controller;
        }

        private static string CheckIfNegative(ref double number)
        {
            if (number >= 0)
            {
                return "0";
            }
            else
            {
                number = Math.Abs(number);
                return "1";
            }
        }

        private static string GetIntPartInBinary(int intPart)
        {
            StringBuilder stringBuilder = new StringBuilder();
            while (intPart != 1 && intPart != 0)
            {
                stringBuilder.Append((intPart % 2).ToString());
                intPart /= 2;
            }

            stringBuilder.Append(intPart.ToString());
            if (stringBuilder.Length < 11)
            {
                stringBuilder.Append('0', 11 - stringBuilder.Length);
            }

            char[] temp = stringBuilder.ToString().Reverse().ToArray();

            return new string(temp);
        }

        private static string GetFractionalPartinBinary(double fractionalPart, int length)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int i = 0;
            while (i < length)
            {
                fractionalPart *= 2;
                stringBuilder.Append(((int)(fractionalPart / 1)).ToString());
                fractionalPart %= 1;
                i++;
            }

            return stringBuilder.ToString();
        }
    }
}
