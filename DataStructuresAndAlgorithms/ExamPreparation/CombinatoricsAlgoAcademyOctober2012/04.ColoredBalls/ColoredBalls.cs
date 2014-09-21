using System;
using System.Linq;
using System.Numerics;

public class ColoredBalls
{
    static void Main()
    {
        char[] colors = Console.ReadLine().ToCharArray();

        var dict = colors.GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count());

        BigInteger all = GetFactorial(colors.Length);
        BigInteger divider = new BigInteger(1);

        foreach (var item in dict)
        {
            divider *= GetFactorial(item.Value);
        }

        Console.WriteLine(all / divider);
    }

    private static BigInteger GetFactorial(int number)
    {
        BigInteger res = new BigInteger(1);

        for (int i = 2; i <= number; i++)
        {
            res *= i;
        }

        return res;
    }
}

