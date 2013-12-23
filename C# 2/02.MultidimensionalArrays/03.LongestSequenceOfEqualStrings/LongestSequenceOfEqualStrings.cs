using System;
//We are given a matrix of strings of size N x M.
//Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal.
//Write a program that finds the longest sequence of equal strings in the matrix. 
class LongestSequenceOfEqualStrings
{
    static void Main()
    {
        Console.Write("Enter number of rows: ");
        int numOfRows = int.Parse(Console.ReadLine());

        Console.Write("Enter number of cols: ");
        int numOfCols = int.Parse(Console.ReadLine());

        string[,] matrix = new string[numOfRows, numOfCols];

        for (int row = 0; row < numOfRows; row++)
        {
            for (int col = 0; col < numOfCols; col++)
            {
                Console.Write("matrix[{0}, {1}] = ", row, col);
                matrix[row, col] = Console.ReadLine();
            }
        }

        int verticalIndex = 0;
        int horizontalIndex = 1;
        int rightDiagonalIndex = 2;
        int leftDiagonalIndex = 3;

        int maxLength = 0;
        int bestRow = 0;
        int bestCol = 0;

        //for each cell we store value for vertical, horizontal, right and left diagonal length sequence
        int[, ,] cellsMaxSequenceLength = new int[numOfRows, numOfCols, 4];

        for (int row = 0; row < numOfRows; row++)
        {
            for (int col = 0; col < numOfCols; col++)
            {
                //on each new iteration of the loop cellsMaxSequenceLength[row, col, index] = 1;
                //each sequence starts with element so our starting values are equal to 1
                for (int index = 0; index < 4; index++)
                {
                    cellsMaxSequenceLength[row, col, index] = 1;
                }

                //check vertical
                if (row > 0 && matrix[row, col].CompareTo(matrix[row - 1, col]) == 0)
                {
                    //current cell value is the previous cell value + 1
                    cellsMaxSequenceLength[row, col, verticalIndex] = cellsMaxSequenceLength[row - 1, col, verticalIndex] + 1;
                }

                //check horizontal
                if (col > 0 && matrix[row, col].CompareTo(matrix[row, col - 1]) == 0)
                {
                    //current cell value is the previous cell value + 1
                    cellsMaxSequenceLength[row, col, horizontalIndex] = cellsMaxSequenceLength[row, col - 1, horizontalIndex] + 1;
                }

                //check right diagonal
                if (row > 0 && col > 0 && matrix[row, col].CompareTo(matrix[row - 1, col - 1]) == 0)
                {
                    //current cell value is the previous cell value + 1
                    cellsMaxSequenceLength[row, col, rightDiagonalIndex] = cellsMaxSequenceLength[row - 1, col - 1, rightDiagonalIndex] + 1;
                }

                //check left diagonal
                if (row > 0 && col < numOfCols - 1 && matrix[row, col].CompareTo(matrix[row - 1, col + 1]) == 0)
                {
                    //current cell value is the previous cell value + 1
                    cellsMaxSequenceLength[row, col, leftDiagonalIndex] = cellsMaxSequenceLength[row - 1, col + 1, leftDiagonalIndex] + 1;
                }

                for (int index = 0; index < 4; index++)
                {
                    if (cellsMaxSequenceLength[row, col, index] > maxLength)
                    {
                        maxLength = cellsMaxSequenceLength[row, col, index];
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }
        }

        Console.WriteLine("The length of the longest sequence is: {0}", maxLength);
        Console.WriteLine("String value is: {0}", matrix[bestRow, bestCol]);
    }
}

