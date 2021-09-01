using System;

namespace DeckOrdering
{
    public class Card : IComparable
    {
        public eSuit Suit { get; set; }
        public int Number { get; set; }

        public int CompareTo(object obj)
        {
            if (obj is Card card)
            {
                if (this.Suit == card.Suit)
                    return this.Number.CompareTo(card.Number);

                return this.Suit.CompareTo(card.Suit)
                    + this.Number.CompareTo(card.Number);
            }

            return 0;
        }
    }

    public static class CardExtensions
    {
        public static int ConvertToNumber(string cardValue) =>
            cardValue.ToUpperInvariant().Trim() switch
            {
                "AS" or "A" => 1,
                "VALETE" or "CAVALO"=> 11,
                "DAMA" or "RAINHA" => 12,
                "REI" => 13,
                _ => int.Parse(cardValue)
            };

        public static string ConvertToValue(int cardNumber) =>
            cardNumber switch
            {
                1 => "AS ou A",
                11 => "VALETE ou CAVALO",
                12 => "DAMA ou RAINHA",
                13 => "REI",
                _ => cardNumber.ToString()
            };
    }
}
