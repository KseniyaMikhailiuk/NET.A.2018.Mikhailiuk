using System;

namespace Day_1
{
    /// <summary>
    /// Provides method for sorting array using merge algorithm.
    /// </summary>
    public class MergeSorter
    {
        /// <summary>
        /// Sorts elements in int array using merge algorithm.
        /// </summary>
        /// <param name="array"></param>
        public static void Sort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (array.Length < 1)
            {
                throw new ArgumentException("Array length must be > 1");
            }
            var resultArray = DivideSortandMerge(array);
            Array.Copy(resultArray, array, array.Length);
        }

        private static int[] DivideSortandMerge(int[] array)
        {
            var unsortedArrayMiddle = array.Length / 2;
            var firstPart = new int[unsortedArrayMiddle];
            var secondPart = new int[array.Length - unsortedArrayMiddle];
            Array.Copy(array, 0, firstPart, 0, unsortedArrayMiddle);
            Array.Copy(array, unsortedArrayMiddle, secondPart, 0, array.Length - unsortedArrayMiddle);
            if (firstPart.Length > 1)
            {
                firstPart = DivideSortandMerge(firstPart);
            }
            if (secondPart.Length > 1)
            {
                secondPart = DivideSortandMerge(secondPart);
            }

            return SortandMergeArrays(firstPart, secondPart);
        }

        private static int[] SortandMergeArrays(int[] firstPart, int[] secondPart)
        {
            var result = new int[firstPart.Length + secondPart.Length];
            int firstCounter = 0, secondCounter = 0, i = 0;
            while (firstCounter < firstPart.Length && secondCounter < secondPart.Length)
            {
                if (firstPart[firstCounter] <= secondPart[secondCounter])
                {
                    result[i] = firstPart[firstCounter];
                    firstCounter++;
                }
                else
                {
                    result[i] = secondPart[secondCounter];
                    secondCounter++;
                }
                i++;
            }
            if (firstCounter != firstPart.Length)
            {
                Array.Copy(firstPart, firstCounter, result, i, firstPart.Length - firstCounter);
            }
            if (secondCounter != secondPart.Length)
            {
                Array.Copy(secondPart, secondCounter, result, i, secondPart.Length - secondCounter);
            }

            return result;
        }
    }
}
