using System;

class TelerikLogo
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int y = x;
        int z = x / 2 + 1;

        int width = 2 * x + 2 * z - 3;
        int height = width;

        int[,] matrix = new int[width, width];

        int curRow = z - 1;
        int curCol = 0;

        bool downRight = false;
        bool upRight = true;

        while (true)
        {
            matrix[curRow, curCol] = 1;
            matrix[curRow, width - curCol - 1] = 1;

            if (upRight)
            {
                curRow--;
                curCol++;

                if (curRow == 0)
                {
                    downRight = true;
                    upRight = false;
                }
            }
            else if (downRight)
            {
                curRow++;
                curCol++;

                if (curRow >= 2 * x - 2)
                {
                    downRight = false;
                    upRight = false;
                }
            }
            else if (upRight == false && downRight == false)
            {
                curRow++;
                curCol--;
            }

            if (curRow == width - 1 && curCol == x + z - 2)
            {
                matrix[curRow, curCol] = 1;
                break;
            }
        }

        //print
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (matrix[i, j] == 0)
                {
                    Console.Write('.');
                }
                else if (matrix[i, j] == 1)
                {
                    Console.Write('*');
                }
            }
            Console.WriteLine();
        }
    }
}

