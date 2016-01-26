using NUnit.Framework;
using RouletteGame.Bets;

namespace RouletteGame.Tests.Unit.Bets
{
    [TestFixture]
    public class BetUnitTest
    {
        [Test]
        public void Bet_Create_AmountIsOK()
        {
            var uut = new FieldBet("Pete Mitchell", 100, 0);
            Assert.AreEqual(uut.Amount, 100);
        }

        [Test]
        public void Bet_Create_NameIsOK()
        {
            var uut = new FieldBet("Pete Mitchell", 100, 0); // Use FieldBet to test superclass Bet properties
            Assert.AreEqual(uut.PlayerName, "Pete Mitchell");
        }
    }
}