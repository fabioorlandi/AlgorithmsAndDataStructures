using System;

namespace Palindrome
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
            Palindrome palindrome = null;

            while (!closeCLI)
            {
                Console.WriteLine("\n--- PALÍNDROMO EM LISTA DUPLAMENTE ENCADEADA ---\n");
                Console.WriteLine("O que deseja fazer? (digite o número da opção)");
                Console.WriteLine("1. Digitar texto");
                Console.WriteLine("2. Visualizar resultado");
                Console.WriteLine("3. Reiniciar");
                Console.WriteLine("4. Sair");
                var option = Console.ReadKey();

                switch (option.Key)
                {
                    case ConsoleKey.D1:
                        palindrome = new Palindrome();
                        ReadText(palindrome);
                        break;
                    case ConsoleKey.D2:
                        ShowResult(palindrome);
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

        static void ReadText(Palindrome palindrome)
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Digite o texto (pode conter letras, números e caracteres especiais)");
            var text = Console.ReadLine();

            palindrome.Build(text);
        }

        static void ShowResult(Palindrome palindrome)
        {
            if (palindrome is null)
            {
                Console.WriteLine("\nTexto não informado!");

                return;
            }

            if (palindrome.IsValidPalindrome())
                Console.WriteLine("\nO texto informado É um palíndromo!");
            else
                Console.WriteLine("\nO texto informado NÃO É um palíndromo!");

            Console.WriteLine("\n--- TEXTO ---");

            //var cards = deck.GetCards();
            //for (var i = 1; i <= deck.GetLength(); i++)
            //{
            //    var card = cards.ElementAt(i - 1);

            //    Console.WriteLine($"\nA carta nº {i} é: {CardExtensions.ConvertToValue(card.Number)}");
            //}
        }
    }
}
