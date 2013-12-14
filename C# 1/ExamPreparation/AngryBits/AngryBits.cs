using System;

class AngryBits
{
    static bool isValidCellForPigs(int row, int col)
    {
        return row >= 0 && row <= 7 && col >= 0 && col <= 7;
    }

    static void Main()
    {
        int[] numbers = new int[8];

        for (int i = 0; i < 8; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int[,] matrix = new int[8, 16];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                if (((numbers[i] >> j) & 1) == 1)
                {
                    matrix[i, j] = 1;
                }
            }
        }

        int score = 0;

        for (int i = 8; i < 16; i++)
        {
            int countDestroyedPigs = 0;
            int lengthOfFlight = 0;
            string direction = "up";

            bool hitPig = false;

            int countBirdsOnLine = 0;
            int row = -1;
            int col = -1;

            for (int j = 0; j < 8; j++)
            {
                if (matrix[j, i] == 1)
                {
                    countBirdsOnLine++;

                    matrix[j, i] = 0;
                    row = j;
                    col = i;
                }
            }

            if (countBirdsOnLine == 1)
            {
                if (row == 0)
                {
                    direction = "down";
                }
                while (true)
                {
                    if (direction == "up")
                    {
                        if (row > 0)
                        {
                            row--;
                        }

                        col--;
                        lengthOfFlight++;
                    }
                    else if (direction == "down")
                    {
                        if (row < 7)
                        {
                            row++;
                        }

                        col--;
                        lengthOfFlight++;
                    }

                    if (row == 0)
                    {
                        direction = "down";
                    }

                    if (matrix[row, col] == 1)
                    {
                        hitPig = true;
                        matrix[row, col] = 0;
                        countDestroyedPigs++;

                        break;
                    }

                    if (row == 7)
                    {
                        matrix[row, col] = 0;
                        break;
                    }

                    if (col == 0)
                    {
                        matrix[row, col] = 0;
                        break;
                    }
                }

                if (hitPig)
                {
                    int[] dx = { -1, -1, -1, 0, 1, 1, 1, 0 };
                    int[] dy = { 1, 0, -1, -1, -1, 0, 1, 1 };

                    for (int k = 0; k < 8; k++)
                    {
                        if (isValidCellForPigs(row + dx[k], col + dy[k]))
                        {
                            if (matrix[row + dx[k], col + dy[k]] == 1)
                            {
                                countDestroyedPigs++;

                                matrix[row + dx[k], col + dy[k]] = 0;
                            }
                        }
                    }

                    score += lengthOfFlight * countDestroyedPigs;

                    lengthOfFlight = 0;
                    countDestroyedPigs = 0;
                }

            }
        }

        bool allPigsAreDestroyed = true;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (matrix[i, j] == 1)
                {
                    allPigsAreDestroyed = false;
                }
            }
        }

        if (allPigsAreDestroyed)
        {
            Console.WriteLine("{0} {1}", score, "Yes");
        }
        else
        {
            Console.WriteLine("{0} {1}", score, "No");
        }
    }
}