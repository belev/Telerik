using System;
using System.Text;
class ConvertTextToUnicode
{
    static void Main()
    {
        string text = Console.ReadLine();

        StringBuilder textAsUnicode = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            string format = "\\u{0:X4}";

            textAsUnicode.AppendFormat(format, (int)text[i]);
        }
        Console.WriteLine(textAsUnicode.ToString());
    }
}

