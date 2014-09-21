namespace _09.BinaryTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class BinaryTrees
    {
        private static void Main()
        {
            var balls = Console.ReadLine();
            var ballsCount = balls.Length;
            var ballColorsDict = balls.GroupBy(b => b).ToDictionary(b => b.Key, b => b.Count());

            var binaryTreesForNCount = new decimal[] { 1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 58786, 208012, 742900, 2674440, 9694845, 35357670, 129644790, 477638700, 1767263190, 6564120420, 24466267020, 91482563640, 343059613650, 1289904147324, 4861946401452 };

            decimal binaryTreesCount = binaryTreesForNCount[ballsCount];
            decimal coloredCombinationsCount = GetColoredBallsCombinationsCount(ballsCount, ballColorsDict);


            Console.WriteLine(binaryTreesCount * coloredCombinationsCount);
        }

        private static decimal GetColoredBallsCombinationsCount(int ballsCount, Dictionary<char, int> ballColorsDict)
        {
            decimal coloredBallsCombinationsCount = GetFactorial(ballsCount);

            foreach (var ballColor in ballColorsDict)
            {
                coloredBallsCombinationsCount /= GetFactorial(ballColor.Value);
            }

            return coloredBallsCombinationsCount;
        }

        private static ulong GetFactorial(int number)
        {
            ulong factorial = 1;

            for (int i = 2; i <= number; i++)
            {
                factorial *= (ulong)i;
            }

            return factorial;
        }
    }
}
