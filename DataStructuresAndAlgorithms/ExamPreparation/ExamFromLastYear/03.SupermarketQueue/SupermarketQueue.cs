namespace SuperMarketQueue
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Wintellect.PowerCollections;

    internal class SupermarketQueue
    {
        private static BigList<string> queue;
        private static Dictionary<string, int> occurances;
        private static StringBuilder result;

        private static void Main()
        {
            queue = new BigList<string>();
            occurances = new Dictionary<string, int>();
            result = new StringBuilder();

            string currentCommand = Console.ReadLine();

            while (currentCommand != "End")
            {
                ProcessCommand(currentCommand.Split(' '));

                currentCommand = Console.ReadLine();
            }

            Console.Write(result);
        }

        private static void ProcessCommand(string[] commandParameters)
        {
            switch (commandParameters[0])
            {
                case "Append":
                    result.AppendLine(Append(commandParameters[1]));
                    break;

                case "Insert":
                    result.AppendLine(Insert(int.Parse(commandParameters[1]), commandParameters[2]));
                    break;

                case "Find":
                    result.AppendLine(Find(commandParameters[1]).ToString());
                    break;

                case "Serve":
                    result.AppendLine(Serve(int.Parse(commandParameters[1])));
                    break;
            }
        }

        private static string Insert(int position, string name)
        {
            if (position < 0 || position > queue.Count)
            {
                return "Error";
            }

            if (position == queue.Count)
            {
                Append(name);
            }
            else
            {
                queue.Insert(position, name);

                if (!occurances.ContainsKey(name))
                {
                    occurances[name] = 1;
                }
                else
                {
                    occurances[name]++;
                }
            }

            return "OK";
        }

        private static string Append(string name)
        {
            if (queue.Count == 0)
            {
                queue.Insert(0, name);
            }
            else
            {
                queue.Insert(queue.Count, name);
            }

            if (!occurances.ContainsKey(name))
            {
                occurances[name] = 1;
            }
            else
            {
                occurances[name]++;
            }

            return "OK";
        }

        private static int Find(string name)
        {
            if (occurances.ContainsKey(name))
            {
                return occurances[name];
            }
            else
            {
                return 0;
            }
        }

        private static string Serve(int count)
        {
            if (count < 0 || count > queue.Count)
            {
                return "Error";
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                var name = queue[0];
                queue.RemoveAt(0);

                occurances[name]--;

                result.Append(name);
                result.Append(' ');
            }

            result.Length--;

            return result.ToString();
        }
    }
}