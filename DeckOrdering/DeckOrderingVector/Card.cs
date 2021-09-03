using System;
using Util;

namespace DeckOrderingVector
{
    internal class Card : IComparable
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
}
