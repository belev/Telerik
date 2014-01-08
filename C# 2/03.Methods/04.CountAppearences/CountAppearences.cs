using System;
//Write a method that counts how many times given number appears in given array. Write a test program to check if the method is working correctly.

class CountAppearences
{
    private static int CountAppearencesOfNumber(int[] sequence, int number)
    {
        int count = 0;

        for (int i = 0; i < sequence.Length; i++)
        {
            if (number == sequence[i])
            {
                count++;
            }
        }
        return count;
    }
    static void Main()
    {
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("Enter the length of the array: ");
        int length = int.Parse(Console.ReadLine());

        int[] sequence = new int[length];
        for (int i = 0; i < length; i++)
        {
            Console.Write("sequence[{0}] = ", i);
            sequence[i] = int.Parse(Console.ReadLine());
        }

        int count = CountAppearencesOfNumber(sequence, number);
        Console.WriteLine("The number {0} appears {1} times in the sequence.", number, count);
    }
}

