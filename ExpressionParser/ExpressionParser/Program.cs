using System;

namespace ExpressionParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Feito por: Fábio Orlandi ---");
            Console.WriteLine("\n--- INTERPRETADOR DE EXPRESSÕES UTILIZANDO PILHA ---\n");

            var expression = ReadExpression();
            ShowResult(expression);

            Main(new string[] { });
        }

        static Expression ReadExpression()
        {
            Console.WriteLine($"Digite a expressão matemática (utilize número INTEIROS de um dígito | não é possível realizar divisões | parênteses são obrigatórios entre cada operação! Ex.: (3*(4+5)))");
            var mathExpression = Console.ReadLine();

            return new Expression(mathExpression);
        }

        static void ShowResult(Expression expression)
        {
            var expressionResult = expression.Calculate();

            if (double.IsNaN(expressionResult))
            {
                Console.WriteLine("\nExpressão matemática não informada ou inválida!\n\n");

                return;
            }

            Console.WriteLine($"\nO resultado da expressão é: {expressionResult}\n\n");
        }
    }
}