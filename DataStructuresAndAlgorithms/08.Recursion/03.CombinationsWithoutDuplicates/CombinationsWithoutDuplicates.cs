namespace _03.CombinationsWithoutDuplicates
{
    using System;

    public class CombinationsWithoutDuplicates
    {
        private static void PrintPermsWithDuplicates(int[] currentPerm, int pos, int n, int startNumber)
        {
            if (pos >= currentPerm.Length)
            {
                Console.WriteLine(string.Join(" ", currentPerm));
                return;
            }

            for (int i = startNumber; i <= n; i++)
            {
                currentPerm[pos] = i;
                PrintPermsWithDuplicates(currentPerm, pos + 1, n, i + 1);
            }
        }

        static void Main()
        {
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter k: ");
            int k = int.Parse(Console.ReadLine());

            PrintPermsWithDuplicates(new int[k], 0, n, 1);
        }
    }
}
