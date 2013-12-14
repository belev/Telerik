using System;

class PrintDigitName
{
    static void Main()
    {
        Console.Write("Please enter digit: ");
        int digit = int.Parse(Console.ReadLine());

        if (digit < 0)
        {
            digit *= -1;
        }

        switch (digit)
        {
            case 0:
                Console.WriteLine("The digit name is: zero");
                break;
            case 1:
                Console.WriteLine("The digit name is: one");
                break;
            case 2:
                Console.WriteLine("The digit name is: two");
                break;
            case 3:
                Console.WriteLine("The digit name is: three");
                break;
            case 4:
                Console.WriteLine("The digit name is: four");
                break;
            case 5:
                Console.WriteLine("The digit name is: five");
                break;
            case 6:
                Console.WriteLine("The digit name is: six");
                break;
            case 7:
                Console.WriteLine("The digit name is: seven");
                break;
            case 8:
                Console.WriteLine("The digit name is: eight");
                break;
            case 9:
                Console.WriteLine("The digit name is: nine");
                break;
            default:
                Console.WriteLine("There is no such digit");
                break;
        }
    }
}

