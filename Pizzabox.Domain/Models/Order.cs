using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MOrder
    {

        public int OrderID;

        public Store Store { get; set; }
        public Customer Customer { get; set; }


        public decimal? Cost = 0;

        public List<CustomPizza> ListOfPizzas = new List<CustomPizza>();

        public List<Toppings> ListOfToppings = new List<Toppings>();



        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {

        }
    }
}