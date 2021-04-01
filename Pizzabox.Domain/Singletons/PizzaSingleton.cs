using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Singletons
{
    public class PizzaSingleton
    {
        private static PizzaSingleton _instance;

        public static List<APizza> Pizzas { get; set; } = new List<APizza>()
            {
                new CheesePizza()
            };

        //public static PizzaSingleton Instance

        private PizzaSingleton()
        {
            Pizzas = new List<APizza>
                {
                    new CheesePizza()
                };
        }

        public static PizzaSingleton Instance()
        {
            if (_instance == null)
            {
                _instance = new PizzaSingleton();
            }

            return _instance;
        }
    }
}