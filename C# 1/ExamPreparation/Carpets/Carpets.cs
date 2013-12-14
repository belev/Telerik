using System;

class Carpets
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        int startSlash = n / 2 - 1;
        int endSlash = n / 2 - 1;

        bool isSlash = true;

        for (int row = 0; row < n / 2; row++)
        {
            for (int col = 0; col < n / 2; col++)
            {
                if (startSlash <= col && col <= endSlash)
                {
                    if (isSlash)
                    {
                        //left top
                        matrix[row, col] = 2;

                        //right top
                        matrix[row, n - col - 1] = 3;

                        //left bottom
                        matrix[n - 1 - row, col] = 3;

                        //right bottom
                        matrix[n - 1 - row, n - 1 - col] = 2;


                        isSlash = false;
                    }
                    else
                    {
                        matrix[row, col] = 1;
                        matrix[row, n - col - 1] = 1;
                        matrix[n - 1 - row, col] = 1;
                        matrix[n - 1 - row, n - 1 - col] = 1;

                        isSlash = true;
                    }
                }
            }
            isSlash = true;
            startSlash--;
        }

        //printing
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] == 0)
                {
                    Console.Write('.');
                }
                else if (matrix[i, j] == 1)
                {
                    Console.Write(' ');
                }
                else if (matrix[i, j] == 2)
                {
                    Console.Write('/');
                }
                else if (matrix[i, j] == 3)
                {
                    Console.Write('\\');
                }
            }
            Console.WriteLine();
        }
    }
}

