using System;
using System.Collections.Generic;
using System.Text;
class BombingCuboids
{
    public static int width;
    public static int height;
    public static int depth;

    public static char[, ,] cube;

    public static int[] countDestroyedColors;
    public static int countAllDestroyed;
    static void Main()
    {
        countDestroyedColors = new int[26];
        ReadInputOfCube();

        int numberOfExplosions = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfExplosions; i++)
        {
            string[] rawBombInfo = Console.ReadLine().Split(' ');
            int bWidth = int.Parse(rawBombInfo[0]);
            int bHeight = int.Parse(rawBombInfo[1]);
            int bDepth = int.Parse(rawBombInfo[2]);
            int bPower = int.Parse(rawBombInfo[3]);

            ProcessBombExplosion(bWidth, bHeight, bDepth, bPower);
        }

        Console.WriteLine(countAllDestroyed);

        for (int i = 0; i < countDestroyedColors.Length; i++)
        {
            if (countDestroyedColors[i] == 0)
            {
                continue;
            }

            char color = (char) (i + 65);

            Console.WriteLine("{0} {1}", color, countDestroyedColors[i]);
        }
    }
    private static void ProcessBombExplosion(int bWidth, int bHeight, int bDepth, int bPower)
    {
        TakeColorsOfDestroyedCells(bWidth, bHeight, bDepth, bPower);

        for (int w = 0; w < width; w++)
        {
            for (int d = 0; d < depth; d++)
            {
                FallDown(w, d);
            }
        }
    }
    private static void FallDown(int w, int d)
    {
        int bottom = 0;
        for (int h = 0; h < height; h++)
        {
            char curChar = cube[w, h, d];

            if (curChar != '\0')
            {
                char tmp = cube[w, h, d];
                cube[w, h, d] = cube[w, bottom, d];
                cube[w, bottom, d] = tmp;
                bottom++;
            }
        }
    }

    private static double CalcEuclidianDistance3D(
            int w1, int h1, int d1, int w2, int h2, int d2)
    {
        double distance = Math.Sqrt(
            (w1 - w2) * (w1 - w2) +
            (h1 - h2) * (h1 - h2) +
            (d1 - d2) * (d1 - d2));
        return distance;
    }
    private static void TakeColorsOfDestroyedCells(int bWidth, int bHeight, int bDepth, int bPower)
    {
        int index = -1;

        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                for (int d = 0; d < depth; d++)
                {
                    double distance = CalcEuclidianDistance3D(w, h, d, bWidth, bHeight, bDepth);

                    if (distance <= bPower)
                    {
                        char curColor = cube[w, h, d];

                        if (curColor != '\0')
                        {
                            //swap values
                            index = cube[w, h, d] - 'A';
                            countDestroyedColors[index]++;
                            countAllDestroyed++;
                        }
                        cube[w, h, d] = '\0';
                    }

                }
            }
        }
    }

    private static void ReadInputOfCube()
    {
        string[] rawSizes = Console.ReadLine().Split(' ');
        width = int.Parse(rawSizes[0]);
        height = int.Parse(rawSizes[1]);
        depth = int.Parse(rawSizes[2]);

        cube = new char[width, height, depth];

        for (int h = 0; h < height; h++)
        {
            string[] rawColors = Console.ReadLine().Split(' ');

            for (int d = 0; d < depth; d++)
            {
                string colorsOnLine = rawColors[d];

                for (int w = 0; w < width; w++)
                {
                    cube[w, h, d] = colorsOnLine[w];
                }
            }
        }
    }
}

