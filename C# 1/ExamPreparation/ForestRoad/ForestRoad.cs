using System;

class ForestRoad
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[2 * n - 1, n];

        int curCol = 0;
        bool hasFallenDown = false;

        for (int i = 0; i < 2 * n - 1; i++)
        {
            matrix[i, curCol] = 1;

            if (hasFallenDown == false)
            {
                curCol++;
            }
            else
            {
                curCol--;
            }

            if (curCol == n - 1)
            {
                hasFallenDown = true;
            }
        }

        for (int i = 0; i < 2 * n - 1; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] == 0)
                {
                    Console.Write('.');
                }
                else if(matrix[i, j] == 1)
                {
                    Console.Write('*');
                }
            }
            Console.WriteLine();
        }
    }
}

