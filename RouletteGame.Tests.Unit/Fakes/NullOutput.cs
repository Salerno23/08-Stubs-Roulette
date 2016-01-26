using RouletteGame.Output;

namespace RouletteGame.Tests.Unit.Fakes
{
    internal class NullOutput : IOutput
    {
        public void Report(string arg)
        {
        }
    }
}