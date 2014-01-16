using System;
class SubstringOccurance
{
    static void Main()
    {
        //string text = "We are living in an yellow submarine.We don't have anything else.Inside the submarine is very tight.So we are drinking all the day.We will move out of it in 5 days.";
        //string substringToSearch = "in";

        string text = Console.ReadLine();
        string stringToSearch = Console.ReadLine();

        int index = text.IndexOf(stringToSearch, 0, StringComparison.InvariantCultureIgnoreCase);
        int count = 0;

        //find the index of the substring in the text, if the index is different from -1 increase count
        while (index != -1)
        {
            count++;

            index = text.IndexOf(stringToSearch, index + stringToSearch.Length, StringComparison.InvariantCultureIgnoreCase);
        }

        Console.WriteLine("The string \"{0}\" appears {1} times in the text.", stringToSearch, count);
    }
}

