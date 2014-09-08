namespace _05.ExtractSongTitles
{
    using System;
    using System.Linq;
    using System.Xml;

    public class ExtractSongTitles
    {
        public static void Main()
        {
            using (var reader = XmlReader.Create("../../../albums.xml"))
            {
                using (var xmlWriter = XmlWriter.Create("../../extractedSongs.xml"))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("songs", "urn:songs");

                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "title"))
                        {
                            xmlWriter.WriteStartElement("song");

                            var title = reader.ReadElementString();

                            xmlWriter.WriteElementString("title", title);
                            xmlWriter.WriteEndElement();
                        }
                    }
                    xmlWriter.WriteEndDocument();
                }
            }
        }
    }
}