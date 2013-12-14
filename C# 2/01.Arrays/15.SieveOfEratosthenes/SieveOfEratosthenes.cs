using System;
using System.Collections.Generic;

//Write a program that finds all prime numbers in the range [1...10 000 000].
//Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

class SieveOfEratosthenes
{
    static void Main()
    {
        Console.Write("Enter the end of the range of the numbers: ");
        ulong numbersLength = ulong.Parse(Console.ReadLine());

        List<ulong> primeNumbers = new List<ulong>();

        
        bool[] notPrime = new bool[numbersLength + 1];

        //3163 * 3163 > 10 000 000
        ulong lastNumberToCheck = 3163;

        for (ulong i = 2; i <= numbersLength; i++)
        {
            if (notPrime[i] == false)
            {
                primeNumbers.Add(i);

                if (i < lastNumberToCheck)
                {
                    for (ulong j = i * i; j <= numbersLength; j += i)
                    {
                        notPrime[j] = true;
                    }
                }

                //if i >= 3163 no need to check because we check those numbers and we know that they are not prime numbers
            }
        }

        string primes = string.Join(", ", primeNumbers);

        Console.WriteLine(primes);
    }
}

