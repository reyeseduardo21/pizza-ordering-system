

using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Linq;
using System.Linq.Expressions;

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
            var pizza = context.Pizzas;
            return pizza.Select(mapper.Map).ToList();
        }

        public List<Customer> GetUserAndPass()
        {
            var info = context.Customers;
            return info.Select(mapper.Map).ToList();
        }

        public APizza GetPizza(string PizzaChoice)
        {
            throw new System.NotImplementedException();
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
            var pizza = context.Pizzas.Where(x => x.PizzaId == Id).FirstOrDefault();

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
            var toppings = context.PizzaToppings;
            return toppings.Select(mapper.Map).ToList();
        }

        public Toppings GetToppingByIndex(int Id)
        {
            var topping = context.PizzaToppings.Where(x => x.PizzaToppingId == Id).FirstOrDefault();
            return mapper.Map(topping);
        }

        // public bool AddOrderToDb(Order order)
        // {


        //     try
        //     {
        //         context.Add(mapper.Map(order));
        //         context.SaveChanges();
        //         return true;
        //     }
        //     catch
        //     {
        //         return false;
        //     }



        // }
    }

}