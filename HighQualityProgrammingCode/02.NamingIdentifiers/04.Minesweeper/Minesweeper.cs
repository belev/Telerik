namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        private const int MaxOpenCellsCount = 35;
        private static readonly Random Random = new Random();

        public static void Main(string[] args)
        {
            string command = string.Empty;

            char[,] playfield = CreatePlayfield();
            char[,] mines = SetMines();

            List<Player> topPlayers = new List<Player>(6);

            int openCellsCount = 0;
            int row = 0;
            int col = 0;

            bool hasExploded = false;
            bool isNewGame = true;
            bool hasReachedMaxCellsOpen = false;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Let's play \"Minesweeper\". Try to find all cells without steping on a mine.\n" +
                                      "Commands:\n" +
                                      "'top' shows players results,\n" +
                                      "'restart' restart game and begin a new one,\n" +
                                      "'exit' exits the game!\n");
                    DisplayPlayfield(playfield);
                    isNewGame = false;
                }

                Console.Write("Enter row and col : ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        row <= playfield.GetLength(0) &&
                        col <= playfield.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        DisplayPlayerResults(topPlayers);
                        break;
                    case "restart":
                        playfield = CreatePlayfield();
                        mines = SetMines();
                        DisplayPlayfield(playfield);

                        hasExploded = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                UpdateOpenCellsCount(playfield, mines, row, col);
                                openCellsCount++;
                            }

                            if (MaxOpenCellsCount == openCellsCount)
                            {
                                hasReachedMaxCellsOpen = true;
                            }
                            else
                            {
                                DisplayPlayfield(playfield);
                            }
                        }
                        else
                        {
                            hasExploded = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! invalid command\n");
                        break;
                }

                if (hasExploded)
                {
                    DisplayPlayfield(mines);

                    Console.Write("\nYou die with {0} points ", openCellsCount);
                    string nickName = Console.ReadLine();

                    Player currentPlayer = new Player(nickName, openCellsCount);

                    if (topPlayers.Count < 5)
                    {
                        topPlayers.Add(currentPlayer);
                    }
                    else
                    {
                        for (int i = 0; i < topPlayers.Count; i++)
                        {
                            if (topPlayers[i].Points < currentPlayer.Points)
                            {
                                topPlayers.Insert(i, currentPlayer);
                                topPlayers.RemoveAt(topPlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    topPlayers.Sort((Player r1, Player r2) => r2.Name.CompareTo(r1.Name));
                    topPlayers.Sort((Player r1, Player r2) => r2.Points.CompareTo(r1.Points));

                    DisplayPlayerResults(topPlayers);

                    playfield = CreatePlayfield();
                    mines = SetMines();

                    openCellsCount = 0;
                    hasExploded = false;
                    isNewGame = true;
                }

                if (hasReachedMaxCellsOpen)
                {
                    Console.WriteLine("\nCongratulations! You have successfully opened {0} cells", MaxOpenCellsCount);
                    DisplayPlayfield(mines);

                    Console.WriteLine("Enter your nick name: ");
                    string nickName = Console.ReadLine();
                    Player currentPlayer = new Player(nickName, openCellsCount);

                    topPlayers.Add(currentPlayer);
                    DisplayPlayerResults(topPlayers);

                    playfield = CreatePlayfield();
                    mines = SetMines();

                    openCellsCount = 0;
                    hasReachedMaxCellsOpen = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria!");
            Console.Read();
        }

        private static void DisplayPlayerResults(List<Player> players)
        {
            Console.WriteLine("\nPoints:");

            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, players[i].Name, players[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The players results list is empty!\n");
            }
        }

        private static void UpdateOpenCellsCount(char[,] playfield, char[,] mines, int row, int col)
        {
            char minesCount = NeighbourMinesCount(mines, row, col);
            mines[row, col] = minesCount;
            playfield[row, col] = minesCount;
        }

        private static void DisplayPlayfield(char[,] playfield)
        {
            int rowsCount = playfield.GetLength(0);
            int colsCount = playfield.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < rowsCount; row++)
            {
                Console.Write("{0} | ", row);

                for (int col = 0; col < colsCount; col++)
                {
                    Console.Write(string.Format("{0} ", playfield[row, col]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayfield()
        {
            int playfieldRowsCount = 5;
            int playfieldColsCount = 10;

            char[,] playfield = new char[playfieldRowsCount, playfieldColsCount];

            for (int row = 0; row < playfieldRowsCount; row++)
            {
                for (int col = 0; col < playfieldColsCount; col++)
                {
                    playfield[row, col] = '?';
                }
            }

            return playfield;
        }

        private static char[,] SetMines()
        {
            int playfieldRowsCount = 5;
            int playfieldColsCount = 10;

            char[,] playfield = new char[playfieldRowsCount, playfieldColsCount];

            for (int row = 0; row < playfieldRowsCount; row++)
            {
                for (int col = 0; col < playfieldColsCount; col++)
                {
                    playfield[row, col] = '-';
                }
            }

            List<int> randomNumbers = new List<int>();

            while (randomNumbers.Count < 15)
            {
                int randomNumber = Random.Next(50);
                if (!randomNumbers.Contains(randomNumber))
                {
                    randomNumbers.Add(randomNumber);
                }
            }

            foreach (int number in randomNumbers)
            {
                int col = number / playfieldColsCount;
                int row = number % playfieldColsCount;

                if (row == 0 && number != 0)
                {
                    col--;
                    row = playfieldColsCount;
                }
                else
                {
                    row++;
                }

                playfield[col, row - 1] = '*';
            }

            return playfield;
        }

        private static void NeighbourMinesCount(char[,] playfield)
        {
            int colsCount = playfield.GetLength(0);
            int rowsCount = playfield.GetLength(1);

            for (int row = 0; row < colsCount; row++)
            {
                for (int col = 0; col < rowsCount; col++)
                {
                    if (playfield[row, col] != '*')
                    {
                        char neighbourBombsCount = NeighbourMinesCount(playfield, row, col);
                        playfield[row, col] = neighbourBombsCount;
                    }
                }
            }
        }

        private static char NeighbourMinesCount(char[,] playfield, int curRow, int curCol)
        {
            int minesCount = 0;
            int rowsCount = playfield.GetLength(0);
            int colsCount = playfield.GetLength(1);

            if (curRow - 1 >= 0)
            {
                if (playfield[curRow - 1, curCol] == '*')
                {
                    minesCount++;
                }
            }

            if (curRow + 1 < rowsCount)
            {
                if (playfield[curRow + 1, curCol] == '*')
                {
                    minesCount++;
                }
            }

            if (curCol - 1 >= 0)
            {
                if (playfield[curRow, curCol - 1] == '*')
                {
                    minesCount++;
                }
            }

            if (curCol + 1 < colsCount)
            {
                if (playfield[curRow, curCol + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((curRow - 1 >= 0) && (curCol - 1 >= 0))
            {
                if (playfield[curRow - 1, curCol - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((curRow - 1 >= 0) && (curCol + 1 < colsCount))
            {
                if (playfield[curRow - 1, curCol + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((curRow + 1 < rowsCount) && (curCol - 1 >= 0))
            {
                if (playfield[curRow + 1, curCol - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((curRow + 1 < rowsCount) && (curCol + 1 < colsCount))
            {
                if (playfield[curRow + 1, curCol + 1] == '*')
                {
                    minesCount++;
                }
            }

            return char.Parse(minesCount.ToString());
        }
    }
}