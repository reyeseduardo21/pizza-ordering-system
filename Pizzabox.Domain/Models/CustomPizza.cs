using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class CustomPizza : APizza
    {



        public CustomPizza()
        {
            Name = "CustomPizza";

        }

        // public override void AddCrust()
        // {
        //     Crust = null;
        // }

        public override void AddSize()
        {
            Size = null;

        }

        public override void AddToppings()
        {

        }

        public decimal GetPrice()
        {
            return PizzaPrice;

        }

        public override void addPrice()
        {

        }

    }
}