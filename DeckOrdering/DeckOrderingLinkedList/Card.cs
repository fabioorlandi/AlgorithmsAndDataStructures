using System;

namespace DeckOrderingLinkedList
{
    internal class Card : IComparable
    {
        public Card(int number)
        {
            this.Number = number;
            this.NextCard = null;
        }

        public int Number { get; set; }
        public Card NextCard { get; set; }

        public int CompareTo(object obj)
        {
            if (obj is Card card)
                return this.Number.CompareTo(card.Number);

            return 0;
        }
    }
}
