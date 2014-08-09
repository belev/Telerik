namespace _02.ProductsSearch
{
    using System;

    public class Product : IComparable<Product>
    {
        public Product(uint price, string name)
        {
            this.Price = price;
            this.Name = name;
        }

        public uint Price { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.Name, this.Price);
        }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
