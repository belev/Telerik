using System;
//Write a program that finds the maximal sequence of equal elements in an array.

class MaximalSequenceOfEqualElements
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

        //maximal length of equal elements
        int maximalLengthOfEqualElements = 0;
        //current length of equal elements
        int tmpLength = 1;
        //the equal element is
        int element = 0;

        bool allAreEqual = true;

        for (int i = 0; i < length - 1; i++)
        {
            if (sequence[i] == sequence[i + 1])
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
                allAreEqual = false;
            }
        }
        //printing the output of the maximal sequence of equal elements
        if (allAreEqual)
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
        else
        {
            for (int i = 0; i < maximalLengthOfEqualElements; i++)
            {
                Console.Write(element);

                if (i != maximalLengthOfEqualElements - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }
    }
}

