using System;
using System.Text;
using System.IO;
class CleanCode
{
    static bool isString;
    static bool isOneLineComment;
    static bool isMultiLineComment;
    static bool isMultiLineString;
    static bool isSingleQuoted;
    static StringBuilder result = new StringBuilder();
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();

            ProcessLine(line);

            if (isMultiLineComment == false && i != n - 1)
            {
                result.AppendLine();
            }
        }
        //new line split
        string[] output = result.ToString().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < output.Length; i++)
        {
            if (!IsEmptyLine(output[i]))
            {
                Console.WriteLine(output[i]);
            }
        }
    }
    private static bool IsEmptyLine(string line)
    {
        for (int i = 0; i < line.Length; i++)
        {
            if (char.IsWhiteSpace(line[i]) == false)
            {
                return false;
            }
        }
        return true;
    }
    private static bool IsValidIndex(int index, int length)
    {
        return (index >= 0 && index < length);
    }
    private static void ProcessLine(string line)
    {
        int length = line.Length;

        for (int i = 0; i < length; i++)
        {
            char current = line[i];

            if (isString)
            {
                if (isMultiLineString)
                {
                    if (current == '\"' && IsValidIndex(i + 1, length) && line[i + 1] == '\"')
                    {
                        result.Append("\"\"");
                        i++;
                        continue;
                    }
                }

                if (current == '\\')
                {
                    if (IsValidIndex(i + 1, length) && line[i + 1] == '\"')
                    {
                        result.Append("\\\"");
                        i++;
                        continue;
                    }

                    if (IsValidIndex(i + 1, length) && line[i + 1] == '\'')
                    {
                        result.Append("\\\'");
                        i++;
                        continue;
                    }
                }

                if (current == '\"' && isSingleQuoted == false)
                {
                    isString = false;
                    isMultiLineString = false;
                    result.Append(current);
                    continue;
                }

                if (current == '\'' && isSingleQuoted)
                {
                    isString = false;
                    isSingleQuoted = false;
                    result.Append(current);
                    continue;
                }

                result.Append(current);
                continue;
            }

            //check multi line comments
            if (isMultiLineComment == false && current == '/' && IsValidIndex(i + 1, length) && line[i + 1] == '*')
            {
                isMultiLineComment = true;
                i++;
                continue;
            }

            if (isMultiLineComment)
            {
                if (current == '*' && IsValidIndex(i + 1, length) && line[i + 1] == '/')
                {
                    isMultiLineComment = false;
                    i++;
                    continue;
                }
                continue;
            }

            //check one line comments
            if (current == '/' && IsValidIndex(i + 1, length) && line[i + 1] == '/')
            {
                if (current == '/' && IsValidIndex(i + 1, length) && line[i + 1] == '/' && IsValidIndex(i + 2, length) && line[i + 2] == '/')
                {
                    result.Append("///");
                    i += 2;
                    continue;
                }
                else
                {
                    break;
                }
            }

            //check strings
            if (current == '@' && IsValidIndex(i + 1, length) && line[i + 1] == '\"')
            {
                isString = true;
                isMultiLineString = true;
                result.Append("@\"");
                i++;
                continue;
            }

            if (current == '\"')
            {
                isString = true;
            }

            if (current == '\'')
            {
                isString = true;
                isSingleQuoted = true;
            }
            result.Append(current);
        }
    }
}