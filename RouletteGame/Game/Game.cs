using System;
using System.Collections.Generic;
using RouletteGame.Bets;
using RouletteGame.Output;
using RouletteGame.Roulette;

namespace RouletteGame.Game
{
    public class Game : IGame
    {
        private readonly IRoulette _roulette;
        protected readonly List<IBet> Bets;
        protected readonly IOutput Output;
        protected bool RoundIsOpen;

        public Game(IRoulette roulette, IOutput output)
        {
            Bets = new List<IBet>();
            _roulette = roulette;
            Output = output;
        }

        public void OpenBets()
        {
            Output.Report("Round is open for bets");
            RoundIsOpen = true;
        }

        public void CloseBets()
        {
            Output.Report("Round is closed for bets");
            RoundIsOpen = false;
        }

        public void PlaceBet(IBet bet)
        {
            if (RoundIsOpen) Bets.Add(bet);
            else throw new RouletteGameException("Bet placed while round closed");
        }

        public void SpinRoulette()
        {
            if (RoundIsOpen) throw new RouletteGameException("Spin roulette while round open for bets");
            Output.Report("Spinning...");
            _roulette.Spin();
            Output.Report(string.Format("Result: {0}", _roulette.GetResult()));
        }

        public void PayUp()
        {
            var result = _roulette.GetResult();

            foreach (var bet in Bets)
            {
                var won = bet.WonAmount(result);
                if (won > 0)
                    Output.Report(string.Format("{0} just won {1}$ on a {2}", bet.PlayerName, won, bet));
            }
        }
    }

    public class RouletteGameException : Exception
    {
        public RouletteGameException(string s) : base(s)
        {
        }
    }
}