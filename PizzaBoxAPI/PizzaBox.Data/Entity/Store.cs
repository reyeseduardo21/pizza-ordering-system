using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Data.Entity
{
    public partial class Store
    {
        public Store()
        {
            Orders = new HashSet<Order>();
        }

        public byte StoreId { get; set; }
        public string StoreLocation { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
