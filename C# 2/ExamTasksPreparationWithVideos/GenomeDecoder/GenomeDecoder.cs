using System;
using System.Text;

class GenomeDecoder
{
    static void Main()
    {
        string input = Console.ReadLine();
        string encodedGenome = Console.ReadLine();

        string[] inputWithoutWhitespace = input.Split(' ');

        int n = int.Parse(inputWithoutWhitespace[0]);
        int m = int.Parse(inputWithoutWhitespace[1]);

        StringBuilder decodedGenome = new StringBuilder();
        int number = 0;

        for (int i = 0; i < encodedGenome.Length; i++)
        {
            if (char.IsDigit(encodedGenome[i]))
            {
                number = number * 10 + (encodedGenome[i] - '0');
            }
            else
            {
                if (number == 0)
                {
                    number = 1;
                }
                decodedGenome.Append(new string(encodedGenome[i], number));
                number = 0;
            }
        }

        int numberOfRows = (int) Math.Ceiling((decimal) decodedGenome.ToString().Length / (decimal) n);
        int padSize = numberOfRows.ToString().Length;

        for (int i = 1; i <= numberOfRows; i++)
        {
            string iAsString = i.ToString();
            StringBuilder lineToOutput = new StringBuilder();

            lineToOutput.Append(new string(' ', padSize - iAsString.Length));
            lineToOutput.Append(iAsString);
            
            for (int j = (i - 1) * n; j <= i * n - 1; j++)
            {
                if ((j - (i - 1) * n) % m == 0)
                {
                    lineToOutput.Append(' ');
                }

                if (j >= decodedGenome.Length)
                {
                    break;
                }
                lineToOutput.Append(decodedGenome[j]);
            }

            Console.WriteLine(lineToOutput.ToString());
        }
    }
}