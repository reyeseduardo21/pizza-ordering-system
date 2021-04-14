using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Data.Entity
{
    public partial class PizzaType
    {
        public string Pizza { get; set; }
        public string BasePrice { get; set; }
        public int? PizzaId { get; set; }
    }
}
