namespace _03.OccurencesOfWordsInLargeText
{
    using System;

    public class Trie
    {
        private const char RootSymbol = '\0';
        private readonly char[] Separators = { ' ', ',', '!', '.', ',', '?', '-', '\r', '\n' };

        private TrieNode root;

        public Trie()
        {
            this.root = new TrieNode(RootSymbol, false);
        }

        public void BuildTrie(string text)
        {
            var wordsInText = text.Split(Separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in wordsInText)
            {
                this.AddWord(word.ToLower());
            }
        }

        public void AddWord(string word)
        {
            var currentNode = this.root;

            bool isWord = false;

            for (int i = 0; i < word.Length; i++)
            {
                if (i == word.Length - 1)
                {
                    isWord = true;
                }

                currentNode.AddChild(word[i], isWord);

                currentNode = currentNode.Children[word[i]];
            }
        }

        public int GetWordOccurences(string word)
        {
            var currentNode = this.root;
            string wordToLower = word.ToLower();

            for (int i = 0; i < wordToLower.Length; i++)
            {
                if (!currentNode.Children.ContainsKey(wordToLower[i]))
                {
                    return -1;
                }

                currentNode = currentNode.Children[wordToLower[i]];

                if (i == wordToLower.Length - 1 && currentNode.IsWord)
                {
                    return currentNode.Count;
                }
            }

            return -1;
        }

        public bool ContainsWord(string word)
        {
            if (this.GetWordOccurences(word) == -1)
            {
                return false;
            }

            return true;
        }
    }
}
