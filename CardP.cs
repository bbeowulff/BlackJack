using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Poker.SUIT;
using static Poker.FACE;
namespace Poker
{
    public enum SUIT
    { Clubs, Spades, Diamonds, Hearts }
    public enum FACE
    { Ace=1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }
    public class CARD
    {
        public SUIT Suit { get; }
        public FACE Face { get; }
        public int Value { get; set; }
        public char Symbol { get; }
        public CARD(SUIT suit, FACE face)
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
        }
        public void WriteDescription()
        {
            if (Suit == SUIT.Diamonds || Suit == SUIT.Hearts)
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
        public static void DrawCardSuitValue(CARD card, int xcoor, int ycoor)
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