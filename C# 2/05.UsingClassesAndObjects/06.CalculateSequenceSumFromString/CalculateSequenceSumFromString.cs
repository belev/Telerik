using System;

class CalculateSequenceSumFromString
{
    //solution without split
    static long CalculateSum(string sequence)
    {
        string tmpSequence = "";
        long sum = 0;

        for (int i = 0; i < sequence.Length; i++)
        {
            tmpSequence += sequence[i];

            if (i == sequence.Length - 1 || sequence[i + 1] == ' ')
            {
                sum += long.Parse(tmpSequence);
                tmpSequence = "";
            }
        }

        return sum;
    }
    static long CalculateSumWithSplit(string sequence)
    {
        string[] splitted = sequence.Split(' ');
        long sum = 0;

        for (int i = 0; i < splitted.Length; i++)
        {
            sum += long.Parse(splitted[i]);
        }

        return sum;
    }

    static void Main()
    {
        string sequence = Console.ReadLine();

        Console.WriteLine(CalculateSum(sequence));

        Console.WriteLine(CalculateSumWithSplit(sequence));
    }
}

