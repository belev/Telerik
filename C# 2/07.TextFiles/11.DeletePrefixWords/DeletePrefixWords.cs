using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
class DeletePrefixWords
{
    static void Main()
    {
        //test with "aenfa testaaef atesttd test testnirng"
        StreamReader reader = new StreamReader(@"..\..\text.txt");
        StringBuilder result = new StringBuilder();

        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] splitted = line.Split(new char[] { ' ', '.', ',', '!', ':', '\'', '\"', '(', ')', '-' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < splitted.Length; i++)
                {
                    if (splitted[i].StartsWith("test") == false)
                    {
                        result.Append(splitted[i]);

                        if (i < splitted.Length - 1)
                        {
                            result.Append(' ');
                        }
                    }
                }
                result.AppendLine();
                line = reader.ReadLine();
            }
        }

        StreamWriter writer = new StreamWriter(@"..\..\text.txt");

        using (writer)
        {
            writer.Write(result.ToString());
        }
    }
}

