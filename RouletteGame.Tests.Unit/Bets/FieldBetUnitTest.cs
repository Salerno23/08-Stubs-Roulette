using NUnit.Framework;
using RouletteGame.Bets;
using RouletteGame.Tests.Unit.Fakes;

namespace RouletteGame.Tests.Unit.Bets
{
    [TestFixture]
    public class FieldBetUnitTest
    {
        private FieldBet _uut;
        private StubField _stubField;

        [SetUp]
        public void SetUp()
        {
            _uut = new FieldBet("Pete Mitchell", 100, 0);
            _stubField = new StubField();
        }
        [Test]
        public void FieldBet_ToString_ContainsCorrectValues()
        {
            Assert.That(_uut.ToString(), Is.StringMatching("100.*0"));
        }

        [TestCase(0, 3600)]
        [TestCase(1, 0)]
        public void FieldBet_DifferentFields_WonAmountCorrect(int fieldNumber, int wonAmount)
        {
            _stubField.Number = (uint) fieldNumber;
            Assert.That(_uut.WonAmount(_stubField), Is.EqualTo(wonAmount));
        }
    }
}