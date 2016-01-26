using NUnit.Framework;
using RouletteGame.Fields;

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
            Assert.AreEqual(uut.Color, FieldColor.Black);
        }

        [Test]
        public void Field_Create_ColorGreenIsOK()
        {
            var uut = new Field(10, FieldColor.Green);
            Assert.AreEqual(uut.Color, FieldColor.Green);
        }

        [Test]
        public void Field_Create_ColorRedIsOK()
        {
            var uut = new Field(10, FieldColor.Red);
            Assert.AreEqual(uut.Color, FieldColor.Red);
        }

        [Test]
        public void Field_Create_Number0IsOK()
        {
            var uut = new Field(0, FieldColor.Black);
            Assert.AreEqual(uut.Number, 0);
        }

        [Test]
        public void Field_Create_Number36IsOK()
        {
            var uut = new Field(36, FieldColor.Black);
            Assert.AreEqual(uut.Number, 36);
        }

        [Test]
        public void Field_Create_Number37ExceptionIsThrown()
        {
            Assert.Throws<FieldException>(() => { new Field(37, FieldColor.Black); });
        }


        // TESTING COLOR VALUES


        // TESTING EVEN/ODD VALUES
        [Test]
        public void Field_Create_Value2EvenIsTrue()
        {
            var uut = new Field(2, FieldColor.Black);
            Assert.AreEqual(uut.Even, true);
        }

        [Test]
        public void Field_Create_Value3EvenIsFalse()
        {
            var uut = new Field(3, FieldColor.Black);
            Assert.AreEqual(uut.Even, false);
        }

        // TESTING TOSTRING
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