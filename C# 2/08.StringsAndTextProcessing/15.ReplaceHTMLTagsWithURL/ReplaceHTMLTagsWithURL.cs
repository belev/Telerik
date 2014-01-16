using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
class ReplaceHTMLTagsWithURL
{
    static void Main()
    {
        //test
        //string htmlFragment = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

        string htmlFragment = Console.ReadLine();
        string[] tags = new string[] { "<a href=\"", "\">", "</a>" };

        int index = 0;
        index = htmlFragment.IndexOf(tags[0], index);

        while (index != -1)
        {
            htmlFragment = htmlFragment.Replace(tags[0], "[URL=");

            index = htmlFragment.IndexOf(tags[1], index);
            htmlFragment = htmlFragment.Replace(tags[1], "]");

            index = htmlFragment.IndexOf(tags[0], index);
        }
        htmlFragment = htmlFragment.Replace(tags[2], "[/URL]");
        Console.WriteLine(htmlFragment);
    }
}

