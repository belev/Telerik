using System;
//Write a program that finds the sequence of maximal sum in given array. Example:
	//{2, 3, -6, -1, 2, -1, 6, 4, -8, 8} - > {2, -1, 6, 4}
	//Can you do it with only one loop (with single scan through the elements of the array)?

class SequenceOfMaximalSum
{
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

        //Kadane's algorithm
        int currentBegin = 0;
        int bestBegin = 0;
        int end = 0;

        int currentSum = sequence[0];
        int maxSum = 0;

        for (int i = 1; i < length; i++)
        {
            if (currentSum < 0)
            {
                currentSum = sequence[i];
                currentBegin = i;
            }
            else
            {
                currentSum += sequence[i];
            }

            if (currentSum > maxSum)
            {
                maxSum = currentSum;

                bestBegin = currentBegin;
                end = i;
            }
        }
        Console.WriteLine("The maximal sum is: {0}", maxSum);
        for (int i = bestBegin; i <= end; i++)
        {
            Console.Write(sequence[i]);
            if (i != end)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
    }
}

