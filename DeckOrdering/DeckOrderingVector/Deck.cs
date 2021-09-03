namespace DeckOrderingVector
{
    internal class Deck
    {
        private readonly Card[] _cards = new Card[7];

        internal void AddCardNeatly(Card newCard)
        {
            if (_cards[0] is null)
                _cards[0] = newCard;
            else
            {
                var j = _cards.Length - 1;

                while (j > 0 && newCard.CompareTo(_cards[j - 1]) <= 0)
                {
                    var aux = _cards[j - 1];
                    _cards[j - 1] = newCard;
                    _cards[j] = aux;

                    j--;
                }
            }
        }

        internal Card[] GetCardsList() =>
            _cards;

        internal Card[] GetInvertedCardsList()
        {
            var invertedCardArray = new Card[_cards.Length];

            for (var i = 1; i <= _cards.Length; i++)
                invertedCardArray[i - 1] = _cards[_cards.Length - i];

            return invertedCardArray;
        }
    }
}
