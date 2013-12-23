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
    //check if our cell is valid for our matrix
    private static bool IsValid(int row, int col, int size)
    {
        return (row >= 0 && row < size && col >= 0 && col < size);
    }

    //check is the cell is empty
    private static bool IsEmpty(int row, int col, int[,] matrix)
    {
        return (matrix[row, col] == 0);
    }
    static void Main()
    {
        Console.Write("Enter n = ");

        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        int numberToAdd = 1;

        //directions -> (1, 0) -> down, (0, 1) -> right, (-1, 0) -> up, (0, -1) -> left
        //dirX is direction for rows
        int[] dirX = { 1, 0, -1, 0 };
        // dirY is direction for cols
        int[] dirY = { 0, 1, 0, -1 };

        //direction index, to now which position we are moving to
        // dirIndex = 0 for down, dirIndex = 1 for right, dirIndex = 2 for up, dirIndex = 3 for left
        int dirIndex = 0;
        int currentRow = 0;
        int currentCol = 0;

        while (true)
        {
            bool isValid = true;
            bool isEmpty = true;

            while (isValid || isEmpty)
            {
                matrix[currentRow, currentCol] = numberToAdd;
                numberToAdd++;

                if (IsValid(currentRow + dirX[dirIndex], currentCol + dirY[dirIndex], n) == false)
                {
                    isValid = false;
                    break;
                }

                if (IsEmpty(currentRow + dirX[dirIndex], currentCol + dirY[dirIndex], matrix) == false)
                {
                    isEmpty = false;
                    break;
                }
                //move in the current direction
                currentRow += dirX[dirIndex];
                currentCol += dirY[dirIndex];
            }

            //for debugging
            //PrintMatrix(matrix);
            //Console.WriteLine("------");

            if (isValid == false || isEmpty == false)
            {
                //increase dirIndex
                dirIndex++;
                //and take its remainder by 4, so we can get available direction index from 0 to 3 inclusive
                dirIndex %= 4;

                //change currentRow and currentCol to the new direction
                currentRow += dirX[dirIndex];
                currentCol += dirY[dirIndex];
            }
            //if numberToAdd == n * n + 1 it means that we already add the number equal to n * n, so we break the loop
            if (numberToAdd == n * n + 1)
            {
                break;
            }
        }

        PrintMatrix(matrix);
    }
}

