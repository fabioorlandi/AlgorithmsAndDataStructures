using System;

namespace OperacaoVetores
{
    class Program
    {
        static void Main(string[] args)
        {
            var elementCollection = new ElementCollection();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Qual o nome do elemento {i + 1}?");
                var elementName = Console.ReadLine();

                var element = new Element()
                {
                    ID = i,
                    Name = elementName
                };

                elementCollection.Insert(i, element);

                Console.WriteLine($"O elemento '{elementName}' foi inserido!\n");
            }

            Console.WriteLine("O array contém os elementos na ordem:");

            foreach (var element in elementCollection.Elements)
                Console.WriteLine($"ID = {element.ID} -> Nome = {element.Name}");

            Console.Write("\nO array será invertido");

            elementCollection.Invert();

            Console.WriteLine("\nO array invertido contém os elementos na ordem:");

            foreach (var element in elementCollection.Elements)
                Console.WriteLine($"ID = {element.ID} -> Nome = {element.Name}");

            Console.ReadLine();
        }
    }
}
