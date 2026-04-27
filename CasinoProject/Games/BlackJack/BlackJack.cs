using CasinoProject.Games.BlackJack.Cards;
using CasinoProject.Games.Casino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoProject.Games.BlackJack
{
    public class BlackJackGame : CasinoGameBase
    {
        private readonly int _cardCount;
        private readonly List<Card> _cards = new List<Card>();
        private Queue<Card> Deck = new Queue<Card>();
        private readonly Random _random = new Random();


        public BlackJackGame(int cardCount)
        {        
            _cardCount = cardCount;
        }


        private void Shuffle()
        {
            var shuffledCards = _cards.OrderBy(x => _random.Next()).ToList();
            Deck = new Queue<Card>(shuffledCards);
        }
        public override void PlayGame()
        {
            var playerCards = new List<Card>();
            var dealerCards = new List<Card>();

           
            InitialCards(playerCards, dealerCards);

            int playerScore = CalculateScore(playerCards);
            int dealerScore = CalculateScore(dealerCards);

            while (playerScore == dealerScore && playerScore < 21)
            {
                playerCards.Add(DrawCard());
                dealerCards.Add(DrawCard());

                playerScore = CalculateScore(playerCards);
                dealerScore = CalculateScore(dealerCards);
            }

            PrintCards(playerCards, dealerCards);
            DetermineWinner(playerScore, dealerScore);


        }

        protected override void FactoryMethod()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    _cards.Add(new Card(rank, suit));
                }
            }

            Shuffle();
        }





        private void InitialCards(List<Card> player, List<Card> dealer)
        {
            player.Add(DrawCard());
            player.Add(DrawCard());

            dealer.Add(DrawCard());
            dealer.Add(DrawCard());
        }


        private Card DrawCard()
        {
            if (Deck.Count == 0)
            {
                throw new InvalidOperationException("Deck is empty.");
            }

            return Deck.Dequeue();
        }

        private int CalculateScore(List<Card> cards)
        {
            int score = 0;

            foreach (var card in cards)
            {
                score += (int)card.Rank;
            }

            return score;
        }

        private void DetermineWinner(int playerScore, int dealerScore)
        {
            if (playerScore <= 21 && (dealerScore > 21 || playerScore > dealerScore))
            {
                OnWinInvoke();
            }
            else if (dealerScore <= 21 && (playerScore > 21 || dealerScore > playerScore))
            {
                OnLooseInvoke();
            }
            else
            {
                OnDrawInvoke();
            }
        }

        private void PrintCards(List<Card> player, List<Card> dealer)
        {
            PrintMessage("Player cards:");
            foreach (var card in player)
            {
                PrintMessage(card.ToString());
            }

            PrintMessage("Dealer cards:");
            foreach (var card in dealer)
            {
                PrintMessage(card.ToString());
            }
        }


    }
}
