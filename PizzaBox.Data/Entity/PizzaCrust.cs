using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Data.Entity
{
    public partial class PizzaCrust
    {
        public string Crusts { get; set; }
        public decimal CrustPrice { get; set; }
        public int? CrustId { get; set; }
    }
}
