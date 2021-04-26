using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Toppings : AComponent
    {
        public int PizzaToppingID = 0;

        public int PizzaID = 0;


        public Toppings()
        {
            Name = "null";
            Price = 0;
            Id = 0;



        }
    }
}