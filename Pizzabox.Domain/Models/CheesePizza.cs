using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class CheesePizza : APizza
    {



        public CheesePizza()
        {
            Name = "CheesePizza";
        }

        // public override void AddCrust()
        // {
        //     Crust = null;
        // }



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