namespace _02.CompanyArticles
{
    using System;
    using System.Diagnostics;
    using Wintellect.PowerCollections;

    public class FindArticlesByPrice
    {
        static OrderedMultiDictionary<double, Article> articles;

        static Random randomGenerator;

        private static void GenerateRandomArticles(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string barcode = new string((char) randomGenerator.Next(97, 123), randomGenerator.Next(5, 11));
                string vendor = new string((char) randomGenerator.Next(97, 123), randomGenerator.Next(5, 11));
                string title = new string((char) randomGenerator.Next(97, 123), randomGenerator.Next(5, 11));
                double price = randomGenerator.Next(2, 2001) * 0.678;

                articles.Add(price, new Article(barcode, vendor, title, price));
            }
        }

        private static void FindArticlesInPriceRange(double lowBound, double highBound)
        {
            var result = articles.Range(lowBound, true, highBound, true);

            // foreach (var item in result)
            // {
            //     Console.WriteLine(item);
            // }
        }

        static void Main()
        {
            const int ArticlesCount = 1000000;

            articles = new OrderedMultiDictionary<double, Article>(true);
            randomGenerator = new Random();

            var watch = new Stopwatch();

            watch.Start();

            // for testing if it works correctly can change ArticlesCount to be smaller and uncomment the foreach loop in FindArticlesInPriceRange method
            // now it only test the searching time in 1 000 000 articles
            GenerateRandomArticles(ArticlesCount);

            watch.Stop();

            Console.WriteLine("Initliazation time: {0}", watch.Elapsed);
            watch.Reset();

            watch.Start();

            FindArticlesInPriceRange(200.0, 1000.0);

            watch.Stop();

            Console.WriteLine("Searching time: {0}", watch.Elapsed);
        }
    }
}
