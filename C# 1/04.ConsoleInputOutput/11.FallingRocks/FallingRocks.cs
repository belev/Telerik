using System;
using System.Collections.Generic;
using System.Threading;

struct Dwarf
{
    public int positionX;
    public int positionY;
    public ConsoleColor color;
    public string symbols;
}

struct Rock
{
    public int x;
    public int y;
    public ConsoleColor color;
    public string symbols;
}

class FallingRocks
{
    public static string[] specialSymbolsForRocks = new string[] { "^", "@", "*", "&", "+", "%", "$", "#", "!", ".", ";", "-" };

    public static ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Cyan, ConsoleColor.Gray, ConsoleColor.Green, ConsoleColor.White
                                                                , ConsoleColor.Blue, ConsoleColor.DarkGreen, ConsoleColor.DarkGray
                                                                , ConsoleColor.DarkCyan, ConsoleColor.DarkMagenta, ConsoleColor.Red, ConsoleColor.DarkGray };

    private static void Draw(int x, int y, ConsoleColor color, string symbols)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;

        Console.Write(symbols);
    }

    private static void SetBufferSize()
    {
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
    }

    private static Dwarf MoveDwarf(int playfieldWidth, Dwarf dwarf)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);

            while (Console.KeyAvailable)
            {
                Console.ReadKey();
            }

            if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                if (dwarf.positionX - 1 >= 0)
                {
                    dwarf.positionX--;
                }
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                if (dwarf.positionX + dwarf.symbols.Length - 1 < playfieldWidth)
                {
                    dwarf.positionX++;
                }
            }
        }

        return dwarf;
    }

    private static Rock CreateRock(int playfieldWidth, Random rand)
    {
        Rock rock = new Rock();

        int indexOfSymbol = rand.Next(0, 12);

        for (int i = 0; i < rand.Next(1, 6); i++)
        {
            rock.symbols += specialSymbolsForRocks[indexOfSymbol];
        }

        rock.y = 0;

        // take random color for every rock
        rock.color = colors[rand.Next(0, 11)];

        int randomPositionX = rand.Next(0, playfieldWidth - rock.symbols.Length + 1);
        rock.x = randomPositionX;

        return rock;
    }

    private static List<Rock> MoveRocks(List<Rock> rocks)
    {
        List<Rock> movedRocks = new List<Rock>();

        for (int i = 0; i < rocks.Count; i++)
        {
            Rock newRock = new Rock();

            newRock.x = rocks[i].x;

            if (rocks[i].y + 1 < Console.WindowHeight)
            {
                newRock.y = rocks[i].y + 1;
            }

            newRock.color = rocks[i].color;
            newRock.symbols = rocks[i].symbols;

            movedRocks.Add(newRock);
        }
        return movedRocks;
    }


    /*
     * Method for increasing acceleration if you want to play with changeble speed of falling
    static double increaseAcceleration(double userScore)
    {
        double acceleration = 0.0;
        if (userScore >= 2000)
        {
            acceleration = 0.1;
        }

        else if (userScore >= 1500 && userScore < 2000)
        {
            acceleration = 0.07;
        }

        else if (userScore >= 500 && userScore < 1500)
        {
            acceleration = 0.06;
        }

        else if (userScore >= 0 && userScore < 500)
        {
            acceleration = 0.05;
        }
        return acceleration;
    }
     */

    static int decreaseIntervalForCreatingRocks(int userScore)
    {
        int intervalForCreatingRocks = 0;

        if (userScore >= 0 && userScore < 300)
        {
            intervalForCreatingRocks = 4;
        }
        else if (userScore >= 300 && userScore < 600)
        {
            intervalForCreatingRocks = 3;
        }
        else if (userScore >= 600 && userScore < 1200)
        {
            intervalForCreatingRocks = 2;
        }
        else if (userScore >= 1200)
        {
            intervalForCreatingRocks = 1;
        }

        return intervalForCreatingRocks;
    }


    static void Main()
    {
        SetBufferSize();

        int playfieldWidth = 2 * Console.WindowWidth / 3;

        // creating the dwarf
        Dwarf dwarf = new Dwarf();
        dwarf.positionX = playfieldWidth / 2;
        dwarf.positionY = Console.WindowHeight - 1;
        dwarf.color = ConsoleColor.Yellow;
        dwarf.symbols = "(0)";

        Random rand = new Random();

        List<Rock> rocks = new List<Rock>();
        bool isHitted = false;

        int livesCount = 2;
        int counterWhenToCreateRock = 0;
        int userScore = 0;
        double acceleration = 0.0;

        int intervalForCreatingRocks = 0;

        while (true)
        {
            dwarf = MoveDwarf(playfieldWidth, dwarf);  // moving dwarf when left or right arrow is pressed

            // depending on the userScore, increase acceleration
            //acceleration = increaseAcceleration(userScore);

            intervalForCreatingRocks = decreaseIntervalForCreatingRocks(userScore); // in some conditions decrease the interval for creating rocks

            // in every intervalForCreatingRocks time we will create one rock and add it to the list of rocks
            if (counterWhenToCreateRock % intervalForCreatingRocks == 0)
            {
                counterWhenToCreateRock = 0;
                Rock createdRock = CreateRock(playfieldWidth, rand);
                rocks.Add(createdRock);
            }

            List<Rock> movedRocks = MoveRocks(rocks); // move rocks one position down

            for (int i = 0; i < movedRocks.Count; i++) // loop for every rock in movedRocks
            {
                Rock currentRock = new Rock();
                currentRock = movedRocks[i];

                // check if some rock hit the dwarf
                if (currentRock.y == dwarf.positionY && (dwarf.positionX <= currentRock.x + currentRock.symbols.Length - 1) && (dwarf.positionX + dwarf.symbols.Length - 1 >= currentRock.x))
                {
                    //if the dwarf is hit, and there is any lives left, decrease lives with 1 and set isHitted to true
                    if (livesCount - 1 >= 0)
                    {
                        livesCount--;
                        isHitted = true;
                    }
                }

                //check is there is no more lives, and if there isn't print some information ot the console
                if (livesCount <= 0)
                {
                    Console.Clear();
                    Draw(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 + 2, ConsoleColor.DarkRed, "GAME OVER");
                    Draw(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2 - 2, ConsoleColor.DarkRed, "Your score: " + userScore);
                    Draw(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 4, ConsoleColor.DarkRed, "Press any key to exit");

                    Console.ReadLine();
                    return;
                }

                //check if rock is on the board of the console, and if it is increase userScore with the lenght of the rock
                if (currentRock.y == Console.WindowHeight - 1 && !isHitted)
                {
                    userScore += currentRock.symbols.Length;
                }


            }

            rocks = movedRocks;

            // clear the console from previous output and after that print the moved rocks, the dwarf and some information on the right
            Console.Clear();

            //check if the dwarf is hit
            if (isHitted)
            {
                //if dwarf was hitted clear rocks so that we begin our game from the beggining and draw (X) with DarkRed to see that we were hitted
                rocks.Clear();
                Draw(dwarf.positionX, dwarf.positionY, ConsoleColor.DarkRed, "(X)");

            }
            else
            {
                //if it was not hitted than draw the dwarf
                Draw(dwarf.positionX, dwarf.positionY, dwarf.color, dwarf.symbols);
            }

            // draw every rock from the current list of rocks
            foreach (Rock rock in rocks)
            {
                Draw(rock.x, rock.y, rock.color, rock.symbols);
            }

            //print some information about the game
            Draw(playfieldWidth + 2, Console.WindowHeight / 2 - 6, ConsoleColor.Red, "Lives left: " + livesCount);
            Draw(playfieldWidth + 2, Console.WindowHeight / 2 - 2, ConsoleColor.Red, "Score: " + userScore);
            Draw(playfieldWidth + 2, Console.WindowHeight / 2 + 2, ConsoleColor.Red, "Time for rock falling: " + intervalForCreatingRocks);


            //if you want to play the game with acceleration, not with constant speed of falling

            /*
            if ((int) userScore * acceleration < 350)
            {
                Thread.Sleep(500 - (int) (userScore * acceleration));
            }
            else
            {
                Thread.Sleep(150);
            }
             */

            Thread.Sleep(150);

            counterWhenToCreateRock++;
            isHitted = false;
        }
    }
}

