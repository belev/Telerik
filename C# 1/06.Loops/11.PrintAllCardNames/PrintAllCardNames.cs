using System;

//Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). The cards should be printed with their English names. Use nested for loops and switch-case.

class PrintAllCardNames
{
    static void Main()
    {
        string[] cardSuits = { "Spades", "Hearts", "Diamonds", "Clubs" };

        for (int i = 0; i < cardSuits.Length; i++)
        {
            for (int j = 2; j <= 14; j++)
            {
                string cardName = cardSuits[i];

                switch (j)
                {
                    case 2:
                        cardName = "Two of " + cardName;
                        break;
                    case 3:
                        cardName = "Three of " + cardName;
                        break;
                    case 4:
                        cardName = "Four of " + cardName;
                        break;
                    case 5:
                        cardName = "Five of " + cardName;
                        break;
                    case 6:
                        cardName = "Six of " + cardName;
                        break;
                    case 7:
                        cardName = "Seven of " + cardName;
                        break;
                    case 8:
                        cardName = "Eight of " + cardName;
                        break;
                    case 9:
                        cardName = "Nine of " + cardName;
                        break;
                    case 10:
                        cardName = "Ten of " + cardName;
                        break;
                    case 11:
                        cardName = "Jack of " + cardName;
                        break;
                    case 12:
                        cardName = "Queen of " + cardName;
                        break;
                    case 13:
                        cardName = "King of " + cardName;
                        break;
                    case 14:
                        cardName = "Ace of " + cardName;
                        break;
                }

                Console.WriteLine(cardName);
            }

            if (i != 3)
            {
                Console.WriteLine();
            }
        }
    }
}

