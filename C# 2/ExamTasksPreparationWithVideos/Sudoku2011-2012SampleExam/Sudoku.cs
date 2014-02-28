using System;
using System.Collections.Generic;
using System.Text;
class Sudoku
{
    static int counter;
    static void SudokuSolver(int row, int col)
    {
        if (row == 9 && col == 0)
        {
            PrintSudoku();
            Environment.Exit(0);
        }

        else if (sudoku[row, col] == 0)
        {
            for (int i = 1; i <= 9; i++)
            {
                if (IsOnRow(row, i) == false && IsOnCol(col, i) == false && IsInSquare(row, col, i) == false)
                {
                    sudoku[row, col] = i;
                    SudokuSolver(NextRow(row, col), NextCol(col));
                    sudoku[row, col] = 0;
                }
            }
        }
        else
        {
            SudokuSolver(NextRow(row, col), NextCol(col));
        }
    }

    private static bool IsInSquare(int row, int col, int number)
    {
        int startRow = (row / 3) * 3;
        int startCol = (col / 3) * 3;

        for (int i = startRow; i < startRow + 3; i++)
        {
            for (int j = startCol; j < startCol + 3; j++)
            {
                if (sudoku[i, j] == number)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private static bool IsOnCol(int col, int number)
    {
        for (int i = 0; i < 9; i++)
        {
            if (sudoku[i, col] == number)
            {
                return true;
            }
        }
        return false;
    }

    private static bool IsOnRow(int row, int number)
    {
        for (int i = 0; i < 9; i++)
        {
            if (sudoku[row, i] == number)
            {
                return true;
            }
        }
        return false;
    }

    static int NextRow(int row, int col)
    {
        col++;

        if (col > 8)
        {
            return row + 1;
        }

        return row;
    }

    static int NextCol(int col)
    {
        col++;

        if (col > 8)
        {
            return 0;
        }
        return col;
    }
    private static void PrintSudoku()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Console.Write(sudoku[i, j]);
            }
            Console.WriteLine();
        }
    }


    static int[,] sudoku = new int[9, 9];

    static void Main()
    {
        for (int i = 0; i < 9; i++)
        {
            string inputLine = Console.ReadLine();

            for (int j = 0; j < 9; j++)
            {
                if (inputLine[j] == '-')
                {
                    sudoku[i, j] = 0;
                }
                else
                {
                    sudoku[i, j] = inputLine[j] - '0';
                }
            }
        }

        SudokuSolver(0, 0);

    }
}
