using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Day_1.Tests
{
    [TestClass()]
    public class MergeSorterTests
    {
        public static int[] GenerateArray()
        {
            Random random = new Random();
            int[] result = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                result[i] = random.Next();
            }

            return result;
        }

        [TestMethod()]
        public void Sort_hugeArrayTest()
        {
            int[] unsortedArray_1 = GenerateArray();
            int[] unsortedArray_2 = new int[1000];
            unsortedArray_1.CopyTo(unsortedArray_2, 0);
            Array.Sort(unsortedArray_1);
            MergeSorter.Sort(unsortedArray_2);
            CollectionAssert.AreEqual(unsortedArray_1, unsortedArray_2);
        }

        [TestMethod()]
        public void Sort_nullTest()
        {
            int[] array = null;
            Assert.ThrowsException<ArgumentNullException>(() => MergeSorter.Sort(array));
        }

        [TestMethod()]
        public void Sort_emptyArrayTest()
        {
            int[] array = new int[0];
            Assert.ThrowsException<ArgumentException>(() => MergeSorter.Sort(array));
        }
    }
}