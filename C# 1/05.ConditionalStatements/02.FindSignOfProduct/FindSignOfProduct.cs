using System;

class FindSignOfProduct
{
    static void Main()
    {
        Console.WriteLine("Please enter three real numbers");

        Console.Write("Enter first number: ");
        double firstNumber = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        double secondNumber = double.Parse(Console.ReadLine());

        Console.Write("Enter third number: ");
        double thirdNumber = double.Parse(Console.ReadLine());

        char sign = '\0';

        //if all are positive than the sign is +
        bool allArePositive = firstNumber > 0.0 && secondNumber > 0.0 && thirdNumber > 0.0;

        //if two of the numbers are negative and the other is positive than the product has got sign +
        bool onePositiveTwoNegative = (firstNumber > 0.0 && secondNumber < 0.0 && thirdNumber < 0.0)
                                        || (firstNumber < 0.0 && secondNumber > 0.0 && thirdNumber < 0.0)
                                        || (firstNumber < 0.0 && secondNumber < 0.0 && thirdNumber > 0.0);

        bool isProductZero = (firstNumber == 0.0) || (secondNumber == 0.0) || (thirdNumber == 0.0);

        bool hasSign = true;

        if (isProductZero)
        {
            hasSign = false;
        }

        else if (allArePositive || onePositiveTwoNegative)
        {
            sign = '+';
        }

        else
        {
            sign = '-';
        }

        if (hasSign)
        {
            Console.WriteLine("The sign of the product is: {0}", sign);
        }
        else
        {
            Console.WriteLine("The product hasn't got sign");
        }

    }
}

