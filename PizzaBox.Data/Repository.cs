

using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace PizzaBox.Data
{
    public class Repository : IRepository
    {

        private readonly Entity.PizzaBoxInformationContext context;

        IMapper mapper = new Mapper();

        public Repository(Entity.PizzaBoxInformationContext context)
        {
            this.context = context;
        }


        // public void addPizza(CustomPizza pizza)
        // {
        //     context.Add(mapper.Map(pizza));
        //     context.SaveChanges();
        // }

        public List<CustomPizza> GetAllPizzas()
        {
            var pizza = context.Specialties;
            return pizza.Select(mapper.Map).ToList();
        }

        public List<MCustomer> GetCustomers()
        {
            var customers = context.Customers;
            Console.WriteLine(customers);
            return customers.Select(mapper.Map).ToList();
        }

        public void AddCustomer(MCustomer customer)
        {
            context.Add(mapper.Map(customer));
            context.SaveChanges();
        }

        public void AddOrder(MOrder order)
        {
            context.Add(mapper.Map(order));
            //AddToppings(order);
            context.SaveChanges();
        }

        public void AddPizza(CustomPizza pizza)
        {


            context.Add(mapper.Map(pizza));


            context.SaveChanges();

        }

        public void AddToppings(Toppings toppings)
        {

            context.Add(mapper.Map(toppings));

            context.SaveChanges();
        }

        public List<MCustomer> GetUserAndPass()
        {
            var info = context.Customers;
            return info.Select(mapper.Map).ToList();
        }



        public List<Store> GetStores()
        {
            var stores = context.Stores;
            return stores.Select(mapper.Map).ToList();
        }

        public Store GetStoreByIndex(int Id)
        {
            var store = context.Stores.Where(x => x.StoreId == Id).FirstOrDefault();

            return mapper.Map(store);
        }

        public CustomPizza GetPizzaByIndex(int Id)
        {
            var pizza = context.Specialties.Where(x => x.SpecialtyId == Id).FirstOrDefault();

            return mapper.Map(pizza);
        }

        public List<Crust> GetPizzaCrusts()
        {
            var crusts = context.Crusts;
            return crusts.Select(mapper.Map).ToList();
        }

        public Crust GetCrustByIndex(int Id)
        {
            var crust = context.Crusts.Where(x => x.CrustId == Id).FirstOrDefault();
            return mapper.Map(crust);
        }

        public List<Size> GetSizes()
        {
            var sizes = context.PizzaSizes;
            return sizes.Select(mapper.Map).ToList();
        }

        public Size GetSizeByIndex(int Id)
        {
            var size = context.PizzaSizes.Where(x => x.PizzaSizeId == Id).FirstOrDefault();
            return mapper.Map(size);
        }

        public List<Toppings> GetToppings()
        {
            var toppings = context.Toppings;
            return toppings.Select(mapper.Map).ToList();
        }

        public Toppings GetToppingByIndex(int Id)
        {
            var topping = context.Toppings.Where(x => x.ToppingId == Id).FirstOrDefault();
            return mapper.Map(topping);
        }

        public int GetOrderCount()
        {
            int count = context.Orders.Count();
            return count;
        }

        public int GetPizzaCount()
        {
            int count = context.Pizzas.Count();
            return count;
        }

        public int GetPizzaToppingCount()
        {
            int count = context.PizzaToppings.Count();
            return count;
        }
    }

}