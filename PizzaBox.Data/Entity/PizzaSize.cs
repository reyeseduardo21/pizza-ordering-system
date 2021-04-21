using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Data.Entity
{
    public partial class PizzaSize
    {
        public PizzaSize()
        {
            Pizzas = new HashSet<Pizza>();
        }

        public byte PizzaSizeId { get; set; }
        public string PizzaSizeName { get; set; }
        public byte PizzaSizeInches { get; set; }
        public decimal PizzaSizePrice { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
