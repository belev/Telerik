using System;
//Write a program that finds in given array of integers a sequence of given sum S (if present).
//Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11 - > {4, 2, 5}
class FindSubsequenceSum
{
    static void Main()
    {
        Console.Write("Enter the length of the sequence: ");
        int length = int.Parse(Console.ReadLine());

        Console.Write("Enter the sum of the wanted subsequence: ");
        int wantedSum = int.Parse(Console.ReadLine());

        int[] sequence = new int[length];

        for (int i = 0; i < length; i++)
        {
            Console.Write("sequence[{0}] = ", i);
            sequence[i] = int.Parse(Console.ReadLine());
        }

        int begin = 0;
        int end = 0;
        bool isFound = false;

        for (int i = 0; i < length; i++)
        {
            int currentSum = 0;

            for (int j = i; j < length; j++)
            {
                currentSum += sequence[j];

                if (currentSum == wantedSum)
                {
                    begin = i;
                    end = j;
                    isFound = true;
                    break;
                }
            }

            if (isFound)
            {
                break;
            }
        }

        if (isFound)
        {
            for (int i = begin; i <= end; i++)
            {
                Console.Write(sequence[i]);
                if (i != end)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("There is no such sequence with the wanted sum");
        }
    }
}

