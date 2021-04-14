using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Data.Entity
{
    public partial class PizzaToppingMatching
    {
        public int PizzaId { get; set; }
        public string Topping { get; set; }
    }
}
