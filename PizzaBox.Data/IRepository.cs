using System.Collections.Generic;

using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Data
{
    public interface IRepository
    {
        //void addPizza(PizzaBox.Domain.Models.CustomPizza pizza);

        List<CustomPizza> GetAllPizzas();

        List<Customer> GetUserAndPass();

        PizzaBox.Domain.Abstracts.APizza GetPizza(string PizzaChoice);

        List<Store> GetStores();

        Store GetStoreByIndex(int Id);

        CustomPizza GetPizzaByIndex(int Id);

        List<Crust> GetPizzaCrusts();

        Crust GetCrustByIndex(int Id);

        List<Size> GetSizes();

        Size GetSizeByIndex(int Id);

        List<Toppings> GetToppings();

        Toppings GetToppingByIndex(int Id);

        //bool AddOrderToDb(MOrder order);


    }
}