using System;

class ZeroSubsetSum
{
    static void Main()
    {
        int[] numbers = new int[5];

        Console.WriteLine("Please enter five numbers");
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Please enter number: ");

            numbers[i] = int.Parse(Console.ReadLine());
        }


        for (int mask = 1; mask < (1 << numbers.Length); mask++)
        {
            int currentSum = 0;

            for (int indexOfNumber = 0; indexOfNumber < numbers.Length; indexOfNumber++)
            {
                if ( ((mask >> indexOfNumber) & 1) == 1)
                {
                    currentSum += numbers[indexOfNumber];
                }
            }

            if (currentSum == 0)
            {
                Console.WriteLine("There is a subset which sum is equal to zero");
                return;
            }
        }

        Console.WriteLine("There is no such subset which sum is equal to zero");
    }
}

