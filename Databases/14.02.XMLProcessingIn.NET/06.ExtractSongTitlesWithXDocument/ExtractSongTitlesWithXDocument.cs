namespace _06.ExtractSongTitlesWithXDocument
{
    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    public class ExtractSongTitlesWithXDocument
    {
        public static void Main()
        {
            var document = XDocument.Load("../../../albums.xml");

            var allSongTitles = document.Descendants("song").Select(s => s.Element("title").Value);

            using (var xmlWriter = XmlWriter.Create("../../extractedSongs.xml"))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("songs", "urn:songs");

                foreach (var title in allSongTitles)
                {
                    xmlWriter.WriteStartElement("song");

                    xmlWriter.WriteElementString("title", title);

                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
        }
    }
}
