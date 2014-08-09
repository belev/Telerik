namespace _02.ProductsSearch
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Diagnostics;

    using Wintellect.PowerCollections;

    public class ProductsSearch
    {
        private static string GenerateName()
        {
            int length = randGenerator.Next(5, 20);

            StringBuilder name = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                name.Append(Letters[randGenerator.Next(0, 62)]);
            }

            return name.ToString();
        }

        private static uint GeneratePrice()
        {
            uint price = (uint) randGenerator.Next(1, 30000);

            return price;
        }

        private static Product[] GenerateAllProducts()
        {
            var products = new Product[NumberOfProducts];

            for (int i = 0; i < NumberOfProducts; i++)
            {
                string productName = GenerateName();
                uint productPrice = GeneratePrice();

                products[i] = (new Product(productPrice, productName));
            }

            return products;
        }

        private static void PrintFirst20ProductsInRange(OrderedBag<Product> products)
        {
            // find first 20 elements in range
            var lowAndHighBound = GenerateBoundToSearchTo();

            var productsInRange = products.Range(new Product(lowAndHighBound[0], "low"), true, new Product(lowAndHighBound[1], "high"), true);

            Console.WriteLine("Start searching from: {0}", lowAndHighBound[0]);
            Console.WriteLine("End searching to: {0}", lowAndHighBound[1]);

            if (productsInRange.Count >= 20)
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine(productsInRange[i]);
                }
            }
            else
            {
                foreach (var product in productsInRange)
                {
                    Console.WriteLine(product);
                }
            }
        }

        private static void PrintTimeElapsedFor10000Searches(OrderedBag<Product> products)
        {
            var watch = new Stopwatch();

            // test 10 000 searches in 500 000 products
            watch.Start();
            for (int i = 0; i < PriceSearchesCount; i++)
            {
                var bounds = GenerateBoundToSearchTo();

                var lowProduct = new Product(bounds[0], "low");
                var highProduct = new Product(bounds[1], "high");

                products.Range(lowProduct, true, highProduct, true);
            }
            watch.Stop();
            Console.WriteLine("Time for searching 10 000 times: {0}", watch.Elapsed);
            watch.Reset();
        }

        private static uint[] GenerateBoundToSearchTo()
        {
            uint leftBound = (uint) randGenerator.Next(1, 15000);
            uint rightBound = (uint) randGenerator.Next(15000, 30000);

            var bounds = new uint[] { leftBound, rightBound };

            return bounds;
        }

        static Random randGenerator;

        const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        const int NumberOfProducts = 500000;
        const int PriceSearchesCount = 10000;

        static void Main()
        {
            randGenerator = new Random();

            var watch = new Stopwatch();
            watch.Start();

            var products = new OrderedBag<Product>(GenerateAllProducts());

            watch.Stop();
            Console.WriteLine("Initialize time: {0}", watch.Elapsed);

            PrintTimeElapsedFor10000Searches(products);

            PrintFirst20ProductsInRange(products);
        }
    }
}
