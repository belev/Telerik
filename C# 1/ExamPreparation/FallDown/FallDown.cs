using System;

class FallDown
{
    static void Main()
    {
        int[] numbers = new int[8];

        for (int i = 0; i < 8; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        for (int j = 0; j < 8; j++)
        {
            for (int i = 7; i > 0; i--)
            {
                for (int bitPos = 0; bitPos < 8; bitPos++)
                {
                    if ((numbers[i] >> bitPos & 1) == 0 && (numbers[i - 1] >> bitPos & 1) == 1)
                    {
                        numbers[i] |= (1 << bitPos);
                        numbers[i - 1] &= ~(1 << bitPos);
                    }
                }
            }
        }

        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}