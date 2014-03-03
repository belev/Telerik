namespace SoftwareAcademy
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Static class which first gets the file content.
    /// Then rewrite the previous content of the text file in it, and add the new content which should be added.
    /// Take the previous content because either way we will lose it and the content in the text file will be the content from the last command.
    /// There can be a little mistake with some new line at the top of the output file, but on the console it works fine.
    /// </summary>
    public static class OutputTextOverwriter
    {
        public static void OverwriteTextOutput(StringBuilder currentOutputFromCommand)
        {
            StreamReader reader = new StreamReader("test.txt");
            string wholeText = "";

            using (reader)
            {
                wholeText = reader.ReadToEnd();
            }

            StreamWriter writer = new StreamWriter("test.txt");
            using (writer)
            {
                writer.WriteLine(wholeText.Trim());
                writer.WriteLine(currentOutputFromCommand.ToString().TrimEnd());
            }
        }
    }
}
