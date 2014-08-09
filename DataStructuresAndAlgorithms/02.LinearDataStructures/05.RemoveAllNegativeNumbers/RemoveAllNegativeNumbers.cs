namespace _05.RemoveAllNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveAllNegativeNumbers
    {
        static List<int> InitializeSequence()
        {
            Console.Write("Enter sequence length: ");
            int n = int.Parse(Console.ReadLine());

            List<int> sequence = new List<int>();

            for (int i = 0; i < n; i++)
            {
                sequence.Add(int.Parse(Console.ReadLine()));
            }

            return sequence;
        }

        static void Main()
        {
            List<int> sequence = InitializeSequence();

            Console.WriteLine("Original sequence: {0}", string.Join(", ", sequence));

            sequence.RemoveAll(x => x < 0);

            Console.WriteLine("Sequence with removed negative numbers: {0}", string.Join(", ", sequence));
        }
    }
}
