using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class CustomPizza : APizza
    {
        public int TotalOrderedPizzas = 0;
        public int SpecialtyId = 0;


        public CustomPizza()
        {
            Name = "CustomPizza";
            Toppings = new List<Toppings>();
            OrderId = 0;
            Size = "null";
            PizzaId = 0;



        }







        public override void AddToppings(Toppings topping)
        {
            Toppings.Add(topping);
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