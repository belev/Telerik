using System;
class SimpleTextBasedMenu
{
    static void Menu()
    {
        Console.WriteLine("Tasks that can be solved: ");
        Console.WriteLine("1. Reverse the digits of a number");
        Console.WriteLine("2. Calculates the average of a sequence of integers");
        Console.WriteLine("3. Solve a linear equation");
        Console.WriteLine();
        Console.Write("Please enter the number of the task which you would like to solve: ");

        int taskToSolve = int.Parse(Console.ReadLine());



        if (taskToSolve == 1)
        {
            Console.WriteLine("You choose to reverse the digits of a number");
            Console.Write("Please enter the number: ");
            int number = int.Parse(Console.ReadLine());
            if (number > 0)
            {
                Console.WriteLine("The reversed number is: {0}", ReverseDigits(number));
            }
            else
            {
                Console.WriteLine("The number is negative");
            }
        }

        else if (taskToSolve == 2)
        {
            Console.WriteLine("You choose to calculate the average of sequence of integers");
            int[] sequence = ReadSequence();
            if (sequence.Length != 0)
            {
                long average = CalculateAverage(sequence);
                Console.WriteLine("The average of the sequence is: {0}", average);
            }
            else
            {
                Console.WriteLine("The sequence is empty");
            }
        }

        else if (taskToSolve == 3)
        {
            Console.WriteLine("You choose to solve a linear equation");
            Console.WriteLine("Please enter the coeficients of the equation: ");
            decimal a = decimal.Parse(Console.ReadLine());
            decimal b = decimal.Parse(Console.ReadLine());
            if (a != 0)
            {
                decimal result = SolveLinearEquation(a, b);
                Console.WriteLine("The solution of the equation is: {0}", result);
            }
            else
            {
                Console.WriteLine("Invalid input for coeficients");
            }
        }

        else
        {
            Console.WriteLine("Invalid operation, please run the program again and choose operation between 1 - 3");
        }
    }


    static string ReverseDigits(int number)
    {
        string numAsString = number.ToString();

        string result = "";

        for (int i = numAsString.Length - 1; i >= 0; i--)
        {
            result += numAsString[i];
        }

        return result;
    }

    static long CalculateAverage(int[] sequence)
    {
        int length = sequence.Length;
        long result = 0;

        for (int i = 0; i < length; i++)
        {
            result += sequence[i];
        }

        result /= length;

        return result;
    }

    static int[] ReadSequence()
    {
        Console.Write("Enter the length of the sequence: ");
        int length = int.Parse(Console.ReadLine());

        int[] sequence = new int[length];

        Console.WriteLine("Please enter the sequence: ");
        for (int i = 0; i < length; i++)
        {
            sequence[i] = int.Parse(Console.ReadLine());
        }

        return sequence;
    }

    static decimal SolveLinearEquation(decimal a, decimal b)
    {
        decimal result = -(b / a);

        return result;
    }


    static void Main()
    {
        Menu();
    }
}

