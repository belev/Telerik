using System;

//Write a program that allocates array of 20 integers and initializes each element
//by its index multiplied by 5. Print the obtained array on the console.

class InitializationOfArray
{
    static void Main()
    {
        int length = 20;
        int[] numbers = new int[length];

        for (int i = 0; i < length; i++)
        {
            numbers[i] = i * 5;
        }

        string outputNumbers = string.Join(", ", numbers);

        Console.WriteLine(outputNumbers);
    }
}

