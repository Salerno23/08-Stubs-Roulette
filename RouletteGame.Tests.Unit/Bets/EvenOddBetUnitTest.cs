using NUnit.Framework;
using RouletteGame.Bets;
using RouletteGame.Fields;
using RouletteGame.Tests.Unit.Fakes;

namespace RouletteGame.Tests.Unit.Bets
{
    [TestFixture]
    public class ParityBetUnitTest
    {
        private EvenOddBet _uutEven;
        private EvenOddBet _uutOdd;
        private EvenOddBet _uutNeither;

        [SetUp]
        public void SetUp()
        {
            _uutEven = new EvenOddBet("Pete Mitchell", 100, Parity.Even);
            _uutOdd = new EvenOddBet("Pete Mitchell", 100, Parity.Odd);
            _uutNeither = new EvenOddBet("Pete Mitchell", 100, Parity.Neither);
        }

        [Test]
        public void EvenBet_ToString_EvenBetContainsCorrectValues()
        {
            Assert.That(_uutEven.ToString().ToLower(), Is.StringMatching("100.*even"));
        }

        [Test]
        public void OddBet_ToString_EvenBetContainsCorrectValues()
        {
            Assert.That(_uutOdd.ToString().ToLower(), Is.StringMatching("100.*odd"));
        }

        [Test]
        public void NeitherBet_ToString_NeitherBetContainsCorrectValues()
        {
            Assert.That(_uutNeither.ToString().ToLower(), Is.StringMatching("100.*neither"));
        }


        [TestCase(Parity.Even, 200)]
        [TestCase(Parity.Odd, 0)]
        [TestCase(Parity.Neither, 0)]
        public void EvenBet_DifferentFields_WonAmountCorrect(Parity parity, int wonAmount)
        {
            var stubField = new StubField { Parity = parity };
            Assert.That(_uutEven.WonAmount(stubField), Is.EqualTo(wonAmount));
        }


        [TestCase(Parity.Even, 0)]
        [TestCase(Parity.Odd, 200)]
        [TestCase(Parity.Neither, 0)]
        public void OddBet_DifferentFields_WonAmountCorrect(Parity parity, int wonAmount)
        {
            var stubField = new StubField { Parity = parity };
            Assert.That(_uutOdd.WonAmount(stubField), Is.EqualTo(wonAmount));
        }

        [TestCase(Parity.Even, 0)]
        [TestCase(Parity.Odd, 0)]
        [TestCase(Parity.Neither, 200)]
        public void NeitherBet_DifferentFields_WonAmountCorrect(Parity parity, int wonAmount)
        {
            var stubField = new StubField { Parity = parity };
            Assert.That(_uutNeither.WonAmount(stubField), Is.EqualTo(wonAmount));
        }



    }
}