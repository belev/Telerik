namespace _08.FortuneTeller
{
    using System;
    using System.Linq;

    internal class FortuneTeller
    {
        private static int[, ,] dp = new int[2600, 2600, 2];
        private static int r;
        private static int w;
        private static string days;

        private static void Main()
        {
            ReadInput();

            int resultStartingWithBadDay = (days[0] == 'B' ? 1 : 0) + Solve(1, 0, true);
            int resultStartingWithGoodDay = (days[0] == 'G' ? 1 : 0) + Solve(1, 0, false);

            Console.WriteLine(Math.Max(resultStartingWithBadDay, resultStartingWithGoodDay));
        }

        private static void ReadInput()
        {
            for (int i = 0; i < 2600; i++)
            {
                for (int j = 0; j < 2600; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        dp[i, j, k] = -1;
                    }
                }
            }

            var rW = Console.ReadLine().Split().Select(int.Parse).ToArray();

            r = rW[0];
            w = rW[1];
            days = Console.ReadLine();
        }

        private static int Solve(int currentPosition, int lastGuessedPosition, bool isWrong)
        {
            if (currentPosition >= days.Length)
            {
                return 0;
            }

            if (dp[currentPosition, lastGuessedPosition, (isWrong ? 0 : 1)] != -1)
            {
                return dp[currentPosition, lastGuessedPosition, (isWrong ? 0 : 1)];
            }

            int result = 0;
            int differenceBetweenLastGuessedAndCurrent = currentPosition - lastGuessedPosition;

            if (!isWrong && differenceBetweenLastGuessedAndCurrent < r)
            {
                result = Math.Max(result, (days[currentPosition] == 'G' ? 1 : 0) + Solve(currentPosition + 1, lastGuessedPosition, isWrong));
            }

            if (!isWrong)
            {
                result = Math.Max(result, (days[currentPosition] == 'B' ? 1 : 0) + Solve(currentPosition + 1, currentPosition, !isWrong));
            }

            if (isWrong && differenceBetweenLastGuessedAndCurrent < w)
            {
                result = Math.Max(result, (days[currentPosition] == 'B' ? 1 : 0) + Solve(currentPosition + 1, lastGuessedPosition, isWrong));
            }

            if (isWrong)
            {
                result = Math.Max(result, (days[currentPosition] == 'G' ? 1 : 0) + Solve(currentPosition + 1, currentPosition, !isWrong));
            }

            dp[currentPosition, lastGuessedPosition, (isWrong ? 0 : 1)] = result;
            return result;
        }
    }
}