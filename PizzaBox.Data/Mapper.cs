using System.Collections.Generic;
using PizzaBox.Data.Entity;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Data
{
    public class Mapper : IMapper
    {
        public PizzaBox.Domain.Models.MOrder Map(Entity.Order pizza)
        {

            return new PizzaBox.Domain.Models.MOrder
            {
                ListOfPizzas = (List<Domain.Models.CustomPizza>)pizza.Pizzas,
                Customer = new Domain.Models.MCustomer
                {
                    username = pizza.Customer.Username,
                    password = pizza.Customer.Password,
                    CustomerID = (int)pizza.CustomerId,
                    FirstName = pizza.Customer.CustomerFirstName,
                    LastName = pizza.Customer.CustomerLastName,
                    PhoneNumber = pizza.Customer.CustomerPhone,
                    Address = pizza.Customer.CustomerAddress,
                    CardNumber = pizza.Customer.CustomerCardNumber,
                    CardCode = pizza.Customer.CustomerCardCvv,
                    CardExpDate = pizza.Customer.CustomerCardDate
                },
                Store = new Domain.Models.Store
                {
                    StoreLocation = pizza.Store.StoreLocation,
                    StoreID = pizza.Store.StoreId
                },

                OrderID = pizza.OrderId,

                Cost = pizza.Cost

            };


        }




        public PizzaBox.Domain.Models.CustomPizza Map(Entity.Pizza pizza)
        {

            return new PizzaBox.Domain.Models.CustomPizza
            {

                PizzaPrice = pizza.PizzaPrice,
                OrderId = (int)pizza.OrderId,
                CrustId = pizza.CrustId,
                SizeId = pizza.PizzaSizeId,
                PizzaId = pizza.PizzaId

            };
        }

        public PizzaBox.Domain.Models.Store Map(Entity.Store store)
        {
            return new PizzaBox.Domain.Models.Store
            {
                StoreID = store.StoreId,
                StoreLocation = store.StoreLocation,

            };


        }

        public PizzaBox.Domain.Models.Crust Map(Entity.Crust crust)
        {
            return new PizzaBox.Domain.Models.Crust
            {
                Name = crust.CrustName,
                Price = crust.CrustPrice,
                Id = crust.CrustId
            };
        }

        public PizzaBox.Domain.Models.Size Map(Entity.PizzaSize size)
        {
            return new PizzaBox.Domain.Models.Size
            {
                Name = size.PizzaSizeName,
                Price = size.PizzaSizePrice,
                Id = size.PizzaSizeId
            };
        }

        public PizzaBox.Domain.Models.Toppings Map(Entity.PizzaTopping topping)
        {
            return new PizzaBox.Domain.Models.Toppings
            {
                PizzaID = topping.PizzaToppingId,
                Id = topping.Topping.ToppingId,
                Name = topping.Topping.ToppingName,
                Price = topping.Topping.ToppingPrice

            };
        }

        public PizzaBox.Domain.Models.Toppings Map(Entity.Topping topping)
        {
            return new PizzaBox.Domain.Models.Toppings
            {
                Id = topping.ToppingId,
                Name = topping.ToppingName,
                Price = topping.ToppingPrice
            };
        }

        public PizzaBox.Domain.Models.MCustomer Map(Entity.Customer customer)
        {
            return new PizzaBox.Domain.Models.MCustomer
            {
                username = customer.Username,
                password = customer.Password,
                FirstName = customer.CustomerFirstName,
                LastName = customer.CustomerLastName,
                PhoneNumber = customer.CustomerPhone,
                Address = customer.CustomerAddress,
                CardNumber = customer.CustomerCardNumber,
                CardExpDate = customer.CustomerCardDate,
                CardCode = customer.CustomerCardCvv,
                CustomerID = customer.CustomerId
            };
        }

        public PizzaBox.Domain.Models.CustomPizza Map(PizzaBox.Data.Entity.Specialty pizza)
        {
            return new Domain.Models.CustomPizza
            {
                Name = pizza.PizzaName,
                PizzaPrice = pizza.PizzaPrice,
                SpecialtyId = pizza.SpecialtyId
            };
        }

        public PizzaBox.Data.Entity.Customer Map(Domain.Models.MCustomer customer)
        {
            return new PizzaBox.Data.Entity.Customer
            {
                Username = customer.username,
                Password = customer.password,
                CustomerFirstName = customer.FirstName,
                CustomerLastName = customer.LastName,
                CustomerPhone = customer.PhoneNumber,
                CustomerAddress = customer.Address,
                CustomerCardNumber = customer.CardNumber,
                CustomerCardDate = customer.CardExpDate,
                CustomerCardCvv = customer.CardCode,
                CustomerId = customer.CustomerID
            };
        }

        public PizzaBox.Data.Entity.Order Map(PizzaBox.Domain.Models.MOrder order)
        {
            return new PizzaBox.Data.Entity.Order
            {
                OrderId = order.OrderID,
                CustomerId = order.Customer.CustomerID,
                StoreId = order.Store.StoreID,
                Cost = order.Cost,
                OrderDate = System.DateTime.Now,



            };
        }




        public PizzaBox.Data.Entity.Pizza Map(PizzaBox.Domain.Models.CustomPizza pizza)
        {
            return new PizzaBox.Data.Entity.Pizza
            {
                PizzaId = pizza.PizzaId,
                OrderId = pizza.OrderId,
                CrustId = pizza.CrustId,
                PizzaSizeId = pizza.SizeId,
                PizzaPrice = pizza.PizzaPrice


            };
        }

        public PizzaBox.Data.Entity.PizzaTopping Map(PizzaBox.Domain.Models.Toppings toppings)
        {
            return new PizzaBox.Data.Entity.PizzaTopping
            {
                PizzaToppingId = toppings.PizzaToppingID,
                PizzaId = toppings.PizzaID,
                ToppingId = (byte)toppings.Id

            };
        }


    }
}