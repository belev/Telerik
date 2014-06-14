namespace PokerTest
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;

    [TestClass]
    public class HandTest
    {
        [TestMethod]
        public void TwoOfClubsAndQueenOfHeartsHandTest()
        {
            var twoOfClubs = new Card(CardFace.Two, CardSuit.Clubs);
            var queenOfHearths = new Card(CardFace.Queen, CardSuit.Hearts);

            IList<ICard> cards = new List<ICard>()
            {
                twoOfClubs,
                queenOfHearths
            };

            var hand = new Hand(cards);

            var expectedResult = twoOfClubs.ToString() + ", " + queenOfHearths.ToString();

            Assert.AreEqual(expectedResult, hand.ToString());
        }

        [TestMethod]
        public void ThreeOfHeartsAceOfClubsAndKingOfClubsHandTest()
        {
            var threeOfHearths = new Card(CardFace.Three, CardSuit.Hearts);
            var aceOfClubs = new Card(CardFace.Ace, CardSuit.Clubs);
            var kingOfClubs = new Card(CardFace.King, CardSuit.Clubs);

            IList<ICard> cards = new List<ICard>()
            {
                threeOfHearths,
                aceOfClubs,
                kingOfClubs
            };

            var hand = new Hand(cards);

            var expectedResult = threeOfHearths.ToString() + ", " + aceOfClubs.ToString() + ", " + kingOfClubs.ToString();

            Assert.AreEqual(expectedResult, hand.ToString());
        }

        [TestMethod]
        public void FullHouseHandTest()
        {
            var kingOfClubs = new Card(CardFace.King, CardSuit.Clubs);
            var kingOfSpades = new Card(CardFace.King, CardSuit.Spades);
            var kingOfHearths = new Card(CardFace.King, CardSuit.Hearts);

            var jackOfDiamonds = new Card(CardFace.Jack, CardSuit.Diamonds);
            var jackOfSpades = new Card(CardFace.Jack, CardSuit.Spades);

            IList<ICard> cards = new List<ICard>()
            {
                kingOfClubs,
                kingOfSpades,
                kingOfHearths,
                jackOfDiamonds,
                jackOfSpades
            };

            var hand = new Hand(cards);

            var expectedResult = kingOfClubs.ToString() + ", " +
                                 kingOfSpades.ToString() + ", " +
                                 kingOfHearths.ToString() + ", " +
                                 jackOfDiamonds.ToString() + ", " +
                                 jackOfSpades.ToString();

            Assert.AreEqual(expectedResult, hand.ToString());
        }

        [TestMethod]
        public void SixOtDiamondsHandTest()
        {
            var sixOfDiamonds = new Card(CardFace.Six, CardSuit.Diamonds);

            var cards = new List<ICard>()
            {
                sixOfDiamonds
            };

            var hand = new Hand(cards);

            var expectedResult = sixOfDiamonds.ToString();

            Assert.AreEqual(expectedResult, hand.ToString());
        }

        [TestMethod]
        public void EmptyHandTest()
        {
            var hand = new Hand(new List<ICard>());

            var expectedResult = string.Empty;

            Assert.AreEqual(expectedResult, hand.ToString());
        }
    }
}
