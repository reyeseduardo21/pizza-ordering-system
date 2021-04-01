using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class APizza
    {
        //field
        //public string Name;
        public Crust Crust { get; set; }

        public Size Size { get; set; }

        public List<string> Toppings { get; set; }


    }
}