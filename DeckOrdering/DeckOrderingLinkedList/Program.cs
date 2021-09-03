using System;
using System.Linq;
using Util;

namespace DeckOrderingLinkedList
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
            var deck = new Deck();

            while (!closeCLI)
            {
                Console.WriteLine("\n--- MONTAR BARALHO EM LISTA ENCADEADA ---\n");
                Console.WriteLine("O que deseja fazer? (digite o número da opção)");
                Console.WriteLine("1. Inserir carta");
                Console.WriteLine("2. Visualizar lista de cartas");
                Console.WriteLine("3. Reiniciar");
                Console.WriteLine("4. Sair");
                var option = Console.ReadKey().Key;

                switch (option)
                {
                    case ConsoleKey.D1:
                        InsertCard(deck);
                        break;
                    case ConsoleKey.D2:
                        ShowDeck(deck);
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

        static void InsertCard(Deck deck)
        {
            var length = deck.GetLength() + 1;

            Console.WriteLine("\n");
            Console.WriteLine($"Informe o valor da carta nº {length} (1 (AS ou A), 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 (Valete ou Cavalo), 12 (Dama ou Rainha), 13 (Rei))");
            var number = CardExtensions.ConvertToNumber(Console.ReadLine());

            deck.AddCardNeatly(new Card(number));
        }

        static void ShowDeck(Deck deck)
        {
            Console.WriteLine("\n--- LISTA DE CARTAS ---");
            Console.WriteLine($"\nExistem {deck.GetLength()} carta(s) na lista!");

            var cards = deck.GetCards();
            for (var i = 1; i <= deck.GetLength(); i++)
            {
                var card = cards.ElementAt(i - 1);

                Console.WriteLine($"\nA carta nº {i} é: {CardExtensions.ConvertToValue(card.Number)}");
            }
        }
    }
}
