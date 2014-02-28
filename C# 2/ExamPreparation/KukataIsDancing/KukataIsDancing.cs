using System;
using System.Collections.Generic;
class KukataIsDancing
{
    static void ColorBoard()
    {
        board[0, 0] = 'R';
        board[0, 1] = 'B';
        board[0, 2] = 'R';

        board[1, 0] = 'B';
        board[1, 1] = 'G';
        board[1, 2] = 'B';

        board[2, 0] = 'R';
        board[2, 1] = 'B';
        board[2, 2] = 'R';
    }
    static char[,] board = new char[3, 3];
    //Right Down Left Up
    static int[] dx = { 0, 1, 0, -1 };
    static int[] dy = { 1, 0, -1, 0 };
    static int dirIndex;
    static void Main()
    {
        ColorBoard();

        int n = int.Parse(Console.ReadLine());

        List<string> result = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string moves = Console.ReadLine();

            int posX = 1;
            int posY = 1;
            dirIndex = 0;
            for (int j = 0; j < moves.Length; j++)
            {
                if (moves[j] == 'L')
                {
                    dirIndex = (dirIndex + 3) % 4;
                }
                else if (moves[j] == 'R')
                {
                    dirIndex = (dirIndex + 1) % 4;
                }
                else
                {
                    posX += dx[dirIndex];

                    posY += dy[dirIndex];

                    if (posX >= 3)
                    {
                        posX = 0;
                    }
                    else if (posX < 0)
                    {
                        posX = 2;
                    }

                    if (posY >= 3)
                    {
                        posY = 0;
                    }
                    else if (posY < 0)
                    {
                        posY = 2;
                    }
                }
            }

            if (board[posX, posY] == 'G')
            {
                result.Add("GREEN");
            }
            else if (board[posX, posY] == 'R')
            {
                result.Add("RED");
            }
            else if (board[posX, posY] == 'B')
            {
                result.Add("BLUE");
            }
        }

        foreach (string color in result)
        {
            Console.WriteLine(color);
        }
    }
}

