using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using System.Xml.Serialization;

namespace PizzaBox.Client.Singletons
{
    /// <summary>
    /// xml.Ignore
    /// </summary>
    public class ToppingSingleton
    {
        private static ToppingSingleton _instance;

        private static readonly FileRepository _fileRepository = new FileRepository();
        //private const string _path = @"Pizzas.xml";

        public List<string> Toppings { get; set; }
        public static ToppingSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ToppingSingleton();
                }

                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private ToppingSingleton()
        {
            // Pizzas = new List<APizza>
            // {
            //     new CheesePizza(),
            //     new MeatPizza(),
            //     new PepperoniPizza(),
            //     new VeganPizza()
            // };
            //_fileRepository.WriteToPizzaFile(Pizzas);
            //Pizzas = _fileRepository.ReadFromFile<APizza>(_path);
        }
    }
}