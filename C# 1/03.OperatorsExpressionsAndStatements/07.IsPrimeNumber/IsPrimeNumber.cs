using System;

class IsPrimeNumber
{
    static void Main()
    {
        Console.Write("Please enter number: ");
        byte number = byte.Parse(Console.ReadLine());

        bool isPrime = true;

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
                break;
            }
        }

        if (isPrime)
        {
            Console.WriteLine("The number {0} is prime", number);
        }

        else
        {
            Console.WriteLine("The number {0} is not prime", number);
        }
    }
}

