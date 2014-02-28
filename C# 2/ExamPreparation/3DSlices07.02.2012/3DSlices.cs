using System;
class Slices
{
    static void Main()
    {
        //read input
        string[] rawDimentions = Console.ReadLine().Split(' ');

        int width = int.Parse(rawDimentions[0]);
        int height = int.Parse(rawDimentions[1]);
        int depth = int.Parse(rawDimentions[2]);

        int[, ,] cube = new int[width, height, depth];
        long sumOfAll = 0;
        for (int h = 0; h < height; h++)
        {
            string line = Console.ReadLine();
            string[] rawLine = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            for (int d = 0; d < depth; d++)
            {
                string[] numbersAsString = rawLine[d].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < width; w++)
                {
                    cube[w, h, d] = int.Parse(numbersAsString[w]);

                    sumOfAll += cube[w, h, d];
                }
            }
        }
        int splitsCount = 0;

        long currentSum = 0;
        //split through height
        for (int h = 0; h < height - 1; h++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int d = 0; d < depth; d++)
                {
                    currentSum += cube[w, h, d];
                }
            }

            if (currentSum * 2 == sumOfAll)
            {
                splitsCount++;
            }
        }

        currentSum = 0;
        //split through width
        for (int w = 0; w < width - 1; w++)
        {
            for (int h = 0; h < height; h++)
            {
                for (int d = 0; d < depth; d++)
                {
                    currentSum += cube[w, h, d];
                }
            }

            if (currentSum * 2 == sumOfAll)
            {
                splitsCount++;
            }
        }

        currentSum = 0;
        //split through depth
        for (int d = 0; d < depth - 1; d++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    currentSum += cube[w, h, d];
                }
            }

            if (currentSum * 2 == sumOfAll)
            {
                splitsCount++;
            }
        }

        Console.WriteLine(splitsCount);
    }
}

