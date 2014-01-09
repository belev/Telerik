using System;
using System.Net;

class DownloadFile
{
    static void Main()
    {
        WebClient client = new WebClient();

        try
        {
            string adressAsString = "http://www.devbg.org/img/Logo-BASD.jpg";

            string location = "Image.jpg";

            client.DownloadFile(adressAsString, location);

            Console.WriteLine("The download is complete. You can find your file in bin/Debug");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The adress parameter is with null value");
        }
        catch (WebException)
        {
            Console.WriteLine("Invalid adress, the file name is empty or null, or the file does not exist");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The method has been called simultaneously on multiple targets");
        }
        finally
        {
            client.Dispose();
        }
    }
}

