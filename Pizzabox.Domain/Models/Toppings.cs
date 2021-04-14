using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Toppings : AComponent
    {
        public int PizzaLogId = 0;
        public Toppings()
        {
            Name = "null";
            Price = 0;
            Id = 0;


        }
    }
}