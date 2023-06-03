using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class DECK
    {
        private List<CARD> cards;
        public DECK()
        {
            Initialize();
        }
        public List<CARD> GetColdDeck()
        {
            List<CARD> coldDeck = new List<CARD>();
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    coldDeck.Add(new CARD((SUIT)j, (FACE)i));
                }
            }
            return coldDeck;
        }
        public List<CARD> DealHand()
        {
            List<CARD> hand = new List<CARD>();
            hand.Add(cards[0]);
            hand.Add(cards[1]);
            cards.RemoveRange(0, 2);
            return hand;
        }
        public CARD DrawCard()
        {
            CARD card = cards[0];
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
                CARD card = cards[k];
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