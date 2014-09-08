namespace _11.FindPricesOfAlbums
{
    using System;
    using System.Linq;
    using System.Xml;

    public class FindPricesOfAlbums
    {
        static void Main(string[] args)
        {
            var document = new XmlDocument();
            document.Load("../../../albums.xml");

            string query = "/albums/album[year<2008]";
            var searchedAlbums = document.SelectNodes(query);

            foreach (XmlNode albume in searchedAlbums)
            {
                string albumName = albume.SelectSingleNode("name").InnerText;
                string price = albume.SelectSingleNode("price").InnerText;

                Console.WriteLine("Album {0} costs: -> {1}", albumName, price);
            }
        }
    }
}