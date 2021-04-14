using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Order
    {
        public Store Store = new Store
        {
            StoreID = 0,
            StoreLocation = "null",
            StoreName = "Null"
        };
        public Customer Customer = new Customer
        {
            username = "null",
            password = "null"
        };
        //public APizza Pizza { get; set; }

        public decimal Cost = 0;

        public List<Size> ListOfSizes = new List<Size>();

        public List<CustomPizza> ListOfPizzas = new List<CustomPizza>();

        public List<decimal> ListOfPrices = new List<decimal>();

        public List<Crust> ListOfCrusts = new List<Crust>();

        public List<Toppings> ListOfToppings = new List<Toppings>();



        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {

        }
    }
}