namespace _12.FindPricesOfAlbumsLINQ
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class FindPricesOfAlbumsLINQ
    {
        static void Main()
        {
            var document = XDocument.Load("../../../albums.xml");

            var allAlbums = document.Descendants("album")
                                    .Where(a => int.Parse(a.Element("year").Value) < 2008)
                                    .Select(a => new
                                    {
                                        Name = a.Element("name").Value,
                                        Price = a.Element("price").Value
                                    });

            foreach (var album in allAlbums)
            {
                Console.WriteLine("Album {0} costs: -> {1}", album.Name, album.Price);
            }
        }
    }
}