using System;

namespace ExpressionParser
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
            Expression expression = null;

            while (!closeCLI)
            {
                Console.WriteLine("\n\n--- INTERPRETADOR DE EXPRESSÕES UTILIZANDO PILHA ---\n");
                Console.WriteLine("O que deseja fazer? (digite o número da opção)");
                Console.WriteLine("1. Digitar expressão matemática");
                Console.WriteLine("2. Visualizar resultado");
                Console.WriteLine("3. Reiniciar");
                Console.WriteLine("4. Sair");
                var option = Console.ReadKey();

                switch (option.Key)
                {
                    case ConsoleKey.D1:
                        expression = new Expression();
                        ReadExpression(expression);
                        break;
                    case ConsoleKey.D2:
                        ShowResult(expression);
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

        static void ReadExpression(Expression expression)
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Digite a expressão matemática (utilize número INTEIROS de um ou mais dígitos | parênteses definem a prioridade dos operadores e são obrigatórios! Ex.: (3*(4+5)))");
            var mathExpression = Console.ReadLine();

            expression.Build(mathExpression);
        }

        static void ShowResult(Expression expression)
        {
            if (expression is null /*|| palindrome.GetLength() == 0*/)
            {
                Console.WriteLine("\n\nExpressão matemática não informada!");

                return;
            }

            var expressionResult = expression.Calculate();

            Console.WriteLine($"\n\nO resultado da expressão é: {expressionResult}");
        }
    }
}