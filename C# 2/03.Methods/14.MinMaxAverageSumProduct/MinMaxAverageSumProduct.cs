using System;
//Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments.

class MinMaxAverageSumProduct
{
    static int Min(params int[] array)
    {
        int min = array[0];
        if (array.Length == 1)
        {
            return min;
        }

        for (int i = 1; i < array.Length; i++)
        {
            if (min > array[i])
            {
                min = array[i];
            }
        }

        return min;
    }

    static int Max(params int[] array)
    {
        int max = array[0];
        if (array.Length == 1)
        {
            return max;
        }

        for (int i = 1; i < array.Length; i++)
        {
            if (max < array[i])
            {
                max = array[i];
            }
        }

        return max;
    }

    static long Average(params int[] array)
    {
        long average = 0;

        for (int i = 0; i < array.Length; i++)
        {
            average += array[i];
        }

        average /= array.Length;

        return average;
    }

    static long Sum(params int[] array)
    {
        long sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        return sum;
    }

    static long Product(params int[] array)
    {
        long product = 1;

        for (int i = 0; i < array.Length; i++)
        {
            product *= array[i];
        }

        return product;
    }

    static void Main()
    {
        int min = Min(-1, 5, 134, -10);
        Console.WriteLine(min);

        int max = Max(-4, 15, 199, 12, 13413);
        Console.WriteLine(max);

        long average = Average(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        Console.WriteLine(average);

        long product = Product(1, 2, 3, 4, 5, 10);
        Console.WriteLine(product);

        long sum = Sum(1, 2, 3, 4, 5);
        Console.WriteLine(sum);
    }
}

