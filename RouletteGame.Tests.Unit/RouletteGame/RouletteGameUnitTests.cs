using System.Collections.Generic;
using NUnit.Framework;
using RouletteGame.Bets;
using RouletteGame.Fields;
using RouletteGame.Game;
using RouletteGame.Roulette;
using RouletteGame.Tests.Unit.DerivedTestClasses;
using RouletteGame.Tests.Unit.Fakes;

namespace RouletteGame.Tests.Unit.RouletteGame
{
    internal class MockRoulette : IRoulette
    {
        private readonly IField _fieldToReturn;

        public MockRoulette()
        {
            _fieldToReturn = null;
        }

        public MockRoulette(IField fieldToReturn)
        {
            _fieldToReturn = fieldToReturn;
        }

        public bool SpinCalled { get; private set; }

        public bool GetResultCalled { get; private set; }

        public void Spin()
        {
            SpinCalled = true;
        }

        public IField GetResult()
        {
            GetResultCalled = true;
            return _fieldToReturn;
        }
    }


    [TestFixture]
    public class RouletteGameUnitTest
    {
        [Test]
        public void RouletteGame_Create_BetsAreEmpty()
        {
            var uut = new TestGame(new MockRoulette());
            Assert.AreEqual(uut.NBets, 0);
        }

        [Test]
        public void RouletteGame_Create_RoundIsClosed()
        {
            var uut = new TestGame(new MockRoulette());
            Assert.IsFalse(uut.IsRoundOpen);
        }

        [Test]
        public void RouletteGame_OpenBets_RoundIsOpen()
        {
            var uut = new TestGame(new MockRoulette());
            uut.OpenBets();
            Assert.IsTrue(uut.IsRoundOpen);
        }

        [Test]
        public void RouletteGame_OpenCloseBets_RoundIsClosed()
        {
            var uut = new TestGame(new MockRoulette());
            uut.OpenBets();
            uut.CloseBets();
            Assert.IsFalse(uut.IsRoundOpen);
        }

        [Test]
        public void RouletteGame_PayUp_10BetWonAmountCalled()
        {
            var bets = new List<MockBet>();
            for (uint i = 0; i < 10; i++)
                bets.Add(new MockBet());

            var roulette = new MockRoulette();
            var uut = new TestGame(roulette);
            uut.OpenBets();
            foreach (var bet in bets)
                uut.PlaceBet(bet);

            uut.CloseBets();
            uut.SpinRoulette();
            uut.PayUp();
            foreach (var bet in bets)
                Assert.IsTrue(bet.WonAmountCalled);
        }

        [Test]
        public void RouletteGame_PayUp_1BetWonAmountCalled()
        {
            var bet = new MockBet {Amount = 100, PlayerName = "Pete Mitchell"};
            var field = new StubField {Number = 10, Color = FieldColor.Red};

            var roulette = new MockRoulette(field);
            var uut = new TestGame(roulette);
            uut.OpenBets();
            uut.PlaceBet(bet);
            uut.CloseBets();
            uut.SpinRoulette();

            uut.PayUp();
            Assert.IsTrue(bet.WonAmountCalled);
        }

        [Test]
        public void RouletteGame_PayUp_RouletteGetResultCalled()
        {
            var field = new StubField {Number = 10, Color = FieldColor.Red};
            var roulette = new MockRoulette(field);
            var uut = new TestGame(roulette);
            uut.OpenBets();
            uut.CloseBets();
            uut.SpinRoulette();

            uut.PayUp();
            Assert.IsTrue(roulette.GetResultCalled);
        }

        [Test]
        public void RouletteGame_PayUp_StringCorrect()
        {
            var bet = new ColorBet("Pete Mitchell", 100, FieldColor.Red);
            var field = new StubField {Number = 10, Color = FieldColor.Red};
            var reporter = new MockOutput();

            var roulette = new MockRoulette(field);
            var uut = new TestGame(roulette, reporter);
            uut.OpenBets();
            uut.PlaceBet(bet);
            uut.CloseBets();
            uut.SpinRoulette();

            uut.PayUp();
            Assert.That(reporter.ArgUsed, Contains.Substring("Pete Mitchell"));
        }


        [Test]
        public void RouletteGame_Place10Bets_NBetsIs10()
        {
            var uut = new TestGame(new MockRoulette());
            uut.OpenBets();
            for (uint i = 0; i < 10; i++)
                uut.PlaceBet(new MockBet());
            Assert.AreEqual(uut.NBets, 10);
        }

        [Test]
        public void RouletteGame_PlaceBetWhenRoundClosed_Exception()
        {
            var uut = new TestGame(new MockRoulette());
            Assert.Throws<RouletteGameException>(() => uut.PlaceBet(new MockBet()));
        }

        [Test]
        public void RouletteGame_PlaceBetWhenRoundOpened_NBetsIs1()
        {
            var uut = new TestGame(new MockRoulette());
            uut.OpenBets();
            uut.PlaceBet(new MockBet());
            Assert.AreEqual(uut.NBets, 1);
        }

        [Test]
        public void RouletteGame_PlaceBetWhenRoundOpenedThenClosed_Exception()
        {
            var uut = new TestGame(new MockRoulette());
            uut.OpenBets();
            uut.CloseBets();

            Assert.Throws<RouletteGameException>(() => uut.PlaceBet(new MockBet()));
        }

        [Test]
        public void RouletteGame_SpinRoulette_SpinCalled()
        {
            var roulette = new MockRoulette();
            var uut = new TestGame(roulette);
            uut.OpenBets();
            uut.CloseBets();
            uut.SpinRoulette();

            Assert.IsTrue(roulette.SpinCalled);
        }


        [Test]
        public void RouletteGame_SpinRouletteWhenRoundOpen_Exception()
        {
            var uut = new TestGame(new MockRoulette());
            uut.OpenBets();

            Assert.Throws<RouletteGameException>(() => uut.SpinRoulette());
        }
    }
}