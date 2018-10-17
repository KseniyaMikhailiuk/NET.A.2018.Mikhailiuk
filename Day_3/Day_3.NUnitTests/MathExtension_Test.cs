using System;
using NUnit.Framework;

namespace Day_3.NUnitTests
{
    [TestFixture]
    public class MathExtension_Test
    {
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void GetNthRoot_Test(double number, int root, double eps, double result)
        {
            Assert.AreEqual(result, MathExtension.GetNthRoot(number, root, eps), 0.1);
        }

        [TestCase(-0.01, 2, 0.0001)]
        [TestCase(0.001, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]
        public void GetNthRoot_Test(double number, int root, double eps)
        {
            Assert.Throws<ArgumentException>(() => MathExtension.GetNthRoot(number, root, eps));
        }

        [TestCase(12, 21)]
        [TestCase(513, 531)]
        [TestCase(2017, 2071)]
        [TestCase(414, 441)]
        [TestCase(144, 414)]
        [TestCase(1234321, 1241233)]
        [TestCase(1234126, 1234162)]
        [TestCase(3456432, 3462345)]
        [TestCase(10, -1)]
        [TestCase(20, -1)]
        public void FindNextBiggerNumber(int number, int result)
        {
            Assert.AreEqual(result, MathExtension.FindNextBiggerNumber(number));
        }
    }
}
