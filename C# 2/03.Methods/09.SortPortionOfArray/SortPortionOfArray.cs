using System;
class SortPortionOfArray
{
    private static int FindIndexOfBiggestElement(int startIndex, int endIndex, int[] sequence)
    {
        int biggestIndex = -1;
        int biggestNumber = int.MinValue;

        for (int i = startIndex; i < endIndex; i++)
        {
            if (biggestNumber < sequence[i])
            {
                biggestNumber = sequence[i];
                biggestIndex = i;
            }
        }
        return biggestIndex;
    }

    private static void Swap(int[] sequence, int positionX, int positionY)
    {
        int tmp = sequence[positionX];
        sequence[positionX] = sequence[positionY];
        sequence[positionY] = tmp;
    }
    private static void SortPortionInDescendingOrder(int startIndex, int[] sequence)
    {
        for (int i = startIndex; i < sequence.Length; i++)
        {
            int index = FindIndexOfBiggestElement(i, sequence.Length, sequence);

            Swap(sequence, i, index);
        }
    }
    private static void SortPortionInAscendingOrder(int startIndex, int[] sequence)
    {
        for (int i = sequence.Length - 1; i > startIndex; i--)
        {
            int index = FindIndexOfBiggestElement(startIndex, i, sequence);

            Swap(sequence, i, index);
        }
    }
    static void Main()
    {
        Console.Write("Enter the length of the array: ");
        int length = int.Parse(Console.ReadLine());

        int[] sequence = new int[length];
        for (int i = 0; i < length; i++)
        {
            sequence[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter starting index: ");
        int startIndex = int.Parse(Console.ReadLine());

        int[] arrToSortInAscendingOrder = (int[]) sequence.Clone();
        int[] arrToSortInDescendingOrder = (int[]) sequence.Clone();

        SortPortionInAscendingOrder(startIndex, arrToSortInAscendingOrder);
        SortPortionInDescendingOrder(startIndex, arrToSortInDescendingOrder);

        Console.WriteLine(string.Join(", ", sequence));
        Console.WriteLine(string.Join(", ", arrToSortInAscendingOrder));
        Console.WriteLine(string.Join(", ", arrToSortInDescendingOrder));

    }
}

