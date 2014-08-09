namespace _03.SortIncreasinglyListOfInts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortIncreasinglyListOfInts
    {
        static void Main()
        {
            List<int> sequence = new List<int>();

            Console.WriteLine("Enter sequence, for end of sequence press enter: ");

            int curNumber;
            while (int.TryParse(Console.ReadLine(), out curNumber) == true)
            {
                sequence.Add(curNumber);
            }

            Console.WriteLine("Original sequence: {0}", string.Join(", ", sequence));

            sequence.Sort();

            Console.WriteLine("Increasingly sorted sequence: {0}", string.Join(", ", sequence));
        }
    }
}
