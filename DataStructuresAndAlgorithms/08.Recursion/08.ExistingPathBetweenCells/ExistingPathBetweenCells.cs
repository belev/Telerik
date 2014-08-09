namespace _07.FindPathsBetweenTwoCells
{
    using System;

    public class FindPathsBetweenTwoCells
    {
        private static void InitializeLabyrinth(int rowsCount, int colsCount)
        {
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    labyrinth[i, j] = " ";
                }
            }
        }

        private static bool IsValidPositionToStep(int row, int col)
        {
            return (row >= 0 && col >= 0 && row < labyrinth.GetLength(0) && col < labyrinth.GetLength(1));
        }

        private static void SetExitInLabyrinth(int row, int col)
        {
            if (!IsValidPositionToStep(row, col))
            {
                throw new ArgumentOutOfRangeException("Cannot set the exit on unexisting cell!");
            }

            labyrinth[row, col] = "e";
        }

        private static void FindAllPaths(int row, int col, char pathStepSymbol)
        {
            if (!IsValidPositionToStep(row, col))
            {
                return;
            }

            if (labyrinth[row, col] == "e")
            {
                PrintLabyrinth();
                Console.WriteLine("Path found.");

                // we found the exit once, so it exist and exit the program
                // test to see that the labyrinth is printed only once
                Environment.Exit(0);
            }

            if (labyrinth[row, col] != " ")
            {
                return;
            }

            labyrinth[row, col] = pathStepSymbol.ToString();

            FindAllPaths(row - 1, col, pathStepSymbol);
            FindAllPaths(row + 1, col, pathStepSymbol);
            FindAllPaths(row, col - 1, pathStepSymbol);
            FindAllPaths(row, col + 1, pathStepSymbol);

            labyrinth[row, col] = " ";
        }

        private static void PrintLabyrinth()
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j] != " ")
                    {
                        if (labyrinth[i, j] == "*")
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        Console.Write(labyrinth[i, j]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        // U -> from unvisited cells
                        Console.Write('U');
                    }

                    if (j != labyrinth.GetLength(1) - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static string[,] labyrinth;
        private static Random rndGenerator;

        static void Main()
        {
            const int rowsCount = 100;
            const int colsCount = 100;

            rndGenerator = new Random();

            labyrinth = new string[rowsCount, colsCount];
            InitializeLabyrinth(rowsCount, colsCount);

            int startingRow = 10;
            int startingCol = 0;

            SetExitInLabyrinth(15, 28);

            //PrintLabyrinth();

            // V -> from visited
            FindAllPaths(startingRow, startingCol, 'V');
        }
    }
}

