using System;
//Write a method that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).

class IsNumberBiggerThanNeighbours
{
    private static bool CheckPosition(int position, int length)
    {
        return (position >= 0 && position < length);
    }
    private static bool IsBiggerThanNeighbours(int[] sequence, int position)
    {
        return (sequence[position] > sequence[position - 1] && sequence[position] > sequence[position + 1]);
    }
    static void Main()
    {
        Console.Write("Enter length of the array: ");
        int length = int.Parse(Console.ReadLine());

        int[] sequence = new int[length];
        for (int i = 0; i < length; i++)
        {
            Console.Write("sequence[{0}] = ", i);
            sequence[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter position of number: ");
        int position = int.Parse(Console.ReadLine());

        if (CheckPosition(position, length))
        {
            if (position == 0 || position == length - 1)
            {
                Console.WriteLine("The number at the given position hasnt got two neighbours");
            }
            else
            {
                bool isBigger = IsBiggerThanNeighbours(sequence, position);

                Console.WriteLine("Is the number at position {0} in the sequence bigger than its neighbours: {1}", position, isBigger);
            }
        }
        else
        {
            Console.WriteLine("Invalid position!");
        }
    }
}

