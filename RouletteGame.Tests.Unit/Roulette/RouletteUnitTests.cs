using NUnit.Framework;
using RouletteGame.Fields;
using RouletteGame.Game;
using RouletteGame.Tests.Unit.Fakes;

namespace RouletteGame.Tests.Unit.Roulette
{
    [TestFixture]
    public class RouletteUnitTest
    {
        [Test]
        public void Ctor_RouletteNotSpun_GetResultNotAllowed()
        {
            var uut = new RouletteGame.Roulette.Roulette(new MockBlack1FieldFactory(), new StubRandomizer());
            Assert.That(() => uut.GetResult(), Throws.TypeOf<RouletteGameException>());
        }

        [Test]
        public void GetResult_RouletteSpun_GetResultAllowed()
        {
            var uut = new RouletteGame.Roulette.Roulette(new MockBlack1FieldFactory(), new StubRandomizer());
            uut.Spin();
            Assert.DoesNotThrow(() => uut.GetResult());
        }


        [Test]
        public void Spin_RandomizerReturnsIllegalValue_ExceptionThrown()
        {
            var randomizer = new StubRandomizer(40); // Always return '40' from randomizer
            var factory = new MockFieldFactory();
            var uut = new RouletteGame.Roulette.Roulette(factory, randomizer);
            Assert.That(() => uut.Spin(), Throws.TypeOf<RouletteGameException>());
        }


        [Test]
        public void GetResult_Spin_ResultColorOK()
        {
            var uut = new RouletteGame.Roulette.Roulette(new MockBlack1FieldFactory(), new StubRandomizer());
            uut.Spin();
            Assert.That(uut.GetResult().Color, Is.EqualTo(FieldColor.Black));
        }

        [Test]
        public void Spin_Spin_ResultNumberOK()
        {
            var uut = new RouletteGame.Roulette.Roulette(new MockBlack1FieldFactory(), new StubRandomizer());
            uut.Spin();
            Assert.That(uut.GetResult().Number, Is.EqualTo(1));
        }

        [Test]
        public void GetResult_SpinAndGetResult_ResultColorOK()
        {
            var randomizer = new StubRandomizer(2); // Always return '2' from randomizer
            var factory = new MockFieldFactory();

            factory.AddField(new StubField {Number = 0, Color = FieldColor.Green});
            factory.AddField(new StubField {Number = 1, Color = FieldColor.Red});
            factory.AddField(new StubField {Number = 6, Color = FieldColor.Black});

            var uut = new RouletteGame.Roulette.Roulette(factory, randomizer);
            uut.Spin();

            Assert.That(uut.GetResult().Color, Is.EqualTo(FieldColor.Black));
        }

        [Test]
        public void GetResult_SpinAndGetResult_ResultNumberOK()
        {
            var randomizer = new StubRandomizer(2); // Always return '2' from randomizer
            var factory = new MockFieldFactory();

            factory.AddField(new StubField {Number = 0, Color = FieldColor.Green});
            factory.AddField(new StubField {Number = 1, Color = FieldColor.Red});
            factory.AddField(new StubField {Number = 6, Color = FieldColor.Black});

            var uut = new RouletteGame.Roulette.Roulette(factory, randomizer);
            uut.Spin();

            Assert.That(uut.GetResult().Number, Is.EqualTo(6));
        }
    }
}