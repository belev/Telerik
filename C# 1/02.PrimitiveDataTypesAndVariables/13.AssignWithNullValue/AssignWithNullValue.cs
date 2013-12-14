using System;

class AssignWithNullValue
{
    static void Main()
    {
        int? firstNumber = null;
        double? secondNumber = null;

        firstNumber = firstNumber + 5; // nothing happens
        secondNumber += null; // nothing happens

        Console.WriteLine(firstNumber);
        Console.WriteLine(secondNumber);
    }
}

