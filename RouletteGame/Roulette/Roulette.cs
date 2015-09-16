﻿using System.Collections.Generic;
using Roulette.Fields;
using Roulette.Game;
using RouletteGame.Randomizing;

namespace Roulette.Roulette
{


    public class Roulette : IRoulette
    {
        protected readonly List<IField> Fields;
        private readonly IRandomizer _randomizer;
        private IField _result;

        public Roulette(IFieldFactory fieldFactory, IRandomizer randomizer)
        {
            Fields = fieldFactory.CreateFields();
            _result = null;
            _randomizer = randomizer;
        }

        public void Spin()
        {
            var n = _randomizer.Next();
            if (Fields.Count > n) _result = Fields[(int) n];
            else throw new RouletteGameException(string.Format("Illegal field number: {0}", n));
        }

        public IField GetResult()
        {
            if (_result == null)
                throw new RouletteGameException("GetResult called before first spin");
            return _result;
        }
    }
}