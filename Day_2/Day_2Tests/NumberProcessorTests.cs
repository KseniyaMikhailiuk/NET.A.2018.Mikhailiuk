using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Day_2.Tests
{
    [TestClass]
    public class NumberProcessorTests
    {
        [DataTestMethod]
        [DataRow(15, 15, 0, 0, 15)]
        [DataRow(15, 8, 0, 0, 9)]
        [DataRow(15, 8, 3, 8, 120)]
        public void InsertNumber_Test(int sourceNumber, int destinationNumber, int firstIndex, int secondIndex, int result)
        {
            NumberProcessor.InsertNumber(sourceNumber, ref destinationNumber, firstIndex, secondIndex);
            Assert.AreEqual(destinationNumber, result);
        }

        [DataTestMethod]
        [DataRow(15, 15, -1, 0)]
        [DataRow(15, 15, -1, 35)]
        [DataRow(15, 15, 6, 1)]
        public void InsertNumber_ExeptionTest(int sourceNumber, int destinationNumber, int firstIndex, int secondIndex)
        {
            Assert.ThrowsException<ArgumentException>(() => NumberProcessor.InsertNumber(sourceNumber, ref destinationNumber, firstIndex, secondIndex));
        }
    }
}