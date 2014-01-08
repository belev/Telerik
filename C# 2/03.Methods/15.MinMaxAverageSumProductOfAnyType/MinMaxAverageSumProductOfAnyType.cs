using System;
class MinMaxAverageSumProductOfAnyType
{
    static T Min<T>(params T[] array)
    {
        dynamic min = array[0];
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

    static T Max<T>(params T[] array)
    {
        dynamic max = array[0];
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

    static T Average<T>(params T[] array)
    {
        dynamic average = 0;

        for (int i = 0; i < array.Length; i++)
        {
            average += array[i];
        }

        average /= array.Length;

        return average;
    }

    static T Sum<T>(params T[] array)
    {
        dynamic sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        return sum;
    }

    static T Product<T>(params T[] array)
    {
        dynamic product = 1;

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

        decimal min1 = Min<decimal>(6.1m, 3.11111m, 2.543m);
        decimal max1 = Max<decimal>(6.1m, 3.11111m, 2.543m);
        decimal sum1 = Sum<decimal>(6.1m, 3.11111m, 2.543m);
        decimal average1 = Average<decimal>(6.1m, 3.11111m, 2.543m);
        decimal product1 = Product<decimal>(6.1m, 3.11111m, 2.543m);

        Console.WriteLine(min1);
        Console.WriteLine(max1);
        Console.WriteLine(sum1);
        Console.WriteLine(average1);
        Console.WriteLine(product1);

    }
}