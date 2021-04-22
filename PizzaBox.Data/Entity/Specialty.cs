using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Data.Entity
{
    public partial class Specialty
    {
        public string PizzaName { get; set; }
        public decimal PizzaPrice { get; set; }
        public int SpecialtyId { get; set; }
    }
}
