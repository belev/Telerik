using System;

class Guitar
{
    private static bool IsPossible(int volume, int maxVolume)
    {
        return (volume >= 0 && volume <= maxVolume);
    }

    static void Main()
    {
        string[] rawVolumeChanges = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int startVolume = int.Parse(Console.ReadLine());
        int maxVolume = int.Parse(Console.ReadLine());

        int[] volumeChanges = new int[rawVolumeChanges.Length];

        int[] possible = new int[maxVolume + 1];
        possible[startVolume] = 1;

        for (int i = 0; i < rawVolumeChanges.Length; i++)
        {
            volumeChanges[i] = int.Parse(rawVolumeChanges[i]);
        }



        for (int i = 0; i < volumeChanges.Length; i++)
        {
            bool hasSolution = false;
            int[] newPossible = new int[maxVolume + 1];

            for (int j = 0; j < maxVolume + 1; j++)
            {
                if (possible[j] == 1)
                {
                    possible[j] = 0;

                    if (IsPossible(j - volumeChanges[i], maxVolume))
                    {
                        hasSolution = true;
                        newPossible[j - volumeChanges[i]] = 1;
                    }

                    if (IsPossible(j + volumeChanges[i], maxVolume))
                    {
                        hasSolution = true;
                        newPossible[j + volumeChanges[i]] = 1;
                    }
                }
            }

            possible = newPossible;

            if (!hasSolution)
            {
                Console.WriteLine(-1);
                break;
            }
        }

        for (int i = maxVolume; i >= 0; i--)
        {
            if (possible[i] == 1)
            {
                Console.WriteLine(i);
                break;
            }
        }
    }
}