using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Data.Entity
{
    public partial class PizzaTopping
    {
        public int PizzaToppingId { get; set; }
        public int? PizzaId { get; set; }
        public byte? ToppingId { get; set; }

        public virtual Pizza Pizza { get; set; }
        public virtual Topping Topping { get; set; }
    }
}
