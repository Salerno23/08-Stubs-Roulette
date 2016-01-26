using RouletteGame.Fields;
using RouletteGame.Randomizing;

namespace RouletteGame.Tests.Unit.DerivedTestClasses
{
    // Roulette derivative to expose "private parts" of class Roulette
    public class TestRoulette : global::RouletteGame.Roulette.Roulette
    {
        public TestRoulette(IFieldFactory fieldFactory, IRandomizer randomizer) : base(fieldFactory, randomizer)
        {
        }


        public int GetFieldListSize()
        {
            return Fields.Count;
        }
    }
}