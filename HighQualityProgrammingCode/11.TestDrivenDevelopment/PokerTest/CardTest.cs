namespace PokerTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;

    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void EightOfDiamondsToStringTest()
        {
            var face = CardFace.Eight;
            var suit = CardSuit.Diamonds;

            var expectedResultFromToString = face + " of " + suit;

            var card = new Card(face, suit);

            Assert.AreEqual(expectedResultFromToString, card.ToString());
        }

        [TestMethod]
        public void KingOfSpadesToStringTest()
        {
            var face = CardFace.King;
            var suit = CardSuit.Spades;

            var expectedResultFromToString = face + " of " + suit;

            var card = new Card(face, suit);

            Assert.AreEqual(expectedResultFromToString, card.ToString());
        }

        [TestMethod]
        public void AceOfHeartsToStringTest()
        {
            var face = CardFace.Ace;
            var suit = CardSuit.Hearts;

            var expectedResultFromToString = face + " of " + suit;

            var card = new Card(face, suit);

            Assert.AreEqual(expectedResultFromToString, card.ToString());
        }

        [TestMethod]
        public void ThreeOfClubsToStringTest()
        {
            var face = CardFace.Three;
            var suit = CardSuit.Clubs;

            var expectedResultFromToString = face + " of " + suit;

            var card = new Card(face, suit);

            Assert.AreEqual(expectedResultFromToString, card.ToString());
        }
    }
}
