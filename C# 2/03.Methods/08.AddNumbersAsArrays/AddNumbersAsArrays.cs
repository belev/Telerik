using System;
using System.Collections.Generic;
//Write a method that adds two positive integer numbers represented as arrays of digits 
//(each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
//Each of the numbers that will be added could have up to 10 000 digits.

class AddNumbersAsArrays
{
    private static List<int> AddNumbers(int[] first, int[] second)
    {
        List<int> result = new List<int>();
        Array.Reverse(first);
        Array.Reverse(second);

        int sumOfDigits = 0;
        int biggerLength = Math.Max(first.Length, second.Length);

        for (int i = 0; i < biggerLength; i++)
        {
            if (i < first.Length)
            {
                sumOfDigits += first[i];
            }
            if (i < second.Length)
            {
                sumOfDigits += second[i];
            }

            result.Add(sumOfDigits % 10);
            sumOfDigits /= 10;
        }

        return result;
    }
    static int[] ReadNumberAsArrayOfDigits()
    {
        Console.Write("Please enter the number of digits of the number: ");
        int numberOfDigits = int.Parse(Console.ReadLine());
        int[] digits = new int[numberOfDigits];

        Console.WriteLine("The digits of the number are: ");
        for (int i = 0; i < numberOfDigits; i++)
        {
            digits[i] = int.Parse(Console.ReadLine());
        }

        return digits;
    }
    static void Main()
    {
        int[] firstNumber = ReadNumberAsArrayOfDigits();

        int[] secondNumber = ReadNumberAsArrayOfDigits();

        List<int> sum = sum = AddNumbers(firstNumber, secondNumber);

        Console.Write("The sum of the two numbers is: ");
        for (int i = sum.Count - 1; i >= 0; i--)
        {
            Console.Write(sum[i]);
        }
    }
}

