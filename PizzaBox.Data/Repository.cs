

using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Linq;

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


        public void addPizza(CustomPizza pizza)
        {
            context.Add(mapper.Map(pizza));
            context.SaveChanges();
        }

        public List<APizza> GetAllPizzas()
        {

            return context.PizzaTypes.Select(mapper.Map).ToList();
        }

        public APizza GetPizza(string PizzaChoice)
        {
            throw new System.NotImplementedException();
        }
    }

}