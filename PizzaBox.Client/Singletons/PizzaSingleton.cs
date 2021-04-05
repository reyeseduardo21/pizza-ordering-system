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
    public class PizzaSingleton
    {
        private static PizzaSingleton _instance;

        private static readonly FileRepository _fileRepository = new FileRepository();
        private const string _path = @"Pizzas.xml";

        public List<APizza> Pizzas { get; set; }
        public static PizzaSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PizzaSingleton();
                }

                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private PizzaSingleton()
        {
            Pizzas = new List<APizza>
            {
                new CheesePizza(),
                new MeatPizza(),
                new PepperoniPizza(),
                new VeganPizza()
            };
            //_fileRepository.WriteToPizzaFile(Pizzas);
            Pizzas = _fileRepository.ReadFromFile<APizza>(_path);
        }
    }
}