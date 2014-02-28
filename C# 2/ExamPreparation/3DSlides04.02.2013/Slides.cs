using System;
class Slides
{
    static int width;
    static int height;
    static int depth;
    static int ballW;
    static int ballD;
    static int ballH;
    static string[, ,] cuboid;
    //is it is wrong, change front and back values
    //                  L, R, F, B, FL, FR, BL, BR
    static int[] dW = { -1, 1, 0, 0, -1, 1, -1, 1 };
    static int[] dH = { 1, 1, 1, 1, 1, 1, 1, 1 };
    static int[] dD = { 0, 0, -1, 1, -1, -1, 1, 1 };
    private static void ReadCuboid()
    {
        string[] rawDimentions = Console.ReadLine().Split(' ');

        width = int.Parse(rawDimentions[0]);
        height = int.Parse(rawDimentions[1]);
        depth = int.Parse(rawDimentions[2]);

        cuboid = new string[width, height, depth];

        for (int h = 0; h < height; h++)
        {
            string line = Console.ReadLine();
            string[] rawLine = line.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

            for (int d = 0; d < depth; d++)
            {
                string[] cubeInfo = rawLine[d].Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < width; w++)
                {
                    cuboid[w, h, d] = cubeInfo[w];
                }
            }
        }
        string[] rawBallPosition = Console.ReadLine().Split(' ');
        ballW = int.Parse(rawBallPosition[0]);
        ballD = int.Parse(rawBallPosition[1]);
        ballH = 0;
    }
    private static bool IsExit(int w, int h, int d)
    {
        return (h == cuboid.GetLength(1) && w >= 0 && d >= 0 && w < cuboid.GetLength(0) && d < cuboid.GetLength(2));
    }
    private static void PrintResult(bool isExit)
    {
        if (isExit)
        {
            Console.WriteLine("Yes");
            Console.WriteLine("{0} {1} {2}", ballW, ballH, ballD);
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine("{0} {1} {2}", ballW, ballH, ballD);
        }
    }
    private static int GetDirectionIndex(string direction)
    {
        int index = -1;

        switch (direction)
        {
            case "L":
                index = 0;
                break;
            case "R":
                index = 1;
                break;
            case "F":
                index = 2;
                break;
            case "B":
                index = 3;
                break;
            case "FL":
                index = 4;
                break;
            case "FR":
                index = 5;
                break;
            case "BL":
                index = 6;
                break;
            case "BR":
                index = 7;
                break;
        }

        return index;
    }
    private static bool CanSlide(int w, int h, int d)
    {
        return w >= 0 && w < cuboid.GetLength(0) && h >= 0 && h < cuboid.GetLength(1) && d >= 0 && d < cuboid.GetLength(2);
    }
    static void Main()
    {
        ReadCuboid();

        while (true)
        {
            char operation = cuboid[ballW, ballH, ballD][0];
            if (operation == 'S')
            {
                string direction = cuboid[ballW, ballH, ballD].Substring(2);

                int dirIndex = GetDirectionIndex(direction);

                if (ballH == cuboid.GetLength(1) - 1)
                {
                    PrintResult(true);
                    break;
                }

                if (CanSlide(ballW + dW[dirIndex], ballH + dH[dirIndex], ballD + dD[dirIndex]))
                {
                    ballW += dW[dirIndex];
                    ballH += dH[dirIndex];
                    ballD += dD[dirIndex];
                    continue;
                }
                else
                {
                    PrintResult(false);
                    break;
                }
            }

            else if (operation == 'T')
            {
                string[] rawTeleportPosition = cuboid[ballW, ballH, ballD].Split(' ');
                ballW = int.Parse(rawTeleportPosition[1]);
                ballD = int.Parse(rawTeleportPosition[2]);
                continue;
            }

            else if (operation == 'E')
            {
                if (IsExit(ballW, ballH + 1, ballD))
                {
                    PrintResult(true);
                    break;
                }
                else
                {
                    ballH++;
                    continue;
                }
            }

            else if (operation == 'B')
            {
                PrintResult(false);
                break;
            }

        }
    }
}

