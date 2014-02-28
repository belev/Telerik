using System;
using System.Collections.Generic;
using System.Diagnostics;
class OneTaskIsNotEnough
{
    static int step;
    private static int FindLastTurnedOnLamp(int n)
    {
        const int maxLamps = 2000000;

        int[] lampsOff = new int[maxLamps + 1];
        int[] lampsToTurnOn = new int[maxLamps + 1];
        int lampsLeft = n;

        for (int i = 1; i <= n; i++)
        {
            lampsOff[i] = i;
        }

        int step = 1;
        while (lampsLeft > 1)
        {
            int currentLampIndex = 1;

            while (currentLampIndex <= lampsLeft)
            {
                lampsToTurnOn[currentLampIndex] = step;
                currentLampIndex += step + 1;
            }

            int newCountOfLampsLeft = 0;
            for (int i = 1; i <= lampsLeft; i++)
            {
                if (lampsToTurnOn[i] != step)
                {
                    newCountOfLampsLeft++;
                    lampsOff[newCountOfLampsLeft] = lampsOff[i];
                }
            }

            lampsLeft = newCountOfLampsLeft;
            step++;
        }
        return lampsOff[1];
    }
    static int[] dx = { 1, 0, -1, 0 };
    static int[] dy = { 0, 1, 0, -1 };
    private static string IsBounded(string cmds)
    {
        int curX = 0;
        int curY = 0;
        int dirIndex = 0;

        for (int j = 0; j < 4; j++)
        {

            for (int i = 0; i < cmds.Length; i++)
            {
                if (cmds[i] == 'S')
                {
                    curX += dx[dirIndex];
                    curY += dy[dirIndex];
                    continue;
                }

                if (cmds[i] == 'R')
                {
                    dirIndex = (dirIndex + 1) % 4;
                    continue;
                }

                if (cmds[i] == 'L')
                {
                    dirIndex = (dirIndex + 3) % 4;
                    continue;
                }
            }
        }

        if (curX == 0 && curY == 0)
        {
            return "bounded";
        }
        else
        {
            return "unbounded";
        }
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string firstCmds = Console.ReadLine();
        string secondCmds = Console.ReadLine();

        int numberOfLastTurnedOnLamp = FindLastTurnedOnLamp(n);
        string isFirstBounded = IsBounded(firstCmds);
        string isSecondBounded = IsBounded(secondCmds);

        Console.WriteLine(numberOfLastTurnedOnLamp);
        Console.WriteLine(isFirstBounded);
        Console.WriteLine(isSecondBounded);
    }
}