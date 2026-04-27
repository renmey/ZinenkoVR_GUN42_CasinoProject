using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoProject.Exceptions
{
    internal class WrongDiceNumberException : Exception
    {
        public WrongDiceNumberException(int value, int min, int max)
        {
            Console.WriteLine($"Invalid dice value: {value}. Enter value in range: {min} - {max}");
        }
    }
}
