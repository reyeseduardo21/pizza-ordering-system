

using System;

namespace PizzaBox.Data
{

    public interface IMapper
    {
        PizzaBox.Domain.Models.CustomPizza Map(PizzaBox.Data.Entity.PizzaOrder pizza);

        PizzaBox.Domain.Models.CustomPizza Map(PizzaBox.Data.Entity.PizzaType pizza);

        PizzaBox.Domain.Models.Customer Map(PizzaBox.Data.Entity.CustomerLogin info);

        PizzaBox.Domain.Models.Store Map(PizzaBox.Data.Entity.Store store);

        PizzaBox.Domain.Models.Crust Map(PizzaBox.Data.Entity.PizzaCrust crust);

        PizzaBox.Domain.Models.Size Map(PizzaBox.Data.Entity.PizzaSizePrice size);

        PizzaBox.Domain.Models.Toppings Map(PizzaBox.Data.Entity.PizzaTopping topping);

        PizzaBox.Domain.Models.Toppings Map(PizzaBox.Data.Entity.PizzaToppingMatching toppingMatch);

        PizzaBox.Data.Entity.PizzaOrder Map(PizzaBox.Domain.Models.Order order);

        public PizzaBox.Data.Entity.PizzaOrder Map(PizzaBox.Domain.Models.CustomPizza pizza);

        public PizzaBox.Data.Entity.PizzaToppingMatching Map(PizzaBox.Domain.Models.Toppings toppings);


    }

}