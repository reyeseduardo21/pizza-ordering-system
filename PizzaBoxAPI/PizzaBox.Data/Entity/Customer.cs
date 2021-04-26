using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Data.Entity
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public decimal CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public decimal CustomerCardNumber { get; set; }
        public short CustomerCardDate { get; set; }
        public short CustomerCardCvv { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
