using System;

class NeuronMapping
{
    static void Main()
    {
        const int uintSizeInBits = sizeof(uint) * 8;
        string inputLine = Console.ReadLine();
        while (inputLine != "-1")
        {
            uint inputNumber = uint.Parse(inputLine);

            bool isInsideNeuron = false;
            bool isOnBoundary = false;
            bool beenInNeuron = false;

            for (int i = 0; i < uintSizeInBits; i++)
            {
                uint mask = 1U << i;
                if ((inputNumber & mask) != 0)
                {
                    isOnBoundary = true;
                    if (isInsideNeuron)
                    {
                        isInsideNeuron = false;
                        beenInNeuron = true;
                    }

                    inputNumber &= (~mask);
                }
                else
                {
                    if (!beenInNeuron && isOnBoundary)
                    {
                        isInsideNeuron = true;
                        isOnBoundary = false;
                    }

                    if (isInsideNeuron)
                    {
                        inputNumber |= mask;
                    }
                }
            }

            if (!beenInNeuron)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(inputNumber);
            }

            inputLine = Console.ReadLine();
        }
    }
}