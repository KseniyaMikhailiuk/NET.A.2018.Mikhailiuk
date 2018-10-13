using System;

namespace Day_1
{
    /// <summary>
    /// Provides method for sorting int array using quicksort algorithm.
    /// </summary>
    public static class QuickSorter
    {
        /// <summary>
        /// Sorts elements in int array using quicksort algorithm
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static void Sort(ref int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if(array.Length < 1)
            {
                throw new ArgumentException("Array length must be > 1");
            }
            RedistributeElems(ref array, 0, array.Length - 1);
        } 

        private static void RedistributeElems(ref int[] array, int leftBorder, int rightBorder)
        {
            if (array.Length > 1)
            {
                var baseElemIndex = ((leftBorder + rightBorder) / 2) + leftBorder;
                int leftPointer = leftBorder, rightPointer = rightBorder;
                while (leftPointer < baseElemIndex || rightPointer > baseElemIndex)
                {
                    ProcessLeftSide(ref array, ref rightPointer, leftPointer, ref baseElemIndex);
                    if (leftPointer < baseElemIndex)
                    {
                        leftPointer++;
                    }
                    ProcessRightSide(ref array, rightPointer, ref leftPointer, ref baseElemIndex);
                    if (rightPointer > baseElemIndex)
                    {
                        rightPointer--;
                    }
                }
                if (array.Length > 2)
                {
                    DivideArray(ref array, baseElemIndex);
                }
            }
        }

        private static void DivideArray(ref int[] array, int baseElemIndex)
        {
            var firstPart = new int[baseElemIndex];
            Array.Copy(array, 0, firstPart, 0, baseElemIndex);
            var secondPart = new int[array.Length - baseElemIndex];
            Array.Copy(array, baseElemIndex, secondPart, 0, array.Length - baseElemIndex);
            RedistributeElems(ref firstPart, 0, firstPart.Length - 1);
            RedistributeElems(ref secondPart, 0, secondPart.Length - 1);
            array = MergeArrays(firstPart, secondPart);
        }

        private static int[] MergeArrays(int[] first, int[] second)
        {
            int[] result = new int[first.Length + second.Length];
            first.CopyTo(result, 0);
            second.CopyTo(result, first.Length);
            return result;
        }

        private static void ProcessRightSide(ref int[] array, int rightPointer, ref int leftPointer, ref int baseElementIndex)
        {
            if (array[rightPointer] < array[baseElementIndex] && rightPointer >= baseElementIndex)
            {
                while (array[leftPointer] < array[baseElementIndex] && leftPointer < baseElementIndex)
                {
                    leftPointer++;
                }
                Swap(ref array[rightPointer], ref array[leftPointer]);
                CheckandChangeBorders(ref baseElementIndex, leftPointer, rightPointer);
            }
        }

        private static void ProcessLeftSide(ref int[] array, ref int rightPointer, int leftPointer, ref int baseElementIndex)
        {
            if (array[leftPointer] > array[baseElementIndex] && leftPointer <= baseElementIndex)
            {
                while (array[rightPointer] >= array[baseElementIndex] && rightPointer > baseElementIndex)
                {
                    rightPointer--;
                }
                Swap(ref array[leftPointer], ref array[rightPointer]);
                CheckandChangeBorders(ref baseElementIndex, rightPointer, leftPointer);
            }
        }

        private static bool CheckandChangeBorders(ref int baseElementIndex, int pointerToCheck, int newBorder)
        {
            if (baseElementIndex == pointerToCheck)
            {
                baseElementIndex = newBorder;

                return true;
            }

            return false;
        }

        private static void Swap(ref int firstInt, ref int secondInt)
        {
            var temp = firstInt;
            firstInt = secondInt;
            secondInt = temp;
        }
    }
}
