using RouletteGame.Output;

namespace RouletteGame.Tests.Unit.Fakes
{
    internal class MockOutput : IOutput
    {
        public string ArgUsed { get; private set; }

        public void Report(string arg)
        {
            ArgUsed = arg;
        }
    }
}