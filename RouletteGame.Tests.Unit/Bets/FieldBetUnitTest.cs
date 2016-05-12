using NUnit.Framework;
using RouletteGame.Bets;
using RouletteGame.Tests.Unit.Fakes;

namespace RouletteGame.Tests.Unit.Bets
{
    [TestFixture]
    public class FieldBetUnitTest
    {
        [Test]
        public void FieldBet_ToString_ContainsCorrectValues()
        {
            var uut = new FieldBet("Pete Mitchell", 100, 0);
            Assert.That(uut.ToString(), Is.StringMatching("100.*0"));
        }

        [Test]
        public void FieldBet_WonIsFalse_NothingWon()
        {
            var stubField = new StubField();
            stubField.Number = 1;

            var uut = new FieldBet("Pete Mitchell", 100, 0);
            Assert.That(uut.WonAmount(stubField), Is.EqualTo(0));
        }

        [Test]
        public void FieldBet_WonIsTrue_36TimesBetAmountWon()
        {
            var stubField = new StubField();
            stubField.Number = 0;

            var uut = new FieldBet("Pete Mitchell", 100, 0);
            Assert.That(uut.WonAmount(stubField), Is.EqualTo(3600));
        }
    }
}