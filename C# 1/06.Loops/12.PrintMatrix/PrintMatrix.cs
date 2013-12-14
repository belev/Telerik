using System;

class PrintMatrix
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];


        for (int row = 0; row < n; row++)
        {
            int numberToAdd = row + 1;

            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = numberToAdd;

                numberToAdd++;
            }
        }


        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}

