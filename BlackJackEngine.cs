using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Casino
    {
        public static int MinimumBet { get; } = 10;
        public static bool IsHandBlackjack(List<Card> hand)
        {
            if (hand.Count == 2)
            {
                if (hand[0].Face == Face.Ace && hand[1].Value == 10) return true;
                else if (hand[1].Face == Face.Ace && hand[0].Value == 10) return true;
            }
            return false;
        }
        public static void ResetColor()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
    public class Player
    {
        public int Chips { get; set; } = 500;
        public int Bet { get; set; }
        public int Wins { get; set; }
        public int HandsCompleted { get; set; } = 1;

        public List<Card> Hand { get; set; }
        public void AddBet(int bet)
        {
            Bet += bet;
            Chips -= bet;
        }
        public void ClearBet()
        {
            Bet = 0;
        }
        public void ReturnBet()
        {
            Chips += Bet;
            ClearBet();
        }
        public int WinBet(bool blackjack)
        {
            int chipsWon;
            if (blackjack)
            {
                chipsWon = (int)Math.Floor(Bet * 1.5);
            }
            else
            {
                chipsWon = Bet * 2;
            }

            Chips += chipsWon;
            ClearBet();
            return chipsWon;
        }
        public int GetHandValue()
        {
            int value = 0;
            foreach (Card card in Hand)
            {
                value += card.Value;
            }
            return value;
        }
        public void WriteHand()
        {
            Console.Write("Bet: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(Bet + "  ");
            Casino.ResetColor();
            Console.Write("Chips: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Chips + "  ");
            Casino.ResetColor();
            Console.Write("Wins: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Wins);
            Casino.ResetColor();
            Console.WriteLine("Round #" + HandsCompleted);
            int x = 1;
            int y = 10;
            Console.SetCursorPosition(x, y);
            Console.WriteLine();
            Console.WriteLine("Your Hand (" + GetHandValue() + "):");
            x--;
            y = y + 2;
            Console.SetCursorPosition(x, y);
            foreach (Card card in Hand)
            {
                Card.DrawCardOutline(x, y);
                card.WriteDescription();
                Card.DrawCardSuitValue(card, x, y);
                Casino.ResetColor();
                x = x + 2;
            }
            Console.WriteLine();
            y = 40;
            x = 0;
            Console.SetCursorPosition(x, y);
        }
    }
    public class Dealer
    {
        public static List<Card> HiddenCards { get; set; } = new List<Card>();
        public static List<Card> RevealedCards { get; set; } = new List<Card>();
        public static void RevealCard()
        {
            RevealedCards.Add(HiddenCards[0]);
            HiddenCards.RemoveAt(0);
        }
        public static int GetHandValue()
        {
            int value = 0;
            foreach (Card card in RevealedCards)
            {
                value += card.Value;
            }
            return value;
        }
        public static void WriteHand()
        {
            int y = 25;
            int x = 1;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Dealer's Hand (" + GetHandValue() + "):");
            x--;
            y = y + 2;
            Console.SetCursorPosition(x, y);
            foreach (Card card in RevealedCards)
            {
                Card.DrawCardOutline(x, y);
                card.WriteDescription();
                Card.DrawCardSuitValue(card, x, y);
                Casino.ResetColor();
                x = x + 2;
            }
            for (int i = 0; i < HiddenCards.Count; i++)
            {
                Card.DrawCardOutline(x, y);
                Console.SetCursorPosition(x + 2 * 12 + 1, y + 7);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("<hidden>");
                Casino.ResetColor();
            }
            Console.WriteLine();
        }
    }
}
