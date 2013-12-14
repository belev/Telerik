using System;
using System.Collections.Generic;

//* Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).

class MergeSortAlgorithm
{
    private static int[] MergeSort(int[] array)
    {
        int[] result = new int[array.Length];

        if (array.Length <= 1)
        {
            return array;
        }
        else
        {
            int middle = array.Length / 2;
            int[] leftPart = new int[middle];
            int[] rightPart = new int[array.Length - middle];

            for (int i = 0; i < middle; i++)
            {
                leftPart[i] = array[i];
            }

            for (int i = middle; i < array.Length; i++)
            {
                rightPart[i - middle] = array[i];
            }

            leftPart = MergeSort(leftPart);
            rightPart = MergeSort(rightPart);

            //little optimization not to call the Merge function
            if (leftPart[leftPart.Length - 1] < rightPart[0])
            {
                for (int i = 0; i < leftPart.Length; i++)
                {
                    result[i] = leftPart[i];
                }
                for (int i = 0; i < rightPart.Length; i++)
                {
                    result[leftPart.Length + i] = rightPart[i];
                }
                return result;
            }
            result = Merge(leftPart, rightPart);

            return result;
        }

    }

    private static int[] Merge(int[] leftPart, int[] rightPart)
    {
        int[] result = new int[leftPart.Length + rightPart.Length];

        int index = 0;
        int leftIncrease = 0;
        int rightIncrease = 0;

        while (leftIncrease < leftPart.Length && rightIncrease < rightPart.Length)
        {
            if (leftPart[leftIncrease] <= rightPart[rightIncrease])
            {
                result[index] = leftPart[leftIncrease];
                leftIncrease++;
                index++;
            }
            else
            {
                result[index] = rightPart[rightIncrease];
                rightIncrease++;
                index++;
            }
        }

        if (leftIncrease < leftPart.Length)
        {
            for (int i = leftIncrease; i < leftPart.Length; i++)
            {
                result[index] = leftPart[i];
                index++;
            }
        }

        if (rightIncrease < rightPart.Length)
        {
            for (int i = rightIncrease; i < rightPart.Length; i++)
            {
                result[index] = rightPart[i];
                index++;
            }
        }

        return result;
    }
    static void Main()
    {
        Console.Write("Enter the length of the array: ");
        int length = int.Parse(Console.ReadLine());

        int[] unsortedArray = new int[length];

        for (int i = 0; i < length; i++)
        {
            Console.Write("unsortedArray[{0}] = ", i);
            unsortedArray[i] = int.Parse(Console.ReadLine());
        }

        int[] sortedArray = new int[length];

        sortedArray = MergeSort(unsortedArray);

        string sortedArrayOutput = string.Join(", ", sortedArray);

        Console.WriteLine(sortedArrayOutput);
    }
}

