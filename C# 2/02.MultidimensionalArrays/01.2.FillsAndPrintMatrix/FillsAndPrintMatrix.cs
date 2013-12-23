using System;
class FillsAndPrintMatrix
{
    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
    static void Main()
    {
        Console.Write("Enter n = ");

        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        int numberToAdd = 1;

        for (int col = 0; col < n; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = numberToAdd;

                    numberToAdd++;
                }
            }
            else
            {
                for (int row = n - 1; row >= 0; row--)
                {
                    matrix[row, col] = numberToAdd;

                    numberToAdd++;
                }
            }
        }
        PrintMatrix(matrix);
    }
}

