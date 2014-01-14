using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
class WholeWordsReplacement
{
    private static bool IsPossibleIndex(int index, int lineLenght)
    {
        return (index >= 0 && index < lineLenght);
    }
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\text.txt");
        StringBuilder result = new StringBuilder();

        using (reader)
        {
            string line = reader.ReadLine();

            while ( line != null)
            {
                StringBuilder lineToResult = new StringBuilder();
                lineToResult.Append(line);

                int wordIndex = line.IndexOf("start");

                if (wordIndex == -1)
                {
                    line = reader.ReadLine();
                    continue;
                }
                else
                {
                    while (wordIndex != -1)
                    {
                        if (IsPossibleIndex(wordIndex - 1, line.Length) && IsPossibleIndex(wordIndex + 5, line.Length))
                        {
                            if (char.IsLetter(line[wordIndex - 1]) == false && char.IsLetter(line[wordIndex + 5]) == false)
                            {
                                lineToResult.Replace("start", "finish", wordIndex, 7);
                            }
                        }
                        else if (IsPossibleIndex(wordIndex - 1, line.Length))
                        {
                            if (char.IsLetter(line[wordIndex - 1]) == false)
                            {
                                lineToResult.Replace("start", "finish", wordIndex, 6);
                            }
                        }
                        else if (IsPossibleIndex(wordIndex + 5, line.Length))
                        {
                            if (char.IsLetter(line[wordIndex + 5]) == false)
                            {
                                lineToResult.Replace("start", "finish", wordIndex, 6);
                            }
                        }
                        wordIndex = line.IndexOf("start", wordIndex + 4);
                    }
                    result.AppendLine(lineToResult.ToString());
                }
                line = reader.ReadLine();
            }

            StreamWriter writer = new StreamWriter(@"..\..\result.txt");
            using (writer)
            {
                writer.Write(result.ToString());
            }
        }
    }
}

