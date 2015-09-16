using System.Collections.Generic;
using Roulette.Fields;

namespace RouletteGame.Tests.Unit.Fakes
{
    internal class MockFieldFactory : IFieldFactory
    {
        private readonly List<IField> _fields;

        public MockFieldFactory()
        {
            _fields = new List<IField>();
        }

        public List<IField> CreateFields()
        {
            return _fields;
        }

        public void AddField(IField field)
        {
            _fields.Add(field);
        }
    }
}