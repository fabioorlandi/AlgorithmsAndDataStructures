namespace ExpressionParser
{
    internal class Component
    {
        public Component(string value)
        {
            this.Value = value;
            this.NextComponent = null;
        }

        public string Value { get; set; }
        public Component NextComponent { get; set; }
    }
}
