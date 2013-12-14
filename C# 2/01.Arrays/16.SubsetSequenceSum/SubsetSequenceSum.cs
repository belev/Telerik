using System;
using System.Text;
//Problem 16
//* We are given an array of integers and a number S. 
//Write a program to find if there exists a subset of the elements of the array that has a sum S.
//Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 - > yes (1+2+5+6)

//Problem 17
//* Write a program that reads three integer numbers N, K and S and an array of N elements from the console. 
//Find in the array a subset of K elements that have sum S or indicate about its absence.

//this is the whole case, i mean problem 17. It runs and works for problem 16 too.
class SubsetSequenceSum
{
    static void Main()
    {
        Console.Write("Enter the length of the sequence: ");
        int length = int.Parse(Console.ReadLine());

        Console.Write("Enter the wanted sum: ");
        int wantedSum = int.Parse(Console.ReadLine());

        Console.Write("How many elements do you want to have the subset: ");
        int numberOfElementsInSubset = int.Parse(Console.ReadLine());

        int[] sequence = new int[length];

        for (int i = 0; i < length; i++)
        {
            Console.Write("sequence[{0}] = ", i);
            sequence[i] = int.Parse(Console.ReadLine());
        }

        int numberOfSubsets = 0;

        for (int i = 1; i < (1 << length); i++)
        {
            StringBuilder subset = new StringBuilder();
            int currentSum = 0;
            int countElements = 0;

            for (int j = 0; j < length; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    currentSum += sequence[j];
                    subset.Append(sequence[j] + ", ");
                    countElements++;
                }
            }

            if (currentSum == wantedSum && countElements == numberOfElementsInSubset)
            {
                numberOfSubsets++;
                Console.Write("Subset number {0} --> ", numberOfSubsets);
                Console.WriteLine(subset.ToString().Remove(subset.Length - 2, 2));
            }
        }
    }
}

