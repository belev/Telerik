using System;

class CalculateSumWithAccuracy
{
    static void Main()
    {
        double currentSum = 1.0;
        double nextSum = 1.5;
        double numberForDivision = 3;

        double difference = nextSum - currentSum;

        while (difference >= 1e-6)
        {
            currentSum = nextSum;

            if(numberForDivision % 2 == 1)
            {
                nextSum -= 1.0 / numberForDivision;
            }
            else
            {
                nextSum += 1.0 / numberForDivision;
            }

            difference = Math.Abs(nextSum - currentSum);
            numberForDivision += 1.0;
        }

        Console.WriteLine("The sum of the sequence is: {0:0.000}", currentSum);
    }
}

