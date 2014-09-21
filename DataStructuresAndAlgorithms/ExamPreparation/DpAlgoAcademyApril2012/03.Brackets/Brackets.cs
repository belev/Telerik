namespace _03.Brackets
{
    using System;
    using System.Linq;

    internal class Brackets
    {
        private static void Main()
        {
            string expression = Console.ReadLine();
            int expressionLength = expression.Length;

            long[,] dp = new long[expressionLength + 1, expressionLength + 2];
            dp[0, 0] = 1;

            for (int i = 0; i < expressionLength; i++)
            {
                if (expression[i] == '(')
                {
                    dp[i + 1, 0] = 0;
                }
                else
                {
                    dp[i + 1, 0] = dp[i, 1];
                }

                for (int j = 1; j <= expressionLength; j++)
                {
                    if (expression[i] == '(')
                    {
                        dp[i + 1, j] = dp[i, j - 1];
                    }
                    else if (expression[i] == ')')
                    {
                        dp[i + 1, j] = dp[i, j + 1];
                    }
                    else
                    {
                        dp[i + 1, j] = dp[i, j - 1] + dp[i, j + 1];
                    }
                }
            }

            Console.WriteLine(dp[expressionLength, 0]);
        }
    }
}