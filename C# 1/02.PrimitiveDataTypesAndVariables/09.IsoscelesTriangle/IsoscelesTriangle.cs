using System;

class IsoscelesTriangle
{
    static void Main()
    {
        char copyRightSign = (char) (0x00A9);
        int numberOfSymbolsOnRow = 1;

        for (int i = 2; i >= 0; i--)
        {
            Console.WriteLine(new string(' ', i) + new string(copyRightSign, numberOfSymbolsOnRow) + new string(' ', i));

            numberOfSymbolsOnRow += 2;
        }
    }
}

