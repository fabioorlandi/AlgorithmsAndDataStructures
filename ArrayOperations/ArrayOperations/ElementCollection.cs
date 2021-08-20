namespace OperacaoVetores
{
    class ElementCollection
    {
        public Element[] Elements { get; set; } = new Element[5];

        public void Insert(int position, Element element)
        {
            if (position > this.Elements.Length)
                return;

            this.Elements[position] = element;
        }

        public void Invert()
        {
            var invertedCollection = new Element[5];

            for (int i = 1; i <= this.Elements.Length; i++)
                invertedCollection[i - 1] = this.Elements[this.Elements.Length - i];

            this.Elements = invertedCollection;
        }
    }
}
