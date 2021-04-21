using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Data.Entity
{
    public partial class Crust
    {
        public Crust()
        {
            Pizzas = new HashSet<Pizza>();
        }

        public byte CrustId { get; set; }
        public string CrustName { get; set; }
        public decimal CrustPrice { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
