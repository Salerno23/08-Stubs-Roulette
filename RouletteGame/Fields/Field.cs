﻿using System;

namespace RouletteGame.Fields
{
    public class Field : IField
    {
        private uint _number;


        // Constructor
        public Field(uint number, FieldColor color)
        {
            Number = number;
            Color = color;
        }

        public FieldColor Color { get; set; }

        public bool Even
        {
            get { return Number%2 == 0; }
        }

        public uint Number
        {
            get { return _number; }
            private set
            {
                if (value <= 36) _number = value;
                else throw new FieldException($"Number {value} not a valid field number");
            }
        }


        public override string ToString()
        {
            return $"[{_number}, {Color}]";
        }
    }

    public class FieldException : Exception
    {
        public FieldException(string s) : base(s)
        {
        }
    }
}