using System;
using System.Collections.Generic;

public class ColoredBunnies
{
    static void Main()
    {
        var bunnies = new Dictionary<int, int>();

        int numberOfBunnies = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfBunnies; i++)
        {
            int bunniesWithSameColorCount = int.Parse(Console.ReadLine());

            if (bunnies.ContainsKey(bunniesWithSameColorCount))
            {
                bunnies[bunniesWithSameColorCount]++;
            }
            else
            {
                bunnies.Add(bunniesWithSameColorCount, 1);
            }
        }

        int result = 0;

        foreach (var pair in bunnies)
        {
            int coloredBunniesGroupsCount = 1;

            if (pair.Value / (pair.Key + 1) > 0)
            {
                coloredBunniesGroupsCount = pair.Value / (pair.Key + 1);

                if (pair.Value % (pair.Key + 1) != 0)
                {
                    coloredBunniesGroupsCount++;
                }
            }

            result += (pair.Key + 1) * coloredBunniesGroupsCount;
        }

        Console.WriteLine(result);
    }
}

