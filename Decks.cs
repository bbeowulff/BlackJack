using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Deck
    {
        private List<Card> cards;
        public Deck()
        {
            Initialize();
        }
        public List<Card> GetColdDeck()
        {
            List<Card> coldDeck = new List<Card>();
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    coldDeck.Add(new Card((Suit)j, (Face)i));
                }
            }
            return coldDeck;
        }
        public List<Card> DealHand()
        {
            List<Card> hand = new List<Card>();
            hand.Add(cards[0]);
            hand.Add(cards[1]);
            cards.RemoveRange(0, 2);
            return hand;
        }
        public Card DrawCard()
        {
            Card card = cards[0];
            cards.Remove(card);
            return card;
        }
        public void Shuffle()
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card card = cards[k];
                cards[k] = cards[n];
                cards[n] = card;
            }
        }
        public void Initialize()
        {
            cards = GetColdDeck();
            Shuffle();
        }
    }
}