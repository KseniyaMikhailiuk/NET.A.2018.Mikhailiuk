using System;
using NUnit.Framework;

namespace Day_1.Tests
{
    [TestFixture]
    public class QuickSorterTest
    {
        [Test]
        public void Sort_hugeArrayTest()
        {
            int[] unsortedArray_1 = GenerateArray();
            int[] unsortedArray_2 = new int[1000];
            unsortedArray_1.CopyTo(unsortedArray_2, 0);
            Array.Sort(unsortedArray_1);
            QuickSorter.Sort(unsortedArray_2);
            CollectionAssert.AreEqual(unsortedArray_1, unsortedArray_2);
        }

        [TestCase(null)]
        public void QuickSorter_nullTest(int[] array)
        {
            Assert.Throws<ArgumentNullException>(() => QuickSorter.Sort(array));
        }

        [Test]
        public void Sort_emptyArrayTest()
        {
            int[] array = new int[0];
            Assert.Throws<ArgumentException>(() => QuickSorter.Sort(array));
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
