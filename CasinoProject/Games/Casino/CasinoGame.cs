using CasinoProject.Games.Dices;
using CasinoProject.Interfaces;
using CasinoProject.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoProject.Games.BlackJack;

namespace CasinoProject.Games.Casino
{
    public class CasinoGame : IGame
    {
       
        private readonly ISaveLoadService<string> _saveService;

        private readonly BlackJackGame _blackjack;
        private readonly DiceGame _diceGame;

        private PlayerProfile _player = new PlayerProfile("", 0);
        private int _currentBet;

        public CasinoGame(ISaveLoadService<string> saveService) {

            _saveService = saveService ?? throw new ArgumentNullException(nameof(saveService));

            _blackjack = new BlackJackGame(36);
            _diceGame = new DiceGame(2, 1, 6);

            SubscribeToEvents();
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to the Casino!");


            if (_player != null)
            {
                _player = _player.LoadPlayer(_saveService);
            }
            else
            {
             
               _player = _player.CreateProfile();

         }

            Console.WriteLine($"Hello, {_player.Name}! Balance: {_player.Balance}");

            
            CasinoGameBase game = ChooseGame();

            
            if (_player.Balance <= 0)
            {
                Console.WriteLine("No money? Kicked!");
                return;
            }

            
            MakeBet();

            game.PlayGame();

            Console.WriteLine($"Your final balance: {_player.Balance}");

            _player.SavePlayer(this._player, _saveService);
        }

        private CasinoGameBase ChooseGame()
        {

            Console.WriteLine("Choose a game:\n1 - Blackjack\n2 - Dice");
           
            while (true)
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": return _blackjack;
                    case "2": return _diceGame;
                    default:
                        Console.WriteLine();
                        break;
                }
            }
        }


        private void MakeBet()
        {
            Console.WriteLine("Enter your bet:");

            _currentBet = int.Parse(Console.ReadLine());
        }


       


        private void SubscribeToEvents()
        {
            _blackjack.OnWin += OnWin;
            _blackjack.OnLoose += OnLose;
            _blackjack.OnDraw += OnDraw;

            _diceGame.OnWin += OnWin;
            _diceGame.OnLoose += OnLose;
            _diceGame.OnDraw += OnDraw;
        }

        private void OnWin(object sender, EventArgs e)
        {
            Console.WriteLine("You win!");

            _player.AddMoney(_currentBet);
            CheckBarPenalty();
        }


        private void OnLose(object sender, EventArgs e)
        {
            Console.WriteLine("You lose!");

            _player.RemoveMoney(_currentBet);
        }

        private void OnDraw(object sender, EventArgs e)
        {
            Console.WriteLine("Draw!");
        }



        private void CheckBarPenalty()
        {
            if (_player.Balance > int.MaxValue / 2)
            {
                _player.Balance /= 2;
                Console.WriteLine("You wasted half of your bank money in casino’s bar");
            }
        }

    }

}
