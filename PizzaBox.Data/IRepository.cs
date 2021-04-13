using System.Collections.Generic;
using PizzaBox.Domain;


namespace PizzaBox.Data
{
    public interface IRepository
    {
        void addPizza(PizzaBox.Domain.Models.CustomPizza pizza);

        List<PizzaBox.Domain.Abstracts.APizza> GetAllPizzas();

        PizzaBox.Domain.Abstracts.APizza GetPizza(string PizzaChoice);


    }
}