using Roulette.Bets;
using Roulette.Fields;

namespace RouletteGame.Tests.Unit.Fakes
{
    internal class MockBet : IBet
    {
        public MockBet()
        {
            WonAmountCalled = false;
        }

        public IField Field { get; private set; }
        public bool WonAmountCalled { get; private set; }

        public string PlayerName { get; set; }
        public uint Amount { get; set; }

        public uint WonAmount(IField field)
        {
            WonAmountCalled = true;
            Field = field;
            return 0;
        }
    }
}