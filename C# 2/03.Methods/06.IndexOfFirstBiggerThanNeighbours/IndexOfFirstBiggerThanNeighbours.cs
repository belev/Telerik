using System;
class IndexOfFirstBiggerThanNeighbours
{
    private static bool IsBiggerThanNeighbours(int[] sequence, int position)
    {
        return (sequence[position] > sequence[position - 1] && sequence[position] > sequence[position + 1]);
    }
    private static int FindIndexOfFirstBiggerThanNeighbours(int[] sequence, int length)
    {
        int index = -1;

        for (int i = 1; i < length - 1; i++)
        {
            if (IsBiggerThanNeighbours(sequence, i))
            {
                index = i;
                break;
            }
        }

        return index;
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

        int index = FindIndexOfFirstBiggerThanNeighbours(sequence, length);

        Console.WriteLine(index);
    }
}

