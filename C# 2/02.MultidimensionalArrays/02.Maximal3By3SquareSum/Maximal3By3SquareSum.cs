using System;
//Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

class Maximal3By3SquareSum
{
    private static void FindSquareWithMaximalSum(int[,] rectangularMatrix)
    {
        int squareSize = 3;

        int rectLength = rectangularMatrix.GetLength(0);
        int rectWidth = rectangularMatrix.GetLength(1);
        int bestStartRow = 0;
        int bestStartCol = 0;
        int maxSum = 0;
        //to find the maximal sum of square 3 by 3
        for (int row = 0; row < rectLength - squareSize + 1; row++)
        {
            int tmpSum = 0;
            for (int col = 0; col < rectWidth - squareSize + 1; col++)
            {
                tmpSum = FindSquareSum(row, col, squareSize, rectangularMatrix);

                //if tmpSum is bigger
                if (tmpSum > maxSum)
                {
                    //change maxSum, bestStartRow, bestStartCol values
                    maxSum = tmpSum;
                    bestStartRow = row;
                    bestStartCol = col;
                }
            }
        }

        //print square
        for (int row = bestStartRow; row < bestStartRow + squareSize; row++)
        {
            for (int col = bestStartCol; col < bestStartCol + squareSize; col++)
            {
                Console.Write(rectangularMatrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
    private static int FindSquareSum(int startRow, int startCol, int squareSize, int[,] rectangularMatrix)
    {
        int sum = 0;

        for (int row = startRow; row < startRow + squareSize; row++)
        {
            for (int col = startCol; col < startCol + squareSize; col++)
            {
                sum += rectangularMatrix[row, col];
            }
        }

        return sum;
    }
    static void Main()
    {
        Console.Write("Enter number of rows: ");
        int numberOfRows = int.Parse(Console.ReadLine());

        Console.Write("Enter number of cols: ");
        int numberOfCols = int.Parse(Console.ReadLine());

        int[,] rectangle = new int[numberOfRows, numberOfCols];

        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfCols; col++)
            {
                Console.Write("rectangle[{0}, {1}] = ",row, col);
                rectangle[row, col] = int.Parse(Console.ReadLine());
            }
        }

        FindSquareWithMaximalSum(rectangle);
    }
}

