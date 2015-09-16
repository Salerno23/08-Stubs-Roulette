using RouletteGame.Randomizing;

namespace RouletteGame.Tests.Unit.Fakes
{
    public class StubRandomizer : IRandomizer
    {
        private readonly uint _retVal;

        public StubRandomizer()
        {
            _retVal = 0;
        }

        public StubRandomizer(uint retVal)
        {
            _retVal = retVal;
        }

        public uint Next()
        {
            return _retVal;
        }
    }
}