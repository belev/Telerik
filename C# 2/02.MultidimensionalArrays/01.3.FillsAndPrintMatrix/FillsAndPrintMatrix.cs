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
        int startRow = n - 1;
        int startCol = 0;

        while (true)
        {
            for (int row = startRow, col = startCol; row < n && col < n; row++, col++)
            {
                matrix[row, col] = numberToAdd;
                numberToAdd++;
            }

            //if startRow > 0 decrease it until it reaches value 0
            if (startRow > 0)
            {
                startRow--;
            }
            else if (startRow == 0) // when startRow == 0 than we increase startCol
            {
                startCol++;
            }

            if (startRow == 0 && startCol == n)
            {
                // after we fill matrix[0, n - 1], the value ot startCol will be increased by 1
                //thats why our check is for startCol == n
                break;
            }
        }

        PrintMatrix(matrix);
    }
}

