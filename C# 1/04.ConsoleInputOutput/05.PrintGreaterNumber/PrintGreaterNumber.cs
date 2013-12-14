using System;

class PrintGreaterNumber
{
    static void Main()
    {
        Console.Write("Please enter first number: ");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.Write("Please enter second number: ");
        int secondNumber = int.Parse(Console.ReadLine());

        int greaterNumber = Math.Max(firstNumber, secondNumber);

        Console.WriteLine("The greater number between {0} and {1} is: {2}", firstNumber, secondNumber, greaterNumber);

        //From Operators and expressions we could use the thernary operator

        /*
        greaterNumber = (firstNumber > secondNumber) ? firstNumber : secondNumber;
        Console.WriteLine("The greater number between {0} and {1} is: {2}", firstNumber, secondNumber, greaterNumber);
         */
    }
}

