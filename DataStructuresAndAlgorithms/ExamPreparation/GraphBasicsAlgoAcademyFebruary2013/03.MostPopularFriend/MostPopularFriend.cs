namespace _03.MostPopularFriend
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class MostPopularFriend
    {
        private static int c;
        private static char[][] inputAdjacency;

        private static void Main()
        {
            ReadInput();
            Solve();
        }

        private static void ReadInput()
        {
            c = int.Parse(Console.ReadLine());
            inputAdjacency = new char[c][];

            for (int i = 0; i < c; i++)
            {
                var lineAsCharArray = Console.ReadLine().ToCharArray();

                inputAdjacency[i] = lineAsCharArray;
            }
        }

        private static void Solve()
        {
            int maxNumberOfTwoFriends = 0;

            // for every user, find the number of two friends
            for (int i = 0; i < c; i++)
            {
                int numberOfTwoFriends = 0;

                // find number of two friends
                for (int j = 0; j < c; j++)
                {
                    bool areTwoFriends = false;
                    if (i == j)
                    {
                        continue;
                    }

                    if (inputAdjacency[i][j] == 'Y')
                    {
                        areTwoFriends = true;
                    }
                    else
                    {
                        for (int k = 0; k < c; k++)
                        {
                            if ((k != i) && (k != j))
                            {
                                if (inputAdjacency[i][k] == 'Y' && inputAdjacency[j][k] == 'Y')
                                {
                                    areTwoFriends = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (areTwoFriends)
                    {
                        numberOfTwoFriends++;
                    }
                }

                maxNumberOfTwoFriends = Math.Max(maxNumberOfTwoFriends, numberOfTwoFriends);
            }

            Console.WriteLine(maxNumberOfTwoFriends);
        }
    }
}