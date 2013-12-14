using System;
//Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. 
//Use the "selection sort" algorithm: Find the smallest element, move it at the first position, 
//find the smallest from the rest, move it at the second position, etc.

class SelectionSort
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

        
        for (int i = 0; i < length - 1; i++)
        {
            int currentMinIndex = i;

            for (int j = i + 1; j < length; j++)
            {
                //find the index of the minimal element
                if (sequence[j] < sequence[currentMinIndex])
                {
                    currentMinIndex = j;
                }
            }

            //swap values
            int tmp = sequence[i];
            sequence[i] = sequence[currentMinIndex];
            sequence[currentMinIndex] = tmp;
        }

        string sortedSequence = string.Join(", ", sequence);

        Console.WriteLine(sortedSequence);
    }
}

