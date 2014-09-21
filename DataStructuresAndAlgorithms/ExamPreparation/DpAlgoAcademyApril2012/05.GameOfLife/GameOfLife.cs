namespace _05.GameOfLife
{
    using System;
    using System.Linq;

    internal class GameOfLife
    {
        private static int numberOfGenerations;
        private static int rowsCount;
        private static int colsCount;
        private static int[][] currentGeneration;

        private static int[] rowDirs = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
        private static int[] colDirs = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };

        private static void Main()
        {
            ReadInput();
            Console.WriteLine(FindNumberOfLiveCells());
        }

        private static void ReadInput()
        {
            numberOfGenerations = int.Parse(Console.ReadLine());
            var rC = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            rowsCount = rC[0];
            colsCount = rC[1];
            currentGeneration = new int[rowsCount][];

            for (int i = 0; i < rowsCount; i++)
            {
                var currentRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                currentGeneration[i] = currentRow;
            }
        }

        private static long FindNumberOfLiveCells()
        {
            for (int generationNumber = 1; generationNumber <= numberOfGenerations; generationNumber++)
            {
                var nextGeneration = new int[rowsCount][];

                for (int j = 0; j < rowsCount; j++)
                {
                    nextGeneration[j] = new int[colsCount];
                    for (int k = 0; k < colsCount; k++)
                    {
                        nextGeneration[j][k] = GetNextGenerationCell(currentGeneration[j][k], j, k);
                    }
                }

                currentGeneration = nextGeneration;

                //PrintCurrentGeneration();
            }

            long liveCells = 0L;

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    if (currentGeneration[i][j] == 1)
                    {
                        liveCells++;
                    }
                }
            }

            return liveCells;
        }

        private static int GetNextGenerationCell(int cellValue, int row, int col)
        {
            var nextGenerationValue = -1;
            var liveCellNeighbours = GetLiveCellNeighbours(row, col);

            if (cellValue == 0)
            {
                if (liveCellNeighbours == 3)
                {
                    nextGenerationValue = 1;
                }
                else
                {
                    nextGenerationValue = 0;
                }
            }
            else
            {
                if (liveCellNeighbours == 2 || liveCellNeighbours == 3)
                {
                    nextGenerationValue = 1;
                }
                else
                {
                    nextGenerationValue = 0;
                }
            }

            return nextGenerationValue;
        }

        private static int GetLiveCellNeighbours(int row, int col)
        {
            var liveCells = 0;

            for (int i = 0; i < rowDirs.Length; i++)
            {
                var neighbourRow = row + rowDirs[i];
                var neighbourCol = col + colDirs[i];

                if (IsValidCell(neighbourRow, neighbourCol))
                {
                    if (currentGeneration[neighbourRow][neighbourCol] == 1)
                    {
                        liveCells++;
                    }
                }
            }

            return liveCells;
        }

        private static bool IsValidCell(int row, int col)
        {
            return row >= 0 && col >= 0 && row < rowsCount && col < colsCount;
        }

        private static void PrintCurrentGeneration()
        {
            Console.WriteLine("******************************************************************");
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    Console.Write(currentGeneration[i][j]);

                    if (j != colsCount - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("******************************************************************");
        }
    }
}
