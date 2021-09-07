namespace Palindrome
{
    internal class Palindrome
    {
        internal Palindrome()
        {
            _head = null;
            _textLength = 0;
        }

        private Character _head;
        private int _textLength;

        internal void Build(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;

            _head = new Character(text[0]);

            Character previousChar = null;
            Character currentChar = _head;
            Character nextChar = null;

            for (var i = 0; i <= text.Length - 1; i++)
            {
                currentChar.PreviousChar = previousChar;

                if (i + 1 < text.Length)
                {
                    var auxChar = new Character(text[i + 1]);
                    currentChar.NextChar = auxChar;
                    nextChar = currentChar.NextChar;

                    previousChar = currentChar;
                    currentChar = nextChar;
                }

                _textLength++;
            }
        }
    }
}
