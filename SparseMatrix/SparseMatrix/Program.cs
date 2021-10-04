using System;

namespace SparseMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("--- Feito por: Fábio Orlandi ---\n\n\n");

            RunMenu();
        }

        static void RunMenu()
        {
            var closeCLI = false;

            while (!closeCLI)
            {
                Console.WriteLine("\n--- Matriz Esparsa ---\n");
                Console.WriteLine("O que deseja fazer? (digite o número da opção)");
                Console.WriteLine("1. Inserir elemento na matriz");
                Console.WriteLine("2. Visualizar matrizes (esparsa e padrão)");
                Console.WriteLine("3. Reiniciar");
                Console.WriteLine("4. Sair");
                var option = Console.ReadKey();

                switch (option.Key)
                {
                    case ConsoleKey.D1:
                        ShowDeck(deck, false);
                        break;
                    case ConsoleKey.D2:
                        ShowDeck(deck, true);
                        break;
                    case ConsoleKey.D3:
                        closeCLI = true;
                        Console.Clear();
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
