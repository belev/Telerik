namespace CardWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Numerics;

    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfAllGames = int.Parse(Console.ReadLine());
            const int cardsToPlayer = 3;
            BigInteger playerOneGlobalScore = 0;
            BigInteger playerTwoGlobalScore = 0;
            bool xCardDrawByPlayerOne = false;
            bool xCardDrawByPlayerTwo = false;
            int gamesWonByPlayerOne = 0;
            int gamesWonByPlayerTwo = 0;

            for (int i = 0; i < numberOfAllGames; i++)
            {
                int currentPlayerOneGamesScore = 0;
                int curentPlayerTwoGameScore = 0;

                for (int j = 0; j < cardsToPlayer; j++)
                {
                    string currentCard = Console.ReadLine();

                    switch (currentCard)
                    {
                        case "J":
                            currentPlayerOneGamesScore += 11;
                            break;
                        case "Q":
                            currentPlayerOneGamesScore += 12;
                            break;
                        case "K":
                            currentPlayerOneGamesScore += 13;
                            break;
                        case "A":
                            currentPlayerOneGamesScore += 1;
                            break;
                        case "Z": playerOneGlobalScore *= 2; break;
                        case "Y": playerOneGlobalScore -= 200; break;
                        case "X": xCardDrawByPlayerOne = true; break;
                        default: currentPlayerOneGamesScore += 12 - int.Parse(currentCard);
                            break;
                    }
                }

                for (int j = 0; j < cardsToPlayer; j++)
                {
                    string currentCard = Console.ReadLine();

                    switch (currentCard)
                    {
                        case "J":
                            curentPlayerTwoGameScore += 11;
                            break;
                        case "Q":
                            curentPlayerTwoGameScore += 12;
                            break;
                        case "K":
                            curentPlayerTwoGameScore += 13;
                            break;
                        case "A":
                            curentPlayerTwoGameScore += 1;
                            break;
                        case "Z": playerTwoGlobalScore *= 2; break;
                        case "Y": playerTwoGlobalScore -= 200; break;
                        case "X": xCardDrawByPlayerTwo = true; break;
                        default: curentPlayerTwoGameScore += 12 - int.Parse(currentCard);
                            break;
                    }
                }

                if (xCardDrawByPlayerOne && xCardDrawByPlayerTwo)
                {
                    playerOneGlobalScore += 50;
                    playerTwoGlobalScore += 50;

                    xCardDrawByPlayerOne = false;
                    xCardDrawByPlayerTwo = false;
                }
                else if (xCardDrawByPlayerOne)
                {
                    break;
                }
                else if (xCardDrawByPlayerTwo)
                {
                    break;
                }

                if (currentPlayerOneGamesScore > curentPlayerTwoGameScore)
                {
                    playerOneGlobalScore += currentPlayerOneGamesScore;
                    gamesWonByPlayerOne++;
                }
                else if (currentPlayerOneGamesScore < curentPlayerTwoGameScore)
                {
                    playerTwoGlobalScore += curentPlayerTwoGameScore;
                    gamesWonByPlayerTwo++;
                }
            }

            if (xCardDrawByPlayerOne)
            {
                Console.WriteLine("X card drawn! Player one wins the match!");

            }
            else if (xCardDrawByPlayerTwo)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");

            }
            else if (playerOneGlobalScore > playerTwoGlobalScore)
            {
                Console.WriteLine("First player wins!");
                Console.WriteLine("Score: {0}", playerOneGlobalScore);
                Console.WriteLine("Games won: {0}", gamesWonByPlayerOne);
            }
            else if (playerOneGlobalScore < playerTwoGlobalScore)
            {
                Console.WriteLine("Second player wins!");
                Console.WriteLine("Score: {0}", playerTwoGlobalScore);
                Console.WriteLine("Games won: {0}", gamesWonByPlayerTwo);
            }
            else
            {
                Console.WriteLine("It's a tie!");
                Console.WriteLine("Score: {0}", playerTwoGlobalScore);
            }
        }
    }
}
