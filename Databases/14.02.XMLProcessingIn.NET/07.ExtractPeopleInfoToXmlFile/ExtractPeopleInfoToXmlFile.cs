namespace _07.ExtractPeopleInfoToXmlFile
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml;

    public class ExtractPeopleInfoToXmlFile
    {
        public static void Main()
        {
            using (var reader = new StreamReader("../../people.txt"))
            {
                using (var xmlWriter = XmlWriter.Create("../../people.xml"))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("people", "urn:people");

                    var currentLine = reader.ReadLine();

                    while (currentLine != null)
                    {
                        var splittedLine = currentLine.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                        var name = splittedLine[0];
                        var address = splittedLine[1];
                        var phone = splittedLine[2];

                        xmlWriter.WriteStartElement("person");

                        xmlWriter.WriteElementString("name", name);
                        xmlWriter.WriteElementString("address", address);
                        xmlWriter.WriteElementString("phone", phone);

                        xmlWriter.WriteEndElement();

                        currentLine = reader.ReadLine();
                    }
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                }
            }
        }
    }
}