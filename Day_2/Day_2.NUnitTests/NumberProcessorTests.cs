using System;
using NUnit.Framework;

namespace Day_2.NUnitTests
{
    [TestFixture]
    public class NumberProcessorTests
    {
        [TestCase(15, 15, 0, 0, 15)]
        [TestCase(15, 8, 0, 0, 9)]
        [TestCase(15, 8, 3, 8, 120)]
        public void InsertNumber_Test(int sourceNumber, ref int destinationNumber, int firstIndex, int secondIndex, int result)
        {
            NumberProcessor.InsertNumber(sourceNumber, ref destinationNumber, firstIndex, secondIndex);
            Assert.AreEqual(destinationNumber, result);
        }

        [TestCase(15, 15, -1, 0)]
        [TestCase(15, 15, -1, 35)]
        [TestCase(15, 15, 6, 1)]
        public void InsertNumber_ExeptionTest(int sourceNumber, int destinationNumber, int firstIndex, int secondIndex)
        {
            Assert.Throws<ArgumentException>(() => NumberProcessor.InsertNumber(sourceNumber, ref destinationNumber, firstIndex, secondIndex));
        }
    }
}
