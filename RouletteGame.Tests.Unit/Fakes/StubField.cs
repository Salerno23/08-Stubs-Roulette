using RouletteGame.Fields;

namespace RouletteGame.Tests.Unit.Fakes
{
    public class StubField : IField
    {
        public uint Number { get; set; }
        public FieldColor Color { get; set; }
        public Parity Parity { get; set; }
    }
}