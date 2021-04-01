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

            foreach (var item in StoreSingleton.Stores)
            {
                Console.WriteLine(item);
            }
        }
    }
}


