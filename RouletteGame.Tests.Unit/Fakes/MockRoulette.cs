using RouletteGame.Fields;
using RouletteGame.Roulette;

namespace RouletteGame.Tests.Unit.Fakes
{
    internal class MockRoulette : IRoulette
    {
        private readonly IField _fieldToReturn;

        public MockRoulette()
        {
            _fieldToReturn = null;
        }

        public MockRoulette(IField fieldToReturn)
        {
            _fieldToReturn = fieldToReturn;
        }

        public bool SpinCalled { get; private set; }

        public bool GetResultCalled { get; private set; }

        public void Spin()
        {
            SpinCalled = true;
        }

        public IField GetResult()
        {
            GetResultCalled = true;
            return _fieldToReturn;
        }
    }
}