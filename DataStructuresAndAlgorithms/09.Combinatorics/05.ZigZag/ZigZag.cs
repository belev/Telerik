using System;

public class ZigZagNumbersCounter
{
    private static int n;
    private static int k;
    private static bool[] used;
    private static int zigZagSequencesCount;

    static void Main()
    {
        var args = Console.ReadLine().Split(' ');
        n = int.Parse(args[0]);
        k = int.Parse(args[1]);

        zigZagSequencesCount = 0;
        used = new bool[n];

        int[] sequence = new int[k];

        PutBigger(sequence, 0, -1);

        Console.WriteLine(zigZagSequencesCount);
    }

    private static void PutBigger(int[] sequence, int index, int current)
    {
        if (index == k)
        {
            zigZagSequencesCount++;
            return;
        }

        // we have come to the biggest available number to put so return
        if (current == n - 1)
        {
            return;
        }

        for (int i = current + 1; i < n; i++)
        {
            if (!used[i])
            {
                used[i] = true;
                sequence[index] = i;
                PutSmaller(sequence, index + 1, i);
                used[i] = false;
            }
        }
    }

    private static void PutSmaller(int[] sequence, int index, int current)
    {
        if (index == k)
        {
            zigZagSequencesCount++;
            return;
        }

        // we have come to the smallest available number to put so return
        if (current == 0)
        {
            return;
        }

        for (int i = current - 1; i >= 0; i--)
        {
            if (!used[i])
            {
                used[i] = true;
                sequence[index] = i;
                PutBigger(sequence, index + 1, i);
                used[i] = false;
            }
        }
    }
}
