using System;

class ApplyBonusScores
{
    static void Main()
    {
        Console.Write("Enter digit: ");
        int digit = int.Parse(Console.ReadLine());

        switch (digit)
        {
            case 0:
                Console.WriteLine("The digit is zero, nothing happens !");
                break;
            case 1:
            case 2:
            case 3:
                Console.WriteLine(digit * 10);
                break;
            case 4:
            case 5:
            case 6:
                Console.WriteLine(digit * 100);
                break;
            case 7:
            case 8:
            case 9:
                Console.WriteLine(digit * 1000);
                break;
            default:
                Console.WriteLine("There is no such digit !");
                break;
        }
    }
}

