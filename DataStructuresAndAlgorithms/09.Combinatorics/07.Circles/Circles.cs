using System;
using System.Collections.Generic;
using System.Linq;

public class Circles
{
    static void Main()
    {
        string letters = Console.ReadLine();

        var dict = letters.GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count());

        long allPerms = GetFactorial(letters.Length - 1);

        foreach (var item in dict)
        {
            allPerms /= GetFactorial(item.Value - 1);
        }

        Console.WriteLine(allPerms);
    }

    private static long GetFactorial(int number)
    {
        long res = 1;

        for (int i = 2; i <= number; i++)
        {
            res *= i;
        }

        return res;
    }
}

