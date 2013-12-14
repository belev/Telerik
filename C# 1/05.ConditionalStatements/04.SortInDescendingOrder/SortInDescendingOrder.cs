using System;

class SortInDescendingOrder
{
    static void Main()
    {
        Console.WriteLine("Enter three real number");

        Console.Write("Please enter first number: ");
        double firstNumber = double.Parse(Console.ReadLine());

        Console.Write("Please enter second number: ");
        double secondNumber = double.Parse(Console.ReadLine());

        Console.Write("Please enter third number: ");
        double thirdNumber = double.Parse(Console.ReadLine());

        //Find the smallest number
        double smallestOfThree = firstNumber;

        if (smallestOfThree > secondNumber || smallestOfThree > thirdNumber)
        {
            if (smallestOfThree > thirdNumber)
            {
                smallestOfThree = thirdNumber;
            }

            if (smallestOfThree > secondNumber)
            {
                smallestOfThree = secondNumber;
            }
        }

        //after finding the smallest number, the smallest number go to last position
        if (smallestOfThree == firstNumber)
        {
            double tmp = firstNumber;
            firstNumber = thirdNumber;
            thirdNumber = tmp;
        }

        else if (smallestOfThree == secondNumber)
        {
            double tmp = secondNumber;
            secondNumber = thirdNumber;
            thirdNumber = tmp;
        }

        //Sort in descending order the first two numbers
        if (firstNumber < secondNumber)
        {
            double tmp = secondNumber;
            secondNumber = firstNumber;
            firstNumber = tmp;
        }

        Console.WriteLine("The numbers in descending order: {0}, {1}, {2}", firstNumber, secondNumber, thirdNumber);
    }
}

