using PizzaBox.Data.Entity;
using PizzaBox.Domain.Abstracts;

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

                Crust = pizza.PizzaCrust


            };
        }

        public PizzaBox.Domain.Models.Toppings Map(Entity.PizzaToppingMatching toppingMatch)
        {

            return new PizzaBox.Domain.Models.Toppings
            {
                Name = toppingMatch.Topping,
                PizzaLogId = toppingMatch.PizzaId

            };
        }

        public PizzaBox.Domain.Models.CustomPizza Map(Entity.PizzaType pizza)
        {

            return new PizzaBox.Domain.Models.CustomPizza
            {
                Name = pizza.Pizza,
                PizzaPrice = decimal.Parse(pizza.BasePrice),
                PizzaId = (int)pizza.PizzaId,


            };
        }



        public PizzaBox.Domain.Models.Customer Map(Entity.CustomerLogin login)
        {
            return new PizzaBox.Domain.Models.Customer
            {
                username = login.CustomerId,
                password = login.CustomerPassword
            };
        }

        public PizzaBox.Domain.Models.Store Map(Entity.Store store)
        {
            return new PizzaBox.Domain.Models.Store
            {
                StoreName = store.StoreName,
                StoreLocation = store.StoreState,
                StoreID = (int)store.StoreId
            };


        }

        public PizzaBox.Domain.Models.Crust Map(Entity.PizzaCrust crust)
        {
            return new PizzaBox.Domain.Models.Crust
            {
                Name = crust.Crusts,
                Price = crust.CrustPrice,
                Id = (int)crust.CrustId
            };
        }

        public PizzaBox.Domain.Models.Size Map(Entity.PizzaSizePrice size)
        {
            return new PizzaBox.Domain.Models.Size
            {
                Name = size.Size,
                Price = (decimal)size.Price,
                Id = (int)size.SizeId
            };
        }

        public PizzaBox.Domain.Models.Toppings Map(Entity.PizzaTopping topping)
        {
            return new PizzaBox.Domain.Models.Toppings
            {
                Name = topping.Toppings,
                Price = topping.ToppingsPrice,
                Id = topping.ToppingsId
            };
        }





        public PizzaBox.Data.Entity.PizzaOrder Map(PizzaBox.Domain.Models.Order order)
        {
            return new PizzaBox.Data.Entity.PizzaOrder
            {
                CustomerId = order.Customer.username,
                Store = order.Store.StoreName,
                DateOrdered = System.DateTime.Now.ToString()
            };
        }

        public PizzaBox.Data.Entity.PizzaOrder Map(PizzaBox.Domain.Models.CustomPizza pizza)
        {
            return new PizzaBox.Data.Entity.PizzaOrder
            {
                PizzaType = pizza.Name,
                PizzaCrust = pizza.Crust,
                PizzaPrice = pizza.PizzaPrice,
                PizzaSize = pizza.Size
            };
        }

        public PizzaBox.Data.Entity.PizzaToppingMatching Map(PizzaBox.Domain.Models.Toppings toppings)
        {
            return new PizzaBox.Data.Entity.PizzaToppingMatching
            {
                PizzaId = toppings.PizzaLogId,
                Topping = toppings.Name
            };
        }
    }
}