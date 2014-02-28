namespace BitArray64
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Tester
    {
        // 05.Define a class BitArray64 to hold 64 bit values inside an ulong value. Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.
        static void Main()
        {
            Bit64Array bitArray = new Bit64Array();

            bitArray[0] = 1;
            bitArray[1] = 1;
            bitArray[2] = 1;
            bitArray[3] = 1;

            foreach (var item in bitArray)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            Console.WriteLine(bitArray.ToString());

            bitArray[3] = 0;
            Console.WriteLine(bitArray.ToString());

            Bit64Array otherBitArray = new Bit64Array(7);

            bool areEqual = bitArray.Equals(otherBitArray);
            Console.WriteLine("bitArray == otherBitArray -> {0}", areEqual);

            // change some bit
            otherBitArray[10] = 1;

            // check if are equal are print the result on the console
            areEqual = bitArray == otherBitArray;
            Console.WriteLine("bitArray == otherBitArray -> {0}", areEqual);

            Console.WriteLine(otherBitArray.GetHashCode());
        }
    }
}
