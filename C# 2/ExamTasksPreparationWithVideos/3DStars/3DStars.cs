using System;
using System.Collections.Generic;

class Stars
{
    private static bool isStar(int width, int height, int depth)
    {
        bool isStar = true;
        char color = cube[width, height, depth];

        for (int i = 0; i < 6; i++)
        {
            bool isValid = isValidCell(width + deltaW[i], height + deltaH[i], depth + deltaD[i]);
            if (isValid == false)
            {
                isStar = false;
                break;
            }

            char colorInCurrentCell = GetStarColor(width + deltaW[i], height + deltaH[i], depth + deltaD[i]);

            if(color != colorInCurrentCell)
            {
                isStar = false;
                break;
            }
        }
        return isStar;
    }

    private static char GetStarColor(int width, int height, int depth)
    {
        return cube[width, height, depth];
    }

    private static void FindAllStars(char[, ,] cube)
    {
        int countStars = 0;
        int[] starsColors = new int[26];

        for (int width = 1; width < w; width++)
        {
            for (int height = 1; height < h; height++)
            {
                for (int depth = 1; depth < d; depth++)
                {
                    if (isStar(width, height, depth))
                    {
                        countStars++;
                        char color = GetStarColor(width, height, depth);

                        (starsColors[color - 'A'])++;
                    }
                }
            }
        }

        Console.WriteLine(countStars);
        for (int i = 0; i < 26; i++)
        {
            if (starsColors[i] != 0)
            {
                Console.WriteLine("{0} {1}", (char)(i + 'A'), starsColors[i]);
            }
        }

    }
    private static bool isValidCell(int width, int height, int depth)
    {
        if (width >= w || height >= h || depth >= d || width < 0 || height < 0 || depth < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private static void ReadInput()
    {
        string[] rawNumbers = Console.ReadLine().Split(' ');

        w = int.Parse(rawNumbers[0]);
        h = int.Parse(rawNumbers[1]);
        d = int.Parse(rawNumbers[2]);

        cube = new char[w, h, d];

        for (int height = 0; height < h; height++)
        {
            string[] input = Console.ReadLine().Split(' ');

            for (int depth = 0; depth < d; depth++)
            {
                string partFromInput = input[depth];

                for (int width = 0; width < w; width++)
                {
                    char symbol = partFromInput[width];

                    cube[width, height, depth] = symbol;
                }
            }
        }
    }

    private static int w;
    private static int h;
    private static int d;

    public static char[, ,] cube;

    private static int[] deltaW = { 0, 0, 0, 0, -1, 1 };
    private static int[] deltaH = { -1, 1, 0, 0, 0, 0 };
    private static int[] deltaD = { 0, 0, -1, 1, 0, 0 };

    static void Main()
    {
        ReadInput();
        FindAllStars(cube);
    }
}
