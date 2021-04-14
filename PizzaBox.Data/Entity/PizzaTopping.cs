using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Data.Entity
{
    public partial class PizzaTopping
    {
        public string Toppings { get; set; }
        public decimal ToppingsPrice { get; set; }
        public int ToppingsId { get; set; }
    }
}
