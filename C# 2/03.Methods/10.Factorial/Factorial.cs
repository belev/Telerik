using System;
using System.Collections.Generic;
//Write a program to calculate n! for each n in the range [1..100].
//Hint: Implement first a method that multiplies a number represented as array of digits by given integer number. 

class Factorial
{
    private static List<int> CalculateFactorial(int n)
    {
        List<int> curFact = new List<int>();
        curFact.Add(1);

        for (int i = 2; i <= n; i++)
        {
            List<int> fact = new List<int>();
            int carry = 0;

            for (int j = 0; j < curFact.Count; j++)
            {
                carry += curFact[j] * i;
                fact.Add(carry % 10);

                carry /= 10;
            }
            //if we exit the loop and carry is still greater than zero, than do the same operation as in the loop to add digits to the new number
            while (carry > 0)
            {
                fact.Add(carry % 10);
                carry /= 10;
            }
            curFact = fact;
        }

        return curFact;
    }
    static void Main()
    {
        List<int> factorial = CalculateFactorial(100);
        factorial.Reverse();

        for (int i = 0; i < factorial.Count; i++)
        {
            Console.Write(factorial[i]);
        }
    }
}

