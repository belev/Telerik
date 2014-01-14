using System;
using System.Collections.Generic;
using System.IO;

class SortNames
{
    static void Main()
    {

        using (StreamReader reader = new StreamReader("Names.txt"))
        {
            List<string> names = new List<string>();

            string currentName = reader.ReadLine();

            while (currentName != null)
            {
                names.Add(currentName);

                currentName = reader.ReadLine();
            }

            names.Sort();

            using (StreamWriter writer = new StreamWriter("SortedNames.txt"))
            {
                foreach (string name in names)
                {
                    writer.WriteLine(name);
                }
            }
        }
    }
}

