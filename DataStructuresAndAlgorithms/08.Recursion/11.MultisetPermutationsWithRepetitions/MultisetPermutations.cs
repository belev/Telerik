namespace _11.MultisetPermutationsWithRepetitions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class MultisetPermutations
    {
        private static HashSet<string> allPermutations;

        private static int[] sequence;

        static void Main(string[] args)
        {
            allPermutations = new HashSet<string>();
            sequence = new int[] { 1, 3, 5, 5 };
            //sequence = new int[] { 1, 5, 5, 5, 5, 5, 5, 5, 5 };

            int sequenceLength = sequence.Length;

            Permute(new bool[sequenceLength], new int[sequenceLength], 0);

            Console.WriteLine(string.Join(Environment.NewLine, allPermutations));
        }

        public static void Permute(bool[] used, int[] permutation, int index)
        {
            if (index == sequence.Length)
            {
                allPermutations.Add(string.Join(" ", permutation));
                return;
            }

            for (int i = 0; i < sequence.Length; i++)
            {
                if (used[i])
                {
                    continue;
                }

                used[i] = true;
                permutation[index] = sequence[i];

                Permute(used, permutation, index + 1);

                used[i] = false;
            }
        }
    }
}
