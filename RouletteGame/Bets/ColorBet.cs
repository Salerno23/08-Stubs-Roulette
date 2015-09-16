using Roulette.Fields;

namespace Roulette.Bets
{
    public class ColorBet : Bet
    {
        private readonly FieldColor _color;

        public ColorBet(string name, uint amount, FieldColor color) : base(name, amount)
        {
            _color = color;
        }

        public override uint WonAmount(IField field)
        {
            if (field.Color == _color) return 2*Amount;
            return 0;
        }

        public override string ToString()
        {
            return string.Format("{0}$ color bet on {1}", Amount, _color);
        }
    }
}