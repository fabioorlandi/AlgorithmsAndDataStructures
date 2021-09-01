using System;

namespace DeckOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("--- Feito por: Fábio Orlandi ---\n\n\n");

            var deck = BuildDeck();
            RunMenu(deck);
        }

        static Deck BuildDeck()
        {
            var deck = new Deck();

            for (var i = 1; i <= deck.GetCardsList().Length; i++)
            {
                var card = new Card();

                Console.WriteLine($"Informe o valor da carta nº {i} (1 (AS ou A), 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 (Valete ou Cavalo), 12 (Dama ou Rainha), 13 (Rei))");
                card.Number = CardExtensions.ConvertToNumber(Console.ReadLine());

                Console.WriteLine($"\nInforme o nipe da carta nº {i} (Copas, Espadas, Ouros ou Paus)");
                card.Suit = SuitExtensions.ConvertSuit(Console.ReadLine());

                deck.AddCardNeatly(card);

                Console.WriteLine("\n");
            }

            return deck;
        }

        static void RunMenu(Deck deck)
        {
            var closeCLI = false;

            while (!closeCLI)
            {
                Console.WriteLine("\n--- BARALHO MONTADO ---\n");
                Console.WriteLine("O que deseja fazer? (digite o número da opção)");
                Console.WriteLine("1. Visualizar lista de cartas");
                Console.WriteLine("2. Visualizar lista de cartas invertida");
                Console.WriteLine("3. Embaralhar cartas novamente");
                Console.WriteLine("4. Sair");
                var option = Console.ReadKey().Key;

                switch (option)
                {
                    case ConsoleKey.D1:
                        ShowDeck(deck, false);
                        break;
                    case ConsoleKey.D2:
                        ShowDeck(deck, true);
                        break;
                    case ConsoleKey.D3:
                        closeCLI = true;
                        Console.WriteLine("\n\n");
                        Main(new string[] { });
                        break;
                    case ConsoleKey.D4:
                        closeCLI = true;
                        break;
                    default:
                        break;
                }
            }
        }

        static void ShowDeck(Deck deck, bool isInverted)
        {
            Card[] cards;

            if (isInverted)
            {
                cards = deck.GetInvertedCardsList();

                Console.WriteLine("\n--- LISTA DE CARTAS INVERTIDA ---");
            }
            else
            {
                cards = deck.GetCardsList();

                Console.WriteLine("\n--- LISTA DE CARTAS ---");
            }

            for (var i = 1; i <= cards.Length; i++)
            {
                var card = cards[i - 1];

                Console.WriteLine($"\nCarta nº {i}");
                Console.WriteLine($"{CardExtensions.ConvertToValue(card.Number)} " +
                    $"- {SuitExtensions.ConvertSuit(card.Suit)}");
            }
        }
    }
}
