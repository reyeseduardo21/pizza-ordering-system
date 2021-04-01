using System;
using PizzaBox.Domain.Singletons;

namespace PizzaBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.Run();
        }

        private static void Run()
        {
            Console.WriteLine("Welcome to PizzaBox ");

            var storeSingleton = StoreSingleton.Instance();
            //var s2 = new StoreSingleton();

            var PizzaSingletons = PizzaSingleton.Instance();

            foreach (var item in StoreSingleton.Stores)
            {
                Console.WriteLine(item);
            }

            foreach (var item in PizzaSingleton.Pizzas)
            {
                Console.WriteLine(item);
            }

            storeSingleton.WriteToFile();
        }
    }
}


