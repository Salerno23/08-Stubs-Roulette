using Roulette.Fields;
using RouletteGame.Bets;

namespace Roulette.Bets
{
    public abstract class Bet : IBet
    {
        private readonly uint _amount;
        private readonly string _playerName;

        protected Bet(string name, uint amount)
        {
            _playerName = name;
            _amount = amount;
        }


        public string PlayerName
        {
            get { return _playerName; }
        }

        public uint Amount
        {
            get { return _amount; }
        }

        public abstract uint WonAmount(IField field);
    }
}