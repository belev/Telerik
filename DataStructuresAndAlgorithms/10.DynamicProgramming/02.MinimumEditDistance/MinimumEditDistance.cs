namespace _02.MinimumEditDistance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class MinimumEditDistance
    {
        private static double FindMED(string first, string second)
        {
            var distance = InitializeDistanceMatrix(first.Length, second.Length);
            
            for (int j = 1; j <= second.Length; j++)
            {
                for (int i = 1; i <= first.Length; i++)
                {
                    if (first[i - 1] == second[j - 1])
                    {
                        distance[i, j] = distance[i - 1, j - 1];
                    }
                    else
                    {
                        distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 0.9, distance[i, j - 1] + 0.8), distance[i - 1, j - 1] + 1);
                    }
                }
            }
            return distance[first.Length, second.Length];
        }

        /// <summary>
        /// Do the initializing with i and j * 0.9 because the deletion operation has cost 0.9
        /// </summary>
        /// <param name="firstWordLength"></param>
        /// <param name="secondWordLength"></param>
        /// <returns></returns>
        private static double[,] InitializeDistanceMatrix(int firstWordLength, int secondWordLength)
        {
            var distanceMatrix = new double[firstWordLength + 1, secondWordLength + 1];

            for (int i = 0; i <= firstWordLength; i++)
            {
                distanceMatrix[i, 0] = i * 0.9;
            }

            for (int j = 0; j <= secondWordLength; j++)
            {
                distanceMatrix[0, j] = j * 0.9;
            }

            return distanceMatrix;
        }

        static void Main()
        {
            string developer = "developer";
            string enveloped = "enveloped";

            string kitten = "kitten";
            string sitting = "sitting";

            Console.WriteLine("{0} to {1} -> {2}", developer, enveloped, FindMED(developer, enveloped));
            Console.WriteLine("{0} to {1} -> {2}", kitten, sitting, FindMED(kitten, sitting));
        }
    }
}
