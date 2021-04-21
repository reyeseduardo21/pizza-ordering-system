using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Data.Entity
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaToppings = new HashSet<PizzaTopping>();
        }

        public int PizzaId { get; set; }
        public int? OrderId { get; set; }
        public byte? CrustId { get; set; }
        public byte PizzaSizeId { get; set; }
        public decimal PizzaPrice { get; set; }

        public virtual Crust Crust { get; set; }
        public virtual Order Order { get; set; }
        public virtual PizzaSize PizzaSize { get; set; }
        public virtual ICollection<PizzaTopping> PizzaToppings { get; set; }
    }
}
