namespace _08.ExtractAlbumNamesAndAuthors
{
    using System;
    using System.Linq;
    using System.Xml;

    public class ExtractAlbumNamesAndAuthors
    {
        public static void Main()
        {
            using (var reader = XmlReader.Create("../../../albums.xml"))
            {
                using (var xmlWriter = XmlWriter.Create("../../albumNamesAndAuthors.xml"))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("albumsNamesAndAuthors", "urn:albumsNamesAndAuthors");

                    var albumName = string.Empty;
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name == "name")
                            {
                                albumName = reader.ReadElementString();
                            }
                            else if (reader.Name == "artist")
                            {
                                var artistName = reader.ReadElementString();

                                xmlWriter.WriteStartElement("album");

                                xmlWriter.WriteElementString("name", albumName);
                                xmlWriter.WriteElementString("artist", artistName);

                                xmlWriter.WriteEndElement();
                            }
                        }
                    }

                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                }
            }
        }
    }
}