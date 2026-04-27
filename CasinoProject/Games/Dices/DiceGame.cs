using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoProject.Games.Casino;

namespace CasinoProject.Games.Dices
{
    public class DiceGame : CasinoGameBase
    {
        private readonly int _diceCount;
        private readonly int _min;
        private readonly int _max;

        private readonly List<Dice> _dices = new List<Dice>();

        public DiceGame(int diceCount, int min, int max)
        {

            _diceCount = diceCount;
            _min = min;
            _max = max;
            FactoryMethod();
        }






        public override void PlayGame()
        {
            int playerScore = RollDices();
            int computerScore = RollDices();

            PrintMessage($"Player score: {playerScore}");
            PrintMessage($"Computer score: {computerScore}");

            DetermineWinner(playerScore, computerScore);
        }
        

        protected override void FactoryMethod()
        {
            for (int i = 0; i < _diceCount; i++)
            {
                _dices.Add(new Dice(_min, _max));
            }
        }

        private int RollDices()
        {
            int total = 0;

            foreach (var dice in _dices)
            {
                int roll = dice.Number;
                total += roll;

                PrintMessage($"Dice: {roll}");
            }

            return total;
        }

        private void DetermineWinner(int playerScore, int computerScore)
        {
            if (playerScore > computerScore)
            {
                OnWinInvoke();
            }
            else if (playerScore < computerScore)
            {
                OnLooseInvoke();
            }
            else
            {
                OnDrawInvoke();
            }
        }

    }
}
