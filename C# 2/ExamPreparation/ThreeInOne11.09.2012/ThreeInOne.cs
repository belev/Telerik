using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInOne11._09._2012
{
    class ThreeInOne
    {
        static int SolveFirstTask()
        {
            for (int i = 21; i >= 1; i--)
            {
                if (playerPoints.ContainsKey(i))
                {
                    if (playerPoints[i] == 1)
                    {
                        return pointsAsList.IndexOf(i);
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            return -1;
        }
        static void ReadFirstTaskInput()
        {
            string[] rawPoints = Console.ReadLine().Split(',');

            for (int i = 0; i < rawPoints.Length; i++)
            {
                int number = int.Parse(rawPoints[i]);

                if (!playerPoints.ContainsKey(number))
                {
                    playerPoints.Add(number, 1);
                }
                else
                {
                    playerPoints[number]++;
                }
                pointsAsList.Add(number);
            }
        }
        static int SolveSecondTask()
        {
            int index = cakeSizes.Count - 1;

            while (index >= 0)
            {
                totalBitesCount += cakeSizes[index];

                index -= friendsCount + 1;
            }

            return totalBitesCount;
        }
        static void ReadSecondTaskInput()
        {
            string[] rawSizes = Console.ReadLine().Split(',');
            friendsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < rawSizes.Length; i++)
            {
                cakeSizes.Add(int.Parse(rawSizes[i]));
            }

            cakeSizes.Sort();
        }

        private static int BuyBeer()
        {
            int exchangeOperations = 0;
            while (G2 > G1)
            {
                --G2;
                S2 += 11;
                exchangeOperations++;
            }

            while (S2 > S1)
            {
                if (G1 > G2)
                {
                    --G1;
                    S1 += 9;
                    exchangeOperations++;
                }
                else
                {
                    --S2;
                    B2 += 11;
                    exchangeOperations++;
                }
            }

            while (B2 > B1)
            {
                if (S1 > S2)
                {
                    --S1;
                    B1 += 9;
                    exchangeOperations++;
                }
                else if (G1 > G2)
                {
                    --G1;
                    S1 += 9;
                    exchangeOperations++;
                }
                else
                {
                    return -1;
                }
            }

            return exchangeOperations;
        }
        static void ReadThirdTaskInput()
        {
            string[] rawNumberOfCoins = Console.ReadLine().Split(' ');

            G1 = int.Parse(rawNumberOfCoins[0]);
            S1 = int.Parse(rawNumberOfCoins[1]);
            B1 = int.Parse(rawNumberOfCoins[2]);

            G2 = int.Parse(rawNumberOfCoins[3]);
            S2 = int.Parse(rawNumberOfCoins[4]);
            B2 = int.Parse(rawNumberOfCoins[5]);
        }

        static SortedDictionary<int, int> playerPoints = new SortedDictionary<int, int>();
        static List<int> pointsAsList = new List<int>();

        static List<int> cakeSizes = new List<int>();
        static int friendsCount;
        static int totalBitesCount;

        static int G1;
        static int S1;
        static int B1;

        static int G2;
        static int S2;
        static int B2;

        static void Main(string[] args)
        {
            ReadFirstTaskInput();
            ReadSecondTaskInput();
            ReadThirdTaskInput();

            Console.WriteLine(SolveFirstTask());

            Console.WriteLine(SolveSecondTask());

            Console.WriteLine(BuyBeer());
        }
    }
}
