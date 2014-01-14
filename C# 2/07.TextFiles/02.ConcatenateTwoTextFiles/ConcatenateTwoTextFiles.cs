using System;
using System.IO;

class ConcatenateTwoTextFiles
{
    static void Main()
    {
        StreamReader firstReader = new StreamReader("FirstText.txt");

        string firstText;
        using (firstReader)
        {
            firstText = firstReader.ReadToEnd();
        }


        StreamReader secondReader = new StreamReader("SecondText.txt");

        string secondText;
        using (secondReader)
        {
            secondText = secondReader.ReadToEnd();
        }

        StreamWriter writer = new StreamWriter("ConcatenateText.txt");

        using (writer)
        {
            writer.WriteLine(firstText);
            writer.WriteLine(secondText);
        }
    }
}

