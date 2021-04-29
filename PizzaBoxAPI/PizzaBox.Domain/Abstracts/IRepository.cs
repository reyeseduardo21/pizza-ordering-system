using System.Collections.Generic;

using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Data
{
    public interface IRepository
    {
        //void addPizza(PizzaBox.Domain.Models.CustomPizza pizza);

        public List<CustomPizza> GetAllPizzas();

        List<MCustomer> GetUserAndPass();

        List<MCustomer> GetCustomers();

        public List<MOrder> GetAllOrders();

        void AddCustomer(MCustomer customer);
        void AddOrder(MOrder order);

        void AddToppings(Toppings toppings);

        void AddPizza(CustomPizza pizza);

        //PizzaBox.Domain.Abstracts.APizza GetPizza(string PizzaChoice);

        List<Store> GetStores();

        Store GetStoreByIndex(int Id);

        CustomPizza GetPizzaByIndex(int Id);

        List<MCrust> GetPizzaCrusts();

        MCrust GetCrustByIndex(int Id);

        List<Size> GetSizes();

        Size GetSizeByIndex(int Id);

        List<Toppings> GetToppings();

        Toppings GetToppingByIndex(int Id);

        int GetOrderCount();

        int GetPizzaCount();

        int GetPizzaToppingCount();
        public List<CustomPizza> GetPizzasOrders();

        public MCustomer GetCustomerById(int Id);
        MOrder GetOrdersById(int id);

        //bool AddOrderToDb(MOrder order);


    }
}