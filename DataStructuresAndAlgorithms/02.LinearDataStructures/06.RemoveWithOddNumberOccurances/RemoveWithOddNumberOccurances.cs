namespace _06.RemoveWithOddNumberOccurances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveWithOddNumberOccurances
    {
        static Dictionary<int, int> sequenceAsDictionary;

        static List<int> InitializeSequence()
        {
            Console.Write("Enter sequence length: ");
            int n = int.Parse(Console.ReadLine());

            var sequence = new List<int>();

            sequenceAsDictionary = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                sequence.Add(number);

                if (sequenceAsDictionary.ContainsKey(number))
                {
                    sequenceAsDictionary[number]++;
                }
                else
                {
                    sequenceAsDictionary.Add(number, 1);
                }
            }

            return sequence;
        }

        static void Main()
        {
            var sequence = InitializeSequence();

            sequence = sequence.Where(x => sequenceAsDictionary[x] % 2 == 0).ToList();

            Console.WriteLine("Sequence with removed elements: {0}", string.Join(", ", sequence));
        }
    }
}
