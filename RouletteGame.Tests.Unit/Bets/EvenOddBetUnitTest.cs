using NUnit.Framework;
using RouletteGame.Bets;
using RouletteGame.Fields;
using RouletteGame.Tests.Unit.Fakes;

namespace RouletteGame.Tests.Unit.Bets
{
    [TestFixture]
    public class EvenOddBetUnitTest
    {
        [Test]
        public void ColorBet_ToString_EvenBetContainsCorrectValues()
        {
            var uut = new EvenOddBet("Pete Mitchell", 100, Parity.Even);
            Assert.That(uut.ToString().ToLower(), Is.StringMatching("100.*even"));
        }

        [Test]
        public void ColorBet_ToString_OddBetContainsCorrectValues()
        {
            var uut = new EvenOddBet("Pete Mitchell", 100, Parity.Odd);
            Assert.That(uut.ToString().ToLower(), Is.StringMatching("100.*odd"));
        }

        [Test]
        public void ColorBet_ToString_NeitherBetContainsCorrectValues()
        {
            var uut = new EvenOddBet("Pete Mitchell", 100, Parity.Neither);
            Assert.That(uut.ToString().ToLower(), Is.StringMatching("100.*neither"));
        }

        [Test]
        public void EvenOddBet_EvenBetOddField_NothingWon()
        {
            var stubField = new StubField {Parity = Parity.Odd};

            var uut = new EvenOddBet("Pete Mitchell", 100, Parity.Even);
            Assert.That(uut.WonAmount(stubField), Is.EqualTo(0));
        }

        [Test]
        public void EvenOddBet_EvenBetEvenField_2TimesBetAmountReturned()
        {
            var stubField = new StubField {Parity = Parity.Even};

            var uut = new EvenOddBet("Pete Mitchell", 100, Parity.Even);
            Assert.That(uut.WonAmount(stubField), Is.EqualTo(200));
        }

        [Test]
        public void EvenOddBet_OddBetEvenField_NothingWon()
        {
            var stubField = new StubField {Parity = Parity.Even};

            var uut = new EvenOddBet("Pete Mitchell", 100, Parity.Odd);
            Assert.That(uut.WonAmount(stubField), Is.EqualTo(0));
        }

        [Test]
        public void EvenOddBet_OddBetOddField_2TimesBetAmountReturned()
        {
            var stubField = new StubField {Parity = Parity.Odd};

            var uut = new EvenOddBet("Pete Mitchell", 100, Parity.Odd);
            Assert.That(uut.WonAmount(stubField), Is.EqualTo(200));
        }

        [Test]
        public void EvenOddBet_OddBetNeitherParityField_NothingWon()
        {
            var stubField = new StubField { Parity = Parity.Neither };

            var uut = new EvenOddBet("Pete Mitchell", 100, Parity.Odd);
            Assert.That(uut.WonAmount(stubField), Is.EqualTo(0));
        }

        [Test]
        public void EvenOddBet_EvenBetNeitherParityField_NothingWon()
        {
            var stubField = new StubField { Parity = Parity.Neither };

            var uut = new EvenOddBet("Pete Mitchell", 100, Parity.Even);
            Assert.That(uut.WonAmount(stubField), Is.EqualTo(0));
        }
    }
}