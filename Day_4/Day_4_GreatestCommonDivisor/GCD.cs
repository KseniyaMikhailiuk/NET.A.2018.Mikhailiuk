using System;
using System.Diagnostics;

namespace Day_4_GreatestCommonDivisor
{
    public class GCD
    {
        private delegate int GcdAlgorithm(int first, int second);

        /// <summary>
        /// Finds greatest common divisor using Stain's algorithm
        /// </summary>
        /// <param name="runTime"></param>
        /// <param name="numbers"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int GetGcdBinary(out long runTime, params int[] numbers)
        {
            var result = ProcessArray(numbers, new GcdAlgorithm(GcdFortwo));
            runTime = result.runTime;
            return result.gcd;
        }

        /// <summary>
        /// Finds greatest common divisor using Euclidean algorithm
        /// </summary>
        /// <param name="runTime"></param>
        /// <param name="numbers"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int GetGcd(out long runTime, params int[] numbers)
        {
            var result = ProcessArray(numbers, new GcdAlgorithm(GcdBinaryFortwo));
            runTime = result.runTime;
            return result.gcd;
        }

        private static (int gcd, long runTime) ProcessArray(int[] numbers, GcdAlgorithm algorithmType)
        {
            if (numbers.Length < 1)
            {
                throw new ArgumentException();
            }

            Stopwatch sw = Stopwatch.StartNew();
            long startTime = sw.ElapsedMilliseconds;
            int gcd = Math.Abs(numbers[0]);
            for (int i = 1; i <= numbers.Length - 1; i++)
            {
                gcd = algorithmType.Invoke(Math.Abs(numbers[i]), gcd);
            }

            return (gcd, sw.ElapsedMilliseconds - startTime);
        }

        private static int GcdFortwo(int first, int second)
        {
            while (first != second)
            {
                if (first > second)
                {
                    first -= second;
                }
                else
                {
                    second -= first;
                }
            }

            return first;
        }

        private static int GcdBinaryFortwo(int first, int second)
        {
            int shift;
            if (first == 0 || second == 0)
            {
                return first | second;
            }

            for (shift = 0;  ((first | second) & 1) == 0; ++shift)
            {
                first >>= 1;
                second >>= 1;
            }

            while ((first & 1) == 0)
            {
                first >>= 1;
            }

            do
            {
                while ((second & 1) == 0)
                {
                    second >>= 1;
                }

                if (first > second)
                {
                    Swap(ref first, ref second);
                }

                second = second - first;
            }
            while (second != 0);

            return first << shift;
        }

        private static void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }
    }
}
