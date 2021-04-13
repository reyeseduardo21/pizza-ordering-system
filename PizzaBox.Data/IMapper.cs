

namespace PizzaBox.Data
{

    public interface IMapper
    {
        PizzaBox.Domain.Models.CustomPizza Map(PizzaBox.Data.Entity.PizzaOrder pizza);
        PizzaBox.Data.Entity.PizzaOrder Map(PizzaBox.Domain.Abstracts.APizza pizza);
    }

}