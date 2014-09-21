namespace _06.SecretLanguage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class SecretLanguage
    {
        private static Dictionary<string, HashSet<string>> words;
        private static string message;
        private static int wordsCount;

        private static void Main()
        {
            ReadInput();
            FindMinimumTransformationPrice();
        }

        private static void ReadInput()
        {
            words = new Dictionary<string, HashSet<string>>();
            message = Console.ReadLine();
            wordsCount = int.Parse(Console.ReadLine());

            var inputWords = Console.ReadLine().Split(' ').Select(x => x).ToArray();

            foreach (var inputWord in inputWords)
            {
                var wordAsArray = inputWord.ToCharArray().OrderBy(x => x).ToArray();
                var sortedWord = new string(wordAsArray);

                if (!words.ContainsKey(sortedWord))
                {
                    words.Add(sortedWord, new HashSet<string>());
                }

                words[sortedWord].Add(inputWord);
            }
        }

        private static void FindMinimumTransformationPrice()
        {
            var prices = Enumerable.Repeat(int.MaxValue, message.Length + 2).ToArray();

            prices[0] = 0;

            var wordUntilNow = new StringBuilder();
            var sortedWord = new List<char>();

            for (int i = 0; i < message.Length; i++)
            {
                wordUntilNow.Append(message[i]);
                sortedWord.Add(message[i]);
                sortedWord.Sort();
                var sortedWordAsString = string.Join("", sortedWord);

                if (words.ContainsKey(sortedWordAsString))
                {
                    foreach (var word in words[sortedWordAsString])
                    {
                        var price = GetTransformationPrice(wordUntilNow.ToString(), word);
                        prices[i + 1] = Math.Min(price, prices[i + 1]);
                    }
                    wordUntilNow.Clear();
                    sortedWord = new List<char>();
                }
            }

            if (prices[message.Length] == int.MaxValue)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(prices.Where(x => x != int.MaxValue).Sum());
            }
        }

        static int GetTransformationPrice(string wordAtMessage, string wordAtLanguage)
        {
            int countPrice = 0;

            for (int i = 0; i < wordAtLanguage.Length; i++)
            {
                if (wordAtLanguage[i] != wordAtMessage[i])
                {
                    countPrice++;
                }
            }

            return countPrice;
        }
    }
}