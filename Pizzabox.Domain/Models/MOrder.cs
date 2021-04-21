using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MOrder
    {

        public int OrderID = 0;

        public Store Store = new Store();
        public MCustomer Customer = new MCustomer();


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