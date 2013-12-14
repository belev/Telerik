using System;

//* Write a program that reads a positive integer number N (N < 20) from console and outputs in the console the numbers 1 ... N numbers arranged as a spiral.

class SpiralMatrix
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        int[,] spiralMatrix = new int[n, n];
        
        //for directions right, down, left, up
        int[] dx = {0, 1, 0, -1};
        int[] dy = { 1, 0, -1, 0 };

        int currentRow = 0;
        int currentCol = 0;

        int nextRow;
        int nextCol;

        int numberToAdd = 1;

        int directionIndex = 0; // shows where in dx and dy are in the moment

        while (numberToAdd <= n * n)
        {
            spiralMatrix[currentRow, currentCol] = numberToAdd;
            numberToAdd++;

            nextRow = currentRow + dx[directionIndex];
            nextCol = currentCol + dy[directionIndex];

            //check for changing the direction, is nextRow or nextCol are outside the matrix
            //and our numberToAdd is smaller than the last number which we have to add in the matrix
            if (numberToAdd <= n * n && (nextRow >= n || nextCol >= n || nextRow < 0 || nextCol < 0 || spiralMatrix[nextRow, nextCol] != 0))
            {
                //increase direction index (we change the direction that way)
                directionIndex++;
                //we take directionIndex = directionIndex % 4 because we can have more than 4 changes in the direction
                directionIndex %= 4;

                nextRow = currentRow + dx[directionIndex];
                nextCol = currentCol + dy[directionIndex];
            }

            currentRow = nextRow;
            currentCol = nextCol;
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,3}", spiralMatrix[i, j]);
            }

            Console.WriteLine();
        }
    }
}

