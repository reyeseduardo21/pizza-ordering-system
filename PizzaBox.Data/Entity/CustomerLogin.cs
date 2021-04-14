using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Data.Entity
{
    public partial class CustomerLogin
    {
        public string CustomerId { get; set; }
        public string CustomerPassword { get; set; }
    }
}
