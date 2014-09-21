namespace _05.Businessmen
{
    using System;
    using System.Linq;

    internal class Businessmen
    {
        private static void Main()
        {
            int businessmenCount = int.Parse(Console.ReadLine());

            Console.WriteLine(FindPerfectHandshakesCount(businessmenCount));
        }

        private static long FindPerfectHandshakesCount(int businessmenCount)
        {
            var dp = new long[businessmenCount + 1];
            dp[0] = 1;
            for (int i = 1; i <= businessmenCount; i++)
            {
                for (int j = 0; j <= i - 2; j += 2)
                {
                    dp[i] += dp[j] * dp[i - j - 2];
                }
            }

            return dp[businessmenCount];
        }
    }
}