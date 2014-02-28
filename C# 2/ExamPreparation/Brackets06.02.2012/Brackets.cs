using System;
using System.Numerics;
namespace Problem_5_Brackets
{
    class Program
    {
        static void Main()
        {
            string pattern = Console.ReadLine();
            int N = pattern.Length;

            BigInteger[,] DP = new BigInteger[N + 1, N + 2];
            DP[0, 0] = 1;

            for (int r = 1; r <= N; r++)
            {
                //look for the zero column
                if (pattern[r - 1] == '(')
                {
                    DP[r, 0] = 0;
                }
                else
                {
                    DP[r, 0] = DP[r - 1, 1];
                }

                for (int c = 1; c <= N; c++)
                {
                    if (pattern[r - 1] == '(')
                    {
                        DP[r, c] = DP[r - 1, c - 1];
                    }
                    else if (pattern[r - 1] == ')')
                    {
                        DP[r, c] = DP[r - 1, c + 1];
                    }
                    else
                    {
                        DP[r, c] = DP[r - 1, c - 1] + DP[r - 1, c + 1];
                    }
                }
            }
            Console.WriteLine(DP[N, 0]);
        }
    }
}
