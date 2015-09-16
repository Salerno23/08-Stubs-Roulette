using System;

namespace Roulette.Fields
{
    public class Field : IField
    {
        private uint _number;

        public FieldColor Color { get; set; }

        public bool Even
        {
            get { return Number % 2 == 0; }
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


        // Constructor
        public Field(uint number, FieldColor color)
        {
            Number = number;
            Color = color;
        }


        public override string ToString()
        {
            return string.Format("[{0}, {1}]", _number, Color);
        }
    }

    public class FieldException : Exception
    {
        public FieldException(string s) : base(s)
        {
        }
    }
}