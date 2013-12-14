using System;

class ASCIITable
{
    static void Main()
    {
        for (int i = 0; i <= 255; i++) // from 0 to 255 exclusive because there are 256 symbols in ASCII table
        {
            char symbolOfASCIITable = (char) i;

            Console.WriteLine(symbolOfASCIITable);
        }
    }
}

