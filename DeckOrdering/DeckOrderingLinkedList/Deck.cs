using System.Collections.Generic;
using Util;

namespace DeckOrderingLinkedList
{
    internal class Deck
    {
        internal Deck()
        {
            _head = null;
            _cardsLength = 0;
        }

        private Card _head;
        private int _cardsLength;

        internal int GetLength() => _cardsLength;

        internal IEnumerable<Card> GetCards()
        {
            var currentCard = _head;

            while (currentCard is not null)
            {
                yield return currentCard;

                currentCard = currentCard.NextCard;
            }
        }

        internal void AddCardNeatly(Card newCard)
        {
            this.InsertIntoList(newCard);

            _cardsLength++;
        }

        private void InsertIntoList(Card newCard)
        {
            var currentCard = _head;
            eInsertionType insertionType = eInsertionType.End;

            if (currentCard is null)
                insertionType = eInsertionType.Start;
            else
                while (currentCard is not null)
                {
                    var comparisonResult = newCard.CompareTo(currentCard);

                    if (comparisonResult < 0)
                    {
                        if (currentCard.Number.Equals(_head.Number))
                            insertionType = eInsertionType.Start;
                        else
                            insertionType = eInsertionType.Middle;

                        break;
                    }

                    currentCard = currentCard.NextCard;
                }

            switch (insertionType)
            {
                case eInsertionType.Start:
                    this.InsertIntoStart(newCard);
                    break;
                case eInsertionType.Middle:
                    this.InsertIntoMiddle(newCard, currentCard);
                    break;
                case eInsertionType.End:
                default:
                    this.InsertIntoEnd(newCard);
                    break;
            }
        }

        private void InsertIntoStart(Card newCard)
        {
            newCard.NextCard = _head;
            _head = newCard;
        }

        private void InsertIntoMiddle(Card newCard, Card cardFlag)
        {
            var currentCard = _head;

            while (!currentCard.NextCard.Number.Equals(cardFlag.Number))
                currentCard = currentCard.NextCard;

            newCard.NextCard = currentCard.NextCard;
            currentCard.NextCard = newCard;
        }

        private void InsertIntoEnd(Card newCard)
        {
            var currentCard = _head;

            while (currentCard.NextCard is not null)
                currentCard = currentCard.NextCard;

            currentCard.NextCard = newCard;
        }
    }
}
