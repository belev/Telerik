using System;
using System.Collections.Generic;
using System.Text;
class BasicLanguage
{
    static StringBuilder result = new StringBuilder();
    static long count = 1;

    static void Main()
    {
        StringBuilder commands = new StringBuilder();
        bool inBrackets = false;

        while (true)
        {
            bool hasExit = false;

            string line = Console.ReadLine();

            bool endOfCommand = false;

            for (int i = 0; i < line.Length; i++)
            {
                char curChar = line[i];

                if (char.IsWhiteSpace(curChar) && inBrackets == false)
                {
                    continue;
                }
                if (curChar == '(')
                {
                    inBrackets = true;
                }
                if (curChar == ')')
                {
                    inBrackets = false;
                }
                if (curChar == ';' && inBrackets == false)
                {
                    endOfCommand = true;
                }

                if (endOfCommand)
                {
                    ProcessCommand(commands, ref hasExit);

                    commands.Clear();
                    count = 1;
                    endOfCommand = false;
                }
                else
                {
                    if(char.IsWhiteSpace(curChar) && inBrackets == false)
                    {
                        continue;
                    }
                    else
                    {
                        commands.Append(curChar);
                    }
                }
            }

            if (hasExit)
            {
                Console.WriteLine(result);
                break;
            }
            commands.AppendLine();
        }
    }

    private static void ProcessCommand(StringBuilder commands, ref bool hasExit)
    {
        string trimmed = commands.ToString().Trim();

        string[] cmds = trimmed.Split(')');

        for (int i = 0; i < cmds.Length; i++)
        {
            string currentCommand = cmds[i].TrimStart();

            if (string.IsNullOrWhiteSpace(currentCommand))
            {
                continue;
            }

            char firstChar = currentCommand[0];

            if (firstChar == 'P')
            {
                int startIndex = currentCommand.IndexOf('(') + 1;

                string content = currentCommand.Substring(startIndex);

                if (content.Length > 0)
                {
                    for (int j = 0; j < count; j++)
                    {
                        result.Append(content);
                    }
                }
            }
            else if (firstChar == 'F')
            {
                bool hasComma = currentCommand.Contains(",");

                if (hasComma)
                {
                    string loopParameteres = currentCommand.Substring(currentCommand.IndexOf('(') + 1);

                    string[] parameters = loopParameteres.Split(',');

                    long a = int.Parse(parameters[0]);
                    long b = int.Parse(parameters[1]);

                    count *= (b - a + 1);
                }
                else
                {
                    int startIndex = currentCommand.IndexOf('(') + 1;

                    string numAsString = currentCommand.Substring(startIndex);

                    if (string.IsNullOrWhiteSpace(numAsString) == false)
                    {
                        int a = int.Parse(numAsString);
                        count *= a;
                    }
                }
            }
            else if (firstChar == 'E')
            {
                hasExit = true;
                break;
            }
        }
    }
}