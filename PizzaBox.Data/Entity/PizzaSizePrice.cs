using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Data.Entity
{
    public partial class PizzaSizePrice
    {
        public string Size { get; set; }
        public decimal? Price { get; set; }
        public int? SizeId { get; set; }
    }
}
