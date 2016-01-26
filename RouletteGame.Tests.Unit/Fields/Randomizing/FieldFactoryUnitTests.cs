using System.Collections.Generic;
using NUnit.Framework;
using RouletteGame.Fields;

namespace RouletteGame.Tests.Unit.Fields.Randomizing
{
    [TestFixture]
    public class FieldFactoryUnitTest
    {
        [SetUp]
        public void SetUp()
        {
            _uut = new StandardFieldFactory();
            _list = _uut.CreateFields();
        }

        private StandardFieldFactory _uut;
        private List<IField> _list;

        private bool IsFieldWithNumberAndColorInList(List<IField> list, uint expectedNumber, FieldColor expectedColor)
        {
            var index = list.FindIndex(field => field.Number == expectedNumber);
            return list[index].Color == expectedColor;
        }

        [Test]
        public void FieldFactory_CreateFields_CountOK()
        {
            Assert.AreEqual(_uut.CreateFields().Count, 37);
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber0OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 0, FieldColor.Green));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber10OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 10, FieldColor.Black));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber11OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 11, FieldColor.Black));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber12OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 12, FieldColor.Red));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber13OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 13, FieldColor.Black));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber14OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 14, FieldColor.Red));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber15OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 15, FieldColor.Black));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber16OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 16, FieldColor.Red));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber17OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 17, FieldColor.Black));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber18OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 18, FieldColor.Red));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber19OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 19, FieldColor.Red));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber1OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 1, FieldColor.Red));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber20OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 20, FieldColor.Black));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber21OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 21, FieldColor.Red));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber22OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 22, FieldColor.Black));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber23OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 23, FieldColor.Red));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber24OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 24, FieldColor.Black));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber25OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 25, FieldColor.Red));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber26OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 26, FieldColor.Black));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber27OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 27, FieldColor.Red));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber28OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 28, FieldColor.Black));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber29OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 29, FieldColor.Black));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber2OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 2, FieldColor.Black));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber30OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 30, FieldColor.Red));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber31OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 31, FieldColor.Black));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber32OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 32, FieldColor.Red));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber33OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 33, FieldColor.Black));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber34OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 34, FieldColor.Red));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber35OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 35, FieldColor.Black));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber36OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 36, FieldColor.Red));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber3OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 3, FieldColor.Red));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber4OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 4, FieldColor.Black));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber5OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 5, FieldColor.Red));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber6OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 6, FieldColor.Black));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber7OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 7, FieldColor.Red));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber8OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 8, FieldColor.Black));
        }

        [Test]
        public void FieldFactory_CreateFields_FieldNumber9OK()
        {
            Assert.IsTrue(IsFieldWithNumberAndColorInList(_list, 9, FieldColor.Red));
        }
    }
}