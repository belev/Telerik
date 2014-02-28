using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTML
{
    class Program
    {
        private const string revTagOpen = "<rev>";
        private const string upperTagOpen = "<upper>";
        private const string lowerTagOpen = "<lower>";
        private const string toggleTagOpen = "<toggle>";
        private const string delTagOpen = "<del>";

        private const string revTagClose = "</rev>";
        private const string upperTagClose = "</upper>";
        private const string lowerTagClose = "</lower>";
        private const string toggleTagClose = "</toggle>";
        private const string delTagClose = "</del>";

        private static int openedDelTags = 0;
        private static StringBuilder output = new StringBuilder();
        static List<string> currentOpenedTags = new List<string>();
        static List<int> revTagContentStarts = new List<int>();

        internal static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string currentLine = Console.ReadLine();

                int inputSymbolIndex = 0;
                while (inputSymbolIndex < currentLine.Length)
                {
                    if (currentLine[inputSymbolIndex] == '<')
                    {
                        string tag = GetTag(currentLine, inputSymbolIndex);
                        ProcessTag(tag);

                        int tagLastIndex = inputSymbolIndex + tag.Length - 1;
                        inputSymbolIndex = tagLastIndex;
                    }
                    else
                    {
                        if (openedDelTags == 0)
                        {
                            char symbolToAdd = currentLine[inputSymbolIndex];

                            for (int tagIndex = currentOpenedTags.Count - 1; tagIndex >= 0; tagIndex--)
                            {
                                symbolToAdd = GetAppliedTagEffect(symbolToAdd, currentOpenedTags[tagIndex]);
                            }

                            output.Append(symbolToAdd);
                        }
                    }

                    inputSymbolIndex++;
                }

                output.Append("\n");
            }

            //output.Replace("\n", Environment.NewLine);

            Console.WriteLine(output.ToString().Trim());
        }

        private static char GetAppliedTagEffect(char symbolToAdd, string tag)
        {
            char currentSymbol = symbolToAdd;
            if (char.IsLetter(currentSymbol))
            {
                switch (tag)
                {
                    case lowerTagOpen:
                        currentSymbol = char.ToLower(currentSymbol);
                        break;
                    case upperTagOpen:
                        currentSymbol = char.ToUpper(currentSymbol);
                        break;
                    case toggleTagOpen:
                        if (char.IsLower(currentSymbol))
                        {
                            currentSymbol = char.ToUpper(currentSymbol);
                        }
                        else
                        {
                            currentSymbol = char.ToLower(currentSymbol);
                        }
                        break;
                    default:
                        break;
                }
            }

            return currentSymbol;
        }

        private static void ProcessTag(string tag)
        {
            if (tag == delTagOpen)
            {
                openedDelTags++;
            }
            else if (tag == delTagClose)
            {
                openedDelTags--;
            }
            else
            {
                if (openedDelTags == 0)
                {
                    if (tag == revTagOpen)
                    {
                        revTagContentStarts.Add(output.Length);
                    }
                    else if (tag == revTagClose)
                    {
                        int currentRevContentStart = revTagContentStarts[revTagContentStarts.Count - 1];
                        Reverse(currentRevContentStart, output.Length - 1);
                        RemoveLastRevTagContentStart();
                    }
                    else if (IsClosing(tag))
                    {
                        RemoveCurrentWrappingTags();
                    }
                    else
                    {
                        currentOpenedTags.Add(tag);
                    }
                }
            }
        }

        private static bool IsClosing(string tag)
        {
            return tag[1] == '/';
        }

        private static void RemoveCurrentWrappingTags()
        {
            currentOpenedTags.RemoveAt(currentOpenedTags.Count - 1);
        }

        private static void RemoveLastRevTagContentStart()
        {
            revTagContentStarts.RemoveAt(revTagContentStarts.Count - 1);
        }

        private static void Reverse(int currentRevContentStart, int length)
        {
            int leftIndex = currentRevContentStart;
            int rightIndex = length;

            while (leftIndex < rightIndex)
            {
                char leftBuffer = output[leftIndex];
                output[leftIndex] = output[rightIndex];
                output[rightIndex] = leftBuffer;

                leftIndex++;
                rightIndex--;
            }
        }

        private static string GetTag(string line, int searchStartIndex)
        {
            int tagStart = searchStartIndex;
            int tagEnd = line.IndexOf('>', tagStart);

            string tag = line.Substring(tagStart, tagEnd - tagStart + 1);

            return tag;
        }
    }
}
