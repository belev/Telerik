using System;

class DetermineUserInputType
{
    static void Main()
    {
        Console.Write("Please enter your input: ");
        string userInput = Console.ReadLine();

        int dotCounter = 0;
        bool containDot = false;
        bool containingOnlyDigits = true;

        bool containOtherSymbols = false;

        for (int i = 0; i < userInput.Length; i++)
        {
            if ((char)userInput[i] == '.')
            {
                dotCounter++;
                containDot = true;
            }

            else if (( (char) userInput[i] < '0' || (char) userInput[i] > '9') && (char)userInput[i] != '.')
            {
                containingOnlyDigits = false;
                containOtherSymbols = true;
            }
        }

        if (containingOnlyDigits && !containDot && !containOtherSymbols)
        {
            int inputNumber = int.Parse(userInput) + 1;
            Console.WriteLine(inputNumber);
        }
        else if (containingOnlyDigits && containDot && !containOtherSymbols && dotCounter == 1)
        {
            double inputNumber = double.Parse(userInput) + 1.0;
            Console.WriteLine(inputNumber);
        }
        else if (containOtherSymbols || dotCounter > 1)
        {
            userInput += "*";
            Console.WriteLine(userInput);
        }
    }
}

