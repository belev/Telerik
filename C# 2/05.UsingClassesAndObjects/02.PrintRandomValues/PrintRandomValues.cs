using System;

class PrintRandomValues
{
    static void Main()
    {
        Random rand = new Random();

        for (int i = 0; i < 10; i++)
        {
            int number = rand.Next(100, 201);

            Console.WriteLine(number);
        }
    }
}

