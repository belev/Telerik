namespace _02.DictionaryUsingRedisDb
{
    using System;
    using System.Linq;
    using ServiceStack.Redis;
    using System.Text;

    internal class DictionaryUsingRedisDb
    {
        static void Main()
        {
            const string DictionaryName = "DictionaryDb";
            using (RedisClient client = new RedisClient())
            {
                PrintMenu();

                var redisDictionary = new WordsDictionary(client, DictionaryName);

                while (true)
                {
                    Console.Write("Please enter a command: ");
                    string command = Console.ReadLine().Trim();

                    if (command == "Exit")
                    {
                        Console.WriteLine("Goodbye. : ) ");
                        break;
                    }

                    CommandExecutor.ExecuteCommand(command, redisDictionary);
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("{0}", new string('*', Console.BufferWidth));

            Console.WriteLine("Dictionary app with Redis.");
            Console.WriteLine("Command options:");
            Console.WriteLine("  -Add - adds a word to the dictionary: example 'Add pesho - very bad student'");
            Console.WriteLine("  -Find - findes a word from the dictionary: example 'Find pesho'");
            Console.WriteLine("  -Remove - removes a word from the dictionary: example 'Remove pesho'");
            Console.WriteLine("  -List - lists all words from the dictionary: example 'List all'");
            Console.WriteLine("  -Exit - exits from the dictionary: example 'Exit'");
            Console.WriteLine();

            Console.WriteLine("{0}", new string('*', Console.BufferWidth));
        }
    }
}
