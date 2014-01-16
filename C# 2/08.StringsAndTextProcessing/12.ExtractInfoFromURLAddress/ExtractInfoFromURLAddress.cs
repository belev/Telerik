using System;
using System.Text;
class ExtractInfoFromURLAddress
{
    static void Main()
    {
        string urlAddress = Console.ReadLine();
        //test with https://www.google.bg/search?q=url+parser+c%23&rlz=1C1CHWA_enBG534BG534&oq=url+parser+c%23&aqs=chrome..69i57j0l5.2884j0j7&sourceid=chrome&espv=210&es_sm=93&ie=UTF-8

        int startIndex = 0;
        int endIndex = urlAddress.IndexOf("://");

        string protocol = urlAddress.Substring(startIndex, endIndex - startIndex);

        startIndex = endIndex + 3;
        endIndex = urlAddress.IndexOf('/', startIndex);
        string server = urlAddress.Substring(startIndex, endIndex - startIndex);

        string resource = urlAddress.Substring(endIndex);

        Console.WriteLine("[protocol] = {0}", protocol);
        Console.WriteLine("[server] = {0}", server);
        Console.WriteLine("[resource] = {0}", resource);
    }
}
