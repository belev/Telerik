namespace _02.PrintNumberOfAlbumsForArtist
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    public class PrintNumberOfAlbumsForArtist
    {
        public static void Main()
        {
            var document = new XmlDocument();
            document.Load("../../../albums.xml");
            XmlNode rootNode = document.DocumentElement;

            var artistsAlbumsCount = new Dictionary<string, int>();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var artistName = node["artist"].InnerText;

                if (!artistsAlbumsCount.ContainsKey(artistName))
                {
                    artistsAlbumsCount.Add(artistName, 0);
                }

                artistsAlbumsCount[artistName]++;
            }

            foreach (var artist in artistsAlbumsCount)
            {
                Console.WriteLine("Artist Name: {0} -> {1} albums", artist.Key, artist.Value);
            }
        }
    }
}