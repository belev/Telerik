using System;
using System.Text;
class EncodeDecodeString
{
    static string Encrypt(string text, string cipher)
    {
        StringBuilder result = new StringBuilder(text.Length);

        for (int i = 0; i < text.Length; i++)
        {
            result.Append((char) (text[i] ^ cipher[i % cipher.Length]));
        }

        return result.ToString();
    }
    static string Decrypt(string text, string cipher)
    {
        return Encrypt(text, cipher);
    }
    static void Main()
    {
        string text = Console.ReadLine();
        string cipher = Console.ReadLine();

        //whatever the input for text and cipher is, after we encrypt it and then decrypt the result is the same text as the input
        Console.WriteLine(Decrypt(Encrypt(text, cipher), cipher));
    }
}

