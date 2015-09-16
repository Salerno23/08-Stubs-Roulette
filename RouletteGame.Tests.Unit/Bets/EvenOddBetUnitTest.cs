using NUnit.Framework;
using RouletteGame.Bets;
using RouletteGame.Tests.Unit.Fakes;

namespace RouletteGame.Tests.Unit.Bets
{
    [TestFixture]
    public class EvenOddBetUnitTest
    {
        [Test]
        public void ColorBet_ToString_EvenBetContainsCorrectValues()
        {
            var uut = new EvenOddBet("Pete Mitchell", 100, true);
            Assert.That(uut.ToString(), Is.StringMatching("100.*even"));
        }

        [Test]
        public void ColorBet_ToString_OddBetContainsCorrectValues()
        {
            var uut = new EvenOddBet("Pete Mitchell", 100, false);
            Assert.That(uut.ToString(), Is.StringMatching("100.*odd"));
        }

        [Test]
        public void EvenOddBet_EvenBetWonIsFalse_NothingWon()
        {
            var stubField = new StubField();
            stubField.Number = 3;

            var uut = new EvenOddBet("Pete Mitchell", 100, true);
            Assert.AreEqual(uut.WonAmount(stubField), 0);
        }

        [Test]
        public void EvenOddBet_EvenBetWonIsTrue_2TimesBetAmountReturned()
        {
            var stubField = new StubField();
            stubField.Number = 2;

            var uut = new EvenOddBet("Pete Mitchell", 100, true);
            Assert.AreEqual(uut.WonAmount(stubField), 200);
        }

        [Test]
        public void EvenOddBet_OddBetWonIsFalse_NothingWon()
        {
            var stubField = new StubField();
            stubField.Number = 2;

            var uut = new EvenOddBet("Pete Mitchell", 100, false);
            Assert.AreEqual(uut.WonAmount(stubField), 0);
        }

        [Test]
        public void EvenOddBet_OddBetWonIsTrue_2TimesBetAmountReturned()
        {
            var stubField = new StubField();
            stubField.Number = 3;

            var uut = new EvenOddBet("Pete Mitchell", 100, false);
            Assert.AreEqual(uut.WonAmount(stubField), 200);
        }
    }
}