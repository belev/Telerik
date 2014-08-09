namespace _03.BiDictionary
{
    using System;

    class Tester
    {
        static void Main()
        {
            var dictionary = new BiDictionary<int, double, string>();

            dictionary.Add(1, 1.5, "mariq");
            dictionary.Add(3, 3.01, "GANCHO");
            dictionary.Add(1, 1.5, "pesho");
            dictionary.Add(2, 50.9, "gosho");
            dictionary.Add(2, 50.9, "drago");
            dictionary.Add(2, 50.9, "dragan");

            var byFirstKey = dictionary.FindByFirstKey(1);
            Console.WriteLine("search by first key: {0}", string.Join(", ", byFirstKey));

            var bySecondKey = dictionary.FindBySecondKey(3.01);
            Console.WriteLine("search by second key: {0}", string.Join(", ", bySecondKey));

            var byBothKeys = dictionary.FindByBothKeys(2, 50.9);
            Console.WriteLine("search by both keys: {0}", string.Join(", ", byBothKeys));
        }
    }
}
