using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Laser
{
    class Vector
    {
        public int Height
        {
            get;
            set;
        }
        public int Width
        {
            get;
            set;
        }
        public int Depth
        {
            get;
            set;
        }
    }
    static bool IsBurnedCell(Vector curPos)
    {
        if (cube[curPos.Width, curPos.Height, curPos.Depth] == 1)
        {
            return true;
        }
        return false;
    }

    static void ReadInput()
    {
        string[] rawNumbers = Console.ReadLine().Split(' ');

        width = int.Parse(rawNumbers[0]);
        height = int.Parse(rawNumbers[1]);
        depth = int.Parse(rawNumbers[2]);

        string[] rawStartPosition = Console.ReadLine().Split(' ');

        int startWidth = int.Parse(rawStartPosition[0]);
        int startHeight = int.Parse(rawStartPosition[1]);
        int startDepth = int.Parse(rawStartPosition[2]);

        curPosition.Width = startWidth;
        curPosition.Height = startHeight;
        curPosition.Depth = startDepth;

        string[] laserInfo = Console.ReadLine().Split(' ');

        laser.Width = int.Parse(laserInfo[0]);
        laser.Height = int.Parse(laserInfo[1]);
        laser.Depth = int.Parse(laserInfo[2]);
    }

    static void MarkBurnedCellsAtStart()
    {
        cube = new int[width + 1, height + 1, depth + 1];

        //mark burn cells
        for (int h = 1; h < height + 1; h++)
        {
            cube[1, h, 1] = 1;
            cube[width, h, 1] = 1;
            cube[1, h, depth] = 1;
            cube[width, h, depth] = 1;
        }

        for (int w = 1; w < width + 1; w++)
        {
            cube[w, 1, 1] = 1;
            cube[w, height, 1] = 1;
            cube[w, 1, depth] = 1;
            cube[w, height, depth] = 1;
        }

        for (int d = 1; d < depth; d++)
        {
            cube[1, 1, d] = 1;
            cube[1, height, d] = 1;
            cube[width, 1, d] = 1;
            cube[width, height, d] = 1;
        }
    }

    private static void StartLaser()
    {
        while (true)
        {
            cube[curPosition.Width, curPosition.Height, curPosition.Depth] = 1;

            Vector nextPos = new Vector();

            nextPos.Width = curPosition.Width + laser.Width;
            nextPos.Height = curPosition.Height + laser.Height;
            nextPos.Depth = curPosition.Depth + laser.Depth;

            if (IsBurnedCell(nextPos))
            {
                Console.WriteLine("{0} {1} {2}", curPosition.Width, curPosition.Height, curPosition.Depth);
                Environment.Exit(0);
            }
            else
            {
                curPosition.Width = nextPos.Width;
                curPosition.Height = nextPos.Height;
                curPosition.Depth = nextPos.Depth;
            }

            //change laser direction
            if (curPosition.Width == 1 || curPosition.Width == width)
            {
                laser.Width *= -1;
            }
            if (curPosition.Height == 1 || curPosition.Height == height)
            {
                laser.Height *= -1;
            }
            if (curPosition.Depth == 1 || curPosition.Depth == depth)
            {
                laser.Depth *= -1;
            }
        }
    }

    static int width;
    static int height;
    static int depth;

    static Vector curPosition = new Vector();
    static Vector laser = new Vector();

    static int[, ,] cube;

    static void Main()
    {
        ReadInput();
        MarkBurnedCellsAtStart();

        StartLaser();
    }
}

