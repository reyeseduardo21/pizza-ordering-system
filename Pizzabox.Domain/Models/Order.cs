using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Order
    {
        public AStore Store { get; set; }
        public Customer Customer { get; set; }
        public APizza Pizza { get; set; }

        public double Cost { get; set; }

        public List<string> ListOfSizes { get; set; }

        public List<APizza> ListOfPizzas { get; set; }

        public List<decimal> ListOfPrices { get; set; }

        public List<string> ListOfCrusts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {

        }
    }
}