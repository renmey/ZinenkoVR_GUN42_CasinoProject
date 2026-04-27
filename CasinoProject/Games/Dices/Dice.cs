using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoProject.Exceptions;

namespace CasinoProject.Games.Dices
{
    public struct Dice
    {
        private readonly int _min;
        private readonly int _max;

        private readonly Random _random = new Random();

        public int Number => _random.Next(_min, _max);

        public Dice(int min, int max)
        {
            if (min < 1 || max > int.MaxValue)
            {
                Exception e = new WrongDiceNumberException(min > max ? min : max, min, max);
            }

            _min = min;
            _max = max;

        }
    }
}
