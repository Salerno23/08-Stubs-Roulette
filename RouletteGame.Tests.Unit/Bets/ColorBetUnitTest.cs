using NUnit.Framework;
using RouletteGame.Bets;
using RouletteGame.Fields;
using RouletteGame.Tests.Unit.Fakes;

namespace RouletteGame.Tests.Unit.Bets
{
    [TestFixture]
    public class ColorBetUnitTest
    {
        [Test]
        public void ColorBet_BlackWonIsTrue_2TimesBetAmountWon()
        {
            var stubField = new StubField();
            stubField.Color = FieldColor.Black;

            var uut = new ColorBet("Pete Mitchell", 100, FieldColor.Black);
            Assert.That(uut.WonAmount(stubField), Is.EqualTo(200));
        }

        [Test]
        public void ColorBet_GreenWonIsTrue_2TimesBetAmountWon()
        {
            var stubField = new StubField();
            stubField.Color = FieldColor.Green;

            var uut = new ColorBet("Pete Mitchell", 100, FieldColor.Green);
            Assert.That(uut.WonAmount(stubField), Is.EqualTo(200));
        }

        [Test]
        public void ColorBet_RedWonIsTrue_2TimesBetAmountWon()
        {
            var stubField = new StubField();
            stubField.Color = FieldColor.Red;

            var uut = new ColorBet("Pete Mitchell", 100, FieldColor.Red);
            Assert.That(uut.WonAmount(stubField), Is.EqualTo(200));
        }

        [Test]
        public void ColorBet_ToString_BlackBetContainsCorrectValues()
        {
            var uut = new ColorBet("Pete Mitchell", 100, FieldColor.Black);
            Assert.That(uut.ToString(), Is.StringMatching("100.*Black"));
        }


        [Test]
        public void ColorBet_ToString_GreenBetContainsCorrectValues()
        {
            var uut = new ColorBet("Pete Mitchell", 1000, FieldColor.Green);
            Assert.That(uut.ToString(), Is.StringMatching("1000.*Green"));
        }

        [Test]
        public void ColorBet_ToString_RedBetContainsCorrectValues()
        {
            var uut = new ColorBet("Pete Mitchell", 50, FieldColor.Red);
            Assert.That(uut.ToString(), Is.StringMatching("50.*Red"));
        }

        [Test]
        public void ColorBet_WonIsFalse_NothingWon()
        {
            var stubField = new StubField();
            stubField.Color = FieldColor.Red;

            var uut = new ColorBet("Pete Mitchell", 100, FieldColor.Black);
            Assert.That(uut.WonAmount(stubField), Is.EqualTo(0));
        }
    }
}