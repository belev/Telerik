namespace _02.SuperSum
{
    using System;
    using System.Linq;

    internal class SuperSum
    {
        private static int k;
        private static int n;
        private static long[,] superSums;

        private static void Main()
        {
            ReadInput();
            Console.WriteLine(Solve());
        }

        private static void ReadInput()
        {
            var kN = Console.ReadLine().Split().Select(int.Parse).ToArray();

            k = kN[0];
            n = kN[1];

            superSums = new long[k + 1, n + 1];
        }

        private static long Solve()
        {
            // base cases
            for (int i = 1; i <= n; i++)
            {
                superSums[0, i] = i;
            }

            for (int i = 1; i <= k; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (int jj = 1; jj <= j; jj++)
                    {
                        superSums[i, j] += superSums[i - 1, jj];
                    }
                }
            }

            return superSums[k, n];
        }
    }
}