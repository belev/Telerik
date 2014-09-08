namespace _03.NumberOfAlbumsForArtistWithXPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    public class NumberOfAlbumsForArtistWithXPath
    {
        public static void Main()
        {
            var document = new XmlDocument();
            document.Load("../../../albums.xml");
            var rootNode = document.DocumentElement;

            var artistsAlbumsCount = new Dictionary<string, int>();

            var artistList = rootNode.SelectNodes("album");

            foreach (XmlNode artist in artistList)
            {
                string artistName = artist.SelectSingleNode("artist").InnerText;

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