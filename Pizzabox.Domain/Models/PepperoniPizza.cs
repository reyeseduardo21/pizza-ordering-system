using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class PepperoniPizza : APizza
    {

        public PepperoniPizza()
        {
            Name = "PepperoniPizza";
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


        }
    }
}