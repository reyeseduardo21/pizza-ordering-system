using System;
using System.Collections.Generic;
using Pizzabox.Domain.Abstracts;
using Pizzabox.Domain.Models;

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
            var stores = new List<AStore>()
            {
                new NewYorkStore(),
                new ChicagoStore()
            };

            foreach (var item in stores)
            {
                Console.WriteLine(item);
            }
        }
    }
}


