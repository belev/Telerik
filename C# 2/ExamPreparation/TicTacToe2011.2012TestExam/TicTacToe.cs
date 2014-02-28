using System;
class TicTacToe
{
    static char[,] board;
    static bool isFirstOnMove;
    static void Main()
    {
        board = new char[3, 3];

        int count = 0;
        for (int i = 0; i < 3; i++)
        {
            string line = Console.ReadLine();

            for (int j = 0; j < 3; j++)
            {
                board[i, j] = line[j];

                if (line[j] == 'X')
                {
                    count++;
                }
                else if (line[j] == 'O')
                {
                    count--;
                }
            }
        }
        isFirstOnMove = (count == 0);

        firstWinsCount = 0;
        secondWinsCount = 0;
        drawsCount = 0;

        Solve(0, 0);

        Console.WriteLine(firstWinsCount);
        Console.WriteLine(drawsCount);
        Console.WriteLine(secondWinsCount);
    }
    static int firstWinsCount;
    static int secondWinsCount;
    static int drawsCount;
  
    static bool isFull;

    private static bool CheckHorizontal(int hor)
    {
        if (board[hor, 0] == board[hor, 1] && board[hor, 1] == board[hor, 2])
        {
            if (board[hor, 0] != '-')
            {
                return true;
            }
        }
        return false;
    }
    private static bool CheckVertical(int ver)
    {
        if (board[0, ver] == board[1, ver] && board[1, ver] == board[2, ver])
        {
            if (board[0, ver] != '-')
            {
                return true;
            }
        }
        return false;
    }
    private static bool CheckRightDiagonal()
    {
        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[2, 2] != '-')
        {
            return true;
        }
        return false;
    }
    private static bool CheckLeftDiagonal()
    {
        if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[2, 0] != '-')
        {
            return true;
        }
        return false;
    }
    private static void Solve(int row, int col)
    {
        if (CheckHorizontal(0) || CheckHorizontal(1) || CheckHorizontal(2) || CheckVertical(0) || CheckVertical(1) || CheckVertical(2)|| CheckRightDiagonal() || CheckLeftDiagonal())
        {
            if (isFirstOnMove)
            {
                secondWinsCount++;
                return;
            }
            else
            {
                firstWinsCount++;
                return;
            }
        }
        isFull = true;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == '-')
                {
                    isFull = false;
                }
            }
        }

        if (isFull)
        {
            if (checkDraw())
            {
                drawsCount++;
                return;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == '-')
                {
                    if (isFirstOnMove)
                    {
                        board[i, j] = 'X';
                        isFirstOnMove = false;
                    }
                    else
                    {
                        board[i, j] = 'O';
                        isFirstOnMove = true;
                    }

                    Solve(i, j);
                    board[i, j] = '-';

                    if (isFirstOnMove)
                    {
                        isFirstOnMove = false;
                    }
                    else
                    {
                        isFirstOnMove = true;
                    }
                }
            }
        } 
    }

    private static bool checkDraw()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == '-')
                {
                    return false;
                }
            }
        }
        return true;
    }
}

