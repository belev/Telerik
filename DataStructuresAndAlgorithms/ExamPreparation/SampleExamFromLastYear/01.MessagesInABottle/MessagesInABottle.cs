namespace _01.MessagesInABottle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class MessagesInABottle
    {
        private static Dictionary<string, char> letterCodes;
        private static SortedSet<string> messages;
        private static StringBuilder message;

        private static void Main()
        {
            var encodedMessage = Console.ReadLine();
            var cipher = Console.ReadLine();

            ParseCipher(cipher);
            FindMessages(encodedMessage);
            PrintResult();
        }

        private static void ParseCipher(string cipher)
        {
            letterCodes = new Dictionary<string, char>();
            messages = new SortedSet<string>();
            message = new StringBuilder();

            char letter = '\0';

            for (int i = 0; i < cipher.Length; i++)
            {
                var curChar = cipher[i];

                if (char.IsLetter(curChar))
                {
                    i++;
                    var letterNumber = new StringBuilder();

                    while (i < cipher.Length && !char.IsLetter(cipher[i]))
                    {
                        letterNumber.Append(cipher[i]);
                        i++;
                    }

                    i--;
                    letterCodes.Add(letterNumber.ToString(), curChar);
                }
            }
        }

        private static void FindMessages(string symbolsLeft)
        {
            if (symbolsLeft.Length == 0)
            {
                messages.Add(message.ToString());
                return;
            }

            foreach (var letterCode in letterCodes)
            {
                if (symbolsLeft.StartsWith(letterCode.Key))
                {
                    message.Append(letterCode.Value);

                    var symbolsLeftAfterRemove = symbolsLeft.Substring(symbolsLeft.IndexOf(letterCode.Key) + letterCode.Key.Length);
                    FindMessages(symbolsLeftAfterRemove);

                    message.Length--;
                }
            }
        }

        private static void PrintResult()
        {
            var result = new StringBuilder();

            result.AppendLine(messages.Count.ToString());

            foreach (var message in messages)
            {
                result.AppendLine(message);
            }
            result.Length--;

            Console.WriteLine(result);
        }
    }
}
