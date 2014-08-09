namespace _07.CountOccurances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CountOccurances
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

                if (number < 0 || number > 1000)
                {
                    throw new ArgumentOutOfRangeException("Entered number out of the range [0, 1000]");
                }

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

        static void Main(string[] args)
        {
            var sequence = InitializeSequence();

            foreach (var item in sequenceAsDictionary)
            {
                Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
            }
        }
    }
}
