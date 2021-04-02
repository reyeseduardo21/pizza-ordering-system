using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class VeganPizza : APizza
    {




        public override void AddCrust()
        {
            Crust = null;
        }

        public override void AddSize()
        {
            Size = null;

        }

        public override void AddToppings()
        {
            Toppings.AddRange(new Toppings[] { new Toppings(), new Toppings() });
        }
    }

}