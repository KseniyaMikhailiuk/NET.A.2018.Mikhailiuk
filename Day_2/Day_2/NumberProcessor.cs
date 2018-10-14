using System;

namespace Day_2
{
    /// <summary>
    /// Provides method that inserts bits from source number into certain bits of destination number
    /// </summary>
    public class NumberProcessor
    {
        private const int MAXINDEX = 31;
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
            char[] sourceNumber32 = FromIntTo32Bit(sourceNumber);
            char[] destinationNumber32 = FromIntTo32Bit(destinationNumber);
            int j = sourceNumber32.Length - (secondIndex - firstIndex) - 1;
            for (int i = destinationNumber32.Length - secondIndex - 1; 
                        i < destinationNumber32.Length - firstIndex; i++)
            {
                destinationNumber32[i] = sourceNumber32[j];
                j++;
            }
            destinationNumber = From32BitToInt(destinationNumber32);
        }


        private static char[] FromIntTo32Bit(int number)
        {
            char[] bits32 = new char[32];
            char[] binaryFormat = Convert.ToString(number, 2).ToCharArray();
            int i = 0;
            while (i < bits32.Length - binaryFormat.Length)
            {
                bits32[i] = '0';
                i++;
            }
            Array.Copy(binaryFormat, 0, bits32, i, binaryFormat.Length);
            return bits32;
        }

        private static int From32BitToInt(char[] number32)
        {
            return Convert.ToInt32(new string(number32), 2);
        }
    }
}
