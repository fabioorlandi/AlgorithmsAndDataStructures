namespace Palindrome
{
    internal class Character
    {
        public Character(char character)
        {
            this.Value = character;
            this.PreviousChar = null;
            this.NextChar = null;
        }

        internal char Value { get; set; }

        internal Character PreviousChar { get; set; }

        internal Character NextChar { get; set; }

        public override string ToString() => this.Value.ToString();
    }
}
