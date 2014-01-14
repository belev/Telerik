using System;
using System.IO;

class PrintOddLinesOfFile
{
    static void Main()
    {
        StreamReader reader = new StreamReader("Text.txt");

        using (reader)
        {
            string line = reader.ReadLine();
            int countLines = 1;

            while (line != null)
            {
                if (countLines % 2 == 1)
                {
                    Console.WriteLine(line);
                }

                line = reader.ReadLine();
                countLines++;
            }
        }
    }
}

