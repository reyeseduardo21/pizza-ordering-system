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
                Customer = new Domain.Models.Customer
                {
                    username = pizza.Customer.Username,
                    password = pizza.Customer.Password,
                    CustomerId = pizza.CustomerId,
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
                PizzaId = pizza.PizzaId,
                PizzaPrice = pizza.PizzaPrice,



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
                PizzaID = (int)topping.PizzaId,
                PizzaToppingID = topping.PizzaToppingId,
                ToppingID = (byte)topping.ToppingId
            };
        }

        public PizzaBox.Domain.Models.Customer Map(Entity.Customer customer)
        {
            return new PizzaBox.Domain.Models.Customer
            {
                username = customer.Username,
                password = customer.Password,
                FirstName = customer.CustomerFirstName,
                LastName = customer.CustomerLastName,
                PhoneNumber = customer.CustomerPhone,
                Address = customer.CustomerAddress,
                CardNumber = customer.CustomerCardNumber,
                CardExpDate = customer.CustomerCardDate,
                CardCode = customer.CustomerCardCvv
            };
        }



        public PizzaBox.Data.Entity.Order Map(PizzaBox.Domain.Models.MOrder order)
        {
            return new PizzaBox.Data.Entity.Order
            {
                OrderId = order.OrderID,
                CustomerId = order.Customer.CustomerId,
                StoreId = order.Store.StoreID,
                Cost = order.Cost,
                OrderDate = System.DateTime.Now,
                Customer = new Customer
                {
                    Username = order.Customer.username,
                    Password = order.Customer.password,
                    CustomerFirstName = order.Customer.FirstName,
                    CustomerLastName = order.Customer.LastName,
                    CustomerPhone = order.Customer.PhoneNumber,
                    CustomerAddress = order.Customer.Address,
                    CustomerCardNumber = order.Customer.CardNumber,
                    CustomerCardDate = order.Customer.CardExpDate,
                    CustomerCardCvv = order.Customer.CardCode
                },
                Store = new Store
                {
                    StoreId = order.Store.StoreID,
                    StoreLocation = order.Store.StoreLocation
                },
                Pizzas = (ICollection<Pizza>)order.ListOfPizzas

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
                PizzaPrice = pizza.PizzaPrice,
                Crust = new Crust
                {
                    CrustId = pizza.CrustId,
                    CrustName = pizza.Crust
                },
                PizzaSize = new PizzaSize
                {
                    PizzaSizeId = pizza.SizeId,
                    PizzaSizeName = pizza.Size,

                }


            };
        }


    }
}