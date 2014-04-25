using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace SokobanGame
{
    class Player
    {
        private int positionX;
        private int positionY;
        private int playerMovesCount;
        public int PositionX
        {
            get { return this.positionX; }
            set { this.positionX = value; }
        }
        public int PositionY
        {
            get { return this.positionY; }
            set { this.positionY = value; }
        }
        public int PlayerMovesCount
        {
            get { return this.playerMovesCount; }
            set { this.playerMovesCount = value; }
        }
        public Player(int x, int y)
        {
            this.positionX = x;
            this.positionY = y;
        }

        public int GetPositionStatus(char[,] board, int posX, int posY)
        {
            if (board[posX, posY] == '#')
            {
                return 0; // wall
            }
            else if (board[posX, posY] == ' ')
            {
                return 1; // whitespace
            }
            else if (board[posX, posY] == '$')
            {
                return 2; // box
            }
            else if (board[posX, posY] == '.')
            {
                return 3; // place for box
            }
            throw new ArgumentException("Invalid symbol, check level text file!");
        }
        public void PrintLastPosition()
        {
            //if the last position was a dot, print it and set it to dot in the board
            for (int i = 0; i < Sokoban.boardDotsCoordinates.Count; i += 2)
            {
                if (Sokoban.boardDotsCoordinates[i] == this.positionX && Sokoban.boardDotsCoordinates[i + 1] == this.positionY)
                {
                    Sokoban.board[this.positionX, this.positionY] = '.';
                    Console.SetCursorPosition(this.positionY + 2, this.positionX + 4);
                    Sokoban.PrintSymbol('.');
                    return;
                }
            }

            //if it is not a dot than put a whitespace
            Sokoban.board[this.positionX, this.positionY] = ' ';
            Console.SetCursorPosition(this.positionY + 2, this.positionX + 4);
            Sokoban.PrintSymbol(' ');
        }
        public void UpMovement(int positionStatusNumber)
        {
            if (positionStatusNumber == 1 || positionStatusNumber == 3)
            {
                //we reach a valid position to move (on whitespace or on place for box)
                PrintLastPosition();
                this.positionX--;
                Sokoban.board[this.positionX, this.positionY] = '@';
                Console.SetCursorPosition(this.positionY + 2, this.positionX + 4);
                Sokoban.PrintSymbol('@');

                this.playerMovesCount++;
            }
            else if (positionStatusNumber == 2)
            {
                //we hit a box and check the position after the box
                int nextPositionStatusNumber = GetPositionStatus(Sokoban.board, this.positionX - 2, this.positionY);

                if (nextPositionStatusNumber == 0 || nextPositionStatusNumber == 2)
                {
                    //it is wall or a box so we can not move the box
                    return;
                }
                else
                {
                    //a whitespace or a place for box -> move the box
                    PrintLastPosition();

                    Sokoban.board[--this.positionX, this.positionY] = '@';
                    Console.SetCursorPosition(this.positionY + 2, this.positionX + 4);
                    Sokoban.PrintSymbol('@');

                    Sokoban.board[this.positionX - 1, this.positionY] = '$';
                    Console.SetCursorPosition(this.positionY + 2, this.positionX + 3);
                    Sokoban.PrintSymbol('$');

                    this.playerMovesCount++;
                }
            }
        }
        public void DownMovement(int positionStatusNumber)
        {
            if (positionStatusNumber == 1 || positionStatusNumber == 3)
            {
                //reach a valid position to move
                PrintLastPosition();

                this.positionX++;
                Sokoban.board[this.positionX, this.positionY] = '@';
                Console.SetCursorPosition(this.positionY + 2, this.positionX + 4);
                Sokoban.PrintSymbol('@');

                this.playerMovesCount++;
            }
            else if (positionStatusNumber == 2)
            {
                //hit a box and check the position after the box
                int nextPositionStatusNumber = GetPositionStatus(Sokoban.board, this.positionX + 2, this.positionY);

                if (nextPositionStatusNumber == 0 || nextPositionStatusNumber == 2)
                {
                    //it is a wall or a box so we can not move the box
                    return;
                }
                else
                {
                    //it is a whitespace or a place for box we move the box
                    PrintLastPosition();

                    Sokoban.board[++this.positionX, this.positionY] = '@';
                    Console.SetCursorPosition(this.positionY + 2, this.positionX + 4);
                    Sokoban.PrintSymbol('@');

                    Sokoban.board[this.positionX + 1, this.positionY] = '$';
                    Console.SetCursorPosition(this.positionY + 2, this.positionX + 5);
                    Sokoban.PrintSymbol('$');

                    this.playerMovesCount++;
                }
            }
        }
        public void LeftMovement(int positionStatusNumber)
        {
            if (positionStatusNumber == 1 || positionStatusNumber == 3)
            {
                //reach a valid position to move
                PrintLastPosition();

                this.positionY--;
                Sokoban.board[this.positionX, this.positionY] = '@';

                Console.SetCursorPosition(this.positionY + 2, this.positionX + 4);
                Sokoban.PrintSymbol('@');

                this.playerMovesCount++;
            }
            else if (positionStatusNumber == 2)
            {
                //hit a box and check the position after the box
                int nextPositionStatusNumber = GetPositionStatus(Sokoban.board, this.positionX, this.positionY - 2);

                if (nextPositionStatusNumber == 0 || nextPositionStatusNumber == 2)
                {
                    //it is a wall or a box so we can not move the box
                    return;
                }
                else
                {
                    //it is a whitespace or a place for box -> we move the box
                    PrintLastPosition();

                    Sokoban.board[this.positionX, --this.positionY] = '@';
                    Console.SetCursorPosition(this.positionY + 2, this.positionX + 4);
                    Sokoban.PrintSymbol('@');

                    Sokoban.board[this.positionX, this.positionY - 1] = '$';
                    Console.SetCursorPosition(this.positionY + 1, this.positionX + 4);
                    Sokoban.PrintSymbol('$');

                    this.playerMovesCount++;
                }
            }

        }
        public void RightMovement(int positionStatusNumber)
        {
            if (positionStatusNumber == 1 || positionStatusNumber == 3)
            {
                //reach a valid position to move
                PrintLastPosition();

                this.positionY++;
                Sokoban.board[this.positionX, this.positionY] = '@';
                Console.SetCursorPosition(this.positionY + 2, this.positionX + 4);
                Sokoban.PrintSymbol('@');

                this.playerMovesCount++;
            }
            else if (positionStatusNumber == 2)
            {
                //hit a box and check the position after the box
                int nextPositionStatusNumber = GetPositionStatus(Sokoban.board, this.positionX, this.positionY + 2);

                if (nextPositionStatusNumber == 0 || nextPositionStatusNumber == 2)
                {
                    //it is a wall or a box so we can not move the box
                    return;
                }
                else
                {
                    //it is a whitespace or a place for box -> move the box
                    PrintLastPosition();

                    Sokoban.board[this.positionX, ++this.positionY] = '@';
                    Console.SetCursorPosition(this.positionY + 2, this.positionX + 4);
                    Sokoban.PrintSymbol('@');

                    Sokoban.board[this.positionX, this.positionY + 1] = '$';
                    Console.SetCursorPosition(this.positionY + 3, this.positionX + 4);
                    Sokoban.PrintSymbol('$');
                    this.playerMovesCount++;
                }
            }
        }
        public bool CanProcessCommand(char[,] board)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);

            while (Console.KeyAvailable)
            {
                Console.ReadKey();
            }

            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                int positionStatusNumber = GetPositionStatus(board, this.positionX - 1, this.positionY);
                UpMovement(positionStatusNumber);
                return true;
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                int positionStatusNumber = GetPositionStatus(board, this.positionX + 1, this.positionY);
                DownMovement(positionStatusNumber);
                return true;
            }
            else if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                int positionStatusNumber = GetPositionStatus(board, this.positionX, this.positionY - 1);
                LeftMovement(positionStatusNumber);
                return true;
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                int positionStatusNumber = GetPositionStatus(board, this.positionX, this.positionY + 1);
                RightMovement(positionStatusNumber);
                return true;
            }
            else if (pressedKey.Key == ConsoleKey.R)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 3);
                Sokoban.ReadLevelInfo(Sokoban.level);
                Sokoban.PrintBoard();
                int[] playerStartPosition = Sokoban.FindPlayerStartPosition();

                this.positionX = playerStartPosition[0];
                this.positionY = playerStartPosition[1];
                this.playerMovesCount = 0;

                return true;
            }
            else if (pressedKey.Key == ConsoleKey.E)
            {
                Console.SetCursorPosition(0, board.GetLength(0) + 3);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You chose to exit the game!");
                Console.WriteLine("Goodbye. : )");
                Environment.Exit(0);
                return true;
            }
            return false;
        }
    }
    class Sokoban
    {
        public static void ReadLevelInfo(int level)
        {
            try
            {
                string path = @"..\..\Level" + level + ".txt";
                StreamReader reader = new StreamReader(path);

                using (reader)
                {
                    string[] boardDimentions = reader.ReadLine().Split(' ');

                    int rows = int.Parse(boardDimentions[0]);
                    int cols = int.Parse(boardDimentions[1]);

                    board = new char[rows, cols];

                    for (int row = 0; row < rows; row++)
                    {
                        string line = reader.ReadLine();

                        for (int col = 0; col < cols; col++)
                        {
                            board[row, col] = line[col];
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

        }
        public static void PrintBoard()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                Console.SetCursorPosition(2, row + 4);

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    PrintSymbol(board[row, col]);
                }
                Console.WriteLine();
            }
        }
        public static void PrintSymbol(char symbol)
        {
            if (symbol == ' ')
            {
                Console.Write(' ');
            }
            else if (symbol == '@')
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write('@');
            }
            else if (symbol == '$')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write('$');
            }
            else if (symbol == '.')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write('.');
            }
            else if (symbol == '#')
            {
                Console.ResetColor();
                Console.Write('#');
            }
        }

        public static int[] FindPlayerStartPosition()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == '@')
                    {
                        int[] positions = new int[2];
                        positions[0] = row;
                        positions[1] = col;
                        return positions;
                    }
                }
            }
            return new int[0];
        }
        /// <summary>
        ///  add the coordinates of the dots on the board
        ///  on even positions in the list is the row position
        ///  on odd positions in the list is the col position
        /// </summary>
        public static void GetDotsPositions()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == '.')
                    {
                        boardDotsCoordinates.Add(row);
                        boardDotsCoordinates.Add(col);
                    }
                }
            }
        }
        private static bool IsLevelCleared()
        {
            for (int i = 0; i < boardDotsCoordinates.Count; i += 2)
            {
                if (board[boardDotsCoordinates[i], boardDotsCoordinates[i + 1]] != '$')
                {
                    return false;
                }
            }
            return true;
        }
        private static void SetBufferSize()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
        }
        private static void PrintGameInfo(int movesCount)
        {
            Console.SetCursorPosition(board.GetLength(0) / 2 + 2, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Level " + level);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(board.GetLength(1) + 10, board.GetLength(0) / 4 + 3);
            Console.WriteLine("To restart: R");

            Console.SetCursorPosition(board.GetLength(1) + 10, board.GetLength(0) / 4 + 6);
            Console.WriteLine("To exit: E");

            Console.SetCursorPosition(board.GetLength(1) + 10, board.GetLength(0) / 4 + 9);
            Console.WriteLine("Moves count: {0}", movesCount);
        }

        private static bool Menu()
        {
            while (true)
            {
                Console.CursorVisible = false;
                Console.Clear();
                Console.WriteLine("Sokoban");
                Console.WriteLine("1. Start");
                Console.WriteLine("2. Level choice");
                Console.WriteLine("3. Game info");
                Console.WriteLine("4. Exit");
                Console.WriteLine();
                Console.WriteLine("Use the keys (0-9) to navigate throug the menu:");

                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.D1 || pressedKey.Key == ConsoleKey.NumPad1)
                {
                    level = 1;
                    return true;
                }
                else if (pressedKey.Key == ConsoleKey.D2 || pressedKey.Key == ConsoleKey.NumPad2)
                {
                    if (LevelMenu())
                    {
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.D3 || pressedKey.Key == ConsoleKey.NumPad3)
                {
                    if (InfoMenu())
                    {
                        continue;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.D4 || pressedKey.Key == ConsoleKey.NumPad4)
                {
                    Console.WriteLine();
                    Console.WriteLine("You chose to exit.");
                    Console.WriteLine("Goodbye. : )");
                }
                else
                {
                    continue;
                }

                return false;
            }
        }

        private static bool LevelMenu()
        {
            while (true)
            {
                Console.CursorVisible = false;
                Console.Clear();
                Console.WriteLine("0. Go back");
                Console.WriteLine("1. Level 1");
                Console.WriteLine("2. Level 2");
                Console.WriteLine();
                Console.WriteLine("Use the keys (0-9) to navigate throug the menu:");

                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.D0 || pressedKey.Key == ConsoleKey.NumPad0)
                {
                    return false;
                }
                else if (pressedKey.Key == ConsoleKey.D1 || pressedKey.Key == ConsoleKey.NumPad1)
                {
                    level = 1;
                    return true;
                }
                else if (pressedKey.Key == ConsoleKey.D2 || pressedKey.Key == ConsoleKey.NumPad2)
                {
                    level = 2;
                    return true;
                }
                else
                {
                    continue;
                }
            }
        }

        private static bool InfoMenu()
        {
            while (true)
            {
                Console.CursorVisible = false;
                Console.Clear();
                Console.WriteLine("Sokoban information:");
                Console.WriteLine("Sokoban is a type of transport puzzle, in which the player pushes boxes trying");
                Console.WriteLine("to get them to storage locations. In the game the storage locations are");
                Console.WriteLine("indicated with \".\" and the boxes with \"$\". The player itself is indicated with");
                Console.WriteLine(" \"@\". Use the arrow keys to control the player and navigate throug the level.");
                Console.WriteLine();
                Console.WriteLine("0. Go back.");

                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.D0 || pressedKey.Key == ConsoleKey.NumPad0)
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }
           
        }

        public static List<int> boardDotsCoordinates = new List<int>();
        public static char[,] board;
        public static int level;
        const int maxLevel = 2;
        static void Main()
        {
            if (Menu())
            {
                while (level <= maxLevel)
                {
                    ReadLevelInfo(level);
                    GetDotsPositions();
                    SetBufferSize();
                    //playerStartPosition[0] - > row
                    //playerStartPosition[1] - > col
                    int[] playerStartPosition = FindPlayerStartPosition();

                    Player player = new Player(playerStartPosition[0], playerStartPosition[1]);
                    Console.Clear();
                    PrintGameInfo(player.PlayerMovesCount);
                    PrintBoard();
                    while (true)
                    {
                        if (!player.CanProcessCommand(board))
                        {
                            continue;
                        }

                        PrintGameInfo(player.PlayerMovesCount);

                        if (IsLevelCleared())
                        {
                            Console.SetCursorPosition(0, board.GetLength(0) + 5);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Level clear !");
                            if (level < maxLevel)
                            {
                                Console.WriteLine("You will be automatically transfered to next level.");
                            }
                            else
                            {
                                Console.WriteLine("Congratulations! You cleared all levels!");
                            }
                            Console.Beep(2000, 300);
                            Console.Beep(2000, 300);
                            Console.Beep(2000, 300);
                            Thread.Sleep(500);
                            break;
                        }
                    }
                    level++;
                }
            }
        }
    }
}
