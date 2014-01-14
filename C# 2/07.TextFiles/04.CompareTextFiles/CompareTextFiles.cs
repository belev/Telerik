using System;
using System.IO;

class CompareTextFiles
{
    static void Main()
    {
        using (StreamReader readerOne = new StreamReader("FirstText.txt"))
        {
            using (StreamReader readerTwo = new StreamReader("SecondText.txt"))
            {
                int equalLines = 0;
                int differentLine = 0;

                string firstTextLine = readerOne.ReadLine();
                string secondTextLine = readerTwo.ReadLine();

                while (firstTextLine != null && secondTextLine != null)
                {
                    if (firstTextLine == secondTextLine)
                    {
                        equalLines++;
                    }
                    else
                    {
                        differentLine++;
                    }

                    firstTextLine = readerOne.ReadLine();
                    secondTextLine = readerTwo.ReadLine();
                }

                Console.WriteLine("There are {0} equal lines", equalLines);
                Console.WriteLine("And {0} different line", differentLine);
            }
        }
    }
}

