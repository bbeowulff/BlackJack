using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Blackjack.Suit;
using static Blackjack.Face;

namespace Blackjack
{
    public enum Suit
    { Clubs, Spades, Diamonds, Hearts }
    public enum Face
    { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }
    public class Card
    {
        public Suit Suit { get; }
        public Face Face { get; }
        public int Value { get; set; }
        public char Symbol { get; }
        public Card(Suit suit, Face face)
        {
            Suit = suit;
            Face = face;

            switch (Suit)
            {
                case Clubs:
                    Symbol = '♣';
                    break;
                case Spades:
                    Symbol = '♠';
                    break;
                case Diamonds:
                    Symbol = '♦';
                    break;
                case Hearts:
                    Symbol = '♥';
                    break;
            }
            switch (Face)
            {
                case Ten:
                case Jack:
                case Queen:
                case King:
                    Value = 10;
                    break;
                case Ace:
                    Value = 11;
                    break;
                default:
                    Value = (int)Face + 1;
                    break;
            }
        }
        public void WriteDescription()
        {
            if (Suit == Suit.Diamonds || Suit == Suit.Hearts)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.White;
        }
        public static void DrawCardOutline(int xcoor, int ycoor)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int x = xcoor * 12;
            int y = ycoor;
            Console.SetCursorPosition(x, y);
            Console.Write("┏━━━━━━━━━━━━┓\n");
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(x, y + 1 + i);
                if (i != 9)
                    Console.WriteLine("│            │");
                else
                {
                    Console.WriteLine("└━━━━━━━━━━━━┘");
                }
            }
        }
        public static void DrawCardSuitValue(Card card, int xcoor, int ycoor)
        {
            int x = xcoor * 12;
            int y = ycoor;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetCursorPosition(x + 6, y + 5);
            Console.Write(card.Symbol);
            Console.SetCursorPosition(x + 4, y + 7);
            Console.Write(card.Face);
        }
    }
}