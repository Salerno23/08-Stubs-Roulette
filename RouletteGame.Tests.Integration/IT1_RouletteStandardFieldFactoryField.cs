using NSubstitute;
using NUnit.Framework;
using RouletteGame.Fields;
using RouletteGame.Game;
using RouletteGame.Randomizing;

namespace RouletteGame.Tests.Integration
{
    [TestFixture]
    public class IT1_RouletteStandardFieldFactoryField
    {
        private IFieldFactory _fieldFactory;
        private IRandomizer _randomizer;
        private Roulette.Roulette _uut;

        [SetUp]
        public void SetUp()
        {
            _fieldFactory = new StandardFieldFactory();
            _randomizer = Substitute.For<IRandomizer>();
            _uut = new Roulette.Roulette(_fieldFactory, _randomizer);
        }


        [Test]
        public void Spin_Field0Selected_NoExceptionThrown()
        {
            _randomizer.Next().Returns((uint)0);
            Assert.That(() => _uut.Spin(), Throws.Nothing);
        }

        [Test]
        public void Spin_Field36Selected_NoExceptionThrown()
        {
            _randomizer.Next().Returns((uint)36);
            Assert.That(() => _uut.Spin(), Throws.Nothing);
        }

        [Test]
        public void Spin_Field37Selected_ExceptionThrown()
        {
            _randomizer.Next().Returns((uint)37);
            Assert.That(() => _uut.Spin(), Throws.TypeOf<RouletteGameException>());
        }

        [Test]
        public void GetResult_Field0Selected_FieldIsGreen()
        {
            _randomizer.Next().Returns((uint)0);
            _uut.Spin();
            Assert.That(_uut.GetResult().Color, Is.EqualTo(FieldColor.Green));
        }


        [Test]
        public void GetResult_Field0Selected_FieldnumberIs0()
        {
            _randomizer.Next().Returns((uint)0);
            _uut.Spin();
            Assert.That(_uut.GetResult().Number, Is.EqualTo(0));
        }
    }
}
