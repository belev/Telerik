namespace _04.DeleteAlbums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    public class DeleteAlbums
    {
        public static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../../albums.xml");
            XmlNode rootNode = doc.DocumentElement;

            var albumsToBeRemoved = new List<XmlNode>();

            foreach (XmlNode album in rootNode.ChildNodes)
            {
                var albumPrice = double.Parse(album["price"].InnerText);

                if (albumPrice > 20.0)
                {
                    albumsToBeRemoved.Add(album);
                    Console.WriteLine("Album for removal: {0} -> costs {1}", album["name"].InnerText, albumPrice);
                }
            }

            foreach (XmlNode albumToBeRemoved in albumsToBeRemoved)
            {
                rootNode.RemoveChild(albumToBeRemoved);
            }
            

            doc.Save("../../albumsNew.xml");
        }
    }
}
