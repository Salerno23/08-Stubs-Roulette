using System;

namespace RouletteGame.Output
{
    public class ConsoleOutput : IOutput
    {
        public void Report(string arg)
        {
            Console.WriteLine("Roulette says: " + arg);
        }
    }
}