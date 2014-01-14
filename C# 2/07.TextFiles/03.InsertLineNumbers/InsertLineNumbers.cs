using System;
using System.IO;

class InsertLineNumbers
{
    static void Main()
    {
        StreamReader reader = new StreamReader("Text.txt");

        using (reader)
        {
            StreamWriter writer = new StreamWriter("TextWithNumberOfLines.txt");

            using (writer)
            {
                int numberOfLine = 1;
                string line = reader.ReadLine();

                while (line != null)
                {
                    writer.WriteLine("{0}. {1}", numberOfLine, line);

                    line = reader.ReadLine();
                    numberOfLine++;
                }
            }

        }
    }
}

