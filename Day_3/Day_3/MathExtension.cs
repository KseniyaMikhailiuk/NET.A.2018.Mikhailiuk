using System;
using System.Collections.Generic;

namespace Day_3
{
    /// <summary>
    /// Provides arithmetical operations
    /// </summary>
    public class MathExtension
    {
        /// <summary>
        /// Get root od Nth degree
        /// </summary>
        /// <param name="number"></param>
        /// <param name="root"></param>
        /// <param name="eps"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">if input values are not valid</exception>
        public static double GetNthRoot(double number, int root, double eps = 0.0001)
        {
            if (number < 0 && root % 2 == 0)
            {
                throw new ArgumentException("Cannot take root out of negative number");
            }

            if (eps <= 0 || eps >= 1)
            {
                throw new ArgumentException("Precision diapason (0..1)");
            }

            if (root <= 0)
            {
                throw new ArgumentException();
            }

            double previousValue = number / root;
            double currentValue = (1.0 / root) * ((((root - 1) * previousValue) + number) / Math.Pow(previousValue, root - 1));
            while (Math.Abs(currentValue - previousValue) >= eps)
            {
                previousValue = currentValue;
                currentValue = (1.0 / root) * ((root - 1) * (previousValue + (number / Math.Pow(currentValue, root - 1))));
            }

            return currentValue;
        }

        /// <summary>
        /// Finds next bigger number  
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int FindNextBiggerNumber(int number)
        {
            int[] digitArray = IntToIntarray(number);
            for (int i = digitArray.Length - 1; i > 0; i--)
            {
                if (digitArray[i] > digitArray[i - 1])
                {
                    Swap(ref digitArray[i], ref digitArray[i - 1]);
                    Array.Sort(digitArray, i, digitArray.Length - i);

                    return IntarrayToInt(digitArray);
                }
            }

            return -1;
        }

        private static int IntarrayToInt(int[] digitArray)
        {
            int result = 0;
            int rank = 1;
            for (int i = digitArray.Length - 1; i >= 0; i--)
            {
                result += digitArray[i] * rank;
                rank *= 10;
            }

            return result;
        }

        private static int[] IntToIntarray(int number)
        {
            var digitArray = new Stack<int>();
            while (number != 0)
            {
                digitArray.Push(number % 10);
                number /= 10;
            }

            return digitArray.ToArray();
        }

        private static void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }
    }
}
