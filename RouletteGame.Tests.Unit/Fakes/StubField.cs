using RouletteGame.Fields;

namespace RouletteGame.Tests.Unit.Fakes
{
    public class StubField : IField
    {
        public uint Number { get; set; }
        public FieldColor Color { get; set; }

        public bool Even
        {
            get { return Number%2 == 0; }
        }
    }
}