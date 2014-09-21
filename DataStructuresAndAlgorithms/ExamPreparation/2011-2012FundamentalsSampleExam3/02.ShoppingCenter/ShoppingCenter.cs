namespace _02.ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class ShoppingCenter
    {
        private const string AddProductCommand = "AddProduct";
        private const string FindProductsByNameCommand = "FindProductsByName";
        private const string DeleteProductsCommand = "DeleteProducts";
        private const string FindProductsByPriceRangeCommand = "FindProductsByPriceRange";
        private const string FindProductsByProducerCommand = "FindProductsByProducer";

        private const string NoProductsFound = "No products found";
        private const string ProductAdded = "Product added";

        private static List<Product> products;

        private static StringBuilder outputResult;

        private static void Main()
        {
            products = new List<Product>();
            outputResult = new StringBuilder();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine();

                ProcessCommand(command);
            }

            outputResult.Length--;
            Console.WriteLine(outputResult.ToString());
        }

        private static void ProcessCommand(string command)
        {
            var commandNameEndIndex = command.IndexOf(' ');
            var commandName = command.Substring(0, commandNameEndIndex);
            var splittedCommandParameters = command.Substring(commandNameEndIndex + 1).Split(';');

            if (commandName == AddProductCommand)
            {
                var name = splittedCommandParameters[0];
                var price = decimal.Parse(splittedCommandParameters[1]);
                var producer = splittedCommandParameters[2];

                AddProduct(name, price, producer);
            }
            else if (commandName == FindProductsByNameCommand)
            {
                var nameToSearch = splittedCommandParameters[0];

                FindProductsByName(nameToSearch);
            }
            else if (commandName == FindProductsByProducerCommand)
            {
                var producerToSearch = splittedCommandParameters[0];

                FindProductsByProducer(producerToSearch);
            }
            else if (commandName == FindProductsByPriceRangeCommand)
            {
                var fromPrice = decimal.Parse(splittedCommandParameters[0]);
                var toPrice = decimal.Parse(splittedCommandParameters[1]);

                FindProductsByPriceRange(fromPrice, toPrice);
            }
            else if (commandName == DeleteProductsCommand)
            {
                if (splittedCommandParameters.Length == 1)
                {
                    var producer = splittedCommandParameters[0];

                    DeleteProductsByProducer(producer);
                }
                else
                {
                    var name = splittedCommandParameters[0];
                    var producer = splittedCommandParameters[1];

                    DeleteProductsByNameAndProducer(name, producer);
                }
            }
        }
        private static void AddProduct(string name, decimal price, string producer)
        {
            var productToAdd = new Product()
            {
                Name = name,
                Price = price,
                Producer = producer
            };

            products.Add(productToAdd);

            outputResult.AppendLine(ProductAdded);
        }

        private static void FindProductsByName(string nameToSearch)
        {
            var searchedProducts = products.Where(p => p.Name == nameToSearch).OrderBy(p => p.Name).ThenBy(p => p.Producer).ThenBy(p => p.Price);

            if (searchedProducts.Count() > 0)
            {
                foreach (var product in searchedProducts)
                {
                    outputResult.AppendLine(product.ToString());
                }
            }
            else
            {
                outputResult.AppendLine(NoProductsFound);
            }
        }

        private static void FindProductsByProducer(string producerToSearch)
        {
            var searchedProducts = products.Where(p => p.Producer == producerToSearch).OrderBy(p => p.Name).ThenBy(p => p.Producer).ThenBy(p => p.Price);

            if (searchedProducts.Count() > 0)
            {
                foreach (var product in searchedProducts)
                {
                    outputResult.AppendLine(product.ToString());
                }
            }
            else
            {
                outputResult.AppendLine(NoProductsFound);
            }
        }

        private static void FindProductsByPriceRange(decimal fromPrice, decimal toPrice)
        {
            var searchedProducts = products.Where(p => p.Price >= fromPrice && p.Price <= toPrice).OrderBy(p => p.Name).ThenBy(p => p.Producer).ThenBy(p => p.Price);

            if (searchedProducts.Count() > 0)
            {
                foreach (var product in searchedProducts)
                {
                    outputResult.AppendLine(product.ToString());
                }
            }
            else
            {
                outputResult.AppendLine(NoProductsFound);
            }
        }

        private static void DeleteProductsByProducer(string producer)
        {
            int result = products.RemoveAll(p => p.Producer == producer);

            if (result > 0)
            {
                outputResult.AppendLine(string.Format("{0} products deleted", result));
            }
            else
            {
                outputResult.AppendLine(NoProductsFound);
            }
        }

        private static void DeleteProductsByNameAndProducer(string name, string producer)
        {
            int result = products.RemoveAll(p => p.Name == name && p.Producer == producer);

            if (result > 0)
            {
                outputResult.AppendLine(string.Format("{0} products deleted", result));
            }
            else
            {
                outputResult.AppendLine(NoProductsFound);
            }
        }
    }


    internal class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Producer { get; set; }

        public override string ToString()
        {
            var result = '{' + string.Format("{0};{1};{2:0.00}", this.Name, this.Producer, this.Price) + '}';
            return result;
        }
    }
}