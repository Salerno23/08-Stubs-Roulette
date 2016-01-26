namespace RouletteGame.Fields
{
    public enum FieldColor
    {
        Red,
        Black,
        Green
    }

    public interface IField
    {
        uint Number { get; }
        FieldColor Color { get; }
        bool Even { get; }
        string ToString();
    }
}