using System;
using System.Collections.Generic;
//* Write a program that reads an array of integers and removes from it a minimal number of elements in such way
//that the remaining array is sorted in increasing order.
//Print the remaining sorted array. Example: {6, 1, 4, 3, 0, 3, 6, 4, 5} --> {1, 3, 3, 4, 5}

class SortedArrayAfterRemovingElements
{
    private static bool IsSorted(List<int> list)
    {
        bool isSorted = true;

        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i] > list[i + 1])
            {
                isSorted = false;
                break;
            }
        }
        return isSorted;
    }

    static void Main()
    {
        Console.Write("Enter the length of the sequence: ");
        int length = int.Parse(Console.ReadLine());

        int[] sequence = new int[length];

        for (int i = 0; i < length; i++)
        {
            Console.Write("sequence[{0}] = ", i);
            sequence[i] = int.Parse(Console.ReadLine());
        }

        List<int> increasingSequence = new List<int>();

        for (int i = 1; i < (1 << length); i++)
        {
            List<int> currentSequence = new List<int>();

            for (int j = 0; j < length; j++)
            {
                //logic from the subset sum problem
                if (((i >> j) & 1) == 1)
                {
                    currentSequence.Add(sequence[j]);
                }
            }

            if (IsSorted(currentSequence))
            {
                if (currentSequence.Count > increasingSequence.Count)
                {
                    increasingSequence = new List<int>(currentSequence);
                }
            }
        }

        string result = string.Join(", ", increasingSequence);
        Console.WriteLine("The longest increasing sequence after removing is: {0}", result);
    }
}

