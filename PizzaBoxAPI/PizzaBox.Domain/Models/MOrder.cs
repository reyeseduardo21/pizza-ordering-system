using PizzaBox.Domain.Abstracts;
using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MOrder
    {

        public int OrderID = 0;

        public int StoreId = 0;
        public int? CustomerId = 0;


        public decimal? Cost = 0;

        public HashSet<CustomPizza> ListOfPizzas = new HashSet<CustomPizza>();

        public List<Toppings> ListOfToppings = new List<Toppings>();

        public DateTime time = DateTime.Now;



        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {

        }
    }
}