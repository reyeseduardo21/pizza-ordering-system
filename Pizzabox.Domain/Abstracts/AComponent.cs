using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class AComponent
    {
        //field
        //public string Name;
        public string Name { get; set; }

        public decimal Price { get; set; }


    }
}