using System;

class BiggestOfThreeNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter three integer numbers");

        Console.Write("Please enter first number: ");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.Write("Please enter second number: ");
        int secondNumber = int.Parse(Console.ReadLine());

        Console.Write("Please enter third number: ");
        int thirdNumber = int.Parse(Console.ReadLine());

        int biggestOfThree = firstNumber;

        if (biggestOfThree < secondNumber || biggestOfThree < thirdNumber)
        {
            if (biggestOfThree < thirdNumber)
            {
                biggestOfThree = thirdNumber;
            }

            if (biggestOfThree < secondNumber)
            {
                biggestOfThree = secondNumber;
            }
        }

        Console.WriteLine("The biggest number is: {0}", biggestOfThree);
    }
}

