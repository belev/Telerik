using System;

//Write a program, that reads from the console an array of N integers and an integer K,
//sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

class LargestNumberLessThanK
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter k: ");
        int k = int.Parse(Console.ReadLine());

        int[] sequence = new int[n];

        for (int i = 0; i < n; i++)
        {
            sequence[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(sequence);

        int index = Array.BinarySearch(sequence, k);

        //from information in msdn about Array.BinarySearch method
        if (index >= 0)
        {
            Console.WriteLine("The found value is: {0}.", sequence[index]);
        }
        else
        {
            if (~index == n)
            {
                Console.WriteLine("The found valus is: {0}.", sequence[n - 1]);
            }
            else if (~index > 0 && ~index < n)
            {
                Console.WriteLine("The found valus is: {0}.", sequence[~index - 1]);
            }
            else
            {
                Console.WriteLine("All the values in the sequence are bigger than {0}.", k);
            }
        }
    }
}

