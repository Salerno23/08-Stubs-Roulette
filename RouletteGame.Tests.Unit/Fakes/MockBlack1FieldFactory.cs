using System.Collections.Generic;
using Roulette.Fields;

namespace RouletteGame.Tests.Unit.Fakes
{
    internal class MockBlack1FieldFactory : IFieldFactory
    {
        public List<IField> CreateFields()
        {
            return new List<IField> {new StubField {Color = FieldColor.Black, Number = 1}};
        }
    }
}