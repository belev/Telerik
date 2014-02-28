using System;
using System.Numerics;

class Tubes
{
    static void Main()
    {
        long n = int.Parse(Console.ReadLine());
        long m = long.Parse(Console.ReadLine());

        long[] tubeSizes = new long[n];
        long maxTube = 0;

        for (int i = 0; i < n; i++)
        {
            tubeSizes[i] = int.Parse(Console.ReadLine());

            if (maxTube < tubeSizes[i])
            {
                maxTube = tubeSizes[i];
            }
        }

        long left = 1;
        long right = maxTube;

        long middle = (left + right) / 2;

        long result = -1;

        while (left <= right)
        {
            long tmpNumberOfTubes = 0;

            for (int i = 0; i < n; i++)
            {
                tmpNumberOfTubes += tubeSizes[i] / middle;
            }

            if (tmpNumberOfTubes < m)
            {
                right = middle - 1;
            }
            else if (tmpNumberOfTubes >= m)
            {
                left = middle + 1;
                result = middle;
            }

            middle = (left + right) / 2;
        }

        Console.WriteLine(result);
    }
}

