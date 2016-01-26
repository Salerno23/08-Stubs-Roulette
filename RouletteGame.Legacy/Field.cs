using System;

namespace RouletteGame.Legacy
{
    public class Field
    {
        public const uint Red = 0;
        public const uint Black = 1;
        public const uint Green = 1;

        private uint _color;

        private uint _number;

        // Constructor
        public Field(uint number, uint color)
        {
            Number = number;
            Color = color;
        }

        public uint Number
        {
            get { return _number; }
            private set
            {
                if (value <= 36) _number = value;
                else throw new FieldException(string.Format("Number {0} not a valid field number", value));
            }
        }

        public uint Color
        {
            get { return _color; }
            private set
            {
                if (value == Red || value == Black || value == Green) _color = value;
                else
                    throw new FieldException(string.Format("Color {0} not a valid color. Must be either Red or Black",
                        value));
            }
        }

        public bool Even
        {
            get { return Number%2 == 0; }
        }

        public override string ToString()
        {
            string colorString;

            switch (Color)
            {
                case Red:
                    colorString = "red";
                    break;
                case Black:
                    colorString = "black";
                    break;
                default:
                    colorString = "green";
                    break;
            }

            return string.Format("[{0}, {1}]", _number, colorString);
        }
    }

    public class FieldException : Exception
    {
        public FieldException(string s) : base(s)
        {
        }
    }
}