namespace _12.EightQueensProblem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EightQueensProblem
    {
        public const int BoardSize = 8;

        private static StringBuilder solutionToAdd;
        private static List<string> solutions;

        private static int[,] board;

        static void Main()
        {
            board = new int[BoardSize, BoardSize];
            solutionToAdd = new StringBuilder();
            solutions = new List<string>();

            PlaceQueen(0);
            Console.WriteLine(solutions.Count);

            Console.WriteLine(solutions[2]);
            Console.WriteLine(solutions[3]);
        }

        private static void PlaceQueen(int row)
        {
            if (row == BoardSize)
            {
                AddToAllSolutions();
                return;
            }

            for (int col = 0; col < BoardSize; col++)
            {
                if (board[row, col] == 0)
                {
                    MarkPositions(row, col, 1);

                    PlaceQueen(row + 1);

                    MarkPositions(row, col, -1);
                }
            }

        }

        private static void MarkPositions(int row, int col, int mark)
        {
            for (int i = 0; i < BoardSize; i++)
            {
                board[row, i] += mark;
                board[i, col] += mark;
            }

            board[row, col] -= mark;

            for (int i = 1; i < BoardSize; i++)
            {
                if (row + i < BoardSize && col + i < BoardSize)
                {
                    board[row + i, col + i] += mark;
                }

                if (row - i >= 0 && col - i >= 0)
                {
                    board[row - i, col - i] += mark;
                }

                if (row - i >= 0 && col + i < BoardSize)
                {
                    board[row - i, col + i] += mark;
                }

                if (row + i < BoardSize && col - i >= 0)
                {
                    board[row + i, col - i] += mark;
                }
            }
        }

        private static void AddToAllSolutions()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    solutionToAdd.Append(board[i, j] == 1 ? "|Q" : "| ");
                }
                solutionToAdd.AppendLine("|");
            }

            solutions.Add(solutionToAdd.ToString());
            solutionToAdd.Clear();
        }
    }
}
