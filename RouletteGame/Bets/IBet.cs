using Roulette.Fields;

namespace Roulette.Bets
{
    public interface IBet
    {
        string PlayerName { get; }
        uint Amount { get; }
        uint WonAmount(IField field);
    }
}