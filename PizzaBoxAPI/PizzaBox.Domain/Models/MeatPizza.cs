using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class MeatPizza : APizza
    {

        public MeatPizza()
        {
            Name = "MeatPizza";
        }
        // public override void AddCrust()
        // {
        //     Crust = null;
        // }



        public override void AddToppings(Toppings topping)
        {
            Toppings.Add(topping);
        }

        public override void addPrice()
        {
            PizzaPrice = 10.99m;

        }
    }
}