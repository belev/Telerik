using System;
//Write a method GetMax() with two parameters that returns the bigger of two integers.
//Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

class PrintBiggestNumber
{
    private static int GetMax(int firstNum, int secondNum)
    {
        return (firstNum > secondNum)? firstNum : secondNum;
    }
    static void Main()
    {
        Console.WriteLine("Enter three integer numbers.");
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        int thirdNum = int.Parse(Console.ReadLine());

        int biggestNumber = GetMax(GetMax(firstNum, secondNum), GetMax(firstNum, thirdNum));

        Console.WriteLine("The biggest number is: {0}", biggestNumber);
    }
}

