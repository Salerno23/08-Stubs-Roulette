using Roulette.Bets;
using Roulette.Fields;

namespace RouletteGame.Bets
{
    public class EvenOddBet : Bet
    {
        private readonly bool _even;

        public EvenOddBet(string name, uint amount, bool even) : base(name, amount)
        {
            _even = even;
        }

        public override uint WonAmount(IField field)
        {
            if (field.Even == _even) return 2*Amount;
            return 0;
        }

        public override string ToString()
        {
            string evenOddString = _even ? "even" : "odd";

            return string.Format("{0}$ even/odd bet on {1}", Amount, evenOddString);
        }
    }
}