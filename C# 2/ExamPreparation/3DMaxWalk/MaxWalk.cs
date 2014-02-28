using System;
class Position
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int Depth { get; set; }
    public Position(int w, int h, int d)
    {
        this.Width = w;
        this.Height = h;
        this.Depth = d;
    }
    public Position()
    {
        this.Width = -1;
        this.Height = -1;
        this.Depth = -1;
    }
}
class MaxWalk
{
    static int width;
    static int height;
    static int depth;
    static int[, ,] cuboid;
    static bool[, ,] visited;
    //left right deeper shallower down up
    static int[] dW = { -1, 1, 0, 0, 0, 0 };
    static int[] dH = { 0, 0, 0, 0, -1, 1 };
    static int[] dD = { 0, 0, 1, -1, 0, 0 };
    private static void ReadCuboid()
    {
        string[] rawDimentions = Console.ReadLine().Split(' ');

        width = int.Parse(rawDimentions[0]);
        height = int.Parse(rawDimentions[1]);
        depth = int.Parse(rawDimentions[2]);

        cuboid = new int[width, height, depth];
        visited = new bool[width, height, depth];

        for (int h = 0; h < height; h++)
        {
            string line = Console.ReadLine();
            string[] rawLine = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            for (int d = 0; d < depth; d++)
            {
                string[] numbersAsString = rawLine[d].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < width; w++)
                {
                    cuboid[w, h, d] = int.Parse(numbersAsString[w]);
                }
            }
        }
    }
    private static bool IsValidCell(int w, int h, int d)
    {
        return (w >= 0 && h >= 0 && d >= 0 && w < width && h < height && d < depth);
    }
    private static Position FindCubeMaxValuePosition(Position curPos)
    {
        Position cubePos = new Position();
        int maxValue = -1001;
        int count = 0;

        for (int i = 0; i < 6; i++)
        {
            Position newPos = new Position(curPos.Width + dW[i], curPos.Height + dH[i], curPos.Depth + dD[i]);
            //check all cell in the six possible positions
            while (IsValidCell(newPos.Width, newPos.Height, newPos.Depth))
            {
                int value = cuboid[newPos.Width, newPos.Height, newPos.Depth];

                if (maxValue == value)
                {
                    count++;
                }

                if (value > maxValue)
                {
                    maxValue = value;
                    cubePos.Width = newPos.Width;
                    cubePos.Height = newPos.Height;
                    cubePos.Depth = newPos.Depth;
                    count = 1;
                }

                if (!IsValidCell(newPos.Width + dW[i], newPos.Height + dH[i], newPos.Depth + dD[i]))
                {
                    break;
                }

                newPos.Width += dW[i];
                newPos.Height += dH[i];
                newPos.Depth += dD[i];
            }
        }
        //if count > 1 , it means there is more than one cell with max value, then return new Position()
        if ((cubePos.Width == -1 && cubePos.Height == -1 && cubePos.Depth == -1) || count > 1)
        {
            return new Position();
        }

        if (cubePos.Width != -1 && cubePos.Height != -1 && cubePos.Depth != -1)
        {
            //if is visited return new Position()
            if (visited[cubePos.Width, cubePos.Height, cubePos.Depth])
            {
                return new Position();
            }
        }
        return cubePos;
    }
    static void Main()
    {
        ReadCuboid();
        Position pos = new Position(width / 2, height / 2, depth / 2);
        visited[pos.Width, pos.Height, pos.Depth] = true;

        long result = 0;
        result += cuboid[pos.Width, pos.Height, pos.Depth];

        while (true)
        {
            pos = FindCubeMaxValuePosition(pos);

            if (pos.Width == -1 && pos.Height == -1 && pos.Depth == -1)
            {
                Console.WriteLine(result);
                break;
            }
            else
            {
                visited[pos.Width, pos.Height, pos.Depth] = true;
                result += cuboid[pos.Width, pos.Height, pos.Depth];
            }
        }
    }
}