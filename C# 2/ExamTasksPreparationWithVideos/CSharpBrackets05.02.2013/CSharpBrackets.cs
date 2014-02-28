using System;
using System.Text;

class CSharpBrackets
{
    static string tab;
    static StringBuilder sb = new StringBuilder();
    static int tabCount = 0;
    static bool isFirstChar = true;

    static bool hasNewLine = false;

    private static void FormatLine(string line = "")
    {
        for (int i = 0; i < line.Length; i++)
        {
            char curChar = line[i];

            if (hasNewLine && char.IsWhiteSpace(curChar))
            {
                continue;
            }

            if (hasNewLine)
            {
                sb.AppendLine();
                hasNewLine = false;
                isFirstChar = true;
            }

            if (curChar == '{')
            {
                if (hasNewLine == false)
                {
                    if (isFirstChar == false)
                    {
                        if (char.IsWhiteSpace(line[i - 1]))
                        {
                            sb.Remove(sb.Length - 1, 1);
                        }
                        sb.AppendLine();
                    }
                }

                AddTabs();
                sb.Append(curChar);
                tabCount++;
                hasNewLine = true;
            }
            else if (curChar == '}')
            {
                tabCount--;

                if (hasNewLine == false)
                {
                    if (isFirstChar == false)
                    {
                        if (char.IsWhiteSpace(line[i - 1]))
                        {
                            sb.Remove(sb.Length - 1, 1);
                        }
                        sb.AppendLine();
                    }
                }

                AddTabs();
                sb.Append(curChar);
                hasNewLine = true;
            }
            else
            {
                if (isFirstChar)
                {
                    AddTabs();
                }

                if (!(isFirstChar && char.IsWhiteSpace(curChar)))
                {
                    if (!(i < line.Length - 1 && char.IsWhiteSpace(curChar) && char.IsWhiteSpace(line[i + 1])))
                    {
                        sb.Append(curChar);
                    }
                }

                isFirstChar = false;
            }
        }
        isFirstChar = true;
        hasNewLine = true;
    }

    private static void AddTabs()
    {
        for (int i = 0; i < tabCount; i++)
        {
            sb.Append(tab);
        }
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        tab = Console.ReadLine();

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();

            FormatLine(line);
        }

        Console.WriteLine(sb);
    }
}

