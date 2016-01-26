using RouletteGame.Output;
using RouletteGame.Roulette;
using RouletteGame.Tests.Unit.Fakes;

namespace RouletteGame.Tests.Unit.DerivedTestClasses
{
    internal class TestRouletteGame : Game.RouletteGame
    {
        public TestRouletteGame(IRoulette roulette)
            : base(roulette, new NullOutput())
        {
        }


        public TestRouletteGame(IRoulette roulette, IOutput output)
            : base(roulette, output)
        {
        }


        public bool IsRoundOpen
        {
            get { return RoundIsOpen; }
        }

        public int NBets
        {
            get { return Bets.Count; }
        }
    }
}