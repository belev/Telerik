using System;
//Write a program that reads two integer numbers N and K and an array of N elements from the console.
//Find in the array those K elements that have maximal sum.

class MaximalSumOfKElements
{
    static void Main()
    {
        Console.Write("Enter the length of the array: ");
        int length = int.Parse(Console.ReadLine());

        Console.Write("Enter k: ");
        int k = int.Parse(Console.ReadLine());

        int[] sequence = new int[length];
        for (int i = 0; i < length; ++i)
        {
            Console.Write("sequence[{0}] = ", i);
            sequence[i] = int.Parse(Console.ReadLine());
        }

        int currentMaximalElementIndex = -1;
        bool[] used = new bool[length];

        if (k <= length)
        {
            for (int j = 0; j < k; j++)
            {
                //find the first number in the sequence which is not used
                currentMaximalElementIndex = Array.IndexOf(used, false);

                if (currentMaximalElementIndex != -1)
                {
                    //find the current maximal element index
                    for (int i = 0; i < length; ++i)
                    {
                        if (used[i] == false && sequence[i] > sequence[currentMaximalElementIndex])
                        {
                            currentMaximalElementIndex = i;
                        }
                    }
                    //set the value, of the maximal element, to true in the used array
                    used[currentMaximalElementIndex] = true;
                    //print the current maximal element
                    Console.WriteLine(sequence[currentMaximalElementIndex]);
                }
            }
        }
    }
}

