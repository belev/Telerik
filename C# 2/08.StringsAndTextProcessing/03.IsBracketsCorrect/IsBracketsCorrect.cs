using System;
class IsBracketsCorrect
{
    static void Main()
    {
        string expression = Console.ReadLine();

        bool inBrackets = false;
        int openBracketsCount = 0;

        bool flag = true;

        foreach (char symbol in expression)
        {
            if (symbol == '(')
            {
                inBrackets = true;
                openBracketsCount++;
            }
            else if (symbol == ')')
            {
                if (inBrackets == false)
                {
                    flag = false;
                    break;
                }
                else
                {
                    openBracketsCount--;

                    if (openBracketsCount < 0)
                    {
                        flag = false;
                        break;
                    }
                    else if(openBracketsCount > 0)
                    {
                        inBrackets = true;
                    }
                    else if (openBracketsCount == 0)
                    {
                        inBrackets = false;
                    }
                }
            }
        }

        if (openBracketsCount > 0 || openBracketsCount < 0 || flag == false)
        {
            Console.WriteLine("The brackets are not put correctly");
        }
        else
        {
            Console.WriteLine("The brackets are put correctly");
        }
    }
}

