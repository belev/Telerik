using System;
//* Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size. 
class LargestEqualNeighboursArea
{
    //positions for neighbours of current cell
    static int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
    static int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };
    private static int GetLengthOfArea(int row, int col, int element)
    {
        int count = 0;

        if (IsValid(row, col, n, m) == false)
        {
            return count;
        }
        else
        {
            if (matrix[row, col] == element)
            {
                count++;
                visited[row, col] = true;

                for (int i = 0; i < 8; i++)
                {
                    //go through all neighbours of the current cell
                    count += GetLengthOfArea(row + dx[i], col + dy[i], element);
                }
            }
        }

        return count;
    }
    private static bool IsValid(int row, int col, int n, int m)
    {
        return (row >= 0 && col >= 0 && row < n && col < m && visited[row, col] == false);
    }

    static bool[,] visited;
    static int[,] matrix;

    static int n;
    static int m;
    static void Main()
    {
        //matrix = new int[,]
        //                   {{1, 3, 2, 2, 2, 4},
        //                    {3, 3, 3, 2, 4, 4},
        //                    {4, 3, 1, 2, 3, 3},
        //                    {4, 3, 1, 3, 3, 1},
        //                    {4, 3, 3, 3, 1, 1}};
        //n = matrix.GetLength(0);
        //m = matrix.GetLength(1);

        Console.Write("Enter number of rows: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter number of cols: ");
        int m = int.Parse(Console.ReadLine());

        matrix = new int[n, m];
        visited = new bool[n, m];

        int maxLength = 0;

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                int tmpLength = GetLengthOfArea(row, col, matrix[row, col]);

                if (tmpLength > maxLength)
                {
                    maxLength = tmpLength;
                }
            }
        }
        Console.WriteLine(maxLength);
    }
}

