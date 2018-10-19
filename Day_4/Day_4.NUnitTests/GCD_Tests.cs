using System;
using Day_4_GreatestCommonDivisor;
using NUnit.Framework;

namespace Day_4.NUnitTests
{
    [TestFixture]
    public class GCD_Tests
    {
        [TestCase(9, -585, 81, 189)]
        [TestCase(6, 78, 294, 570, 36)]
        [TestCase(1, 661, 113)]
        [TestCase(45, 45)]
        public static void GetGcd_Test(int expected, params int[] test)
        {
            Assert.AreEqual(expected, GCD.GetGcd(out long runTime, test));
        }

        [TestCase(9, -585, 81, 189)]
        [TestCase(6, 78, 294, 570, 36)]
        [TestCase(1, 661, 113)]
        [TestCase(45, 45)]
        public static void GetGcdBinary_Test(int expected, params int[] test)
        {
            Assert.AreEqual(expected, GCD.GetGcdBinary(out long runTime, test));
        }

        public static void GetGcdBinary_NullTest(int expected, params int[] test)
        {
            Assert.Throws<ArgumentException>(() => GCD.GetGcdBinary(out long runTime, new int[0]));
        }

        public static void GetGcd_NullTest(int expected, params int[] test)
        {
            Assert.Throws<ArgumentException>(() => GCD.GetGcd(out long runTime, new int[0]));
        }
    }
}
