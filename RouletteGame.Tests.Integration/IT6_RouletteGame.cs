using NSubstitute;
using NSubstitute.Routing.AutoValues;
using NUnit.Framework;
using RouletteGame.Bets;
using RouletteGame.Fields;
using RouletteGame.Output;
using RouletteGame.Game;
using RouletteGame.Randomizing;

namespace RouletteGame.Tests.Integration
{
    [TestFixture]
    class IT6_RouletteGame
    {
        private Game.Game _game;
        private Roulette.Roulette _roulette;
        private IOutput _output;
        private IRandomizer _randomizer;
        private readonly IBet _evenOddBet = new EvenOddBet("Berit", 100, true);
        private readonly IBet _colorBet = new ColorBet("Bente", 100, FieldColor.Black);
        private readonly IBet _fieldBet = new FieldBet("Bjarne", 100, 2);
        [SetUp]
        public void SetUp()
        {
            _randomizer = Substitute.For<IRandomizer>();
            _output = Substitute.For<IOutput>();

            _roulette = new Roulette.Roulette(new StandardFieldFactory(), _randomizer);
            _game = new Game.Game(_roulette, _output);
        }

        [Test]
        public void OpenBets_BetsOpened_BetsAreAnnouncedAsOpen()
        {
            _randomizer.Next().Returns((uint)0);
            _game.OpenBets();
            _output.Received().Report(Arg.Is<string>(str =>
                str.ToLower().Contains("open")
                ));
        }

        [Test]
        public void CloseBets_BetsClose_BetsAreAnnouncedAsClosed()
        {
            _randomizer.Next().Returns((uint)0);
            _game.OpenBets();
            _game.CloseBets();
            _output.Received().Report(Arg.Is<string>(str =>
                str.ToLower().Contains("closed")
                ));
        }

        [Test]
        public void SpinRoulette_RouletteIsSpun_RouletteIsReportedAsSpinning()
        {
            _randomizer.Next().Returns((uint)0);
            _game.OpenBets();
            _game.CloseBets();
            _game.SpinRoulette();
            _output.Received().Report(Arg.Is<string>(str =>
                str.ToLower().Contains("spinning")
                ));
        }


        [Test]
        public void SpinRoulette_RouletteIsSpun_ResultFieldAnnounced()
        {
            _randomizer.Next().Returns((uint)2);
            _game.OpenBets();
            _game.CloseBets();
            _game.SpinRoulette();
            _output.Received().Report(Arg.Is<string>(str =>
                str.ToLower().Contains("2") &&
                str.ToLower().Contains("black")
                ));
        }


        [Test]
        public void PayUp_EvenOddBetPlaced_WinnerIsAnnouncedCorrectly()
        {
            _randomizer.Next().Returns((uint)2);    // Requires knowledge that Fields[2] is even
            _game.OpenBets();
            _game.PlaceBet(_evenOddBet);
            _game.CloseBets();
            _game.SpinRoulette();
            _game.PayUp();

            _output.Received().Report(Arg.Is<string>(str => 
                str.ToLower().Contains("berit") &&
                str.ToLower().Contains("200") &&
                str.ToLower().Contains("even")
                ));
        }


        [Test]
        public void PayUp_ColorBetPlaced_WinnerIsAnnouncedCorrectly()
        {
            _randomizer.Next().Returns((uint) 2);   // Requires knowledge that Fields[2] is black
            _game.OpenBets();
            _game.PlaceBet(_colorBet);
            _game.CloseBets();
            _game.SpinRoulette();
            _game.PayUp();

            _output.Received().Report(Arg.Is<string>(str =>
                str.ToLower().Contains("bente") &&
                str.ToLower().Contains("200") &&
                str.ToLower().Contains("black")
                ));
        }

        [Test]
        public void PayUp_FieldBetPlaced_WinnerIsAnnouncedCorrectly()
        {
            _randomizer.Next().Returns((uint)2);   // Requires knowledge that Fields[2] is #2
            _game.OpenBets();
            _game.PlaceBet(_fieldBet);
            _game.CloseBets();
            _game.SpinRoulette();
            _game.PayUp();

            _output.Received().Report(Arg.Is<string>(str =>
                str.ToLower().Contains("bjarne") &&
                str.ToLower().Contains("3600") &&
                str.ToLower().Contains("2")
                ));
        }


        [Test]
        public void PayUp_FieldBetPlaced_NoWinnerIsAnnounced()
        {
            _randomizer.Next().Returns((uint)3);   // Requires knowledge that Fields[3] is NOT #2
            _game.OpenBets();
            _game.PlaceBet(_fieldBet);
            _game.CloseBets();
            _game.SpinRoulette();
            _game.PayUp();

            _output.DidNotReceive().Report(Arg.Is<string>(str =>
                str.ToLower().Contains("bjarne")
                ));
        }
    }
}
