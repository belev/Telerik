using System;

class GreatestOfFiveNumbers
{
    static void Main()
    {
        int greatestNumber = 0;
        int currentNumber = 0;

        Console.WriteLine("Enter five numbers");

        for (int i = 0; i < 5; i++)
        {
            Console.Write("Please enter number: ");
            currentNumber = int.Parse(Console.ReadLine());

            if (i == 0)
            {
                greatestNumber = currentNumber;
            }

            else
            {
                if (greatestNumber < currentNumber)
                {
                    greatestNumber = currentNumber;
                }
            }
        }

        Console.WriteLine("The greatest number is: {0}", greatestNumber);
    }
}

