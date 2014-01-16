using System;
using System.Collections.Generic;
using System.Text;
class ExtractHTMLTitleAndBody
{
    static void Main()
    {
        string html = @"        <html><head><title>News</title></head><body><p><a href=""http://academy.telerik.com"">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body></html>";

        int indexClosing = html.IndexOf('>');

        while (indexClosing > -1)
        {
            if (indexClosing < html.Length - 1 && html[indexClosing + 1] != '<')
            {
                int nextOpeningIndex = html.IndexOf('<', indexClosing);
                int textLength = nextOpeningIndex - indexClosing - 1;

                Console.WriteLine(html.Substring(indexClosing + 1, textLength).Trim());
            }
            indexClosing = html.IndexOf('>', indexClosing + 1);
        }
    }
}

