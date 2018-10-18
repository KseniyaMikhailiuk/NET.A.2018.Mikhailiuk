using System;
using NUnit.Framework;

namespace Day_1.Tests
{
    [TestFixture]
    public class MergeSorterTests
    { 
        [Test]
        public void MergeSorter_hugeArrayTest()
        {
            int[] unsortedArray_1 = GenerateArray();
            int[] unsortedArray_2 = new int[1000];
            unsortedArray_1.CopyTo(unsortedArray_2, 0);
            Array.Sort(unsortedArray_1);
            MergeSorter.Sort(unsortedArray_2);
            CollectionAssert.AreEqual(unsortedArray_1, unsortedArray_2);
        }

        [TestCase(null)]
        public void MergeSorter_nullTest(int[] array)
        {
            Assert.Throws<ArgumentNullException>(() => MergeSorter.Sort(array));
        }

        [Test]
        public void Sort_emptyArrayTest()
        {
            int[] array = new int[0];
            Assert.Throws<ArgumentException>(() => MergeSorter.Sort(array));
        }

        private static int[] GenerateArray()
        {
            Random random = new Random();
            int[] result = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                result[i] = random.Next();
            }

            return result;
        }
    }
}
