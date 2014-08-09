namespace _06.PhonesAndCommands
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;


    public class PhonesAndCommands
    {
        private static MultiDictionary<string, MultiDictionary<string, string>> FillPhoneBook()
        {
            const string PhonesPath = "phones.txt";

            StreamReader phonesReader = new StreamReader(PhonesPath);

            var phoneBook = new MultiDictionary<string, MultiDictionary<string, string>>(true);

            using (phonesReader)
            {
                string line = phonesReader.ReadLine();

                while (line != null)
                {
                    var splittedEntry = line.Split('|');

                    string name = splittedEntry[0].Trim();
                    string town = splittedEntry[1].Trim();
                    string phoneNumber = splittedEntry[2].Trim();

                    if (phoneBook.ContainsKey(name))
                    {
                        var nameInPhoneBook = phoneBook[name].First();

                        if (nameInPhoneBook.ContainsKey(town))
                        {
                            nameInPhoneBook[town].Add(phoneNumber);
                        }
                        else
                        {
                            nameInPhoneBook.Add(town, phoneNumber);
                        }
                    }
                    else
                    {
                        phoneBook.Add(name, new MultiDictionary<string, string>(true));
                        var nameInPhoneBook = phoneBook[name].First();
                        nameInPhoneBook.Add(town, phoneNumber);
                    }

                    line = phonesReader.ReadLine();
                }

                return phoneBook;
            }
        }

        private static string ProcessCommands(MultiDictionary<string, MultiDictionary<string, string>> phoneBook)
        {
            StreamReader commandsReader = new StreamReader("commands.txt");

            StringBuilder result = new StringBuilder();

            using (commandsReader)
            {
                string command = commandsReader.ReadLine();

                while (command != null)
                {
                    int indexOfOpenBracket = command.IndexOf('(');
                    string withoutCommandName = command.Substring(indexOfOpenBracket + 1).TrimEnd(')');

                    var splitted = withoutCommandName.Split(',');
                    string nameFromCommand = splitted[0].Trim();

                    // if the command is search by name only
                    if (splitted.Length == 1)
                    {
                        // get all elements which have got the same name as the searched name from command
                        var resultOnlyByName = phoneBook.Where(p => p.Key == nameFromCommand);

                        foreach (var nameEntries in resultOnlyByName)
                        {
                            foreach (var townPhoneCollection in nameEntries.Value)
                            {
                                foreach (var phoneCollection in townPhoneCollection)
                                {
                                    foreach (var phoneNumber in phoneCollection.Value)
                                    {
                                        string addingLineToResult = string.Format("{0} from {1} -> {2}", nameEntries.Key, phoneCollection.Key, phoneNumber);
                                        result.AppendLine(addingLineToResult);
                                    }
                                }
                            }
                        }

                        // added to divide different commands results
                        result.AppendLine("------------------------------------------------");
                    }
                    else if (splitted.Length == 2)
                    {
                        // if the command is search by name and location
                        string town = splitted[1].Trim();

                        // get all elements which have got the same name as the searched name from command
                        var currentResultByName = phoneBook.Where(p => p.Key == nameFromCommand);

                        foreach (var nameEntries in currentResultByName)
                        {
                            foreach (var townPhoneCollection in nameEntries.Value)
                            {
                                // then get all elements which have got the same town as the searched town from command
                                var resultAndByTown = townPhoneCollection.Where(t => t.Key == town);

                                foreach (var phoneCollection in resultAndByTown)
                                {
                                    foreach (var phoneNumber in phoneCollection.Value)
                                    {
                                        string addingLineToResult = string.Format("{0} from {1} -> {2}", nameEntries.Key, phoneCollection.Key, phoneNumber);
                                        result.AppendLine(addingLineToResult);
                                    }
                                }
                            }
                        }

                        // added to divide different commands results
                        result.AppendLine("------------------------------------------------");
                    }

                    command = commandsReader.ReadLine();
                }
            }

            return result.ToString();
        }

        static void Main()
        {
            var phoneBook = FillPhoneBook();

            string commandsResult = ProcessCommands(phoneBook).Trim();
            Console.WriteLine(commandsResult);
        }
    }
}
