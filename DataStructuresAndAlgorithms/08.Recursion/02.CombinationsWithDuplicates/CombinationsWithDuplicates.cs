namespace _02.CombinationsWithDuplicates
{
    using System;

    public class CombinationsWithDuplicates
    {
        private static void PrintPermsWithDuplicates(int[] currentPerm, int pos, int n)
        {
            if (pos >= currentPerm.Length)
            {
                Console.WriteLine(string.Join(" ", currentPerm));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                currentPerm[pos] = i;
                PrintPermsWithDuplicates(currentPerm, pos + 1, n);
            }
        }

        static void Main()
        {
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter k: ");
            int k = int.Parse(Console.ReadLine());

            PrintPermsWithDuplicates(new int[k], 0, n);
        }
    }
}
