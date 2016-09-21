using System.Collections.Generic;
using NUnit.Framework;
using RouletteGame.Bets;
using RouletteGame.Fields;
using RouletteGame.Game;
using RouletteGame.Tests.Unit.Fakes;

namespace RouletteGame.Tests.Unit.Game
{
    [TestFixture]
    public class RouletteGameUnitTest
    {
        private RouletteGame.Game.Game _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new RouletteGame.Game.Game(new MockRoulette(), new MockOutput());
        }


        [Test]
        public void Ctor_BetPlaced_NotAllowed()
        {
            Assert.Throws<RouletteGameException>(() => _uut.PlaceBet(new MockBet()));
        }


        [Test]
        public void PlaceBets_RoundIsOpen_Allowed()
        {
            _uut.OpenBets();
            Assert.DoesNotThrow(() => _uut.PlaceBet(new MockBet()));
        }

        [Test]
        public void PlaceBet_OpenCloseBets_NotAllowed()
        {
            _uut.OpenBets();
            _uut.CloseBets();
            Assert.Throws<RouletteGameException>(() => _uut.PlaceBet(new MockBet()));
        }

        [Test]
        public void PayUp_1BetPlaced_BetQueriedForWonAmount()
        {
            var bet = new MockBet { Amount = 100, PlayerName = "Pete Mitchell" };
            var field = new StubField { Number = 10, Color = FieldColor.Red };

            var roulette = new MockRoulette(field);
            var uut = new RouletteGame.Game.Game(roulette, new MockOutput());
            uut.OpenBets();
            uut.PlaceBet(bet);
            uut.CloseBets();
            uut.SpinRoulette();

            uut.PayUp();
            Assert.That(bet.WonAmountCalled, Is.True);
        }

        [Test]
        public void PayUp_10BetsPlaced_AllBetsQueriedForWonAmount()
        {
            var allBetsQueried = true;
            var bets = new List<MockBet>();
            for (uint i = 0; i < 10; i++)
                bets.Add(new MockBet());

            _uut.OpenBets();
            foreach (var bet in bets)
                _uut.PlaceBet(bet);

            _uut.CloseBets();
            _uut.SpinRoulette();
            _uut.PayUp();

            foreach (var bet in bets)
                allBetsQueried &= bet.WonAmountCalled;

            Assert.That(allBetsQueried, Is.True);
        }


        [Test]
        public void PayUp_RoundPlayed_RouletteQueriedForResult()
        {
            var field = new StubField {Number = 10, Color = FieldColor.Red};
            var roulette = new MockRoulette(field);
            var uut = new RouletteGame.Game.Game(roulette, new MockOutput());

            uut.OpenBets();
            uut.CloseBets();
            uut.SpinRoulette();

            uut.PayUp();
            Assert.That(roulette.GetResultCalled, Is.True);
        }

        [Test]
        public void PayUp_WinningBetPlaced_ReportContainsPlayerName()
        {
            var bet = new ColorBet("Pete Mitchell", 100, FieldColor.Red);
            var field = new StubField {Number = 10, Color = FieldColor.Red};
            var reporter = new MockOutput();

            var roulette = new MockRoulette(field);
            var uut = new RouletteGame.Game.Game(roulette, reporter);
            uut.OpenBets();
            uut.PlaceBet(bet);
            uut.CloseBets();
            uut.SpinRoulette();

            uut.PayUp();
            Assert.That(reporter.ArgUsed, Contains.Substring("Pete Mitchell"));
        }


        [Test]
        public void RouletteGame_SpinRoulette_RouletteSpun()
        {
            var roulette = new MockRoulette();
            var uut = new RouletteGame.Game.Game(roulette, new MockOutput());
            uut.OpenBets();
            uut.CloseBets();
            uut.SpinRoulette();

            Assert.That(roulette.SpinCalled, Is.True);
        }


        [Test]
        public void Spin_RoundOpen_SpinNotAllowed()
        {
            var uut = new RouletteGame.Game.Game(new MockRoulette(), new MockOutput());
            uut.OpenBets();

            Assert.That(() => uut.SpinRoulette(), Throws.TypeOf<RouletteGameException>());
        }
    }
}