using NUnit.Framework;
using RouletteGame.Fields;
using RouletteGame.Game;

namespace RouletteGame.Tests.Unit.Fields
{
    [TestFixture]
    public class FieldUnitTest
    {
        // TESTING NUMBER VALUES
        [Test]
        public void Field_Create_ColorBlackIsOK()
        {
            var uut = new Field(10, FieldColor.Black);
            Assert.That(uut.Color, Is.EqualTo(FieldColor.Black));
        }

        [Test]
        public void Field_Create_ColorGreenIsOK()
        {
            var uut = new Field(10, FieldColor.Green);
            Assert.That(uut.Color, Is.EqualTo(FieldColor.Green));
        }

        [Test]
        public void Field_Create_ColorRedIsOK()
        {
            var uut = new Field(10, FieldColor.Red);
            Assert.That(uut.Color, Is.EqualTo(FieldColor.Red));
        }

        [Test]
        public void Field_Create_Number0IsOK()
        {
            var uut = new Field(0, FieldColor.Black);
            Assert.That(uut.Number, Is.EqualTo(0));
        }

        [Test]
        public void Field_Create_Number36IsOK()
        {
            var uut = new Field(36, FieldColor.Black);
            Assert.That(uut.Number, Is.EqualTo(36));
        }

        [Test]
        public void Field_Create_Number37ExceptionIsThrown()
        {
            Assert.That(() =>  new Field(37, FieldColor.Black), Throws.TypeOf<FieldException>());
        }


        [Test]
        public void Field_Create_Value0ParityIsNeither()
        {
            var uut = new Field(0, FieldColor.Green);
            Assert.That(uut.Parity, Is.EqualTo(Parity.Neither));
        }

        [Test]
        public void Field_Create_Value2ParityIsEven()
        {
            var uut = new Field(2, FieldColor.Black);
            Assert.That(uut.Parity, Is.EqualTo(Parity.Even));
        }

        [Test]
        public void Field_Create_Value3ParityIsOdd()
        {
            var uut = new Field(3, FieldColor.Black);
            Assert.That(uut.Parity, Is.EqualTo(Parity.Odd));
        }

        [Test]
        public void Field_ToString_BlackContainsCorrectValues()
        {
            var uut = new Field(3, FieldColor.Black);
            Assert.That(uut.ToString(), Is.StringMatching("3.*Black"));
        }

        [Test]
        public void Field_ToString_GreenContainsCorrectValues()
        {
            var uut = new Field(0, FieldColor.Green);
            Assert.That(uut.ToString(), Is.StringMatching("0.*Green"));
        }

        [Test]
        public void Field_ToString_RedContainsCorrectValues()
        {
            var uut = new Field(4, FieldColor.Red);
            Assert.That(uut.ToString(), Is.StringMatching("4.*Red"));
        }
    }
}