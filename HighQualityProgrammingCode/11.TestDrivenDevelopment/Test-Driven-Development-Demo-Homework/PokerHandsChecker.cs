namespace Poker
{
    using System;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int CardsPerHandCount = 5;
        private const int CardsForFourOfAKindCount = 4;

        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != CardsPerHandCount)
            {
                return false;
            }

            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].ToString() == hand.Cards[j].ToString())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("The hand which is passed doesnt contain 5 different cards.");
            }

            return AreOfSameFace(hand, CardsForFourOfAKindCount);
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("The hand which is passed doesnt contain 5 different cards.");
            }

            var cardsInHand = hand.Cards;

            var firstCardSuit = cardsInHand[0].Suit;

            for (int i = 1; i < cardsInHand.Count; i++)
            {
                if (firstCardSuit != cardsInHand[i].Suit)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private bool AreOfSameFace(IHand hand, int numberOfSameCards)
        {
            var groupedByFace = hand.Cards
                .GroupBy(x => x.Face)
                .ToDictionary(x => x.Key, y => y.Count());

            return groupedByFace.ContainsValue(numberOfSameCards);
        }
    }
}
