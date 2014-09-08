namespace _02.DictionaryUsingRedisDb
{
    using System;
    using System.Linq;

    public class CommandExecutor
    {
        public static void ExecuteCommand(string command, WordsDictionary redisDictionary)
        {
            int commandEndIndex = command.IndexOf(' ');

            string parsedCommand = command.Substring(0, commandEndIndex).Trim();

            switch (parsedCommand)
            {
                case "Add":
                    {
                        AddToDictionary(command, redisDictionary);
                        break;
                    }
                case "Remove":
                    {
                        RemoveFromDictionary(command, redisDictionary);
                        break;
                    }
                case "Find":
                    {
                        string result = FindFromDictionary(command, redisDictionary);
                        Console.WriteLine(result);
                        break;
                    }
                case "List":
                    {
                        ListAllFromDictionary(redisDictionary);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong command. Try again.");
                        break;
                    }
            }
        }

        private static void AddToDictionary(string command, WordsDictionary redisDictionary)
        {
            int wordStartIndex = command.IndexOf(' ') + 1;
            int wordEndIndex = command.IndexOf('-');

            string word = command.Substring(wordStartIndex, wordEndIndex - wordStartIndex).Trim();
            string translation = command.Substring(wordEndIndex + 1).Trim();

            redisDictionary.Add(word, translation);
            Console.WriteLine("Word is added successfully.");
        }

        private static void RemoveFromDictionary(string command, WordsDictionary redisDictionary)
        {
            int wordStartIndex = command.IndexOf(' ') + 1;

            string word = command.Substring(wordStartIndex, command.Length - wordStartIndex).Trim();

            redisDictionary.Remove(word);
            Console.WriteLine("Word is removed successfully.");
        }

        private static string FindFromDictionary(string command, WordsDictionary redisDictionary)
        {
            int wordStartIndex = command.IndexOf(' ') + 1;

            string word = command.Substring(wordStartIndex, command.Length - wordStartIndex).Trim();

            return word + " -> " + redisDictionary[word];
        }

        private static void ListAllFromDictionary(WordsDictionary redisDictionary)
        {
            if (redisDictionary.Count > 0)
            {
                foreach (var item in redisDictionary)
                {
                    Console.WriteLine("{0} -> {1}", item.Name, item.Translation);
                }
            }
            else
            {
                Console.WriteLine("There are no words in the dictionary.");
            }
        }
    }
}