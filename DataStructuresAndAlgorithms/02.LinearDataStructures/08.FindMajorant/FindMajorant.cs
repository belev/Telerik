namespace _08.FindMajorant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FindMajorant
    {
        static Dictionary<int, int> sequenceAsDictionary;

        static int[] InitializeSequence()
        {
            Console.Write("Enter sequence length: ");
            int n = int.Parse(Console.ReadLine());

            var sequence = new int[n];

            sequenceAsDictionary = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                sequence[i] = number;

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

            Console.WriteLine("Sequence: {0}", string.Join(", ", sequence));

            try
            {
                int majorant = sequence.First(x => sequenceAsDictionary[x] >= sequence.Length / 2 + 1);

                Console.WriteLine("The majorant is: {0}", majorant);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("The sequence has no majorant element!");
            }

        }
    }
}
