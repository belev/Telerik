using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
class Program
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\text.txt");
        StringBuilder result = new StringBuilder();

        using (reader)
        {
            string line = reader.ReadLine();

            while (line != null)
            {
                result.AppendLine(line);
                line = reader.ReadLine();
            }
        }
        result.Replace("start", "finish");

        StreamWriter writer = new StreamWriter(@"..\..\result.txt");
        using (writer)
        {
            writer.Write(result.ToString());
        }
    }
}

