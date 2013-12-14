using System;
//Write a program that finds the maximal increasing sequence in an array. 
class MaximalIncreasingSequence
{
    static void Main()
    {
        Console.Write("Enter the length of the array: ");
        int length = int.Parse(Console.ReadLine());

        int[] sequence = new int[length];

        for (int i = 0; i < length; i++)
        {
            Console.Write("sequence[{0}] = ", i);
            sequence[i] = int.Parse(Console.ReadLine());
        }

        //maximal length of incraesing elements
        int maximalLengthOfEqualElements = 0;
        //current length of increasing elements
        int tmpLength = 1;
        //the last element
        int element = 0;

        bool allAreIncreasing = true;

        for (int i = 0; i < length - 1; i++)
        {
            if (sequence[i] == sequence[i + 1] - 1)
            {
                tmpLength++;
            }
            else
            {
                if (maximalLengthOfEqualElements < tmpLength)
                {
                    maximalLengthOfEqualElements = tmpLength;
                    element = sequence[i];
                }
                tmpLength = 1;
                allAreIncreasing = false;
            }
        }
        //printing the output of the maximal increasing sequence of elements
        if (allAreIncreasing)
        {
                for (int i = 0; i < tmpLength; i++)
                {
                    Console.Write(sequence[i]);

                    if (i != tmpLength - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine();
        }
        else if (allAreIncreasing == false)
        {
            if (maximalLengthOfEqualElements > 1)
            {
                for (int i = 0; i < maximalLengthOfEqualElements; i++)
                {
                    //began the printing from the first element of the increasing sequence
                    Console.Write(element - maximalLengthOfEqualElements + 1 + i);

                    if (i != maximalLengthOfEqualElements - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("There is no increasing sequence");
            }
        }
        
    }
}

