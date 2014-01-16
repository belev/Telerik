using System;
using System.Text;
class ExtractSentencesContainingGivenWord
{
    static bool IsValidPositionInSentence(int index, int sentenceLength)
    {
        return (index >= 0 && index < sentenceLength);
    }
    static void Main()
    {
        string text = Console.ReadLine();
        string word = Console.ReadLine();

        string[] sentences = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < sentences.Length; i++)
        {
            int indexOfWord = sentences[i].IndexOf(word);

            if (indexOfWord == -1)
            {
                continue;
            }
            else
            {
                while (indexOfWord != -1)
                {
                    if (IsValidPositionInSentence(indexOfWord - 1, sentences[i].Length) && IsValidPositionInSentence(indexOfWord + word.Length, sentences[i].Length))
                    {
                        if (char.IsLetter(sentences[i][indexOfWord - 1]) == false && char.IsLetter(sentences[i][indexOfWord + word.Length]) == false)
                        {
                            result.Append(sentences[i].Trim() + '.');

                            if (i != sentences.Length - 1)
                            {
                                result.AppendLine();
                            }
                        }
                    }
                    else if (IsValidPositionInSentence(indexOfWord - 1, sentences[i].Length))
                    {
                        if (char.IsLetter(sentences[i][indexOfWord - 1]) == false)
                        {
                            result.Append(sentences[i].Trim() + '.');

                            if (i != sentences.Length - 1)
                            {
                                result.AppendLine();
                            }
                        }
                    }
                    else if (IsValidPositionInSentence(indexOfWord + word.Length, sentences[i].Length))
                    {
                        if (!char.IsLetter(sentences[i][indexOfWord + word.Length]))
                        {
                            result.Append(sentences[i].Trim() + '.');

                            if (i != sentences.Length - 1)
                            {
                                result.AppendLine();
                            }
                        }
                    }

                    indexOfWord = sentences[i].IndexOf(word, indexOfWord + word.Length);
                }
            }
        }
        Console.WriteLine(result.ToString());
    }
}

