namespace Roulette.Output
{
    public class ConsoleOutput : IOutput
    {
        public void Report(string arg)
        {
            System.Console.WriteLine("Roulette says: " + arg);
        }
    }
}