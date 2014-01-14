using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
class ExtractTextFromXML
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\text.txt");
        using (reader)
        {
            string xmlTextContent = reader.ReadToEnd();

            StringBuilder result = new StringBuilder();
            StringBuilder wordInXML = new StringBuilder();
            bool inTag = false;

            for (int i = 0; i < xmlTextContent.Length; i++)
            {
                char currentSymbol = xmlTextContent[i];

                if (currentSymbol == '<')
                {
                    inTag = true;

                    if (wordInXML.ToString() != string.Empty)
                    {
                        result.AppendLine(wordInXML.ToString());
                    }
                    wordInXML.Clear();
                }
                else if (currentSymbol == '>')
                {
                    inTag = false;
                }
                else if(inTag == false)
                {
                    wordInXML.Append(currentSymbol);
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}

