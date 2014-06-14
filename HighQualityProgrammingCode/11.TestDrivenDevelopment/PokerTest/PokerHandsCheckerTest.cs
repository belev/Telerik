namespace PokerTest
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;

    [TestClass]
    public class PokerHandsCheckerTest
    {
        private static PokerHandsChecker handsChecker;

        [ClassInitialize]
        public static void InitializeHandsChecker(TestContext textContext)
        {
            handsChecker = new PokerHandsChecker();
        }

        [TestMethod]
        public void InvalidHandWithOneCardTest()
        {
            var fourOfDiamonds = new Card(CardFace.Four, CardSuit.Diamonds);

            var cards = new List<ICard>() 
            {
                fourOfDiamonds
            };

            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void InvalidHandWithFourCardsTest()
        {
            var fourOfDiamonds = new Card(CardFace.Four, CardSuit.Diamonds);
            var fourOfClubs = new Card(CardFace.Four, CardSuit.Clubs);
            var fourOfHearts = new Card(CardFace.Four, CardSuit.Hearts);
            var fourOfSpades = new Card(CardFace.Four, CardSuit.Spades);

            var cards = new List<ICard>() 
            {
                fourOfDiamonds,
                fourOfClubs,
                fourOfHearts,
                fourOfSpades
            };

            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void InvalidHandWithSixCardsTest()
        {
            var fourOfDiamonds = new Card(CardFace.Four, CardSuit.Diamonds);
            var fourOfClubs = new Card(CardFace.Four, CardSuit.Clubs);
            var fourOfHearts = new Card(CardFace.Four, CardSuit.Hearts);
            var fourOfSpades = new Card(CardFace.Four, CardSuit.Spades);

            var twoOfSpades = new Card(CardFace.Two, CardSuit.Spades);
            var threeOfSpades = new Card(CardFace.Three, CardSuit.Spades);

            var cards = new List<ICard>() 
            {
                fourOfDiamonds,
                fourOfClubs,
                fourOfHearts,
                fourOfSpades,
                twoOfSpades,
                threeOfSpades
            };

            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void InvalidHandWithCardRepetition()
        {
            var kingOfDiamonds = new Card(CardFace.King, CardSuit.Diamonds);
            var kingOfClubs = new Card(CardFace.King, CardSuit.Clubs);
            var fourOfHearts = new Card(CardFace.Four, CardSuit.Hearts);
            var fourOfHeartsAgain = new Card(CardFace.Four, CardSuit.Hearts);
            var threeOfSpades = new Card(CardFace.Three, CardSuit.Spades);

            var cards = new List<ICard>() 
            {
                kingOfDiamonds,
                kingOfClubs,
                fourOfHearts,
                fourOfHeartsAgain,
                threeOfSpades
            };

            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void ValidHandTest()
        {
            var kingOfDiamonds = new Card(CardFace.King, CardSuit.Diamonds);
            var kingOfClubs = new Card(CardFace.King, CardSuit.Clubs);
            var fourOfHearts = new Card(CardFace.Four, CardSuit.Hearts);
            var fourOfSpades = new Card(CardFace.Four, CardSuit.Spades);
            var threeOfSpades = new Card(CardFace.Three, CardSuit.Spades);

            var cards = new List<ICard>() 
            {
                kingOfDiamonds,
                kingOfClubs,
                fourOfHearts,
                fourOfSpades,
                threeOfSpades
            };

            var hand = new Hand(cards);

            Assert.IsTrue(handsChecker.IsValidHand(hand));
        }

        // flush hand tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidHandWithCardRepetitionForFlushTest()
        {
            var kingOfDiamonds = new Card(CardFace.King, CardSuit.Diamonds);
            var queenOfDiamonds = new Card(CardFace.Queen, CardSuit.Diamonds);
            var jackOfDiamonds = new Card(CardFace.Jack, CardSuit.Diamonds);
            var fourOfHearts = new Card(CardFace.Four, CardSuit.Hearts);
            var queenOfDiamondsAgain = new Card(CardFace.Queen, CardSuit.Diamonds);

            var cards = new List<ICard>() 
            {
                kingOfDiamonds,
                queenOfDiamonds,
                jackOfDiamonds,
                fourOfHearts,
                queenOfDiamondsAgain
            };

            var hand = new Hand(cards);

            handsChecker.IsFlush(hand);
        }

        [TestMethod]
        public void InvalidHandForFlushTest()
        {
            var kingOfDiamonds = new Card(CardFace.King, CardSuit.Diamonds);
            var queenOfDiamonds = new Card(CardFace.Queen, CardSuit.Diamonds);
            var jackOfDiamonds = new Card(CardFace.Jack, CardSuit.Diamonds);
            var fourOfHearts = new Card(CardFace.Four, CardSuit.Hearts);
            var twoOfDiamongs = new Card(CardFace.Two, CardSuit.Diamonds);

            var cards = new List<ICard>() 
            {
                kingOfDiamonds,
                queenOfDiamonds,
                jackOfDiamonds,
                fourOfHearts,
                twoOfDiamongs
            };

            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsFlush(hand));
        }

        [TestMethod]
        public void ValidHandForFlushTest()
        {
            var kingOfDiamonds = new Card(CardFace.King, CardSuit.Diamonds);
            var queenOfDiamonds = new Card(CardFace.Queen, CardSuit.Diamonds);
            var jackOfDiamonds = new Card(CardFace.Jack, CardSuit.Diamonds);
            var fourOfDiamonds = new Card(CardFace.Four, CardSuit.Diamonds);
            var twoOfDiamongs = new Card(CardFace.Two, CardSuit.Diamonds);

            var cards = new List<ICard>() 
            {
                kingOfDiamonds,
                queenOfDiamonds,
                jackOfDiamonds,
                fourOfDiamonds,
                twoOfDiamongs
            };

            var hand = new Hand(cards);

            Assert.IsTrue(handsChecker.IsFlush(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        public void InvalidHandWithMoreCardsForFourOfAKindTest()
        {
            var kingOfDiamonds = new Card(CardFace.King, CardSuit.Diamonds);
            var queenOfDiamonds = new Card(CardFace.Queen, CardSuit.Diamonds);
            var jackOfDiamonds = new Card(CardFace.Jack, CardSuit.Diamonds);
            var fourOfHearts = new Card(CardFace.Four, CardSuit.Hearts);
            var twoOfDiamongs = new Card(CardFace.Two, CardSuit.Diamonds);
            var twoOfSpades = new Card(CardFace.Two, CardSuit.Spades);

            var cards = new List<ICard>() 
            {
                kingOfDiamonds,
                queenOfDiamonds,
                jackOfDiamonds,
                fourOfHearts,
                twoOfDiamongs,
                twoOfSpades
            };

            var hand = new Hand(cards);

            handsChecker.IsFourOfAKind(hand);
        }

        [TestMethod]
        public void InvalidFourOfAKindHandTest()
        {
            var kingOfDiamonds = new Card(CardFace.King, CardSuit.Diamonds);
            var queenOfDiamonds = new Card(CardFace.Queen, CardSuit.Diamonds);
            var jackOfDiamonds = new Card(CardFace.Jack, CardSuit.Diamonds);
            var fourOfDiamonds = new Card(CardFace.Four, CardSuit.Diamonds);
            var twoOfDiamongs = new Card(CardFace.Two, CardSuit.Diamonds);

            var cards = new List<ICard>() 
            {
                kingOfDiamonds,
                queenOfDiamonds,
                jackOfDiamonds,
                fourOfDiamonds,
                twoOfDiamongs
            };

            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void ValidFourOfAKindHandTest()
        {
            var kingOfDiamonds = new Card(CardFace.King, CardSuit.Diamonds);
            var kingOfSpades = new Card(CardFace.King, CardSuit.Spades);
            var kingOfHearts = new Card(CardFace.King, CardSuit.Hearts);
            var kingOfClubs = new Card(CardFace.King, CardSuit.Clubs);
            var twoOfDiamongs = new Card(CardFace.Two, CardSuit.Diamonds);

            var cards = new List<ICard>() 
            {
                kingOfDiamonds,
                kingOfSpades,
                kingOfHearts,
                twoOfDiamongs,
                kingOfClubs
            };

            var hand = new Hand(cards);

            Assert.IsTrue(handsChecker.IsFourOfAKind(hand));
        }
    }
}