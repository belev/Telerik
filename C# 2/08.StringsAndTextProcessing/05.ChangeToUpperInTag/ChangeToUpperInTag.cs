using System;
using System.Text;
class ChangeToUpperInTag
{
    static bool IsPossibleIndex(int index, int textLength)
    {
        return (index < textLength);
    }
    static void Main()
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        StringBuilder result = new StringBuilder();
        //split on <upcase>
        string[] splittedForOpenTags = text.Split(new string[] { "<upcase>"}, StringSplitOptions.RemoveEmptyEntries);


        for (int i = 0; i < splittedForOpenTags.Length; i++)
        {
            if (splittedForOpenTags[i].Contains("</upcase>"))
            {
                //if the splitted part contains close tag
                //split on </upcase>
                string[] splittedForCloseTags = splittedForOpenTags[i].Split(new string[] { "</upcase>" }, StringSplitOptions.RemoveEmptyEntries);

                //append the left part to the result in upper case, because thats the part between the tag
                result.Append(splittedForCloseTags[0].ToUpper());

                //and if there is something else after the close tag, append it to the result
                if (splittedForCloseTags.Length > 1)
                {
                    result.Append(splittedForCloseTags[1]);
                }
            }
            else
            {
                //if the splitted part does not contains close tag, append the part of text to the result
                result.Append(splittedForOpenTags[i]);
            }
        }
        Console.WriteLine(result.ToString());
    }
}

