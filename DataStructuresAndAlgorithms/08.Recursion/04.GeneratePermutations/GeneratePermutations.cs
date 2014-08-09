namespace _04.GeneratePermutations
{
    using System;

    public class GeneratePermutations
    {
        private static void PrintGeneratedPermutation(int pos, int[] currentPermutation, bool[] used)
        {
            if (pos == currentPermutation.Length)
            {
                Console.WriteLine(string.Join(" ", currentPermutation));
                return;
            }

            for (int i = 1; i <= currentPermutation.Length; i++)
            {
                if (used[i - 1])
                {
                    continue;
                }

                currentPermutation[pos] = i;

                used[i - 1] = true;
                PrintGeneratedPermutation(pos + 1, currentPermutation, used);
                used[i - 1] = false;
            }
        }

        static void Main()
        {
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());

            int[] permutation = new int[n];
            bool[] used = new bool[n];

            PrintGeneratedPermutation(0, permutation, used);
        }
    }
}
