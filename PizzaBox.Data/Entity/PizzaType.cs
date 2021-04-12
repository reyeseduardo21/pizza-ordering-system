using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Data.Entity
{
    public partial class PizzaType
    {
        public string Pizza { get; set; }
        public decimal? Price { get; set; }
    }
}
