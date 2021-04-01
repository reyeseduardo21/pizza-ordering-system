using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Singletons
{
    public class StoreSingleton
    {
        private static StoreSingleton _instance;

        public static List<AStore> Stores { get; set; } = new List<AStore>()
            {
                new NewYorkStore(),
                new ChicagoStore()
            };

        //public static StoreSingleton Instance

        private StoreSingleton()
        {
            Stores = new List<AStore>
                {
                    new NewYorkStore(),
                    new ChicagoStore()
                };
        }

        public static StoreSingleton Instance()
        {
            if (_instance == null)
            {
                _instance = new StoreSingleton();
            }

            return _instance;
        }
    }
}