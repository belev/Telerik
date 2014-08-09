namespace _07.FindPathsBetweenTwoCells
{
    using System;

    public class FindPathsBetweenTwoCells
    {
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
                PrintPath();
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

        private static void PrintPath()
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

        private static string[,] labyrinth = 
        {
            {" ", " ", " ", "*", " ", " ", " "},
            {"*", "*", " ", "*", " ", "*", " "},
            {" ", " ", " ", " ", " ", " ", " "},
            {" ", "*", "*", "*", "*", "*", " "},
            {" ", " ", " ", " ", " ", " ", " "},
        };

        static void Main()
        {
            int startingRow = 0;
            int startingCol = 0;

            SetExitInLabyrinth(4, 3);

            // V -> from visited
            FindAllPaths(startingRow, startingCol, 'V');
        }
    }
}
