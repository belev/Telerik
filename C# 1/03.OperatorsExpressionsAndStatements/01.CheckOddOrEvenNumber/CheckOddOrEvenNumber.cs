using System;

class CheckOddOrEvenNumber
{
    static void Main()
    {
        Console.Write("Please enter number: ");
        int number = int.Parse(Console.ReadLine());

        bool isOdd = (number % 2) != 0;

        if (isOdd)
        {
            Console.WriteLine("The entered number is odd");
        }
        else
        {
            Console.WriteLine("The entered number is even");
        }
                
    }
}

