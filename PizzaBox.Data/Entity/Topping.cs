using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Data.Entity
{
    public partial class Topping
    {
        public Topping()
        {
            PizzaToppings = new HashSet<PizzaTopping>();
        }

        public byte ToppingId { get; set; }
        public string ToppingName { get; set; }
        public decimal ToppingPrice { get; set; }

        public virtual ICollection<PizzaTopping> PizzaToppings { get; set; }
    }
}
