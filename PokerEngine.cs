using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Casino
    {
        public static int MinimumBet { get; } = 10;
        public static bool IsHandBlackjack(List<CARD> hand)
        {
            if (hand.Count == 2)
            {
                if (hand[0].Face == FACE.Ace && hand[1].Value == 10) return true;
                else if (hand[1].Face == FACE.Ace && hand[0].Value == 10) return true;
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
        public int Chips { get; set; } = 1500;
        public int Bet { get; set; }
        public int Wins { get; set; }
        public int HandsCompleted { get; set; } = 1;

        public List<CARD> Hand { get; set; }
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
            foreach (CARD card in Hand)
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
            foreach (CARD card in Hand)
            {
                CARD.DrawCardOutline(x, y);
                card.WriteDescription();
                CARD.DrawCardSuitValue(card, x, y);
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
        public static List<CARD> HiddenCards { get; set; } = new List<CARD>();
        public static List<CARD> RevealedCards { get; set; } = new List<CARD>();
        public static void RevealCard()
        {
            RevealedCards.Add(HiddenCards[0]);
            HiddenCards.RemoveAt(0);
            RevealedCards.Add(HiddenCards[1]);
            HiddenCards.RemoveAt(1);
        }
        public static int GetHandValue()
        {
            int value = 0;
            foreach (CARD card in RevealedCards)
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
            foreach (CARD card in RevealedCards)
            {
                CARD.DrawCardOutline(x, y);
                card.WriteDescription();
                CARD.DrawCardSuitValue(card, x, y);
                Casino.ResetColor();
                x = x + 2;
            }
            for (int i = 0; i < HiddenCards.Count; i++)
            {
                CARD.DrawCardOutline(x, y);
                Console.SetCursorPosition(x + 2 * 12 + 1, y + 7);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("<hidden>");
                Casino.ResetColor();
            }
            Console.WriteLine();
        }
    }
}

