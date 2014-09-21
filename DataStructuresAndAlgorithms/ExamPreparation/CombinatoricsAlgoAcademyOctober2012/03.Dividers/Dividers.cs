using System;
using System.Linq;

public class Dividers
{
    private static int[] digitsSequence;

    private static int minDividorsCount = int.MaxValue;
    private static int bestNumber = int.MaxValue;

    static void Main()
    {
        int numbersCount = int.Parse(Console.ReadLine());

        digitsSequence = new int[numbersCount];

        for (int i = 0; i < numbersCount; i++)
        {
            digitsSequence[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(digitsSequence);

        Permute(0, new bool[numbersCount], new int[numbersCount]);

        Console.WriteLine(bestNumber);
    }

    private static void Permute(int index, bool[] used, int[] permutation)
    {
        if (index >= digitsSequence.Length)
        {
            int numberToAdd = int.Parse(string.Join("", permutation));
            int numberToAddDividersCount = FindDividersCount(numberToAdd);

            if (minDividorsCount > numberToAddDividersCount)
            {
                minDividorsCount = numberToAddDividersCount;
                bestNumber = numberToAdd;
            }
            else if (minDividorsCount == numberToAddDividersCount)
            {
                if (bestNumber > numberToAdd)
                {
                    bestNumber = numberToAdd;
                }
            }
            return;
        }

        for (int i = 0; i < digitsSequence.Length; i++)
        {
            if (used[i])
            {
                continue;
            }

            used[i] = true;
            permutation[index] = digitsSequence[i];

            Permute(index + 1, used, permutation);

            used[i] = false;
        }
    }

    private static int FindDividersCount(int number)
    {
        int count = 0;

        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                count++;
            }
        }

        return count;
    }
}