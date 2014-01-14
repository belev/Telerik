using System;
using System.IO;

class MaximalSquareSum
{
    static int CalculateMaxSquareSum(int[,] matrix)
    {
        int numberOfRows = matrix.GetLength(0);
        int numberOfCols = matrix.GetLength(1);
        int maxSum = int.MinValue;

        int currentRow = 0;
        int currentCol = 0;

        while (currentRow + 1 < numberOfRows)
        {
            while (currentCol + 1 < numberOfCols)
            {
                int currentSum = 0;

                for (int i = currentRow; i <= currentRow + 1; i++)
                {
                    for (int j = currentCol; j <= currentCol + 1; j++)
                    {
                        currentSum += matrix[i, j];
                    }
                }

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
                currentCol++;
            }

            currentCol = 0;
            currentRow++;

        }

        return maxSum;
    }

    static void Main()
    {
        using (StreamReader reader = new StreamReader("Text.txt"))
        {
            int n = int.Parse(reader.ReadLine());

            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                string[] line = reader.ReadLine().Split(' ');

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(line[j]);
                }
            }

            using (StreamWriter writeResult = new StreamWriter("Result.txt"))
            {
                writeResult.WriteLine(CalculateMaxSquareSum(matrix));
            }
        }

    }
}

