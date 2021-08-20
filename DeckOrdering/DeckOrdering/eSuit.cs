namespace DeckOrdering
{
    public enum eSuit
    {
        Undefined,
        Hearts,
        Spades,
        Diamonds,
        Clubs
    }

    public class SuitExtensions
    {
        public static eSuit ConvertSuit(string suit) =>
            suit.ToUpperInvariant() switch
            {
                "COPAS" => eSuit.Hearts,
                "ESPADAS" => eSuit.Spades,
                "OUROS" => eSuit.Diamonds,
                "PAUS" => eSuit.Clubs,
                _ => eSuit.Undefined
            };

        public static string ConvertSuit(eSuit suit) =>
            suit switch
            {
                eSuit.Hearts => "COPAS",
                eSuit.Spades => "ESPADAS",
                eSuit.Diamonds => "OUROS",
                eSuit.Clubs => "PAUS",
                _ => eSuit.Undefined.ToString().ToUpperInvariant()
            };
    }
}
