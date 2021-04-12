using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Data.Entity
{
    public partial class PizzaOrder
    {
        public string CustomerId { get; set; }
        public string Store { get; set; }
        public string PizzaType { get; set; }
        public string PizzaCrust { get; set; }
        public string PizzaToppings { get; set; }
        public string PizzaSize { get; set; }
        public decimal? PizzaPrice { get; set; }
        public string DateOrdered { get; set; }
    }
}
