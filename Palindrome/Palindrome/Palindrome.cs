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

            for (var i = 0; i <= text.Length - 1; i++)
            {
                currentChar.PreviousChar = previousChar;

                if (i + 1 < text.Length)
                {
                    currentChar.NextChar = new Character(text[i + 1]);

                    previousChar = currentChar;
                    currentChar = currentChar.NextChar;
                }

                _textLength++;
            }

            currentChar.NextChar = _head;
            _head.PreviousChar = currentChar;
        }

        internal bool IsValidPalindrome()
        {
            var forwardChar = _head;
            var backwardChar = _head.PreviousChar;
            var isPalindrome = true;

            for (var i = 0; i < _textLength / 2; i++)
            {
                if (!forwardChar.Value.Equals(backwardChar.Value))
                {
                    isPalindrome = false;

                    break;
                }

                forwardChar = forwardChar.NextChar;
                backwardChar = backwardChar.PreviousChar;
            }

            return isPalindrome;
        }
    }
}
