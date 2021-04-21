

using System;

namespace PizzaBox.Data
{

    public interface IMapper
    {
        public PizzaBox.Domain.Models.MOrder Map(Entity.Order pizza);

        PizzaBox.Domain.Models.CustomPizza Map(PizzaBox.Data.Entity.Pizza pizza);

        PizzaBox.Domain.Models.MCustomer Map(PizzaBox.Data.Entity.Customer info);

        PizzaBox.Domain.Models.Store Map(PizzaBox.Data.Entity.Store store);

        PizzaBox.Domain.Models.Crust Map(PizzaBox.Data.Entity.Crust crust);

        PizzaBox.Domain.Models.Size Map(PizzaBox.Data.Entity.PizzaSize size);

        PizzaBox.Domain.Models.Toppings Map(PizzaBox.Data.Entity.PizzaTopping topping);

        PizzaBox.Data.Entity.Order Map(PizzaBox.Domain.Models.MOrder order);

        PizzaBox.Data.Entity.Customer Map(PizzaBox.Domain.Models.MCustomer customer);

        //PizzaBox.Data.Entity.Order Map(PizzaBox.Domain.Models.CustomPizza pizza);



    }

}