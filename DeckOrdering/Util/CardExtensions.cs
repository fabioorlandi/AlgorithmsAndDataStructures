namespace Util
{
    public static class CardExtensions
    {
        public static int ConvertToNumber(string cardValue) =>
            cardValue.ToUpperInvariant().Trim() switch
            {
                "AS" or "A" => 1,
                "VALETE" or "CAVALO" => 11,
                "DAMA" or "RAINHA" => 12,
                "REI" => 13,
                _ => int.Parse(cardValue)
            };

        public static string ConvertToValue(int cardNumber) =>
            cardNumber switch
            {
                1 => "AS ou A",
                11 => "VALETE ou CAVALO",
                12 => "DAMA ou RAINHA",
                13 => "REI",
                _ => cardNumber.ToString()
            };
    }
}
