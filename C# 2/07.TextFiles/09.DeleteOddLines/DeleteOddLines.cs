using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
class DeleteOddLines
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\text.txt");
        StringBuilder result = new StringBuilder();

        using (reader)
        {
            string line = reader.ReadLine();
            int count = 0;


            while (line != null)
            {
                if (count % 2 == 0)
                {
                    result.AppendLine(line);
                }

                line = reader.ReadLine();
                count++;
            }
        }

        StreamWriter writer = new StreamWriter(@"..\..\text.txt");
        using (writer)
        {
            writer.Write(result.ToString());
        }
    }
}

