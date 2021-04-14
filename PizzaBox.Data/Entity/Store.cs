using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Data.Entity
{
    public partial class Store
    {
        public string StoreName { get; set; }
        public string StoreState { get; set; }
        public int? StoreId { get; set; }
    }
}
