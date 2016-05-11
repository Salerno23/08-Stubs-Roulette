using RouletteGame.Output;
using RouletteGame.Roulette;
using RouletteGame.Tests.Unit.Fakes;

namespace RouletteGame.Tests.Unit.DerivedTestClasses
{
    internal class TestGame : Game.Game
    {
        public TestGame(IRoulette roulette)
            : base(roulette, new NullOutput())
        {
        }


        public TestGame(IRoulette roulette, IOutput output)
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