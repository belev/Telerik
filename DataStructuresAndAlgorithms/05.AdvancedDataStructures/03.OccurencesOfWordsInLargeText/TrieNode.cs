namespace _03.OccurencesOfWordsInLargeText
{
    using System.Collections.Generic;

    public class TrieNode
    {
        public TrieNode(char value, bool isWord)
        {
            this.Value = value;
            this.IsWord = isWord;
            this.Children = new Dictionary<char, TrieNode>();

            if (isWord)
            {
                this.Count = 1;
            }
            else
            {
                this.Count = 0;
            }
        }

        public TrieNode(char value)
            : this(value, false)
        {
        }

        public TrieNode(bool isWord)
            : this(' ', isWord)
        {
        }

        public char Value { get; private set; }

        public bool IsWord { get; private set; }

        public int Count { get; private set; }

        public Dictionary<char, TrieNode> Children { get; set; }

        public void AddChild(char value, bool isWord)
        {
            if (this.Children.ContainsKey(value))
            {
                if (isWord)
                {
                    this.Children[value].IsWord = true;
                    this.Children[value].Count++;
                }
            }
            else
            {
                this.Children.Add(value, new TrieNode(value, isWord));
            }
        }
    }
}
