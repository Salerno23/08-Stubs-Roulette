using NUnit.Framework;
using Roulette.Randomizing;

namespace RouletteGame.Tests.Unit.Fields.Randomizing
{
    [TestFixture]
    public class RouletteRandomizerUnitTest
    {
        [Test]
        public void RouletteRandomizer_NextOK()
        {
            var uut = new RouletteRandomizer();
            uint result = uut.Next();
            Assert.That(result <= 36); // Not exactly exhaustive
        }
    }
}