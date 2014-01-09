using System;
using System.IO;

class ReadFileContent
{
    static void Main()
    {

        try
        {
            string path = Console.ReadLine(); 

            string readText = File.ReadAllText(path);
            Console.WriteLine("Successfully read the text from the text file");
            Console.WriteLine(readText);
        }

        catch (PathTooLongException)
        {
            Console.WriteLine("Your path or your file name is too big and exceed the maximal length defined");
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("There was no such file in that path you entered");
        }

        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Invalid path. There is no such directory");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Null is invalid path. Please enter a valid path");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("There might be some invalid symbol in your path or the path is with zero-length, or it contains only whitespaces.");
        }
        catch (IOException)
        {
            Console.WriteLine("An error occured whille opening the file");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The path is in an invalid format.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("The path cannot be opened.");
        }
        catch (System.Security.SecurityException)
        {
            Console.WriteLine("You don't have the required permission to open this file.");
        }
    }
}

