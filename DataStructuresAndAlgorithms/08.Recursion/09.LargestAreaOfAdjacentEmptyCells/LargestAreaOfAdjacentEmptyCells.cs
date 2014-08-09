namespace _09.LargestAreaOfAdjacentEmptyCells
{
    using System;
    using System.Collections.Generic;

    public class LargestAreaOfAdjacentEmptyCells
    {
        private static void FindBiggestArea(string[,] labyrinth)
        {
            int rowsCount = labyrinth.GetLength(0);
            int colsCount = labyrinth.GetLength(1);

            int largestAreaMaxCount = 0;
            int currentAreaCount = 0;

            int level = 0;
            int maxLevel = 0;

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    if (labyrinth[row, col] == " ")
                    {
                        FindArea(labyrinth, row, col, level, ref currentAreaCount);

                        if (largestAreaMaxCount <= currentAreaCount)
                        {
                            largestAreaMaxCount = currentAreaCount;
                            maxLevel = level;
                        }

                        currentAreaCount = 0;
                        level++;
                    }
                }
            }

            PrintLabyrint(maxLevel.ToString(), labyrinth);
            Console.WriteLine("Largest area marked with: {0}", maxLevel);
            Console.WriteLine("Largest area count: {0}", largestAreaMaxCount);
            Console.WriteLine();
        }

        private static void FindArea(string[,] labyrinth, int row, int col, int level, ref int count)
        {
            if (row < 0 || col < 0 || row >= labyrinth.GetLength(0) || col >= labyrinth.GetLength(1))
            {
                return;
            }

            if (labyrinth[row, col] != " ")
            {
                return;
            }

            labyrinth[row, col] = level.ToString();
            count++;

            for (int i = 0; i < dirX.Length; i++)
            {
                FindArea(labyrinth, row + dirX[i], col + dirY[i], level, ref count);
            }
        }

        private static void PrintLabyrint(string number, string[,] labyrinth)
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j] == number || labyrinth[i, j] == "*")
                    {
                        Console.Write("{0, 2} ", labyrinth[i, j]);
                    }
                    else
                    {
                        Console.Write("{0, 2} ", " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int[] dirX = new int[] { 0, 0, -1, 1 };
        static int[] dirY = new int[] { -1, 1, 0, 0 };

        static string[,] labyrinth = 
        {
            {"*", " ", "*", "*", " ", " ", " "},
            {" ", " ", " ", "*", " ", "*", " "},
            {" ", " ", " ", "*", " ", "*", " "},
            {"*", " ", "*", "*", "*", "*", "*"},
            {" ", " ", " ", "*", " ", " ", " "},
        };

        static string[,] matrix =
            {
                {" ", " ", "*", " ", " ", " ", "*", "*", " ", " "},
                {"*", " ", "*", " ", " ", "*", " ", " ", "*", " "},
                {" ", " ", "*", " ", " ", " ", "*", " ", " ", " "},
                {" ", "*", "*", "*", " ", "*", " ", "*", "*", " "},
                {" ", " ", " ", "*", " ", "*", "*", " ", " ", "*"},
            };

        static void Main()
        {
            FindBiggestArea(matrix);
            FindBiggestArea(labyrinth);
        }
    }
}