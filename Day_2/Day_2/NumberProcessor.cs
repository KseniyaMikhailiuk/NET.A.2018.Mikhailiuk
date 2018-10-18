using System;

namespace Day_2
{
    /// <summary>
    /// Provides method that inserts bits from source number into certain bits of destination number
    /// </summary>
    public class NumberProcessor
    {
        /// <summary>
        /// Max index
        /// </summary>
        private const int MAXINDEX = 31;

        /// <summary>
        /// Min index
        /// </summary>
        private const int MININDEX = 0;

        /// <summary>
        /// Inserts bits from source number into certain bits of destination number 
        /// </summary>
        /// <param name="sourceNumber"></param>
        /// <param name="destinationNumber"></param>
        /// <param name="firstIndex"></param>
        /// <param name="secondIndex"></param>
        public static void InsertNumber(int sourceNumber, ref int destinationNumber, int firstIndex, int secondIndex)
        {
            if (firstIndex > secondIndex || firstIndex < MININDEX || secondIndex > MAXINDEX)
            {
                throw new ArgumentException("Check indexes");
            }

            destinationNumber = BitOperations(destinationNumber);

            int BitOperations(int destination)
            {
                int maskSource = ~(int.MaxValue << (MAXINDEX - (secondIndex - firstIndex))) >> (MAXINDEX - secondIndex - 1);
                sourceNumber &= maskSource;
                sourceNumber <<= firstIndex;
                int destMask = ~(int.MaxValue << (secondIndex - firstIndex)) >> (secondIndex - 1);
                destination &= destMask;

                return destination |= sourceNumber;
            }
        }
    }
}
