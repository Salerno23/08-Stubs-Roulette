﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using RouletteGame.Bets;
using RouletteGame.Output;
using RouletteGame.Randomizing;
using RouletteGame.Fields;

namespace RouletteGame.Tests.Integration
{
    [TestFixture]
    class IT7_RouletteGameRandomizer
    {
        private Game.Game _game;
        private Roulette.Roulette _roulette;
        private IOutput _output;
        private IRandomizer _randomizer;

        [SetUp]
        public void SetUp()
        {
            _randomizer = Substitute.For<IRandomizer>();
            _output = Substitute.For<IOutput>();

            _roulette = new Roulette.Roulette(new StandardFieldFactory(), _randomizer);
            _game = new Game.Game(_roulette, _output);
        }

        [Test]
        public void PayUp_AllEvenOddBets_ShowSomeWinner()
        {
            _game.OpenBets();

            _game.PlaceBet(new EvenOddBet("Bjarne", 100, false));
            _game.PlaceBet(new EvenOddBet("Bjarne", 100, true));

            _game.CloseBets();
            _game.SpinRoulette();
            _game.PayUp();

            _output.Received().Report(Arg.Is<string>(str =>
                str.ToLower().Contains("bjarne") &&
                str.ToLower().Contains("200")
                ));
        }


    }
}