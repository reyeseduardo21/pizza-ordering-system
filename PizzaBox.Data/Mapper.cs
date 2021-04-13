using PizzaBox.Data.Entity;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Data
{
    public class Mapper : IMapper
    {
        public PizzaBox.Domain.Models.CustomPizza Map(Entity.PizzaOrder pizza)
        {

            return new PizzaBox.Domain.Models.CustomPizza
            {
                Name = pizza.PizzaType,
                PizzaPrice = (decimal)pizza.PizzaPrice,
                Size = pizza.PizzaSize,
                //Toppings = new System.Collections.Generic.List<string>(),
                Toppings = pizza.PizzaToppings,
                Crust = pizza.PizzaCrust


            };
        }

        public PizzaBox.Domain.Models.CustomPizza Map(Entity.PizzaType pizza)
        {

            return new PizzaBox.Domain.Models.CustomPizza
            {
                Name = pizza.Pizza,
                PizzaPrice = (decimal)pizza.Price,

            };
        }

        public PizzaOrder Map(APizza pizza)
        {

            return new PizzaBox.Data.Entity.PizzaOrder
            {
                PizzaType = pizza.Name,
                PizzaPrice = pizza.PizzaPrice,
                PizzaCrust = pizza.Crust,
                PizzaSize = pizza.Size,
                PizzaToppings = pizza.Toppings

            };
        }
    }
}