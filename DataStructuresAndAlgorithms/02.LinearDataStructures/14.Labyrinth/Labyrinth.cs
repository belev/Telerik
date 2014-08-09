namespace _14.Labyrinth
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public static class MatrixExtensionMethod
    {
        public static string GetStartPositionAsString(this int[,] matrix, int value)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == value)
                    {
                        return (row + " " + col);
                    }
                }
            }

            return null;
        }
    }

    public class Labyrinth
    {
        private static bool IsValidCell(int row, int col)
        {
            return (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1));
        }

        private static void Solve(int row, int col, int level)
        {
            // the current position is out of the labyrinth
            if (!IsValidCell(row, col))
            {
                return;
            }

            // the cell is not empty
            if (matrix[row, col] == -2)
            {
                return;
            }

            // if cell is already visited and the current level is bigger than the value in the cell
            if (matrix[row, col] > 0 && matrix[row, col] < level)
            {
                return;
            }

            if (matrix[row, col] != -1)
            {
                matrix[row, col] = level;
            }

            Solve(row - 1, col, level + 1);
            Solve(row + 1, col, level + 1);
            Solve(row, col - 1, level + 1);
            Solve(row, col + 1, level + 1);
        }

        private static string[] GetProperOutput()
        {
            string[] result = new string[matrix.GetLength(0)];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    if (matrix[row, col] == -2)
                    {
                        result[row] += "X";
                    }
                    else if (matrix[row, col] == -1)
                    {
                        result[row] += "*";
                    }
                    else if (matrix[row, col] == 0)
                    {
                        result[row] += "U";
                    }
                    else
                    {
                        result[row] += matrix[row, col];
                    }

                    if (col != matrix.GetLength(1) - 1)
                    {
                        result[row] += " ";
                    }
                }
            }

            return result;
        }

        // 0 -> empty cell
        // -1 -> starting position
        // -2 -> full cell
        public static int[,] matrix = 
            {
                { 0, 0, 0, -2, 0, -2 },
                { 0, -2, 0, -2, 0, -2 },
                { 0, -1, -2, 0, -2, 0 },
                { 0, -2, 0, 0, 0, 0 },
                { 0, 0, 0, -2, -2, 0 },
                { 0, 0, 0, -2, 0, -2 }
            };

        private const int StartPositionValue = -1;

        static void Main()
        {
            string startPositionAsString = matrix.GetStartPositionAsString(StartPositionValue);

            var rawStartPosition = startPositionAsString.Split(' ');

            int startPosRow = int.Parse(rawStartPosition[0]);
            int startPosCol = int.Parse(rawStartPosition[1]);

            Solve(startPosRow, startPosCol, 0);

            string[] result = GetProperOutput();

            foreach (var line in result)
            {
                Console.WriteLine(line);
            }
        }
    }
}
