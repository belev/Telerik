using System;
class AirplaneDrinks
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int teaCount = int.Parse(Console.ReadLine());
        int[] tea = new int[teaCount];
        for (int i = 0; i < teaCount; i++)
        {
            tea[i] = int.Parse(Console.ReadLine());
        }


        long res = n * 4;

        bool[] isTea = new bool[n];

        for (int i = 0; i < teaCount; i++)
        {
            isTea[tea[i] - 1] = true;
        }

        long countT = 0;
        long countC = 0;

        long lastT = 0;
        long lastC = 0;

        for (int i = n - 1; i >= 0; i--)
        {
            if (isTea[i])
            {
                countT++;

                if (lastT < i + 1)
                {
                    lastT = i + 1;
                }
            }
            else
            {
                countC++;

                if (lastC < i + 1)
                {
                    lastC = i + 1;
                }
            }

            if (countT == 7)
            {
                res += lastT * 2;
                res += 47;
                countT = 0;
                lastT = 0;
            }

            if (countC == 7)
            {
                res += lastC * 2;
                res += 47;
                countC = 0;
                lastC = 0;
            }
        }

        if (countT != 0)
        {
            res += lastT * 2;
            res += 47;
        }

        if (countC != 0)
        {
            res += lastC * 2;
            res += 47;
        }

        Console.WriteLine(res);
    }
}

